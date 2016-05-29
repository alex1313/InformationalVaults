namespace InformationalVaults.Providers
{
    using System;
    using System.Linq;
    using System.Web.Security;
    using DataAccess;
    using DomainModel.Entities;

    public class InformationalVaultsRoleProvider : RoleProvider
    {
        public override string ApplicationName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override string[] GetRolesForUser(string email)
        {
            string[] role = {};
            using (var db = new InformationalVaultsContext())
            {
                try
                {
                    var user = db.Users
                        .FirstOrDefault(x => x.Email == email);

                    if (user != null)
                    {
                        var userRole = db.Roles.FirstOrDefault(x => x.Id == user.RoleId);

                        if (userRole != null)
                        {
                            role = new[] {userRole.Name};
                        }
                    }
                }
                catch
                {
                    role = new string[] {};
                }
            }
            return role;
        }

        public override void CreateRole(string roleName)
        {
            var newRole = new Role {Name = roleName};
            var db = new InformationalVaultsContext();
            db.Roles.Add(newRole);
            db.SaveChanges();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            var outputResult = false;
            using (var db = new InformationalVaultsContext())
            {
                try
                {
                    var user = db.Users
                        .FirstOrDefault(x => x.Email == username);

                    if (user != null)
                    {
                        var userRole = db.Roles.Find(user.RoleId);

                        if (userRole != null && userRole.Name == roleName)
                        {
                            outputResult = true;
                        }
                    }
                }
                catch
                {
                    outputResult = false;
                }
            }
            return outputResult;
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}