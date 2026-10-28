using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagementSystem.Enum;
namespace LibraryManagementSystem.Models
{
    internal class Member : Account
    {
        #region Attributes
        public int MaximumLoanItems { get; set; }

        public int CurrentLoanItems { get; set; }

        public MemberStatusEnum Status { get; set; } = MemberStatusEnum.Active;

        public List<LibraryItem> LoanedItems { get; set; } = new List<LibraryItem>();

        public List<LoanedRecord> LoanedRecords { get; set; } = new List<LoanedRecord>();
        public int FeesOwed { get; set; } = 0;

        #endregion

        #region Constructors

        public Member(string username, string password, string phoneNumber, string email, int maximumLoanItems) : base(username, password, phoneNumber, email, AccountRoleEnum.Member)
        {
            MaximumLoanItems = maximumLoanItems;
            CurrentLoanItems = 0;
        }
        #endregion
        #region Methods

        public override void DisplayAccountInfo()
        {
            Console.WriteLine($"Member ID: {AccountId}");
            Console.WriteLine($"Username: {Username}");
            Console.WriteLine($"Phone Number: {PhoneNumber}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Status: {Status}");
            Console.WriteLine($"Maximum Loan Items: {MaximumLoanItems}");
            Console.WriteLine($"Current Loan Items: {CurrentLoanItems}");
            Console.WriteLine($"Fees Owed: ${FeesOwed}");
            Console.WriteLine("Loaned Items:");
            foreach (var loan in LoanedItems)
            {
                loan.DisplayItemInfo();
            }
            Console.WriteLine("Loaned Records:");
            foreach (var record in LoanedRecords)
            {
                record.DisplayRecordInfo();
            }
        }

        
        #endregion
    }
}
