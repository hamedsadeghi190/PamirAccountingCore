using System;
using System.Collections.Generic;

#nullable disable

namespace PamirAccounting.Domains
{
    public partial class Currency
    {
        public Currency()
        {
            Agencies = new HashSet<Agency>();
            Banks = new HashSet<Bank>();
            CurrencyAgencyDestiniationCurrenies = new HashSet<CurrencyAgency>();
            CurrencyAgencySourceCurrenies = new HashSet<CurrencyAgency>();
            Customers = new HashSet<Customer>();
            Settings = new HashSet<Setting>();
            Transactions = new HashSet<Transaction>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Agency> Agencies { get; set; }
        public virtual ICollection<Bank> Banks { get; set; }
        public virtual ICollection<CurrencyAgency> CurrencyAgencyDestiniationCurrenies { get; set; }
        public virtual ICollection<CurrencyAgency> CurrencyAgencySourceCurrenies { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Setting> Settings { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
