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

        public Book(string title, ItemStatusEnum status, ItemTypeEnum type, string author, int pageCount) : base(title, status, type, Period: 14, FeePerDay: 50)
        {
            Author = author;
            PageCount = pageCount;
        }
        #endregion
        #region Methods
        
        public override void DisplayItemInfo()
        {
            Console.WriteLine($"Book ID: {Id}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Page Count: {PageCount}");
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
