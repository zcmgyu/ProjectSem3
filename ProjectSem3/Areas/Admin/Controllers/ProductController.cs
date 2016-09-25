using Model.DAO;
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

        //[ChildActionOnly]
        //public ActionResult LoadProduct()
        //{
        //    var model = new ProductDao().LoadProduct();
        //    return PartialView("_LoadProduct", model);
        //}

        [HttpPost]
        public ActionResult LoadProductToTable(Model.ViewModel.ProductFilterViewModel model)
        {
            //
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            // Find search value
            var sID = model.ID;
            var sName = model.Name;
            var sPriceFrom = model.PriceFrom;
            var sPriceTo = model.PriceTo;
            var sPromotionPriceFrom = model.PromotionPriceFrom;
            var sPromotionPriceTo = model.PromotionPriceTo;
            var sQuantityFrom = model.SumQuantityFrom;
            var sQuantityTo = model.SumQuantityTo;
            var sCreatedDateFrom = model.CreatedDateFrom;
            var sCreatedDateTo = model.CreatedDateTo;
            var sStatus = model.Status;
            //var sId = Request.Form.GetValues("columns[1][search][value]").FirstOrDefault();
            //var sName = Request.Form.GetValues("columns[2][search][value]").FirstOrDefault();
            //var sCategory = Request.Form.GetValues("columns[3][search][value]").FirstOrDefault();
            //var sPriceFrom = Request.Form.GetValues("columns[4][search][value]").FirstOrDefault();
            //var sPriceTo = Request.Form.GetValues("columns[4][search][value]").FirstOrDefault();
            //var sPromotionPriceFrom = Request.Form.GetValues("columns[5][search][value]").FirstOrDefault();
            //var sPromotionPriceTo = Request.Form.GetValues("columns[5][search][value]").FirstOrDefault();

            // Get data from DB
            var data = new ProductDao().LoadProduct();
            if (sID != 0) data = data.Where(x => x.ID == sID).ToList();

            if (!string.IsNullOrEmpty(sName))
            {
                data = data.Where(x => x.Name.Contains(sName)).ToList();
            }
            //if (!string.IsNullOrEmpty(sCategory))
            //{
            //    data = data.Where(x => x.Category == sCategory).ToList();
            //}
            if (sPriceFrom != null)
            {
                data = data.Where(x => x.Price >= Convert.ToDecimal(sPriceFrom)).ToList();
            }
            if (sPriceTo != null)
            {
                data = data.Where(x => x.Price <= Convert.ToDecimal(sPriceTo)).ToList();
            }
            if (sPromotionPriceFrom != null)
            {
                data = data.Where(x => x.PromotionPrice >= Convert.ToDecimal(sPromotionPriceFrom)).ToList();
            }
            if (sPromotionPriceTo != null)
            {
                data = data.Where(x => x.PromotionPrice <= Convert.ToDecimal(sPromotionPriceTo)).ToList();
            }
            if (sQuantityFrom != null)
            {
                data = data.Where(x => x.SumQuantity >= Convert.ToInt32(sQuantityFrom)).ToList();
            }
            if (sQuantityTo != null)
            {
                data = data.Where(x => x.SumQuantity <= Convert.ToInt32(sQuantityTo)).ToList();
            }
            if (sCreatedDateFrom != DateTime.MinValue)
            {
                data = data.Where(x => x.CreatedDate >= sCreatedDateFrom).ToList();
            }
            if (sCreatedDateFrom != DateTime.MinValue)
            {
                data = data.Where(x => x.CreatedDate <= sCreatedDateFrom).ToList();
            }
            if (sStatus != null)
            {
                data = data.Where(x => x.Status == sStatus).ToList();
            }
            int totalRecords = data.Count();
            data = data.Skip(skip).Take(pageSize).ToList();
            
            return Json(new { draw = draw, recordsFiltered = totalRecords, recordsTotal = totalRecords, data = data }, JsonRequestBehavior.AllowGet);
            //return Json(new { data = model }, JsonRequestBehavior.AllowGet);
        }
        // GET: Admin/Product
        public ActionResult Create()
        {
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
                    SizeAndQuantities = new List<Models.SizeAndQuantity>()
                };
                model.SizeColorQuantities.Add(child);
                foreach (var size in sizes)
                {
                    child.SizeAndQuantities.Add(new Models.SizeAndQuantity()
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
                model.ProductGeneral.Description, model.ProductGeneral.ShortDescription, model.ProductGeneral.SKU, model.ProductGeneral.ProductType,
                model.ProductGeneral.Price, model.ProductGeneral.PromotionPrice, model.ProductGeneral.Status, strImg, strSCQ);
            if (productDao)
                return RedirectToAction("List");
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