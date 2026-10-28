using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagementSystem.Enum;
namespace LibraryManagementSystem.Models
{
    internal class Admin : Librarian
    {
        #region Constructors
        public Admin(string username, string password, string phoneNumber, string email, AccountRoleEnum role) : base(username, password, phoneNumber, email, role)
        {

        }
        #endregion
        #region Methods
        public override void DisplayAccountInfo()
        {
            Console.WriteLine($"Admin ID: {Id}");
            Console.WriteLine($"Username: {Username}");
            Console.WriteLine($"Phone Number: {PhoneNumber}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Role: {Role}");
        }
        #endregion
    }
}
