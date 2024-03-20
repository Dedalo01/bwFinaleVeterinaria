using bwFinaleVeterinaria.Models;
using System.Linq;
using System.Web.Mvc;

namespace bwFinaleVeterinaria.Controllers
{
    public class ApiController : Controller
    {
        // GET: Api
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetActiveAdmissions()
        {
            VeterinariaDbContext db = new VeterinariaDbContext();

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
    }
}