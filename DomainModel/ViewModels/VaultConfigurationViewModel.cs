namespace DomainModel.ViewModels
{
    using System.Collections.Generic;

    public class VaultConfigurationViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<int> Users { get; set; }
    }
}