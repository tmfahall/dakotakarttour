using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DKTFinal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About Us";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Info";

            return View();
        }

        public ActionResult Calendar()
        {
            ViewBag.Message = "Calendar of Events";

            return View();
        }

        public ActionResult Pictures()
        {
            ViewBag.Message = "Tour Photos";

            return View();
        }

        public ActionResult Rules()
        {
            ViewBag.Message = "Tour Rules";

            return View();
        }

        public ActionResult Sponsors()
        {
            ViewBag.Message = "We'd Like To Thank";

            return View();
        }
    }
}