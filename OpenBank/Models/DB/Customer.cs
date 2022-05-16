using System;
using System.Collections.Generic;

namespace OpenBank.Models.DB
{
    public partial class Customer
    {
        public Customer()
        {
            BankAccounts = new HashSet<BankAccount>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<BankAccount> BankAccounts { get; set; }
    }
}
