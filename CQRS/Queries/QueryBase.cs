namespace CQRS.Queries
{
    using DataAccess.UnitOfWork;
    using Infrastructure;

    public abstract class QueryBase<TCriterion, TResult> : IQuery<TCriterion, TResult>
        where TCriterion : class, ICriterion
    {
        public IUnitOfWorkFactory UnitOfWorkFactory { get; set; }

        public abstract TResult Execute(TCriterion criterion);
    }
}