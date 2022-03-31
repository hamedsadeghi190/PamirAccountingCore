using System;
using System.Collections.Generic;

#nullable disable

namespace PamirAccounting.Domains
{
    public partial class Agency
    {
        public Agency()
        {
            Drafts = new HashSet<Draft>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEn { get; set; }
        public string Phone { get; set; }
        public bool? Active { get; set; }
        public int? CurrenyId { get; set; }
        public string Address { get; set; }
        public int? Percentage { get; set; }
        public bool? OrderType { get; set; }
        public string Dsc { get; set; }

        public virtual Currency Curreny { get; set; }
        public virtual ICollection<Draft> Drafts { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
