using System;
using System.Collections.Generic;
namespace KvitkouNet.Logic.Common.Models.User
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IList<Address> Adress { get; set; }
        public string SecretQuestion { get; set; }
        public string SecretAnswer { get; set; }
        public IList<string> Mobile { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsDelete { get; set; }
        public bool IsVerified { get; set; }
        public UserGroup UserGroup { get; set; }
        public string UserRole { get; set; }
        public string UserSettings { get; set; }
        public IList<string> Tickets { get; set; }
        public IList<string> CreditCards { get; set; }
    }
}
