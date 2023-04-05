using PYS.Application.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PYS.Application.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Application["SecretKey"] = System.Configuration.ConfigurationManager.AppSettings["SecretKey"].ToString();
        }

        protected void Session_Start()
        {
            Session["Token"] = "";
            Session["Login"] = false;
        }
    }
}
