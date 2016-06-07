namespace DomainModel.ViewModels
{
    using System.Web.Mvc;

    public class VaultAdminsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AdminId { get; set; }
        public SelectListItem[] Users { get; set; }
    }
}