using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Model.DAO;
using Model.EF;
using ProjectSem3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProjectSem3.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        //
        // GET: /Manage/Index
        public ActionResult Index()
        {

            var userId = User.Identity.GetUserId();
            var user = new AccountDao().GetInfo(userId);
            var model = new AccountViewModel
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Address = user.Address,
                Email = user.Email,
                City = user.City,
                District = user.District,
                DOB = user.DOB,
                Gender = user.Gender,
                PhoneNumber = user.PhoneNumber,
                PostCode = user.PostCode
            };
            
            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public JsonResult UpdateInfo(AccountViewModel model)
        {
            var account = new AspNetUser
            {
                Id = User.Identity.GetUserId(),
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
                City = model.City,
                District = model.District,
                //Email = model.Email,
                Gender = model.Gender,
                DOB = model.DOB,
                PostCode = model.PostCode
            };
            var result = new AccountDao().UpdateInfo(account);
            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Shipping()
        {
            return Json(new { a = "" });
        }

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ManageController()
        {
        }

        public ManageController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


    }
}