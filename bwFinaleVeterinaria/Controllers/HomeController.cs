using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bwFinaleVeterinaria.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {


            return View();
        }
        [Authorize(Roles = "Doctor")]
        public ActionResult Contact()
        {


            return View();
        }

        [Authorize(Roles = "Pharmacist")]
        public ActionResult About()
        {


            return View();
        }
    }
}