using PYS.Application.Data;
using PYS.Application.Helper;
using PYS.Application.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PYS.Application.Web.Controllers
{
    public class PanelController : Controller
    {
        // GET: Panel
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexPanel()
        {
            HttpCookie nameCookie = Request.Cookies["PYS"];
            string CookieToken = nameCookie != null ? nameCookie.Value.Split('=')[1] : "undefined";
            string SessionToken = HttpContext.Session["Token"].ToString();

            if (CookieToken != SessionToken)
            {
                Session["Token"] = "";
                Session["Login"] = false;
                Response.Redirect("~/", true);
            }
            return View();
        }
    }
}