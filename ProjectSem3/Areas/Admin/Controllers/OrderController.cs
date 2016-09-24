using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;

namespace ProjectSem3.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        // GET: Admin/Order
        public ActionResult List()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoadOrderToTable(Model.ViewModel.OrderFilterViewModel model)
        {
            //
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            // Find search value
            var sOrderID = model.OrderID;
            var sPurchaseOnFrom = model.PurchasedOnFrom;
            var sPurchaseOnTo = model.PurchasedOnTo;
            var sFirstname = model.Firstname;
            var sLastname = model.Lastname;
            var sShipTo = model.ShipTo;
            var sShipEmail = model.ShipEmail;
            var sPaymentType = model.PaymentType;
            var sStatus = model.Status;
            //var sId = Request.Form.GetValues("columns[1][search][value]").FirstOrDefault();
            //var sName = Request.Form.GetValues("columns[2][search][value]").FirstOrDefault();
            //var sCategory = Request.Form.GetValues("columns[3][search][value]").FirstOrDefault();
            //var sPriceFrom = Request.Form.GetValues("columns[4][search][value]").FirstOrDefault();
            //var sPriceTo = Request.Form.GetValues("columns[4][search][value]").FirstOrDefault();
            //var sPromotionPriceFrom = Request.Form.GetValues("columns[5][search][value]").FirstOrDefault();
            //var sPromotionPriceTo = Request.Form.GetValues("columns[5][search][value]").FirstOrDefault();

            // Get data from DB
            var data = new OrderDao().LoadAllOrder();
            if (sOrderID != 0) data = data.Where(x => x.OrderID == sOrderID).ToList();

           
            if (sPurchaseOnFrom != DateTime.MinValue)
            {
                data = data.Where(x => x.PurchasedOn >= sPurchaseOnFrom).ToList();
            }
            if (sPurchaseOnTo != DateTime.MinValue)
            {
                data = data.Where(x => x.PurchasedOn >= sPurchaseOnFrom).ToList();
            }
            if (!string.IsNullOrEmpty(sFirstname))
            {
                data = data.Where(x => x.Firstname.Contains(sFirstname)).ToList();
            }
            if (!string.IsNullOrEmpty(sLastname))
            {
                data = data.Where(x => x.Lastname.Contains(sLastname)).ToList();
            }
            if (!string.IsNullOrEmpty(sShipTo))
            {
                data = data.Where(x => x.ShipTo.Contains(sShipTo)).ToList();
            }
            if (!string.IsNullOrEmpty(sShipEmail))
            {
                data = data.Where(x => x.ShipEmail.Contains(sShipEmail)).ToList();
            }
            if (sPaymentType != null)
            {
                data = data.Where(x => x.PaymentType == sPaymentType).ToList();
            }
            if (sStatus != null)
            {
                data = data.Where(x => x.Status == sStatus).ToList();
            }
            int totalRecords = data.Count();
            data = data.Skip(skip).Take(pageSize).ToList();

            return Json(new { draw = draw, recordsFiltered = totalRecords, recordsTotal = totalRecords, data = data }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Detail(int id)
        {
            var order = new OrderDao().LoadOrderById(id);
            ViewBag.Order = order;
            ViewBag.OrderDetail = new OrderDao().LoadOrderDetailById(id);
            ViewBag.CustomerInfo = new AccountDao().GetInfo(order.CustomerID);
            return View();
        }
        [HttpPost]
        public ActionResult ChangeStatus(int status, long orderId)
        {
            var result = new OrderDao().UpdateOrderStatusById(orderId, status);
     
            return Json(new { result = result});
        }
    }
}