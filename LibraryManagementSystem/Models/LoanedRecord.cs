using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagementSystem.Enum;
namespace LibraryManagementSystem.Models
{
    internal class LoanedRecord
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int cnt { get; set; } = 0;
        public LoanedRecordEnum Status { get; set; }

        public LoanedRecord(int Id , string Title)
        {
            this.Id = Id;
            this.Title = Title;
            Status = LoanedRecordEnum.currently;

        }
        public void DisplayRecordInfo()
        {
            Console.WriteLine($"Id : {Id} /Number of previous loans : {cnt} / Title : {Title} / Status : {Status}");
        }
    }
}
