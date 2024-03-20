using bwFinaleVeterinaria.Models;
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
    }
}