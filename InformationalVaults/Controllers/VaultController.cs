namespace InformationalVaults.Controllers
{
    using System.Web.Mvc;
    using CQRS.Queries.Criteria;
    using DataAccess.UnitOfWork;
    using DomainModel.Entities;

    [Authorize]
    public class VaultController : BaseController
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public VaultController(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public ActionResult Index()
        {
            var vaults = QueryBuilder.ResultingIn<Vault[]>()
                .Execute(new EmptyCriterion());

            return View(vaults);
        }

        public ActionResult Details(int id)
        {
            var vault = QueryBuilder.ResultingIn<Vault>()
                .Execute(new IdCriterion(id));

            return vault != null
                ? View(vault)
                : View("Index");
        }
    }
}