namespace CQRS.Commands.Infrastructure
{
    public interface ICommandBuilder
    {
        void Execute<TCommandContext>(TCommandContext context)
            where TCommandContext : class, ICommandContext;
    }
}