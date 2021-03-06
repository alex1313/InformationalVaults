﻿namespace DomainModel.ViewModels
{
    using System.Web.Mvc;

    public class UsersRolesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RoleId { get; set; }
        public SelectListItem[] Roles { get; set; }
    }
}