using System;
using System.Collections.Generic;

#nullable disable

namespace PamirAccounting.Domains
{
    public partial class Bank
    {
        public Bank()
        {
            Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? CountryId { get; set; }
        public int? BaseCurrencyId { get; set; }
        public long? Balance { get; set; }
        public string AccountNumber { get; set; }
        public string BranchName { get; set; }

        public virtual Currency BaseCurrency { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
