using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagementSystem.Enum;
namespace LibraryManagementSystem.UI
{
    internal class AdminMenu : LibrarianMenu
    {
        public Account acc;
        public AdminMenu(Account acc, List<LibraryItem> items, List<Account> accounts):base(acc,items,accounts)
        {
            this.acc = acc;
        }

        public void Run()
        {
            Console.WriteLine($"Welcome, {acc.Username}!");
            int choice;
            do
            {
                Console.WriteLine("Admin Menu:");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Update Item");
                Console.WriteLine("3. Browse Library");
                Console.WriteLine("4. Search for Items");
                Console.WriteLine("5. View Members");
                Console.WriteLine("6. Add New Member");
                Console.WriteLine("7. Search for Member");
                Console.WriteLine("8. Update Member");
                Console.WriteLine("9. Most Loaned Items");
                Console.WriteLine("10. Add New Librarian");
                Console.WriteLine("11. Logout");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Add Item selected.");
                        AddItem();
                        break;
                    case 2:
                        Console.WriteLine("Update Item selected.");
                        ItemUpdate();
                        break;
                    case 3:
                        Console.WriteLine("Browse Library selected.");
                        Browse();
                        break;
                    case 4:
                        Console.WriteLine("Search for Items selected.");
                        SearchItem();
                        break;
                    case 5:
                        Console.WriteLine("View Members :");
                        ViewMembers();
                        break;
                    case 6:
                        Console.WriteLine("Add New Member selected.");
                        Register();
                        break;
                    case 7:
                        Console.WriteLine("Search for Member selected.");
                        SearchMember();
                        break;
                    case 8:
                        Console.WriteLine("Upadte Member selected.");
                        UpdateMember();
                        break;
                    case 9:
                        Console.WriteLine("Most Loaned Items selected.");
                        MostLoanded();

                        break;
                    case 10:
                        Console.WriteLine("Add New Librarian selected.");
                        RegisterLibrarian();

                        break;
                    case 11:
                        Console.WriteLine("Logging out. Goodbye!");

                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != 9);
        }

        public void RegisterLibrarian()
        {
            string name, password, phoneNumber, email;
            Console.WriteLine("Enter the name:");
            name = Console.ReadLine();
            Console.WriteLine("Enter the password:");
            password = Console.ReadLine();
            Console.WriteLine("Enter the phone number:");
            phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter the email:");
            email = Console.ReadLine();

            accounts.Add(new Librarian(name, password, phoneNumber, email , AccountRoleEnum.Librarian));

            Console.WriteLine("Registration successful!");
        }


    }
}
