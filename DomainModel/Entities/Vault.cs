namespace DomainModel.Entities
{
    using System;
    using System.Collections.Generic;

    public class Vault : IEntity
    {
        public Vault(string name, string description)
        {
            Name = name;
            Description = description;
            Users = new List<User>();
            VaultAccessLogs = new List<VaultAccessLog>();
        }

        [Obsolete("Only for ORM")]
        public Vault()
        {
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<User> Users { get; set; }

        public virtual List<VaultAccessLog> VaultAccessLogs { get; set; }

        public int Id { get; set; }
    }
}