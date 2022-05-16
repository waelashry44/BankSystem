using System;
using System.Collections.Generic;

namespace OpenBank.Models.DB
{
    public partial class TransactionType
    {
        public TransactionType()
        {
            TransactionHistories = new HashSet<TransactionHistory>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<TransactionHistory> TransactionHistories { get; set; }
    }
}
