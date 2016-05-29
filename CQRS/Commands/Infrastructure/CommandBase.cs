namespace CQRS.Commands.Infrastructure
{
    using DataAccess.UnitOfWork;

    public abstract class CommandBase<TCommandContext> : ICommand<TCommandContext> where TCommandContext : class, ICommandContext
    {
        public IUnitOfWorkFactory UnitOfWorkFactory { get; set; }

        public abstract void Execute(TCommandContext context);
    }
}