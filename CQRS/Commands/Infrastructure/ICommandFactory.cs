namespace CQRS.Commands.Infrastructure
{
    public interface ICommandFactory
    {
        ICommand<TCommandContext> Create<TCommandContext>()
            where TCommandContext : class, ICommandContext;
    }
}