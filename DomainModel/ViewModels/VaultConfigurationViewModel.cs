namespace DomainModel.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class VaultConfigurationViewModel
    {
        [Required]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Display(Name = "Open time")]
        public TimeSpan? OpenTime { get; set; }

        [Display(Name = "Close time")]
        public TimeSpan? CloseTime { get; set; }

        public List<int> Users { get; set; }
    }
}