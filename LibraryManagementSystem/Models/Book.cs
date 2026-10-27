using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagementSystem.Enum;
namespace LibraryManagementSystem.Models
{
    internal class Book : LibraryItem
    {
        #region Attributes

            public string Author { get; set; }

            public int PageCount { get; set; }


        #endregion
        #region Constructors

        public Book(string title, ItemStatus status, ItemType type, string author, int pageCount) : base(title, status, type)
        {
            Author = author;
            PageCount = pageCount;
        }
        #endregion
        #region Methods
        
        public override void DisplayItemInfo()
        {
            Console.WriteLine($"Book ID: {ItemID}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Page Count: {PageCount}");
            Console.WriteLine($"Status: {Status}");
            Console.WriteLine($"Type: {Type}");
        }

        public override void LoanPeriod()
        {
            Console.WriteLine("Loan period for a book is 14 days.");
        }

        public override void FineCalculation()
        {
            Console.WriteLine("Fine for a book is $0.50 per day.");
        }

        #endregion

    }
}
