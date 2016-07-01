using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Model.DAO;
using ProjectSem3.Common;
using ProjectSem3.Models;

namespace ProjectSem3.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult LoginAndRegister()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AccountViewModels.LoginViewModel model)
        {
            if (!ModelState.IsValid) return View("LoginAndRegister");
            var encryptedPassword = Encryptor.Md5Hash(model.Password);
            if (new AccountDao().Login(model.Email, encryptedPassword))
            {
                FormsAuthentication.SetAuthCookie(model.Email, false);
                ViewBag.Email = model.Email;
                return RedirectToAction("Index", "Home");
            }
            return View("LoginAndRegister");
        }

        [HttpPost]
        public ActionResult Register()
        {
            return RedirectToAction("LoginAndRegister");
        }
    }
}