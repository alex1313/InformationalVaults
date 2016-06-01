namespace CQRS.Commands
{
    using DataAccess.UnitOfWork;
    using Infrastructure;
    using Queries.Infrastructure;

    public abstract class CommandBase<TCommandContext> : ICommand<TCommandContext> where TCommandContext : class, ICommandContext
    {
        public IUnitOfWorkFactory UnitOfWorkFactory { get; set; }

        public IQueryBuilder Query { get; set; }

        public abstract void Execute(TCommandContext context);
    }
}