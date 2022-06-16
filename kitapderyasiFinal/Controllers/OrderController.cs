using kitapderyasiFinal.Entity;
using kitapderyasiFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kitapderyasiFinal.Controllers
{
    public class OrderController : Controller
    {
        DataContext db = new DataContext();
        // GET: Order
        public ActionResult Index()
        {
            var orders = db.Orders.Select(i => new AdminOrder()
            {
                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Total = i.Total,
                Count = i.OrderLines.Count
            }).OrderByDescending(i => i.OrderDate).ToList();
            return View(orders); 
        }
        public ActionResult Details(int id)
        {
            var model = db.Orders.Where(i => i.Id == id).Select(i => new OrderDetails()
            {
                OrderId = i.Id,
                OrderNumber = i.OrderNumber,
                Total = i.Total,
                UserName=i.UserName,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Adres = i.Adres,
                Sehir = i.Sehir,
                Semt = i.Semt,
                Mahalle = i.Mahalle,
                PostaKodu = i.PostaKodu,
                OrderLines = i.OrderLines.Select(x => new OrderLineModel()
                {
                    ProductId = x.ProductId,
                    Image=x.Product.Image,
                    ProductName=x.Product.Name,
                    Quantity=x.Quantity,
                    Price=x.Price
                }).ToList()
            }).FirstOrDefault();
            return View(model);
        }
        public ActionResult UpdateOrderState(int OrderId,OrderState OrderState)
        {
            var order = db.Orders.FirstOrDefault(i => i.Id == OrderId);
            if (order != null)
            {
                order.OrderState = OrderState;
                db.SaveChanges();
                TempData["mesaj"] = "Bilgiler kaydedildi.";
                return RedirectToAction("Details",new { id = OrderId });
            }
            return RedirectToAction("Index");
        }
        public ActionResult WaitingOrders()
        {
            var model = db.Orders.Where(i => i.OrderState == OrderState.Bekleniyor).ToList();
            return View(model);
        }
        public ActionResult CompletedOrders()
        {
            var model = db.Orders.Where(i => i.OrderState == OrderState.Tamamlandı).ToList();
            return View(model);
        }
        public ActionResult PackagedOrders()
        {
            var model = db.Orders.Where(i => i.OrderState == OrderState.Paketlendi).ToList();
            return View(model);
        }
        public ActionResult ShippedOrders()
        {
            var model = db.Orders.Where(i => i.OrderState == OrderState.Kargolandı).ToList();
            return View(model);
        }
    }
}