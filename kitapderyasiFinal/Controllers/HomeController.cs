using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using kitapderyasiFinal.Entity;

namespace kitapderyasiFinal.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        public ActionResult Search(string q)
        {
            //var p = db.Products.Where(i => i.IsApproved == true);       
            //if (!string.IsNullOrEmpty(q))
            //{
            //    p = p.Where(i => i.Name.Contains(q) ||i.Writer.Contains(q)||i.Brand.Contains(q)||i.Colour.Contains(q));
            //}
            //return View(p.ToList());
            return View(db.Products.Where(i => i.Name.Contains(q) || i.Writer.Contains(q) || i.Brand.Contains(q) || i.Colour.Contains(q) || q == null).ToList());
        }
        public PartialViewResult _FeaturedProductList()
        {
            return PartialView(db.Products.Where(i => i.IsApproved && i.IsFeatured).Take(3).ToList());
        }
        public PartialViewResult Slider()
        {
            return PartialView(db.Products.Where(i => i.IsApproved && i.Slider).Take(5).ToList());
        }
        public ActionResult Index()
        {
            return View(db.Products.Where(i=>i.IsHome&&i.IsApproved).ToList());
        }
        public ActionResult ProductDetails(int id)
        {
            return View(db.Products.Where(i=>i.Id==id).FirstOrDefault());
        }
        public ActionResult Product()
        {
            return View(db.Products.ToList());
        }
        public ActionResult ProductList(int id)
        {
            return View(db.Products.Where(i=>i.CategoryId==id).ToList());
        }
    }
}