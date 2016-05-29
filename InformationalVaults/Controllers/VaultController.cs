using System.Linq;
using System.Web.Mvc;

namespace InformationalVaults.Controllers
{
    using DataAccess;

    [Authorize]
    public class VaultController : Controller
    {
        //TODO: Unit of Work
        private readonly InformationalVaultsContext _db = new InformationalVaultsContext();

        public ActionResult Index()
        {
            var allVaults = _db.Vaults.AsEnumerable();

            return View(allVaults);
        }

        public ActionResult Details(int id)
        {
            var vault = _db.Vaults.FirstOrDefault(x => x.Id == id);

            return vault != null
                ? View(vault)
                : View("Error");
        }
    }
}
