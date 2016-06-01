﻿namespace InformationalVaults.Controllers
{
    using System.Web.Mvc;
    using CQRS.Commands.Contexts;
    using CQRS.Queries.Criteria;
    using DomainModel.Entities;
    using DomainModel.ViewModels;

    [Authorize]
    public class VaultController : BaseController
    {
        public ActionResult Index()
        {
            var currentUser = QueryBuilder.ResultingIn<User>()
                .Execute(new NameCriterion(User.Identity.Name));

            var vaults = QueryBuilder.ResultingIn<VaultViewModel[]>()
                .Execute(new GetVaultViewModelsCriterion(currentUser.Id));

            return View(vaults);
        }

        public ActionResult Details(int vaultId)
        {
            var vault = QueryBuilder.ResultingIn<Vault>()
                .Execute(new IdCriterion(vaultId));

            if (vault == null)
                View("Index");

            var currentUser = QueryBuilder.ResultingIn<User>()
                .Execute(new NameCriterion(User.Identity.Name));

            CommandBuilder.Execute(new AddVaultAccessLogContext(currentUser.Id, vaultId));

            return View(vault);
        }

        public ActionResult AccessLogs(int vaultId)
        {
            var vaultAccessLogs = QueryBuilder
                .ResultingIn<VaultAccessLogsViewModel[]>()
                .Execute(new IdCriterion(vaultId));

            return View(vaultAccessLogs);
        }
    }
}