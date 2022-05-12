using System;
using System.Collections.Generic;

#nullable disable

namespace PamirAccounting.Domains
{
    public partial class User
    {
        public User()
        {
            DailyOperations = new HashSet<DailyOperation>();
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public int? AgentId { get; set; }
        public int? CurrenyId { get; set; }
        public int? CustomerId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Agency Agent { get; set; }
        public virtual Currency Curreny { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<DailyOperation> DailyOperations { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
