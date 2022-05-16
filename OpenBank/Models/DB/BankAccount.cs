using System;
using System.Collections.Generic;

namespace OpenBank.Models.DB
{
    public partial class BankAccount
    {
        public BankAccount()
        {
            TransactionHistoryBankAccounts = new HashSet<TransactionHistory>();
            TransactionHistorySenderBankAccounts = new HashSet<TransactionHistory>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public double Balance { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<TransactionHistory> TransactionHistoryBankAccounts { get; set; }
        public virtual ICollection<TransactionHistory> TransactionHistorySenderBankAccounts { get; set; }
    }
}
