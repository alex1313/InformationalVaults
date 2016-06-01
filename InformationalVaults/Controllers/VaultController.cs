namespace InformationalVaults.Controllers
{
    using System.Web.Mvc;
    using CQRS.Commands;
    using CQRS.Commands.Contexts;
    using CQRS.Queries.Criteria;
    using DataAccess.UnitOfWork;
    using DomainModel.Entities;
    using Models;

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

            if (vault == null)
                View("Index");

            var currentUser = QueryBuilder.ResultingIn<User>()
                .Execute(new NameCriterion(User.Identity.Name));

            CommandBuilder.Execute(new AddVaultAccessLogContext(currentUser.Id, id));

            return View(vault);
        }
    }
}