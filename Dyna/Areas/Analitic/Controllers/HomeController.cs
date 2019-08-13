using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dyna.Models;

namespace Dyna.Areas.Analitic.Controllers
{
    public class HomeController : Controller
    {
        // GET: Analitic/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}