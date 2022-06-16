using kitapderyasiFinal.Entity;
using kitapderyasiFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kitapderyasiFinal.Controllers
{
    public class CartController : Controller
    {
        DataContext db = new DataContext();
        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }
        private void SaveOrder(Cart cart,ShippingDetails model)
        {
            var order = new Order();
            order.OrderNumber = "A" + (new Random()).Next(1111, 9999).ToString();
            order.Total = cart.Total();
            order.OrderDate = DateTime.Now;
            order.UserName = User.Identity.Name;
            order.OrderState = OrderState.Bekleniyor;
            order.Adres = model.Address;
            order.Sehir = model.Sehir;
            order.Semt = model.Semt;
            order.Mahalle = model.Mahalle;
            order.PostaKodu = model.Postakodu;
            order.OrderLines = new List<OrderLine>();
            foreach(var item in cart.CartLines)
            {
                var orderline = new OrderLine();
                orderline.Quantity = item.Quantity;
                orderline.Price = item.Quantity * item.Product.Price;
                orderline.ProductId = item.Product.Id;
            }
            db.Orders.Add(order);
            db.SaveChanges();
        }
        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }
        [HttpPost]
        public ActionResult Checkout(ShippingDetails model)
        {
            var cart = GetCart();
            if (cart.CartLines.Count == 0)
            {
                ModelState.AddModelError("UrunYok", "Sepetinizde ürün bulunmamaktadır.");
            }
            if (ModelState.IsValid)
            {
                SaveOrder(cart, model);
                cart.Clear();
                return View("OrderCompleted");
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult AddToCart(int id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == id);
            if (product != null)
            {
                GetCart().AddProduct(product, 1);
            }
            return RedirectToAction("Index");
        }
        public Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ActionResult RemoveFromCart(int id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == id);
            if (product != null)
            {
                GetCart().DeleteProduct(product);
            }
            return RedirectToAction("Index");
        }
        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }
        public PartialViewResult Summary1()
        {
            return PartialView(GetCart());
        }
    }
}