using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Model.DAO;
using Model.EF;
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
        public ActionResult Login([Bind(Prefix = "Item1")] AccountViewModels.LoginViewModel model)
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
        public ActionResult Register([Bind(Prefix = "Item1")]AccountViewModels.RegisterViewModel model)
        {
            var account = new Account()
            {
                Email = model.Email,
                Password = Encryptor.Md5Hash(model.Password),
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Gender = model.Gender,
                DOB = model.DOB,
                Country = model.City,
                City = model.City,
                Address = model.Address,
                Phone = model.Phone,
                PostCode = model.PostCode,
                CreatedBy = "client"
            };
            var result = new AccountDao().Register(account);
            if (result == 1)
            {
                return RedirectToAction("Index", "Home");
            }
            var tuple = new Tuple<AccountViewModels.LoginViewModel, AccountViewModels.RegisterViewModel>(null, model);
            if (result != 3) return View("LoginAndRegister", tuple);
            ViewBag.SelectedItem = "RegisterEmail";
            return View("LoginAndRegister");
        }
    }
}