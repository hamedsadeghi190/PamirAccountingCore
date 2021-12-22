using System;
using System.Collections.Generic;

#nullable disable

namespace PamirAccounting.Domains
{
    public partial class Country
    {
        public Country()
        {
            Banks = new HashSet<Bank>();
            Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string NameFa { get; set; }
        public string NameEn { get; set; }
        public string Code { get; set; }

        public virtual ICollection<Bank> Banks { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
