using bwFinaleVeterinaria.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace bwFinaleVeterinaria.Controllers
{

    [Authorize(Roles = "Pharmacist, Doctor")]
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


        // POST: Pharmacist/SearchProduct
        [HttpPost]
        public async Task<ActionResult> SearchProduct(string productName)
        {
            var product = await db.Products
                .Include(p => p.Cabinets)
                .Include(p => p.Cabinets.Select(c => c.Drawer))
                .FirstOrDefaultAsync(p => p.Name == productName);

            if (product == null)
            {
                return PartialView("~/Views/Pharmacist/_ProductSearchResults.cshtml", null);
            }

            return PartialView("~/Views/Pharmacist/_ProductSearchResults.cshtml", product);
        }

        // POST: Pharmacist/SearchByFiscalCode
        [HttpPost]
        public async Task<ActionResult> SearchByFiscalCode(string fiscalCode)
        {
            var sales = await db.Sales
                .Include(s => s.Owner)
                .Where(s => s.Owner.FiscalCode == fiscalCode)
                .ToListAsync();

            return PartialView("~/Views/Pharmacist/_FiscalCodeSearchResults.cshtml", sales);
        }

        // POST: Pharmacist/SearchByDate
        [HttpPost]
        public async Task<ActionResult> SearchByDate(DateTime saleDate)
        {
            var sales = await db.Sales
                .Where(s => DbFunctions.TruncateTime(s.SaleDate) == saleDate.Date)
                .ToListAsync();

            return PartialView("~/Views/Pharmacist/_DateSearchResults.cshtml", sales);
        }

        [AllowAnonymous]
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