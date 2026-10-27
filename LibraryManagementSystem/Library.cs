using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Enum;
namespace LibraryManagementSystem
{
    internal class Library
    {
        List<Account> accounts = new List<Account>();
        List<LibraryItem> items = new List<LibraryItem>();
        public Library()
        {
            accounts.Add(new Librarian("Ahmad", "1234", "1234567890", "ahmad@gmail.com", AccountRoleEnum.Librarian));
            items.Add(new Book("The Great Gatsby",ItemStatusEnum.Available,ItemTypeEnum.Book, "F. Scott Fitzgerald", 1925));
            items.Add(new Book("To Kill a Mockingbird",ItemStatusEnum.Available,ItemTypeEnum.Book, "Harper Lee", 1960));
            items.Add(new ResearchPaper("Quantum Computing: An Overview", ItemStatusEnum.Available, ItemTypeEnum.ResearchPaper, "John Doe", "Computer Science"));
            items.Add(new Magazine("National Geographic", ItemStatusEnum.Available, ItemTypeEnum.Magazine, 2));

        }

        public void Run()
        {
            Console.WriteLine("Welcome to the Library Management System!");
            Console.WriteLine("Please select an option:");
            int choice;
            do
            {
                
                Console.WriteLine("1.Login");
                Console.WriteLine("2. Register New Member");
                Console.WriteLine("3. Browse Library");
                Console.WriteLine("4. Search for Items");
                Console.WriteLine("5. Exit");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Login selected.");
                        Login();
                        break;
                    case 2:
                        Console.WriteLine("Register New Member selected.");
                        // Implement registration functionality here
                        break;
                    case 3:
                        Console.WriteLine("Browse Library selected.");
                        // Implement browsing functionality here
                        break;
                    case 4:
                        Console.WriteLine("Search for Items selected.");
                        // Implement search functionality here
                        break;
                    case 5:
                        Console.WriteLine("Exiting the system. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while(choice!=5);
            

        }

        private void Login()
        {
            Console.WriteLine("Enter your email:");
            string email = Console.ReadLine();
            Console.WriteLine("Enter your password:");
            string password = Console.ReadLine();

            if(accounts.Exists(a=> a.Email == email && a.Password == password))
            {
                Console.WriteLine("Login successful!");
                Account loggedInAccount = accounts.Find(a => a.Email == email && a.Password == password);
                if(loggedInAccount.Role == AccountRoleEnum.Librarian)
                {
                    Console.WriteLine("Welcome, Librarian!");
                    // Implement librarian functionalities here
                }
                else if (loggedInAccount.Role == AccountRoleEnum.Member)
                {
                    Console.WriteLine("Welcome, Member!");
                    // Implement member functionalities here
                }
            }
            else
            {
                Console.WriteLine("Invalid email or password.");
            }
        }
    }
}
