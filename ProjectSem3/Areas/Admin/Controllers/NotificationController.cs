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
    }
}