namespace CQRS.Queries.Criteria
{
    using Infrastructure;

    public class IdCriterion : ICriterion
    {
        public IdCriterion(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}