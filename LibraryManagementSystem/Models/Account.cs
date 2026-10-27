using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagementSystem.Enum;
namespace LibraryManagementSystem.Models
{
    internal abstract class Account
    {
        #region Attributes
            public static int Id { get; set; } = 0;
            public string Username { get; set; }
            public string Password { get; set; }
            
            public string PhoneNumber { get; set; }

            public string Email { get; set; }

            public  AccountRoleEnum Role { get; set; }

        #endregion

        #region Constructors

        public Account(string username, string password, string phoneNumber, string email)
        {
            Id = ++Id;
            Username = username;
            Password = password;
            PhoneNumber = phoneNumber;
            Email = email;
        }
        #endregion

        #region Methods

        public bool CheckPassword(string password) => Password == password;
        
        public abstract void DisplayAccountInfo();


        #endregion
    }
}
