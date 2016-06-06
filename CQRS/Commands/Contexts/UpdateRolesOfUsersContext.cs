namespace CQRS.Commands.Contexts
{
    using DomainModel.ViewModels;
    using Infrastructure;

    public class UpdateRolesOfUsersContext : ICommandContext
    {
        public UpdateRolesOfUsersContext(UsersRolesViewModel[] usersRolesViewModels)
        {
            UsersRolesViewModels = usersRolesViewModels;
        }

        public UsersRolesViewModel[] UsersRolesViewModels { get; set; }
    }
}