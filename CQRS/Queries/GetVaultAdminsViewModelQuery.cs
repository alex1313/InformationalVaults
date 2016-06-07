namespace CQRS.Queries
{
    using System.Linq;
    using System.Web.Mvc;
    using Criteria;
    using DomainModel.ViewModels;

    public class GetVaultAdminsViewModelQuery : QueryBase<EmptyCriterion, VaultAdminsViewModel[]>
    {
        public override VaultAdminsViewModel[] Execute(EmptyCriterion criterion)
        {
            using (var uow = UnitOfWorkFactory.Create())
            {
                var vaults = uow.VaultRepository.GetAll()
                    .OrderBy(x => x.Id);

                var users = uow.UserRepository.GetAll();

                return vaults.Select(v => new VaultAdminsViewModel
                {
                    Id = v.Id,
                    Name = v.Name,
                    Users = users.Select(u => new SelectListItem
                    {
                        Text = u.Email,
                        Value = u.Id.ToString(),
                        Selected = v.AdminId == u.Id
                    })
                    .ToArray()
                })
                .ToArray();
            }
        }
    }
}