using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagementSystem.Enum;
using System.Data;
namespace LibraryManagementSystem.UI
{
    internal class LibrarianMenu
    {
        public Account acc;

        public List<LibraryItem> items = new List<LibraryItem>();

        public LibrarianMenu(Account acc , List<LibraryItem> items)
        {
            this.acc = acc;
            this.items = items;
        }
        public void Run()
        {   Console.WriteLine($"Welcome, {acc.Username}!");
            int choice;
            do
            {
                Console.WriteLine("Librarian Menu:");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Update Item");
                Console.WriteLine("3. Update Item");
                Console.WriteLine("4. View All Items");
                Console.WriteLine("5. Logout");
                choice = int.Parse(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        Console.WriteLine("Add Item selected.");
                        AddItem();
                        break;
                    case 2:
                        Console.WriteLine("Update Item selected.");
                        Update();
                        break;
                    case 3:
                        Console.WriteLine("Update Item selected.");
                        // Implement update item functionality here
                        break;
                    case 4:
                        Console.WriteLine("View All Items selected.");
                        // Implement view all items functionality here
                        break;
                    case 5:
                        Console.WriteLine("Logging out. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice < 1 || choice > 5);
        }

        private void Update()
        {
            throw new NotImplementedException();
        }

        private void AddItem()
        {
            Console.WriteLine("Enter the title of the item:");
            string title = Console.ReadLine();
            Console.WriteLine("Enter the period of the item:");
            int period = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the fee per day for the item:");
            int feePerDay = int.Parse(Console.ReadLine());
            Console.WriteLine("Choose the type of the item :");
            Console.WriteLine("1. Book");
            Console.WriteLine("2. Magazine");
            Console.WriteLine("3. Research Paper");
            Console.WriteLine("4. Back to Main Menu");
            int type ;
            do
            {
                type = int.Parse(Console.ReadLine());
                switch (type)
                {
                    case 1:
                        Console.WriteLine("Enter the author of the book:");
                        string author = Console.ReadLine();

                        Console.WriteLine("Enter the page count of the book:");
                        int pageCount;
                        do { 
                            pageCount = int.Parse(Console.ReadLine());
                            if(pageCount < 1)
                            {
                                Console.WriteLine("Page count must be a positive integer. Please try again.");
                            }

                        } while(pageCount < 1);
                        
                        items.Add(new Book(title, ItemStatusEnum.Available, ItemTypeEnum.Book, author, pageCount));                  
                        break;
                    case 2:
                        Console.WriteLine("Enter the issue number of the magazine:");
                        int issueNumber;
                        do
                        {
                            issueNumber = int.Parse(Console.ReadLine());
                            if (issueNumber < 1)
                            {
                                Console.WriteLine("Issue number must be a positive integer. Please try again.");
                            }
                        } while (issueNumber < 1);
                        items.Add(new Magazine(title, ItemStatusEnum.Available, ItemTypeEnum.Magazine, issueNumber));
                        break;
                    case 3:
                        Console.WriteLine("Enter the name of the researcher:");
                        string researcherName = Console.ReadLine();
                        Console.WriteLine("Enter the research field:");
                        string researchField = Console.ReadLine();
                        items.Add(new ResearchPaper(title, ItemStatusEnum.Available, ItemTypeEnum.ResearchPaper, researcherName, researchField));
                        break;
                    case 4:
                        Console.WriteLine("Returning to Main Menu.");
                        break;
                    default:
                        Console.WriteLine("Invalid item type.");
                        break;
                }
            } while (type < 1 || type > 4);
            if(type != 4)
            {
                Console.WriteLine("Item added successfully.");
            }
        }
    }
}
