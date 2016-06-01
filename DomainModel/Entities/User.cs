namespace DomainModel.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Web.Helpers;

    public class User : IEntity
    {
        [Obsolete("Only for ORM")]
        public User()
        {
        }

        public User(string email, string password, Role role)
        {
            Email = email;
            Password = Crypto.HashPassword(password);
            RoleId = role.Id;
            Vaults = new List<Vault>();
            VaultAccessLogs = new List<VaultAccessLog>();
        }

        public string Email { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        public virtual List<Vault> Vaults { get; set; }

        public List<VaultAccessLog> VaultAccessLogs { get; set; }

        public int Id { get; set; }
    }
}