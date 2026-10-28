using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Enum;
using LibraryManagementSystem.UI;
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
            items.Add(new ResearchPaper("Quantum Computing: An Overview", ItemStatusEnum.CheckedOut, ItemTypeEnum.ResearchPaper, "John Doe", "Computer Science"));
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
                        Register();
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
                        Console.WriteLine("Exiting the system. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while(choice!=5);
            

        }

        private void SearchItem()
        {
            int choice;
            do { 
            Console.WriteLine("Search for Items by:");
            Console.WriteLine("1. Title");
            Console.WriteLine("2. Item ID");
            Console.WriteLine("3. Back to Main Menu");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the title to search for:");
                    string title = Console.ReadLine();
                    if(items.Exists(i=>i.Title == title && i.Status != ItemStatusEnum.CheckedOut))
                    {   
                        LibraryItem foundItem = items.Find(i=>i.Title == title);
                        foundItem.DisplayItemInfo();
                    }
                    else
                    {
                        Console.WriteLine("Item not found.");
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter the Item ID to search for:");
                    int id = int.Parse(Console.ReadLine());
                    if (items.Exists(i => i.Id == id && i.Status != ItemStatusEnum.CheckedOut))
                    {
                        LibraryItem foundItem = items.Find(i => i.Id == id );
                        foundItem.DisplayItemInfo();
                    }
                    else
                    {
                        Console.WriteLine("Item not found.");
                    }
                    break;
                case 3:
                        Console.WriteLine("Returning to Main Menu.");
                        break;
                default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;

            }}while(choice<1 || choice>3);
        }

        private void Browse()
        {
            Console.WriteLine("Library Items:");
            foreach (var item in items)
            {   
                if (item.Status != ItemStatusEnum.CheckedOut)
                    Console.WriteLine($"Title: {item.Title}, Status: {item.Status}, Type: {item.Type}");
            }
        }

        private void Register()
        {
            string name, password, phoneNumber, email;
            Console.WriteLine("Enter your name:");
            name = Console.ReadLine();
            Console.WriteLine("Enter your password:");
            password = Console.ReadLine();
            Console.WriteLine("Enter your phone number:");
            phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter your email:");
            email = Console.ReadLine();

            accounts.Add(new Member(name, password, phoneNumber, email, 5));

            Console.WriteLine("Registration successful! You can now log in with your email and password.");
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
                   
                    LibrarianMenu LM = new LibrarianMenu(loggedInAccount , items);
                    LM.Run();
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
