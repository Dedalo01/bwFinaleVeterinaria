using bwFinaleVeterinaria.Models;
using System.Linq;
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

            // error da modelState
            return View(pet);
        }
    }
}