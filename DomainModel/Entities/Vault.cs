namespace DomainModel.Entities
{
    public class Vault : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}