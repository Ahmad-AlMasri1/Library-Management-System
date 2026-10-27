using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagementSystem.Enum;
namespace LibraryManagementSystem.Models
{
    internal class ResearchPaper : LibraryItem
    {
        #region Attributes
        public string ResearcherName { get; set; }

        public string ResearchField { get; set; }
        #endregion
        #region Constructors

        public ResearchPaper(string researcherName, string researchField) : base(title: "", status: ItemStatus.Available, type: ItemType.ResearchPaper)
        {
            ResearcherName = researcherName;
            ResearchField = researchField;
        }
        #endregion
        #region Methods
        public override void DisplayItemInfo()
        {
            Console.WriteLine($"Research Paper ID: {ItemID}");
            Console.WriteLine($"Researcher Name: {ResearcherName}");
            Console.WriteLine($"Research Field: {ResearchField}");
            Console.WriteLine($"Status: {Status}");
            Console.WriteLine($"Type: {Type}");
        }
        public override void LoanPeriod()
        {
            Console.WriteLine("Loan period for a research paper is 30 days.");
        }

        public override void FineCalculation()
        {
            Console.WriteLine("Fine for a research paper is $1.00 per day.");
        }
        #endregion
    }
}
