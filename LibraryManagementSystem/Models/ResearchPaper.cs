using LibraryManagementSystem.Enum;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
namespace LibraryManagementSystem.Models
{
    internal class ResearchPaper : LibraryItem
    {
        #region Attributes
        public string ResearcherName { get; set; }

        public string ResearchField { get; set; }
        #endregion
        #region Constructors

        public ResearchPaper(string title, ItemStatusEnum status, ItemTypeEnum type, string researcherName, string researchField) : base(title, status, type, Period: 30,FeePerDay: 10)
        {
            ResearcherName = researcherName;
            ResearchField = researchField;
        }
        #endregion
        #region Methods
        public override void DisplayItemInfo()
        {
            Console.WriteLine($"Research Paper ID: {Id}");
            Console.WriteLine($"Researcher Name: {ResearcherName}");
            Console.WriteLine($"Research Field: {ResearchField}");
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
