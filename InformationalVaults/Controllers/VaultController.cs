using System.Web.Mvc;

namespace InformationalVaults.Controllers
{
    using System.Linq;
    using DataAccess.UnitOfWork;

    [Authorize]
    public class VaultController : Controller
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public VaultController(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public ActionResult Index()
        {
            using (var uow = _unitOfWorkFactory.Create())
            {
                var allVaults = uow.VaultRepository
                    .GetAll()
                    .ToArray();

                return View(allVaults);
            }
        }

        public ActionResult Details(int id)
        {
            using (var uow = _unitOfWorkFactory.Create())
            {
                var vault = uow.VaultRepository.GetById(id);

                return vault != null
                    ? View(vault)
                    : View("Error");
            }
        }
    }
}
