namespace CQRS.Queries.Infrastructure
{
    public interface IQueryBuilder
    {
        IQueryDescriptor<TResult> ResultingIn<TResult>();
    }
}