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

        public VaultController(ISendAlertService sendAlertService)
        {
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

        public ActionResult Details(int vaultId)
        {
            var vaultViewModel = QueryBuilder.ResultingIn<VaultViewModel>()
                .Execute(new IdCriterion(vaultId));

            if (vaultViewModel == null)
                return RedirectToAction("Index");

            var currentUser = QueryBuilder.ResultingIn<User>()
                .Execute(new NameCriterion(User.Identity.Name));

            var addVaultAccessLogContext = new AddVaultAccessLogContext(currentUser.Id, vaultId);
            CommandBuilder.Execute(addVaultAccessLogContext);

            if (addVaultAccessLogContext.CreatedVaultAccessLog.IsAccessDenied)
                _sendAlertService.CreateAndSendAccessDeniedAlert(addVaultAccessLogContext.CreatedVaultAccessLog, vaultViewModel.AdminEmail);

            return View(vaultViewModel);
        }

        public ActionResult Configure(int vaultId)
        {
            var vaultConfigurationViewModel = QueryBuilder
                .ResultingIn<VaultConfigurationViewModel>()
                .Execute(new IdCriterion(vaultId));

            return View(vaultConfigurationViewModel);
        }

        [HttpPost]
        public ActionResult Configure(VaultConfigurationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                CommandBuilder.Execute(new UpdateVaultConfigurationContext(viewModel));

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        public ActionResult AccessLogs(int vaultId)
        {
            var vaultAccessLogViewModels = QueryBuilder
                .ResultingIn<VaultAccessLogViewModel[]>()
                .Execute(new GetVaultAccessLogViewModelsForLastDayContext(vaultId));

            return View(vaultAccessLogViewModels);
        }

        public ActionResult VaultAdmins()
        {
            var usersRolesViewModel = QueryBuilder
                .ResultingIn<VaultAdminsViewModel[]>()
                .Execute(new EmptyCriterion());

            return View(usersRolesViewModel);
        }

        [HttpPost]
        [Authorize(Roles=RoleNames.Administrator)]
        public ActionResult VaultAdmins(VaultAdminsViewModel[] viewModel)
        {
            CommandBuilder.Execute(new UpdateAdminsOfVaultsContext(viewModel));

            return RedirectToAction("Index", "Vault");
        }
    }
}