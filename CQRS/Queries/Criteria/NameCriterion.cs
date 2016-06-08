namespace CQRS.Queries.Criteria
{
    using Infrastructure;

    public class NameCriterion : ICriterion
    {
        public NameCriterion(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}