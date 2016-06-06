namespace CQRS.Queries
{
    using System.Linq;
    using System.Web.Mvc;
    using Criteria;
    using DomainModel.ViewModels;

    public class GetUsersRolesViewModel : QueryBase<EmptyCriterion, UsersRolesViewModel[]>
    {
        public override UsersRolesViewModel[] Execute(EmptyCriterion criterion)
        {
            using (var uow = UnitOfWorkFactory.Create())
            {
                var users = uow.UserRepository.GetAll();
                var roles = uow.RoleRepository.GetAll();

                return users.Select(u => new UsersRolesViewModel
                {
                    Id = u.Id,
                    Name = u.Email,
                    Role = roles.Select(r => new SelectListItem
                    {
                        Text = r.Name,
                        Value = r.Id.ToString(),
                        Selected = r.Id == u.RoleId
                    })
                    .ToArray()
                })
                .ToArray();
            }
        }
    }
}