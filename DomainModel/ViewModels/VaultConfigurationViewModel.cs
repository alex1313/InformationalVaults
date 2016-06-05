namespace DomainModel.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class VaultConfigurationViewModel
    {
        private const string TimeFormat = "{0:hh\\:mm}";

        [Required]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = TimeFormat, ApplyFormatInEditMode = true)]
        public TimeSpan? OpenTime { get; set; }

        [DisplayFormat(DataFormatString = TimeFormat, ApplyFormatInEditMode = true)]
        public TimeSpan? CloseTime { get; set; }

        public List<int> Users { get; set; }
    }
}