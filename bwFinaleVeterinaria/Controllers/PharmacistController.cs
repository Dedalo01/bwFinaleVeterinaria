using System;
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
            return View();
        }

        // POST: Pharmacist/SearchProduct
        [HttpPost]
        public async Task<ActionResult> SearchProduct(string productName)
        {
            var product = await _context.Products
                .Include(p => p.Cabinets)
                .Include(p => p.Cabinets.Select(c => c.Drawer))
                .FirstOrDefaultAsync(p => p.Name == productName);

            if (product == null)
            {
                return PartialView("_ProductSearchResults", null);
            }

            return PartialView("_ProductSearchResults", product);
        }

        // POST: Pharmacist/SearchByFiscalCode
        [HttpPost]
        public async Task<ActionResult> SearchByFiscalCode(string fiscalCode)
        {
            var sales = await _context.Sales
                .Include(s => s.Owner)
                .Where(s => s.Owner.FiscalCode == fiscalCode)
                .ToListAsync();

            return PartialView("_FiscalCodeSearchResults", sales);
        }

        // POST: Pharmacist/SearchByDate
        [HttpPost]
        public async Task<ActionResult> SearchByDate(DateTime saleDate)
        {
            var sales = await _context.Sales
                .Where(s => DbFunctions.TruncateTime(s.SaleDate) == saleDate.Date)
                .ToListAsync();

            return PartialView("_DateSearchResults", sales);
        }
    }
}
