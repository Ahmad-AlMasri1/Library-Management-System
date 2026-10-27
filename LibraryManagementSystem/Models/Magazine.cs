using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagementSystem.Enum;
namespace LibraryManagementSystem.Models
{
    internal class Magazine : LibraryItem
    {
        #region Attributes
        public int IssueNumber { get; set; }
        #endregion
        #region Constructors
        public Magazine(string title, ItemStatusEnum Status, ItemTypeEnum Type, int issueNumber) : base(title, Status, Type, Period: 7, FeePerDay: 25)
        {
            IssueNumber = issueNumber;
        }
        #endregion
        #region Methods
        public override void DisplayItemInfo()
        {
            Console.WriteLine($"Magazine ID: {Id}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Issue Number: {IssueNumber}");
            Console.WriteLine($"Status: {Status}");
            Console.WriteLine($"Type: {Type}");
        }
        public override string LoanPeriod(int Period)
        {
            return $"Loan period for a book is {Period} days.";
        }

        public override string CalculateFee(int NumberOfDays)
        {
            int totalFee = NumberOfDays * FeePerDay;
            return $"Total fee for a book is ${totalFee}.";
        }
        #endregion
    }
    }
