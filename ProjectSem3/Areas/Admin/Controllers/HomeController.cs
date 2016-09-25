using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectSem3.Areas.Admin.Controllers
{
    //[AreaAuthorize]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
       {
            
            return View();
        }

        // GET:
        [ChildActionOnly]
        public ActionResult _SideBar()
        {
            var model = new ComponentDao().LoadMenu(1);
            return PartialView(model);
        }

    }
}