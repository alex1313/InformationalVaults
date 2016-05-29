namespace CQRS.Queries.Infrastructure
{
    public interface IQueryFactory
    {
        IQuery<TCriterion, TResult> Create<TCriterion, TResult>()
            where TCriterion : class, ICriterion;
    }
}