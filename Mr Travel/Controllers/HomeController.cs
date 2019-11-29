using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mr_Travel.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        [ValidateInput(true)]
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(true)]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [ValidateInput(true)]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }   
}