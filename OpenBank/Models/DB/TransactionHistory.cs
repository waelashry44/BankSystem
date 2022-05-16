using System;
using System.Collections.Generic;

namespace OpenBank.Models.DB
{
    public partial class TransactionHistory
    {
        public int Id { get; set; }
        public int TransactionTypeId { get; set; }
        public int BankAccountId { get; set; }
        public DateTime TransactionDate { get; set; }
        public double Amount { get; set; }
        public int? SenderBankAccountId { get; set; }

        public virtual BankAccount BankAccount { get; set; } = null!;
        public virtual BankAccount? SenderBankAccount { get; set; }
        public virtual TransactionType TransactionType { get; set; } = null!;
    }
}
