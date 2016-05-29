namespace CQRS.Queries.Infrastructure
{
    using DataAccess.UnitOfWork;

    public abstract class QueryBase<TCriterion, TResult> : IQuery<TCriterion, TResult>
        where TCriterion : class, ICriterion
    {
        public IUnitOfWorkFactory UnitOfWorkFactory { get; set; }

        public abstract TResult Execute(TCriterion criterion);
    }
}