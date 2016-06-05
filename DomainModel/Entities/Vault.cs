namespace DomainModel.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Vault : IEntity
    {
        public Vault(string name, string description, TimeSpan? openTime = null, TimeSpan? closeTime = null)
        {
            Name = name;
            Description = description;
            OpenTime = openTime;
            CloseTime = closeTime;
            Users = new List<User>();
            VaultAccessLogs = new List<VaultAccessLog>();
        }

        [Obsolete("Only for ORM")]
        public Vault()
        {
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public TimeSpan? OpenTime { get; set; }
        public TimeSpan? CloseTime { get; set; }

        public int? AdminId { get; set; }
        public virtual User Admin { get; set; }

        public virtual List<User> Users { get; set; }

        public virtual List<VaultAccessLog> VaultAccessLogs { get; set; }

        public int Id { get; set; }
    }
}