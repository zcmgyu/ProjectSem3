using Model.DAO;
using Model.EF;
using ProjectSem3.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace ProjectSem3.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult List()
        {
            return View();
        }
        // GET: Admin/Product
        public ActionResult Create()
        {
            //var colors = new List<string>() { "Red", "Blue" };
            //var sizes = new List<string>() { "S", "M", "L", "XL" };
            var colors = new ProductDao().LoadProductColor();
            var sizes = new ProductDao().LoadProductSize();
            var categories = new ProductDao().LoadProductCategory();

            var model = new ProductViewModel
            {
                ProductGeneral = new ProductGeneral(),
                SizeColorQuantities = new List<SizeColorQuantityViewModel>()
            };

            
            foreach (var color in colors)
            {
                var child = new SizeColorQuantityViewModel
                {
                    ColorId = color,
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
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var listImage = model.ProductImages;
            var serializerImg = new XmlSerializer(typeof(List<Image>));
            var outputImg = new StringBuilder();
            var writerImg = new StringWriter(outputImg);
            serializerImg.Serialize(writerImg, listImage);
            var strImg = outputImg.ToString().Replace("&#xD;&#xA;", Environment.NewLine);
            // 
            var listSCQ = model.SizeColorQuantities;
            var serializerSCQ = new XmlSerializer(typeof(List<SizeColorQuantityViewModel>));
            var outputSCQ = new StringBuilder();
            var writerSCQ = new StringWriter(outputSCQ);
            serializerSCQ.Serialize(writerSCQ, listSCQ);
            var strSCQ = outputSCQ.ToString().Replace("&#xD;&#xA;", Environment.NewLine);
            //
            var productDao = new ProductDao().InsertProduct(model.ProductGeneral.Name, 
                model.ProductGeneral.Description, model.ProductGeneral.ShortDescription, model.ProductGeneral.SKU,
                model.ProductGeneral.Price, model.ProductGeneral.PromotionPrice, model.ProductGeneral.Status, strImg, strSCQ);
            if (productDao) RedirectToAction("List");
            return View(model);
        }

        public ActionResult Test()
        {
            ViewBag.CountColor = 4;
            return View();
        }
        public ActionResult AddImageRow()
        {
            return PartialView("_ImageRow");
        }

        
    }
}