using bwFinaleVeterinaria.Models;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;


namespace bwFinaleVeterinaria.Controllers
{
    public class ApiController : Controller
    {
        private VeterinariaDbContext db = new VeterinariaDbContext();

        // GET: Api
        public ActionResult Index()
        {
            return View();
        }

        //chiamata asincrona per le Examination
        public ActionResult GetAnimalHistory(int petId)
        {
            var animal = db.Pets.Include(p => p.Examinations).SingleOrDefault(p => p.Id == petId);
            if (animal == null)
            {
                return HttpNotFound();
            }

            return PartialView("_AnimalHistoryPartial", animal.Examinations.OrderByDescending(e => e.ExaminationDate));
        }
    }
}