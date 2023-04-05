using PYS.Application.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace PYS.Application.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //TRestClient client = new TRestClient();
            //TApiUser user = new TApiUser();
            //user.Username = "tuncgulec";
            //user.Password = "112233";
            //var token = client.GetToken(user);
            return View();
        }
        

        [HttpGet]
        public ActionResult GetTest()
        {
            //Thread.Sleep(15000);
            TRestClient client = new TRestClient();
            string resultData = client.Test();
            return Json(resultData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult PostTest(string Name, string Surname)
        {
            Thread.Sleep(5000);
            return Json(Name + " " + Surname, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult PostTest()
        {
            Thread.Sleep(15000);
            TRestClient client = new TRestClient();
            string resultData = client.Test();
            return Json(resultData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Register()
        {
            TRestClient client = new TRestClient();
            //client.Register()
            return Json(JsonRequestBehavior.AllowGet);
        }

    }
}