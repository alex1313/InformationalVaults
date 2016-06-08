namespace DomainModel.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class VaultViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Display(Name = "Admin name")]
        public string AdminEmail { get; set; }

        public bool IsCurrentUserVaultAdmin { get; set; }
        public bool HasAccessLogs { get; set; }
    }
}