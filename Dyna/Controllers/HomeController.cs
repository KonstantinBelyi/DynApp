using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Dyna.Models;

namespace Dyna.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            //IEnumerable<Home> result = HomeCollection.ErrorLog;
            //return View(result);

            //ViewBag.User = User.Identity.Name;
            //ViewBag.MachName = Server.MachineName;
            //ViewBag.ip = Request.UserHostAddress;


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}