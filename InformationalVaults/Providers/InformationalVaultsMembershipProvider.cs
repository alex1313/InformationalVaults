namespace InformationalVaults.Providers
{
    using System;
    using System.Linq;
    using System.Web.Helpers;
    using System.Web.Security;
    using DataAccess;
    using DomainModel.Entities;

    public class InformationalVaultsMembershipProvider : MembershipProvider
    {
        public override string ApplicationName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override bool ValidateUser(string username, string password)
        {
            var isValid = false;

            using (var db = new InformationalVaultsContext())
            {
                try
                {
                    var user = db.Users
                        .FirstOrDefault(x => x.Email == username);

                    if (user != null && Crypto.VerifyHashedPassword(user.Password, password))
                        isValid = true;
                }
                catch (Exception e)
                {
                    isValid = false;
                }
            }
            return isValid;
        }

        public MembershipUser CreateUser(string email, string password)
        {
            var membershipUser = GetUser(email, false);

            if (membershipUser != null)
                return null;

            try
            {
                using (var db = new InformationalVaultsContext())
                {
                    var user = new User
                    {
                        Email = email,
                        Password = Crypto.HashPassword(password)
                    };

                    var role = db.Roles.Find(2);
                    if (role != null)
                    {
                        user.RoleId = 2;
                    }

                    db.Users.Add(user);
                    db.SaveChanges();
                    membershipUser = GetUser(email, false);
                    return membershipUser;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public override MembershipUser GetUser(string email, bool userIsOnline)
        {
            try
            {
                using (var db = new InformationalVaultsContext())
                {
                    var users = db.Users
                        .Where(x => x.Email == email);

                    if (users.Any())
                    {
                        var user = users.First();
                        var memberUser = new MembershipUser("MyMembershipProvider", user.Email, null, null, null, null,
                            false, false, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue,
                            DateTime.MinValue);
                        return memberUser;
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }
            return null;
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password,
            string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email,
            string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey,
            out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize,
            out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize,
            out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }
    }
}