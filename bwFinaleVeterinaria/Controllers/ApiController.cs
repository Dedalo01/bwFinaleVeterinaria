using System.Web.Mvc;
using bwFinaleVeterinaria.Models;
using System.Linq;

namespace bwFinaleVeterinaria.Controllers
{
    public class ApiController : Controller
    {
        private VeterinariaDbContext db = new VeterinariaDbContext();

        public ActionResult GetPetByMicrochip(string microchip)
        {
            var pet = db.Pets.Where(p => p.Microchip == microchip).Select(p => new
            {
                p.Name,
                p.Microchip,
                AdmissionInfo = db.RescueAdmissions.Where(ra => ra.PetId == p.Id).Select(ra => new
                {
                    ra.PetImageUrl,
                    ra.AdmissionDate
                }).FirstOrDefault()
            }).FirstOrDefault();

            if (pet != null)
            {
                return Json(new { success = true, pet = pet }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}