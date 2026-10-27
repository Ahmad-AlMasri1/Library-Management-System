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
        public string Title { get; set; }
        public ItemStatus Status { get; set; }
        public ItemType Type { get; set; }
        #endregion

        #region Constructors
        public LibraryItem(string title, ItemStatus Status, ItemType Type)
        {
            ItemID = ++ItemID;
            Title = title;
            this.Status = Status;
            this.Type = Type;

        }
        #endregion

        #region Methods

        public abstract void DisplayItemInfo();
       
        public abstract void LoanPeriod();

        public abstract void FineCalculation();

        #endregion


    }
}
