using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shopdodadung.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    { 
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.Session["User_Admin"] == null)
                {
                    Response.Redirect("~/Admin/login");
                }
                return View();
        }
    }
}