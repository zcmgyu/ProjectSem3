using Model.EF;
using ProjectSem3.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text;
using System.IO;
using Model.DAO;

namespace ProjectSem3.Controllers
{
    public class PaypalController : Controller
    {
        public ActionResult Index()
        {
            var cart = Session[Common.CommonSession.CartSession] as List<CartItem>;
            if (cart == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(cart);
        }

        // GET: Paypal
        public ActionResult GetDataPaypal()
        {

            var getData = new GetDataPaypal();
            var orderPaypal  = getData.InformationOrder(getData.GetPayPalResponse(Request.QueryString["tx"]));
            ViewBag.tx = Request.QueryString["tx"];
            var order = new Order()
            {
                CreatedDate = DateTime.Now,
                ShipFirstname = orderPaypal.PayerFirstName,
                ShipLastname = orderPaypal.PayerLastName,
                CustomerID = User.Identity.GetUserId(),
                ShipAddress = orderPaypal.Address,
                ShipCity = orderPaypal.City,
                ShipState = orderPaypal.State,
                PaymentType = 2, // Paypal Type
                ShipCountry = orderPaypal.Country,
                ShipEmail = orderPaypal.PayerEmail,
                ShipPostCode = orderPaypal.PostCode,
                Status = 1,
                ShipDistrict = "",
                ShipGender = 3,
                ShipNote = orderPaypal.Memo ?? "Dont have note",
                ShipMobile = ""
            };

            ///

            var cart = Session[Common.CommonSession.CartSession] as List<CartItem>;
            var cartViewModel = new List<CartItemViewModel>();
            foreach (var item in cart)
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


            // Insert to DB
            var result = new ShoppingDao().InsertOrder(order, xmlSCQ);
            if (result)
            {
                // Remove session
                Session[Common.CommonSession.CartSession] = null;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}