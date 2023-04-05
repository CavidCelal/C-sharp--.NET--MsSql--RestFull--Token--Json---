using PYS.Application.Data;
using PYS.Application.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace PYS.Application.Web.Controllers
{
    public class ApiController : Controller
    {

        [HttpPost]
        public ActionResult Login(string Username, string Password)
        {
            TRestClient client = new TRestClient();
            string resultData = client.GetToken(Username, Password);
            if (resultData != null)
            {
                if (resultData != "")
                {
                    HttpCookie nameCookie = new HttpCookie("PYS");
                    nameCookie.Values["Token"] = resultData;
                    nameCookie.Expires = DateTime.Now.AddMinutes(20);
                    Response.Cookies.Add(nameCookie);
                    Session["Token"] = resultData;
                    Session["Login"] = true;
                }
            }
            return Json(resultData, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult GetLoginUserDetail()
        {
            HttpCookie nameCookie = Request.Cookies["PYS"];
            string CookieToken = nameCookie != null ? nameCookie.Value.Split('=')[1] : "undefined";
            string SessionToken = HttpContext.Session["Token"].ToString();
            TResult result = new TResult();
            VwKisiKullaniciIletisim PersonData = new VwKisiKullaniciIletisim();
            if (CookieToken == SessionToken)
            {
                TRestClient client = new TRestClient();
                result = client.GetLoginUserDetail(HttpContext.Application["SecretKey"].ToString(), SessionToken);
                PersonData = JsonConvert.DeserializeObject<VwKisiKullaniciIletisim>(result.Data[0].ToString());
                PersonData.Sifre = "***";
            }
            return Json(PersonData, JsonRequestBehavior.AllowGet);
        }

    }
}