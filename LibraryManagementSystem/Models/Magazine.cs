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
        public Magazine(string title, ItemStatus Status, ItemType Type, int issueNumber) : base(title, Status, Type)
        {
            IssueNumber = issueNumber;
        }
        #endregion
        #region Methods
        public override void DisplayItemInfo()
        {
            Console.WriteLine($"Magazine ID: {ItemID}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Issue Number: {IssueNumber}");
            Console.WriteLine($"Status: {Status}");
            Console.WriteLine($"Type: {Type}");
        }
        public override void LoanPeriod()
        {
            Console.WriteLine("Loan period for a magazine is 7 days.");
        }
        public override void FineCalculation()
        {
            Console.WriteLine("Fine for a magazine is $0.25 per day.");
        }
        #endregion
    }
    }
