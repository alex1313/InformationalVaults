namespace CQRS.Commands.Infrastructure
{
    public interface ICommand<in TCommandContext>
        where TCommandContext : class, ICommandContext
    {
        void Execute(TCommandContext context);
    }
}