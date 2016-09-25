using Model.DAO;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using PagedList;
using System.Web.Helpers;

namespace ProjectSem3.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult TestUrlParams(string key1, string key2)
        {
            return Json(new { key1 = key1, key2 = key2});
        }

        // GET: Product
        public ActionResult ShopList(int? categoryId, decimal? firstprice, decimal? lastprice, string color = "", string size = "", int page = 1, int pageSize = 9)
        {
            int totalRecord = 0;
            var listProduct = new ProductDao().LoadSimpleProductList(ref totalRecord, categoryId, firstprice, lastprice, color, size, page, pageSize);
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            int maxPage = 3;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((totalRecord / (double)pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = maxPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            var listProductVM = new List<SimpleProductViewModel>();

            foreach (var item in listProduct)
            {

                XElement xImages = XElement.Parse(item.MoreImages);
                var listImageReturn = new List<string>();

                foreach (var xItem in xImages.Elements())
                {
                    var result = xItem.Element("Url").Value;
                    listImageReturn.Add(xItem.Element("Url").Value);
                };
                var product = new SimpleProductViewModel()
                {
                    Id = item.ID,
                    Name = item.Name,
                    MetaTitle = item.MetaTitle,
                    MoreImages = listImageReturn,
                    Price = item.Price,
                    PromotionPrice = item.PromotionPrice,
                    ShortDescription = item.ShortDescription
                };
                listProductVM.Add(product);
            }
            //
            ViewBag.Colors = new ProductDao().LoadProductColor();
            return View(listProductVM);
        }

        //[ChildActionOnly]
        //public ActionResult ListProduct(int page = 1, int pageSize = 9)
        //{
        //    int totalRecord = 0;
        //    var listProduct = new ProductDao().LoadSimpleProductList(ref totalRecord, page, pageSize);
        //    ViewBag.Total = totalRecord;
        //    ViewBag.Page = page;
        //    int maxPage = 3;
        //    int totalPage = 0;
        //    totalPage = (int)Math.Ceiling((totalRecord / (double)pageSize));
        //    ViewBag.TotalPage = totalPage;
        //    ViewBag.MaxPage = maxPage;
        //    ViewBag.First = 1;
        //    ViewBag.Last = maxPage;
        //    ViewBag.Next = page + 1;
        //    ViewBag.Prev = page - 1;

        //    var listProductVM = new List<SimpleProductViewModel>();

        //    foreach (var item in listProduct)
        //    {
        //        //var emptyElement = XElement.Parse("empStr");
        //        //item.MoreImages = item.MoreImages ?? emptyElement.Value;
        //        XElement xImages = XElement.Parse(item.MoreImages);
        //        var listImageReturn = new List<string>();

        //        foreach (var xItem in xImages.Elements())
        //        {
        //            var result = xItem.Element("Url").Value;
        //            listImageReturn.Add(xItem.Element("Url").Value);
        //        };
        //        var product = new SimpleProductViewModel()
        //        {
        //            Id = item.ID,
        //            Name = item.Name,
        //            MetaTitle = item.MetaTitle,
        //            MoreImages = listImageReturn,
        //            Price = item.Price,
        //            PromotionPrice = item.PromotionPrice,
        //            ShortDescription = item.ShortDescription
        //        };
        //        listProductVM.Add(product);
        //    }
        //    return PartialView("_ListProduct", listProductVM);
        //}


        public ActionResult Detail(long id)
        {
            var model = new ProductDao().LoadProductDetail(id);
            ViewBag.RelatedProduct = new ProductDao().LoadRelatedProduct(id);
            return View(model);
        }
    }
}