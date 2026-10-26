using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem
{
    internal class Library
    {


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
                        // Implement login functionality here
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

    }
}
