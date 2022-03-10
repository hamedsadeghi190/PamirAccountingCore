using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamirAccounting.Models
{
   public  class CustomerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string NationalCode { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string GroupName { get; set; }
        public int? GroupId { get; set; }
        public int? CreditLimit { get; set; }
        public string Dsc { get; set; }
        public int? CreditCurrencyId { get; set; }
        public int? CountryId { get; set; }
        public int? BankId { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPrimery { get; set; }
        public string Date { get; set; }
        public int? Radif { get; set; }
    }
}
