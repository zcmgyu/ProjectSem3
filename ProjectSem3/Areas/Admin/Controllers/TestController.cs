using Model.DAO;
using ProjectSem3.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectSem3.Areas.Admin.Controllers
{
    public class TestController : Controller
    {
        // GET: Admin/Test
        

        public ActionResult Create()
        {
            var colors = new List<SelectListViewModel> {
                new SelectListViewModel(){ Text = "Red", Value = "Red"} ,
                new SelectListViewModel(){ Text = "Blue", Value = "Blue"},
                new SelectListViewModel(){ Text = "Green", Value = "Green"},
                new SelectListViewModel(){ Text = "Yellow", Value = "Yellow"}
            };

            //var selectListColor = new SelectList(colors, "Value", "Text");
            ViewBag.ListColor = colors;
            var sizes = new List<string>() { "S", "M", "L", "XL" };
            var categories = new ProductDao().LoadProductCategory();

            var productGeneral = new ProductGeneral()
            {
                //Categories = categories
            };
            var model = new ProductViewModel
            {
                ProductGeneral = productGeneral,
                SizeColorQuantities = new List<SizeColorQuantityViewModel>()
            };


            foreach (var color in colors)
            {
                var child = new SizeColorQuantityViewModel
                {
                    ColorId = color.Text,
                    SizeAndQuantities = new List<SizeAndQuantity>()
                };
                model.SizeColorQuantities.Add(child);
                foreach (var size in sizes)
                {
                    child.SizeAndQuantities.Add(new SizeAndQuantity()
                    {
                        SizeId = size // assumes SizeId is changed to string, not int
                    });
                }
            }
            return View(model);
        }

        // POST: Admin/Product
        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }
    }
}