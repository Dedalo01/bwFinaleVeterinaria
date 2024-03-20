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

        public ActionResult AddExamination()
        {
            var Pets = db.Pets.ToList();
            TempData["Pets"] = Pets;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddExamination([Bind(Include = "petId, ExaminationDate, ObjectiveExamimation, TreatmentDescription")] Examination exam, int petId)
        {
            if (petId < 0)
            {
                TempData["Error"] = "Non hai inserito il Proprietario";
                return RedirectToAction("AddExamination");
            }

            if (ModelState.IsValid)
            {
                exam.PetId = petId;
                db.Examinations.Add(exam);
                db.SaveChanges();
                TempData["Success"] = "La visita è stata aggiunta correttamente.";
                return RedirectToAction("AddExamination");
            }

            TempData["Fail"] = "La visita NON è stata aggiunta correttamente.";
            return View(exam);
        } 
    }
}