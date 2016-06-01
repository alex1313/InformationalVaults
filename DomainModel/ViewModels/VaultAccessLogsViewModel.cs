namespace DomainModel.ViewModels
{
    using System;

    public class VaultAccessLogsViewModel
    {
        public DateTime DateTimeStamp { get; set; }
        public string UserName { get; set; }
        public string VaultName { get; set; }
        public bool IsAccessDenied { get; set; }
    }
}