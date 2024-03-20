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
        public ActionResult Login(Employee model)
        {
            if (ModelState.IsValid)
            {
                var user = db.Employees.Where(u => u.Username == model.Username && u.Password == model.Password).FirstOrDefault();

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Id.ToString(), true);

                    if (user.RoleId == 1)
                    {
                        return RedirectToAction("Contact","Home");
                    }
                    else if (user.RoleId == 2)
                    {
                        return RedirectToAction("About", "Home");
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
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
