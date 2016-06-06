namespace InformationalVaults.Controllers
{
    using System.Web.Mvc;
    using CQRS.Commands.Contexts;
    using CQRS.Queries.Criteria;
    using DomainModel.Definitions;
    using DomainModel.ViewModels;

    [Authorize(Roles = RoleNames.Administrator)]
    public class RoleController : BaseController
    {
        public ActionResult Manage()
        {
            var usersRolesViewModel = QueryBuilder
                .ResultingIn<UsersRolesViewModel[]>()
                .Execute(new EmptyCriterion());

            return View(usersRolesViewModel);
        }

        [HttpPost]
        public ActionResult Manage(UsersRolesViewModel[] viewModel)
        {
            CommandBuilder.Execute(new UpdateRolesOfUsersContext(viewModel));

            return RedirectToAction("Index", "Vault");
        }
    }
}