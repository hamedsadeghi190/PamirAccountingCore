using System;
using System.Collections.Generic;

#nullable disable

namespace PamirAccounting.Domains
{
    public partial class Customer
    {
        public Customer()
        {
            Drafts = new HashSet<Draft>();
            SettingCostsAccounts = new HashSet<Setting>();
            SettingNotRunnedRemittances = new HashSet<Setting>();
            TransactionDestinitionCustomers = new HashSet<Transaction>();
            TransactionSourceCustomers = new HashSet<Transaction>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public int? GroupId { get; set; }
        public int? CreditLimit { get; set; }
        public string Dsc { get; set; }
        public int? CreditCurrencyId { get; set; }
        public int? CountryId { get; set; }
        public int? BankId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Bank Bank { get; set; }
        public virtual Country Country { get; set; }
        public virtual Currency CreditCurrency { get; set; }
        public virtual CustomerGroup Group { get; set; }
        public virtual ICollection<Draft> Drafts { get; set; }
        public virtual ICollection<Setting> SettingCostsAccounts { get; set; }
        public virtual ICollection<Setting> SettingNotRunnedRemittances { get; set; }
        public virtual ICollection<Transaction> TransactionDestinitionCustomers { get; set; }
        public virtual ICollection<Transaction> TransactionSourceCustomers { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
