using Model.DAO;
using Model.EF;
using ProjectSem3.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectSem3.Areas.Admin.Controllers
{
    public class MasterController : BaseController
    {
        // GET: Admin/Master
        public ActionResult ListSlide()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult ListSlideTable()
        {
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;

            var data = new ProductDao().ListSlide();
            data = data.Skip(skip).Take(pageSize).ToList();
            int totalRecords = data.Count();
            return Json(new { draw = draw, recordsFiltered = totalRecords, recordsTotal = totalRecords, data = data }, JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/Master
        public ActionResult CreateSlide()
        {
            return View();
        }

        // POST: Admin/Master
        [HttpPost]
        public ActionResult CreateSlide(Slide model)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            var result = new ProductDao().InsertSlide(model);

            if(result)
            {
                return RedirectToAction("ListSlide");
            }
            return View();
        }
        public ActionResult SlideDetail(int ID)
        {
            var model = new ProductDao().EditSlide(ID);
            return View(model);
        }

        public ActionResult EditSlide(int ID)
        {
            var model = new ProductDao().EditSlide(ID);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult UpdateSlide(Slide model)
        {
            var result = new ProductDao().UpdateSlide(model);
            if(result)
            {
                SetAlert("Update successful completed", "success");
                return RedirectToAction("ListSlide");
            }
            return View(model);
        }
    }
}