namespace DomainModel.Entities
{
    using System;
    using System.Collections.Generic;

    public class Role : IEntity
    {
        [Obsolete("Only for ORM")]
        public Role()
        {
        }

        public Role(string name)
        {
            Name = name;
            Users = new List<User>();
        }

        public string Name { get; set; }

        public List<User> Users { get; set; }

        public int Id { get; set; }
    }
}