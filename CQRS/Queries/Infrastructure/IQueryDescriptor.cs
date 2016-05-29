namespace CQRS.Queries.Infrastructure
{
    public interface IQueryDescriptor<out TResult>
    {
        TResult Execute<TCriterion>(TCriterion criterion)
            where TCriterion : class, ICriterion;
    }
}