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
            CurrenciesMappingDestiniationCurrenies = new HashSet<CurrenciesMapping>();
            CurrenciesMappingSourceCurrenies = new HashSet<CurrenciesMapping>();
            Customers = new HashSet<Customer>();
            DraftConvertedCurrencies = new HashSet<Draft>();
            DraftDepositCurrencies = new HashSet<Draft>();
            DraftTypeCurrencies = new HashSet<Draft>();
            Settings = new HashSet<Setting>();
            Transactions = new HashSet<Transaction>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double? BaseRate { get; set; }
        public byte? Action { get; set; }

        public virtual ICollection<Agency> Agencies { get; set; }
        public virtual ICollection<Bank> Banks { get; set; }
        public virtual ICollection<CurrenciesMapping> CurrenciesMappingDestiniationCurrenies { get; set; }
        public virtual ICollection<CurrenciesMapping> CurrenciesMappingSourceCurrenies { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Draft> DraftConvertedCurrencies { get; set; }
        public virtual ICollection<Draft> DraftDepositCurrencies { get; set; }
        public virtual ICollection<Draft> DraftTypeCurrencies { get; set; }
        public virtual ICollection<Setting> Settings { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
