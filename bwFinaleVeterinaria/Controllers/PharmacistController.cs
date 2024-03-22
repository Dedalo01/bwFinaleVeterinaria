using bwFinaleVeterinaria.Models;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace bwFinaleVeterinaria.Controllers
{
    [Authorize(Roles = "Pharmacist")]
    public class PharmacistController : Controller
    {
        private readonly VeterinariaDbContext _db = new VeterinariaDbContext();

        // GET: Pharmacist
        public ActionResult SalesAdd()
        {
            var viewModel = new SalesViewModel
            {
                Products = _db.Products.ToList(),
                Owners = _db.Owners.ToList(),
                Examinations = _db.Examinations.ToList()
            };

            return View("SalesAdd", viewModel);
        }


        [HttpPost]
        public ActionResult SalesAdd(SalesViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Sale sale = new Sale
                {
                    ExaminationId = viewModel.ExaminationId,
                    OwnerId = viewModel.OwnerId,
                    ProductId = viewModel.ProductId,
                    SaleDate = viewModel.SaleDate
                };

                _db.Sales.Add(sale);
                _db.SaveChanges();

                TempData["Success"] = "Prodotto Aggiunto con Successo";

                return RedirectToAction("SalesAdd");
            }

            viewModel.Products = _db.Products.ToList();
            viewModel.Owners = _db.Owners.ToList();
            viewModel.Examinations = _db.Examinations.ToList();

            TempData["Fail"] = "Problemi ad Aggiungere il Prodotto";
            return View(viewModel);
        }

        public ActionResult SalesDetails()
        {
            var sales = _db.Sales.Include("Product").Include("Owner").Include("Examination").ToList();

            // Raggruppa le vendite per proprietario
            var salesByOwner = sales.GroupBy(s => s.OwnerId);

            return View(salesByOwner);
        }


        public ActionResult ProductsList()
        {
            var products = _db.Products.ToList();
            return View(products);
        }



        public ActionResult ProductAdd()
        {
            var viewModel = new ProductAddViewModel
            {
                Companies = _db.Companies.ToList(),
                Drawers = _db.Drawers.ToList(),
                Cabinets = _db.Cabinets.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductAdd(ProductAddViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    Name = viewModel.Name,
                    Type = viewModel.Type,
                    PossibleUses = viewModel.PossibleUses,
                    CompanyId = viewModel.CompanyId
                };

                _db.Products.Add(product);
                _db.SaveChanges();


                var cabinet = new Cabinet
                {
                    NumericCode = viewModel.NumericCode,
                    DrawerId = viewModel.DrawerId,
                    ProductId = product.Id
                };

                _db.Cabinets.Add(cabinet);
                _db.SaveChanges();

                return RedirectToAction("ProductsList", "Pharmacist");
            }

            viewModel.Companies = _db.Companies.ToList();
            viewModel.Drawers = _db.Drawers.ToList();
            viewModel.Cabinets = _db.Cabinets.ToList();
            return View(viewModel);
        }

        public ActionResult CompanyAdd()
        {
            return View();
        }

        // POST: Company/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CompanyAdd(Company company)
        {
            if (ModelState.IsValid)
            {
                _db.Companies.Add(company);
                _db.SaveChanges();
                TempData["Success"] = "Prodotto Aggiunto con Successo";
                return RedirectToAction("CompanyAdd");
            }

            TempData["Fail"] = "Problemi ad Aggiungere il Prodotto";
            return View(company);
        }

        public ActionResult CompanyDetails(int id)
        {
            var company = _db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        public async Task<ActionResult> ProductDetails(int id)
        {
            var medicine = await _db.Products
                .Include(p => p.Cabinets.Select(c => c.Drawer))
                .FirstOrDefaultAsync(p => p.Id == id);

            if (medicine == null)
            {
                return HttpNotFound();
            }

            return View("ProductDetails", medicine);

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: Pharmacist/Search
        public ActionResult Search()
        {
            return View();
        }

    }
}
