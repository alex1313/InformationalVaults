namespace InformationalVaults.Controllers
{
    using System.Web.Mvc;
    using CQRS.Commands.Contexts;
    using CQRS.Queries.Criteria;
    using DomainModel.Definitions;
    using DomainModel.Entities;
    using DomainModel.ViewModels;
    using Services;

    [Authorize]
    public class VaultController : BaseController
    {
        private readonly ISendAlertService _sendAlertService;
        private readonly IVaultAccessService _vaultAccessService;

        public VaultController(IVaultAccessService vaultAccessService, ISendAlertService sendAlertService)
        {
            _vaultAccessService = vaultAccessService;
            _sendAlertService = sendAlertService;
        }

        public ActionResult Index()
        {
            var currentUser = QueryBuilder.ResultingIn<User>()
                .Execute(new NameCriterion(User.Identity.Name));

            var vaultViewModels = QueryBuilder.ResultingIn<VaultViewModel[]>()
                .Execute(new GetAllVaultViewModelsCriterion(currentUser));

            return View(vaultViewModels);
        }

        public ActionResult Details(int id)
        {
            var vaultViewModel = QueryBuilder.ResultingIn<VaultViewModel>()
                .Execute(new IdCriterion(id));

            if (vaultViewModel == null)
                return RedirectToAction("Index");

            var currentUser = QueryBuilder.ResultingIn<User>()
                .Execute(new NameCriterion(User.Identity.Name));

            var addVaultAccessLogContext = new AddVaultAccessLogContext(currentUser.Id, id);
            CommandBuilder.Execute(addVaultAccessLogContext);

            if (addVaultAccessLogContext.CreatedVaultAccessLog.IsAccessDenied)
            {
                _sendAlertService.CreateAndSendAccessDeniedAlert(addVaultAccessLogContext.CreatedVaultAccessLog, vaultViewModel.AdminEmail);

                return RedirectToAction("AccessDenied");
            }

            return View(vaultViewModel);
        }

        public ActionResult Configure(int id)
        {
            if (IsCurrentUserVaultAdmin(id) == false)
                return RedirectToAction("Index");

            var vaultConfigurationViewModel = QueryBuilder
                .ResultingIn<VaultConfigurationViewModel>()
                .Execute(new IdCriterion(id));

            return View(vaultConfigurationViewModel);
        }

        [HttpPost]
        public ActionResult Configure(VaultConfigurationViewModel viewModel)
        {
            if (IsCurrentUserVaultAdmin(viewModel.Id) == false)
                return RedirectToAction("Index");

            if (ModelState.IsValid)
            {
                CommandBuilder.Execute(new UpdateVaultConfigurationContext(viewModel));

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        public ActionResult AccessLogs(int id)
        {
            if (IsCurrentUserVaultAdmin(id) == false)
                return RedirectToAction("Index");

            var vaultAccessLogViewModels = QueryBuilder
                .ResultingIn<VaultAccessLogViewModel[]>()
                .Execute(new GetVaultAccessLogViewModelsForLastDayContext(id));

            return View(vaultAccessLogViewModels);
        }

        [Authorize(Roles = RoleNames.Administrator)]
        public ActionResult VaultAdmins()
        {
            var usersRolesViewModel = QueryBuilder
                .ResultingIn<VaultAdminsViewModel[]>()
                .Execute(new EmptyCriterion());

            return View(usersRolesViewModel);
        }

        [HttpPost]
        [Authorize(Roles = RoleNames.Administrator)]
        public ActionResult VaultAdmins(VaultAdminsViewModel[] viewModel)
        {
            CommandBuilder.Execute(new UpdateAdminsOfVaultsContext(viewModel));

            return RedirectToAction("Index", "Vault");
        }

        public ActionResult AccessDenied()
        {
            return View();
        }

        private bool IsCurrentUserVaultAdmin(int vaultId)
        {
            var currentUser = QueryBuilder.ResultingIn<User>()
                .Execute(new NameCriterion(User.Identity.Name));

            var vault = QueryBuilder.ResultingIn<Vault>()
                .Execute(new IdCriterion(vaultId));

            return _vaultAccessService.IsUserVaultAdmin(currentUser, vault);
        }
    }
}