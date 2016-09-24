using Model.DAO;
using ProjectSem3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml.Linq;

namespace ProjectSem3.Controllers
{
    public class CartController : Controller
    {
        // GET: Admin/Cart
        public ActionResult Index()
        {
            var cart = Session[Common.CommonSession.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        public ActionResult AddItem(string model)
        {
            var cartItem = new JavaScriptSerializer().Deserialize<CartItem>(model);
            long productId = cartItem.Product.ID;
            string size = cartItem.Size;
            string color = cartItem.Color;
            int quantity = cartItem.Quantity;
            var product = new ProductDao().LoadProduct(productId);
            var xImages = XElement.Parse(product.MoreImages);
            var listImageReturn = new List<string>();
            // Get first value on 
            var first = xImages.Elements().First();
            var singleImage = xImages.Elements().First().Element("Url").Value;
            product.Image = singleImage;
            var cart = Session[Common.CommonSession.CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Product.ID == productId & x.Size == size & x.Color == color))
                {

                    foreach (var item in list)
                    {
                        if (item.Product.ID == productId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    //tạo mới đối tượng cart item
                    var item = new CartItem()
                    {
                        Product = product,
                        Color = color,
                        Size = size,
                        Quantity = quantity
                    };
                    list.Add(item);
                }
                //Gán vào session
                Session[Common.CommonSession.CartSession] = list;
            }
            else
            {
                //tạo mới đối tượng cart item
                var item = new CartItem()
                {
                    Product = product,
                    Quantity = quantity,
                    Color = color,
                    Size = size
                };
                var list = new List<CartItem>();
                list.Add(item);
                //Gán vào session
                Session[Common.CommonSession.CartSession] = list;
            }
            return Json(new { result = true }, JsonRequestBehavior.AllowGet);
        }
    }
}