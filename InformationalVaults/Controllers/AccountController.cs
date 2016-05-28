namespace InformationalVaults.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using DataAccess;
    using Models;

    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            using (var db = new InformationalVaultsContext())
            {
                var users = db.Users.ToList();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Login(LogOnViewModel viewModel, string returnUrl)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}