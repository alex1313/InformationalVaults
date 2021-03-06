﻿namespace DomainModel.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class VaultAccessLog : IEntity
    {
        public VaultAccessLog(int userId, int vaultId, bool isAccessDenied)
        {
            UserId = userId;
            VaultId = vaultId;
            IsAccessDenied = isAccessDenied;
            DateTimeStamp = DateTime.Now;
        }

        [Obsolete("Only for ORM")]
        public VaultAccessLog()
        {
        }

        [Display(Name = "Date time stamp")]
        public DateTime DateTimeStamp { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int VaultId { get; set; }
        public virtual Vault Vault { get; set; }

        [Display(Name = "Access was denied")]
        public bool IsAccessDenied { get; set; }

        public int Id { get; set; }
    }
}