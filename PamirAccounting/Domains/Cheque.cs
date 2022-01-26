using System;
using System.Collections.Generic;

#nullable disable

namespace PamirAccounting.Domains
{
    public partial class Cheque
    {
        public long Id { get; set; }
        public byte RealBankId { get; set; }
        public DateTime RegisterDateTime { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public string ChequeNumber { get; set; }
        public string BankAccountNumber { get; set; }
        public long Amount { get; set; }
        public int CustomerId { get; set; }
        public string Description { get; set; }
        public long DocumentId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual RealBank RealBank { get; set; }
    }
}
