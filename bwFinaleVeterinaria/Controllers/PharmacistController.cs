using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using bwFinaleVeterinaria.Models;

namespace bwFinaleVeterinaria.Controllers
{
    public class PharmacistController : Controller
    {
        private readonly VeterinariaDbContext _context;

        public PharmacistController()
        {
            _context = new VeterinariaDbContext();
        }

        // GET: Pharmacist/Search
        public ActionResult Search()
        {
            return View(); // Assicurati che esista una vista chiamata Search.cshtml nella cartella Views/Pharmacist
        }

        [HttpPost]
        public async Task<ActionResult> Search(string productName)
        {
            var product = await _context.Products
                .Include("Cabinets")
                .Include("Cabinets.Drawer")
                .FirstOrDefaultAsync(p => p.Name == productName);

            if (product == null)
            {
                return HttpNotFound();
            }

            return PartialView("_ProductDetailsPartial", product);
        }
    }
}
