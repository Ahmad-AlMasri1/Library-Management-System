using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagementSystem.Enum;
namespace LibraryManagementSystem.Models
{
    internal abstract class LibraryItem
    {
        #region Attributes

        public static int ItemID { get; set; } = 0;

        public int Id { get; set; }
        public string Title { get; set; }
        public ItemStatusEnum Status { get; set; }
        public ItemTypeEnum Type { get; set; }

        public int cnt { get; set; } = 0;

        public int Period { get; set; }

        public int FeePerDay { get; set; }
        #endregion

        #region Constructors
        public LibraryItem(string title, ItemStatusEnum Status, ItemTypeEnum Type, int Period, int FeePerDay)
        {
            Id = ++ItemID;
            Title = title;
            this.Status = Status;
            this.Type = Type;
            this.Period = Period;
            this.FeePerDay = FeePerDay;
        }
        #endregion

        #region Methods

        public abstract void DisplayItemInfo();
       
        public abstract string LoanPeriod(int Period);

        public abstract string CalculateFee(int NumberOfDays);

        #endregion


    }
}
