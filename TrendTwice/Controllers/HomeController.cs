using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrendTwice.App_Code;

namespace TrendTwice.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            TimeSpan ts = new TimeSpan(1, 0, 0, 0);

            if (string.IsNullOrEmpty(HttpHelpers.GetCookie("TrendTwiceSessionId")))
            {
                HttpHelpers.SetCookie("TrendTwiceSessionId", HttpHelpers.GetSessionId(), ts);
            }

            return View();
        }
    }
}
