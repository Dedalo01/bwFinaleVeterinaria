using bwFinaleVeterinaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bwFinaleVeterinaria.Controllers
{
    public class HomeController : Controller
    {
        private VeterinariaDbContext db = new VeterinariaDbContext();
        //Get: Lista ricoveri
        public ActionResult Index()
        {
            if (HttpContext.User.IsInRole("Doctor"))
            {
                return RedirectToAction("Index", "Doctor");
            }
            if (HttpContext.User.IsInRole("Pharmacist"))
            {
                return RedirectToAction("ProductsList", "Pharmacist");
            }
            var viewModel = new HomeView
            {
                RescueAdmissions = db.RescueAdmissions.ToList(),
                Employee = new Employee() 
            };

            return View(viewModel);
        }


        [HttpGet]
        public ActionResult Ricerca()
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