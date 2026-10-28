using LibraryManagementSystem.Enum;
using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.UI
{
    internal class MemberMenu
    {
        List<LibraryItem> items = new List<LibraryItem>();
        Member member;
        
        public MemberMenu(Member member , List<LibraryItem> items)
        {
            this.member = member;
            this.items = items;
        }

        public void Run()
        {
            Console.WriteLine($"Welcome, {member.Username}!");
            int choice;
            do
            {
                Console.WriteLine("Member Menu:");
                Console.WriteLine("1. Browse Library");
                Console.WriteLine("2. Search For Items");
                Console.WriteLine("3. Display Member Info");
                Console.WriteLine("4. Loan Item");
                Console.WriteLine("5. Return Item");
                Console.WriteLine("6. Pay the fine");
                Console.WriteLine("7. Search for Member");
                Console.WriteLine("8. Update Member");
                Console.WriteLine("9. Logout");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Browse();
                        break;
                    case 2:
                        SearchItem();
                        break;
                    case 3:
                        member.DisplayAccountInfo();
                        break;
                    case 4:
                        LoanItem();
                        break;
                    case 5:
                        ReturnItem();
                        break;
                    case 6:
                        PayTheFine();
                        break;
                    case 7:
                        
                        break;
                    case 8:
                      

                        break;
                    case 9:
                        Console.WriteLine("Logging out. Goodbye!");

                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != 9);
        }

        private void PayTheFine()
        {   
            if(member.FeesOwed == 0)
            {
                Console.WriteLine("There is no fees owed to pay");
                return;
            }
            Console.WriteLine($"The Current Fine :{member.FeesOwed}");
            int owed = member.FeesOwed;
            Console.WriteLine("Enter the amount you want to pay :");
            int pay = int.Parse(Console.ReadLine());
            if (pay > owed)
            {
                member.FeesOwed = 0;
                Console.WriteLine($"Amount due after payment: {pay - owed}");
            }else if(pay == owed)
            {
                member.FeesOwed = 0;
                Console.WriteLine("The payment process was completed successfully.");
            }else if(pay < owed && pay > 0)
            {
                member.FeesOwed -=owed;
                Console.WriteLine("The payment process was completed successfully.");
                Console.WriteLine($"Fees left to pay : {member.FeesOwed}");
            }
            else
            {
                Console.WriteLine("Invalid Value");
            }
        }

        private void ReturnItem()
        {
            Console.WriteLine("Choose Item To Return by Id:");

            foreach(LibraryItem item in member.LoanedItems)
            {   
                Console.WriteLine("==========================");
                Console.WriteLine($"Item Id: {item.Id}");
                Console.WriteLine($"Item Title: {item.Title}");
                
            }
            Console.WriteLine("==========================");
            Console.WriteLine("Press -1 To Return To Main Menu");
            int choice;
            do
            {
                choice = int.Parse(Console.ReadLine());
                if(choice == -1)
                {
                    return;
                }else if (member.LoanedItems.Exists(i => i.Id == choice))
                {
                    Console.WriteLine("How many days did you loan the item :");
                    int days;
                    do
                    {
                        days = int.Parse(Console.ReadLine());
                        if (days < 0)
                        {
                            Console.WriteLine("Invalid Value, Try Again : ");
                        }
                    } while (days < 0);
                    LibraryItem LI = member.LoanedItems.Find(i => i.Id == choice);
                    if (days > LI.Period)
                        member.FeesOwed += LI.FeePerDay * (days - LI.Period);
                    member.CurrentLoanItems -= 1;    
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid Id Number, Try Again:");
                }
            } while (choice!=-1);
        }

        private void LoanItem()
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
                            if(foundItem.Status == ItemStatusEnum.Available && member.CurrentLoanItems < member.MaximumLoanItems && member.FeesOwed == 0)
                            {
                                member.LoanedItems.Add(foundItem);
                                member.CurrentLoanItems += 1;
                            }
                            else
                            {
                                Console.WriteLine("Item Not Availabe To Loan");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Item not found.");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter The Item ID to search for:");
                        int id = int.Parse(Console.ReadLine());
                        if (items.Exists(i => i.Id == id && i.Status != ItemStatusEnum.CheckedOut))
                        {
                            LibraryItem foundItem = items.Find(i => i.Id == id);
                            if (foundItem.Status == ItemStatusEnum.Available && member.CurrentLoanItems < member.MaximumLoanItems && member.FeesOwed == 0)
                            {
                                member.LoanedItems.Add(foundItem);
                                member.CurrentLoanItems += 1;
                            }
                            else
                            {
                                Console.WriteLine("Item Not Availabe To Loan");
                            }
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

        private void Browse()
        {
            Console.WriteLine("Library Items:");
            foreach (var item in items)
            {
                if (item.Status != ItemStatusEnum.CheckedOut)
                    Console.WriteLine($"Title: {item.Title}, Status: {item.Status}, Type: {item.Type}");
            }
        }
        private void SearchItem()
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
    }
}
