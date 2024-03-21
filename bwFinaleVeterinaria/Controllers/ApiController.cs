using bwFinaleVeterinaria.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;


namespace bwFinaleVeterinaria.Controllers
{
    public class ApiController : Controller
    {
        private VeterinariaDbContext db = new VeterinariaDbContext();

        public JsonResult GetActiveAdmissions()
        {
            var strayPets = db.Pets
             .Where(p => p.RescueAdmissions.Any(ra => ra.EndAdmissionDate == null))
             .Select(p => new
             {
                 Pet = new
                 {
                     p.Id,
                     p.Name,
                     p.Type,
                     p.CoatColor,
                     p.Microchip
                 },
                 RescueAdmission = p.RescueAdmissions
                     .Where(ra => ra.EndAdmissionDate == null)
                     .Select(ra => new
                     {
                         ra.Id,
                         ra.AdmissionDate,
                         ra.PetImageUrl,
                         ra.Price
                     })
                     .FirstOrDefault()
             })
             .ToList();

            return Json(strayPets, JsonRequestBehavior.AllowGet);
        }

        // Metodo Asincrono per recuperare le visite in Examination
        public ActionResult GetAnimalHistory(int petId)
        {
            var animal = db.Pets.Include(p => p.Examinations).SingleOrDefault(p => p.Id == petId);
            if (animal == null)
            {
                return HttpNotFound();
            }

            return PartialView("~/Views/Doctor/_AnimalHistoryPartial.cshtml", animal.Examinations.OrderByDescending(e => e.ExaminationDate));
        }
    }
}