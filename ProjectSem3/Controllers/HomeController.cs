using Model.DAO;
using ProjectSem3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectSem3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult TopSlide()
        {
            var model = new ProductDao().ListSlideForClient();
            return PartialView("_TopSlide", model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [ChildActionOnly]
        public ActionResult HeaderCart()
        {
            var cart = (List<CartItem>)Session[ProjectSem3.Common.CommonSession.CartSession];
            return PartialView("_HeaderCart", cart);
        }
    }
}