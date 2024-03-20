using System.Web.Mvc;
using bwFinaleVeterinaria.Models;
using System.Web.Security;
using System.Linq;
using static System.Web.Razor.Parser.SyntaxConstants;


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
                        return RedirectToAction("Index","Doctor");
                    }
                    else if (user.RoleId == 2)
                    {
                        return RedirectToAction("Index", "Pharmacist");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Ruolo non autorizzato.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Username o password non validi.");
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
