using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectSem3.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {

        public ActionResult Detail(string id)
        {
            ViewBag.Profile = new CustomerDao().LoadCustomerInfoById(id);
            ViewBag.OrderInfo = new CustomerDao().CountOrderTimeItemAmountByUserId(id);
            return View();
        }


        // GET: Admin/Customer
        public ActionResult List()
        {

            return View();
        }

        public ActionResult LoadCustomerToTable(Model.ViewModel.CustomerFilterViewModel model)
        {

            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            // Find search value
            var sFirstname = model.Firstname;
            var sLastname = model.Lastname;
            var sGender = model.Gender;
            var sDOB = model.DOB;
            var sCity = model.City;
            var sDistrict = model.District;
            var sAddress = model.Address;
            var sEmail = model.Email;
            var sPhone = model.Phone;
            var sStatus = model.Status;
            //var sId = Request.Form.GetValues("columns[1][search][value]").FirstOrDefault();
            //var sName = Request.Form.GetValues("columns[2][search][value]").FirstOrDefault();
            //var sCategory = Request.Form.GetValues("columns[3][search][value]").FirstOrDefault();
            //var sPriceFrom = Request.Form.GetValues("columns[4][search][value]").FirstOrDefault();
            //var sPriceTo = Request.Form.GetValues("columns[4][search][value]").FirstOrDefault();
            //var sPromotionPriceFrom = Request.Form.GetValues("columns[5][search][value]").FirstOrDefault();
            //var sPromotionPriceTo = Request.Form.GetValues("columns[5][search][value]").FirstOrDefault();

            // Get data from DB
            var data = new CustomerDao().LoadListCustomer();
            //if (sID != 0) data = data.Where(x => x.ID == sID).ToList();

            if (!string.IsNullOrEmpty(sFirstname))
            {
                data = data.Where(x => x.Firstname.Contains(sFirstname)).ToList();
            }
            if (!string.IsNullOrEmpty(sLastname))
            {
                data = data.Where(x => x.Lastname.Contains(sLastname)).ToList();
            }
            if (sDOB != DateTime.MinValue)
            {
                data = data.Where(x => x.DOB == sDOB).ToList();
            }
            if (sGender != null)
            {
                data = data.Where(x => x.Gender == sGender).ToList();
            }
            if (sCity != null)
            {
                data = data.Where(x => x.City == (sCity)).ToList();
            }
            if (sDistrict != null)
            {
                data = data.Where(x => x.District == (sDistrict)).ToList();
            }
            if (sAddress != null)
            {
                data = data.Where(x => x.Address == (sAddress)).ToList();
            }
       
            if (!string.IsNullOrEmpty(sPhone))
            {
                data = data.Where(x => x.Phone.Contains(sPhone)).ToList();
            }
            if (!string.IsNullOrEmpty(sEmail))
            {
                data = data.Where(x => x.Email.Contains(sEmail)).ToList();
            }
            if (sStatus != null)
            {
                data = data.Where(x => x.Status == sStatus).ToList();
            }

            ////if (!string.IsNullOrEmpty(sCategory))
            ////{
            ////    data = data.Where(x => x.Category == sCategory).ToList();
            ////}
            //if (sPriceFrom != null)
            //{
            //    data = data.Where(x => x.Price >= Convert.ToDecimal(sPriceFrom)).ToList();
            //}
            //if (sPriceTo != null)
            //{
            //    data = data.Where(x => x.Price <= Convert.ToDecimal(sPriceTo)).ToList();
            //}
            //if (sPromotionPriceFrom != null)
            //{
            //    data = data.Where(x => x.PromotionPrice >= Convert.ToDecimal(sPromotionPriceFrom)).ToList();
            //}
            //if (sPromotionPriceTo != null)
            //{
            //    data = data.Where(x => x.PromotionPrice <= Convert.ToDecimal(sPromotionPriceTo)).ToList();
            //}
            //if (sQuantityFrom != null)
            //{
            //    data = data.Where(x => x.SumQuantity >= Convert.ToInt32(sQuantityFrom)).ToList();
            //}
            //if (sQuantityTo != null)
            //{
            //    data = data.Where(x => x.SumQuantity <= Convert.ToInt32(sQuantityTo)).ToList();
            //}
            //if (sCreatedDateFrom != DateTime.MinValue)
            //{
            //    data = data.Where(x => x.CreatedDate >= sCreatedDateFrom).ToList();
            //}
            //if (sCreatedDateFrom != DateTime.MinValue)
            //{
            //    data = data.Where(x => x.CreatedDate <= sCreatedDateFrom).ToList();
            //}
            //if (sStatus != null)
            //{
            //    data = data.Where(x => x.Status == sStatus).ToList();
            //}
            int totalRecords = data.Count();
            data = data.Skip(skip).Take(pageSize).ToList();

            return Json(new { draw = draw, recordsFiltered = totalRecords, recordsTotal = totalRecords, data = data }, JsonRequestBehavior.AllowGet);
        }
    }
}