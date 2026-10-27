using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Models
{
    internal class Account
    {
        #region Attributes
            public int Id { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            
            public string PhoneNumber { get; set; }

            public string Email { get; set; }

            public DateOnly DOB { get; set; }

        #endregion

        #region Constructors
        public Account()
        {
            Id = 0;
            Username = string.Empty;
            Password = string.Empty;
            PhoneNumber = string.Empty;
            Email = string.Empty;
            DOB = DateOnly.MinValue;
        }
        public Account(int id, string username, string password, string phoneNumber, string email, DateOnly dob)
        {
            Id = id;
            Username = username;
            Password = password;
            PhoneNumber = phoneNumber;
            Email = email;
            DOB = dob;
        }
        #endregion

        #region Methods

        public bool CheckPassword(string password) => Password == password;
        

        #endregion
    }
}
