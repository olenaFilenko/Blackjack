using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blackjack.Angular6.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //return new FilePathResult("~/ClientApp/dist/ClientApp/index.html", "text/html");
            return View();
        }

       
    }
}