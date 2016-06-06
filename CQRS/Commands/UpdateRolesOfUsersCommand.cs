namespace CQRS.Commands
{
    using Contexts;

    public class UpdateRolesOfUsersCommand : CommandBase<UpdateRolesOfUsersContext>
    {
        public override void Execute(UpdateRolesOfUsersContext context)
        {
            using (var uow = UnitOfWorkFactory.Create())
            {
                foreach (var viewModel in context.UsersRolesViewModels)
                {
                    var user = uow.UserRepository.GetById(viewModel.Id);
                    //TODO: add logging
                    if (user == null || user.RoleId == viewModel.RoleId)
                        continue;

                    user.RoleId = viewModel.RoleId;

                    uow.UserRepository.Update(user);
                    uow.Commit();
                }
            }
        }
    }
}