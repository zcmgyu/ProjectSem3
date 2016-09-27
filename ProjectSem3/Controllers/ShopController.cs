using Microsoft.AspNet.Identity;
using Model.DAO;
using Model.EF;
using ProjectSem3.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace ProjectSem3.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        [Authorize]
        public ActionResult Checkout()
        {
            var currentUserId = User.Identity.GetUserId();
            var shippingInfo = new AccountDao().GetShippingInfo(currentUserId);
            // Check this info is created?
            //ViewBag.IsCreated = (shippingInfo == null) ? false : true;
            shippingInfo = shippingInfo ?? new Shipping();
            return View(shippingInfo);
        }


        [Authorize]
        [HttpPost]
        public ActionResult Payment(Shipping model)
        {
            model.AccountID = User.Identity.GetUserId();
            var cart = Session[Common.CommonSession.CartSession] as List<CartItem>;
            var cartViewModel = new List<CartItemViewModel>();
            foreach(var item in cart)
            {
                decimal? actualPrice = item.Product.PromotionPrice ?? item.Product.Price;
                var cartitem = new CartItemViewModel
                {
                    ProductID = item.Product.ID,
                    Color = item.Color,
                    Size = item.Size,
                    Quantity = item.Quantity,
                    ActualPrice = actualPrice
                };
                cartViewModel.Add(cartitem);
            }
            // Parse cart to XML
            var listSCQ = cartViewModel;
            var serializerSCQ = new XmlSerializer(typeof(List<CartItemViewModel>));
            var outputSCQ = new StringBuilder();
            var writerSCQ = new StringWriter(outputSCQ);
            serializerSCQ.Serialize(writerSCQ, listSCQ);
            var xmlSCQ = outputSCQ.ToString().Replace("&#xD;&#xA;", Environment.NewLine);

            // Cast from Shipping model to Order Model
            var order = new Model.EF.Order()
            {
                CreatedDate = DateTime.Now,
                CustomerID = User.Identity.GetUserId(),
                ShipAddress = model.Address,
                ShipCity = model.City,
                ShipDistrict = model.District,
                ShipEmail = model.Email,
                ShipFirstname = model.Firstname,
                ShipLastname = model.Lastname,
                ShipGender = model.Gender,
                ShipNote = model.OrderNote,
                ShipMobile = model.PhoneNumber,
                ShipPostCode = model.PostCode,
                Status = 1
            };

            // Insert to DB
            var result = new ShoppingDao().InsertOrder(order, xmlSCQ);
            if(result)
            {
                // Remove session
                Session[Common.CommonSession.CartSession] = null;
                return RedirectToAction("Index", "Home");
            }
            return View("Checkout", model);

        }
        
    }
}