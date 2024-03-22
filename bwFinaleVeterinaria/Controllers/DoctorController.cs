using bwFinaleVeterinaria.Models;
using System.Linq;
using System.Web.Mvc;

namespace bwFinaleVeterinaria.Controllers
{
    [Authorize(Roles = "Doctor")]
    public class DoctorController : Controller
    {
        private VeterinariaDbContext db = new VeterinariaDbContext();
        // GET: Doctor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddPet()
        {
            var owners = db.Owners.ToList();
            TempData["owners"] = owners;

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPet(Pet pet, int ownerId)
        {
            if (ownerId < 0)
            {
                TempData["Error"] = "Non hai inserito il Proprietario";
                return RedirectToAction("AddPet");
            }

            if (ModelState.IsValid)
            {
                pet.OwnerId = ownerId;
                db.Pets.Add(pet);
                db.SaveChanges();
                TempData["Success"] = $"L'Animale di nome {pet.Name} è stato aggiunto al database con successo.";
                return RedirectToAction("AddPet");
            }

            var owners = db.Owners.ToList();
            TempData["owners"] = owners;
            return View(pet);
        }

        //add Rescued Pet
        public ActionResult AddStray()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStray(PetRescueViewModel strayPet)
        {
            if (ModelState.IsValid)
            {
                db.Pets.Add(strayPet.Pet);
                db.SaveChanges();


                var lastPet = db.Pets.OrderByDescending(p => p.Id).FirstOrDefault();

                strayPet.RescueAdmission.PetId = lastPet.Id;
                db.RescueAdmissions.Add(strayPet.RescueAdmission);
                db.SaveChanges();

                TempData["Success"] = $"L'animale di nome {strayPet.Pet.Name} è stato aggiunto con successo tra i randagi.";
                return RedirectToAction("AddStray");
            }

            return View(strayPet);
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