using Common;
using ProjectSem3.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectSem3.Areas.Admin.Controllers
{
    public class NotificationController : Controller
    {
        // GET: Admin/Notification
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Notification
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(FormMailViewModel model)
        {
            //string htmlContent = System.IO.File.ReadAllText(Server.MapPath("~/Content/Admin/Extension/MailContent.html"));
            //htmlContent = htmlContent.Replace("{{content}}", model.Content);
            new MailHelper().SendMail(model.SendMailTo, model.Subject, model.Content);
            return RedirectToAction("List", "Notification");
        }

    }
}