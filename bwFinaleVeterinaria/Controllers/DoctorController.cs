using bwFinaleVeterinaria.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bwFinaleVeterinaria.Controllers
{
    public class DoctorController : Controller
    {
        private VeterinariaDbContext db = new VeterinariaDbContext();

        // GET: Doctor
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddOwner()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOwner([Bind(Include = "Name, Surname, FiscalCode")] Owner owner)
        {
            if (ModelState.IsValid)
            {
                db.Owners.Add(owner);
                db.SaveChanges();
                TempData["Success"] = "Il proprietario è stato aggiunto correttamente.";
                return RedirectToAction("AddOwner");
            }

            TempData["Fail"] = "Il proprietario NON è stato aggiunto correttamente.";
            return View(owner);
        }
    }
}