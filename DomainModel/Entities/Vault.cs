namespace DomainModel.Entities
{
    using System.Collections.Generic;

    public class Vault : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}