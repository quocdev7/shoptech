﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace shopdodadung
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        protected void Session_Start()
        {
            Session["Cart"] = "";
            Session["User_Admin"] = "";
            Session["User_Id"] = 1;
            Session["Thongbao"] = "";
            Session["GioHang"] = "";
        }
    }
}
