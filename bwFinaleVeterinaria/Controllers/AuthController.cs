using bwFinaleVeterinaria.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;


namespace bwFinaleVeterinaria.Controllers
{
    public class AuthController : Controller
    {
        private VeterinariaDbContext db = new VeterinariaDbContext();


        [HttpPost]
        public ActionResult Login(HomeView utente)
        {
            if (ModelState.IsValid)
            {
                var user = db.Employees.Where(u => u.Username == utente.Employee.Username && u.Password == utente.Employee.Password).FirstOrDefault();

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Id.ToString(), true);

                    if (user.RoleId == 1)
                    {
                        return RedirectToAction("Index", "Doctor");
                    }
                    else if (user.RoleId == 2)
                    {
                        return RedirectToAction("ProductsList", "Pharmacist");
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Ruolo non autorizzato.";
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Username o password non validi.";
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "Home", utente);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}