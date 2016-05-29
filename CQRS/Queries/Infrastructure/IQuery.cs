namespace CQRS.Queries.Infrastructure
{
    public interface IQuery<in TCriterion, out TResult>
        where TCriterion : class, ICriterion
    {
        TResult Execute(TCriterion criterion);
    }
}