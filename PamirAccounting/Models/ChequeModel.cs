using PamirAccounting.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamirAccounting.Models
{
   public class ChequeModel
    {
        public long Id { get; set; }
        public byte? RealBankId { get; set; }
        public string RealBankName { get; set; }
        public DateTime RegisterDateTime { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public string IssueDatePersian { get; set; }
        public string DueDatePersian { get; set; }
        public string ChequeNumber { get; set; }
        public string BankAccountNumber { get; set; }
        public long Amount { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Description { get; set; }
        public long DocumentId { get; set; }
        public int Type { get; set; }
        public string BranchName { get; set; }
        public int UserId { get; set; }
        public int? RowId { get; set; }
        public int? BankId { get; set; }
        public string BankName { get; set; }
        public int? OrginalCustomerId { get; set; }
        public List<Customer> OrginalCustomer { get; set; }
        public string OrginalCustomerName { get; set; }
        public DateTime? VosoolDate { get; set; }
        public string VosoolDatePersian { get; set; }
        //public List< Customer> Customers { get; set; }
        //public List<RealBank> RealBanks { get; set; }
        //public List<User> Users { get; set; }
    }
}
