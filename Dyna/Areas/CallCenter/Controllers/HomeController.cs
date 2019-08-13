using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dyna.Areas.CallCenter.Controllers
{
    public class HomeController : Controller
    {
        // GET: CallCenter/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}