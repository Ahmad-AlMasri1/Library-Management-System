using LibraryManagementSystem;
using LibraryManagementSystem.Enum;
using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace LibraryManagementSystem.UI
{
    internal class LibrarianMenu
    {
        public Account acc;

        public List<LibraryItem> items = new List<LibraryItem>();

        public List<Account> accounts = new List<Account>();

        public LibrarianMenu(Account acc , List<LibraryItem> items , List<Account> accounts)


        {
            this.acc = acc;
            this.items = items;
            this.accounts = accounts;
        }
        public void Run()
        {   Console.WriteLine($"Welcome, {acc.Username}!");
            int choice;
            do
            {
                Console.WriteLine("Librarian Menu:");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Update Item");
                Console.WriteLine("3. Browse Library");
                Console.WriteLine("4. Search for Items");
                Console.WriteLine("5. View Members");
                Console.WriteLine("6. Add New Member");
                Console.WriteLine("7. Search for Member");
                Console.WriteLine("8. Update Member");
                Console.WriteLine("9. Most Loaned Items");
                Console.WriteLine("10. Logout");
                choice = int.Parse(Console.ReadLine());
                switch(choice)
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
                        Console.WriteLine("Logging out. Goodbye!");
                        
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != 9);
        }

        protected void MostLoanded()
        {
            var most = items.OrderByDescending(i => i.cnt).ToList();

            foreach(var item in most)
            {
                Console.WriteLine("====================");
                item.DisplayItemInfo();

            }
        }

        protected void UpdateMember()
        {
            Console.WriteLine("Enter Member ID :");
            int MemberNumber;
            do
            {
                MemberNumber = int.Parse(Console.ReadLine());
                if (MemberNumber < 0)
                {
                    Console.WriteLine("Invalid Member Number, Try Again:");
                }

            } while (MemberNumber < 0);
            bool flag = false;
            foreach (var account in accounts)
            {
                if (account.AccountId == MemberNumber && account is Member member)
                {
                    flag = true;
                    Console.WriteLine("Choose What Do You Want to change : ");
                    Console.WriteLine("1.MaximumLoanItems");
                    Console.WriteLine("2.The Member Status");
                    int choice;
                    do
                    {
                        choice = int.Parse(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("Enter The New Maximum Loan Items:");
                                int loan;
                                do
                                {
                                    loan = int.Parse(Console.ReadLine());
                                    if (loan < 1) Console.WriteLine("Invaled Number Please Try Again:");
                                } while (loan < 1);
                                member.MaximumLoanItems = loan;
                                break;
                            case 2:
                                Console.WriteLine("Enter The New Status:");
                                Console.WriteLine("1.Active.");
                                Console.WriteLine("2.InActive.");
                                int status;
                                do
                                {
                                    status = int.Parse(Console.ReadLine());
                                    if (status == 1)
                                    {
                                        member.Status = MemberStatusEnum.Active;
                                    }else if(status == 2)
                                    {
                                        member.Status = MemberStatusEnum.Active;
                                    }else
                                    {
                                        Console.WriteLine("Invalid Number, Try Again:");
                                    }
                                } while (status < 1 || status > 2);
                                break;
                                
                        }

                    } while (choice <1 || choice >2);
                }
            }

            if (!flag)
            {
                Console.WriteLine("No Member Found");
            }
        }

        protected void SearchMember()
        {
            int MemberNumber;
            Console.WriteLine("Enter the Member Number to search for:");
            do
            {
                MemberNumber = int.Parse(Console.ReadLine());
                if(MemberNumber < 0)
                {
                    Console.WriteLine("Invalid Member Number, Try Again:");
                }

            } while (MemberNumber < 0);
            bool flag = false;
            foreach(var account in accounts)
            {
                if(account.AccountId == MemberNumber && account.Role == AccountRoleEnum.Member)
                {
                    flag = true;
                    account.DisplayAccountInfo();
                }
            }

            if (!flag)
            {
                Console.WriteLine("No Member Found");
            }
        }

        protected void Register()
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

        protected void ViewMembers()
        {
            foreach (var account in accounts)
            {
                if (account is Member member)
                {
                    member.DisplayAccountInfo();
                }
            }
            return;
        }

        protected void SearchItem()
        {
            int choice;
            do
            {
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
                        if (items.Exists(i => i.Title == title && i.Status != ItemStatusEnum.CheckedOut))
                        {
                            LibraryItem foundItem = items.Find(i => i.Title == title);
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
                            LibraryItem foundItem = items.Find(i => i.Id == id);
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

                }
            } while (choice < 1 || choice > 3);
        }

        protected void Browse()
        {
            Console.WriteLine("Library Items:");
            foreach (var item in items)
            {
                    Console.WriteLine($"Title: {item.Title}, Status: {item.Status}, Type: {item.Type}");
            }
        }
        protected void ItemUpdate()
        {
            Console.WriteLine("Enter the ID of the item to update:");
            int id = int.Parse(Console.ReadLine());
            if (items.Exists(i => i.Id == id))
            {
                LibraryItem foundItem = items.Find(i => i.Id == id);
                int choice;
                do
                {
                    Console.WriteLine("What would you like to update:");
                    Console.WriteLine("1. Title");
                    Console.WriteLine("2. Status");
                    if (foundItem is Book)
                    {
                        Console.WriteLine("3. Author");
                        Console.WriteLine("4. Page Count");
                        Console.WriteLine("5. Back to Main Menu");
                    }
                    else if (foundItem is Magazine)
                    {
                        Console.WriteLine("3. Issue Number");
                        Console.WriteLine("4. Back to Main Menu");
                    }
                    else if (foundItem is ResearchPaper)
                    {
                        Console.WriteLine("3. Researcher Name");
                        Console.WriteLine("4. Research Field");
                        Console.WriteLine("5. Back to Main Menu");
                    }
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter the new title:");
                            foundItem.Title = Console.ReadLine();
                            Console.WriteLine("Title updated successfully.");
                            break;
                        case 2:
                            Console.WriteLine("Choose the new status:");
                            Console.WriteLine("1. Available");
                            Console.WriteLine("2. Checked Out");
                            Console.WriteLine("3. Reserved");
                            int statusChoice = int.Parse(Console.ReadLine());
                            do
                            {
                                switch (statusChoice)
                                {
                                    case 1:
                                        foundItem.Status = ItemStatusEnum.Available;
                                        break;
                                    case 2:
                                        foundItem.Status = ItemStatusEnum.CheckedOut;
                                        break;
                                    case 3:
                                        foundItem.Status = ItemStatusEnum.Reserved;
                                        break;
                                    default:
                                        Console.WriteLine("Invalid status choice. Try again.");
                                        break;
                                }

                            } while (statusChoice < 1 || statusChoice > 3);
                            break;
                        case 3:
                            if (foundItem is Book book)
                            {
                                Console.WriteLine("Enter the new author:");
                                book.Author = Console.ReadLine();
                                Console.WriteLine("Author updated successfully.");
                            }
                            else if (foundItem is Magazine magazine)
                            {
                                Console.WriteLine("Enter the new issue number:");
                                int newIssueNumber;
                                do
                                {
                                    newIssueNumber = int.Parse(Console.ReadLine());
                                    if (newIssueNumber < 1)
                                    {
                                        Console.WriteLine("Issue number must be a positive integer. Please try again.");
                                    }
                                } while (newIssueNumber < 1);
                                magazine.IssueNumber = newIssueNumber;
                                Console.WriteLine("Issue number updated successfully.");
                            }
                            else if (foundItem is ResearchPaper researchPaper)
                            {
                                Console.WriteLine("Enter the new researcher name:");
                                researchPaper.ResearcherName = Console.ReadLine();
                                Console.WriteLine("Researcher name updated successfully.");
                            }
                            break;
                        case 4:
                            if (foundItem is Book book2)
                            {
                                Console.WriteLine("Enter the new page count:");
                                int newPageCount;
                                do
                                {
                                    newPageCount = int.Parse(Console.ReadLine());
                                    if (newPageCount < 1)
                                    {
                                        Console.WriteLine("Page count must be a positive integer. Please try again.");
                                    }
                                } while (newPageCount < 1);
                                book2.PageCount = newPageCount;
                                Console.WriteLine("Page count updated successfully.");
                            }
                            else if (foundItem is ResearchPaper researchPaper2)
                            {
                                Console.WriteLine("Enter the new research field:");
                                researchPaper2.ResearchField = Console.ReadLine();
                                Console.WriteLine("Research field updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Returning  to Main Menu");
                            }
                            break;

                        case 5:
                            if (foundItem is Book || foundItem is ResearchPaper)
                            {
                                Console.WriteLine("Returning to Main Menu.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid choice. Please try again.");
                            }
                            break;

                    }

                } while (((foundItem.Type == ItemTypeEnum.Book || foundItem.Type == ItemTypeEnum.ResearchPaper) && (choice > 5 || choice < 1)) || ((foundItem.Type == ItemTypeEnum.Magazine) && (choice > 4 || choice < 1)));
                }
                 else
            {
                Console.WriteLine("Item not found.");
            }
        }

        protected void AddItem()
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
