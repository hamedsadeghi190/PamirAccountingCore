using System;
using System.Collections.Generic;

#nullable disable

namespace PamirAccounting.Domains
{
    public partial class Transaction
    {
        public int Id { get; set; }
        public int SourceCustomerId { get; set; }
        public int? DestinitionCustomerId { get; set; }
        public int TransactionType { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public DateTime Date { get; set; }
        public long? WithdrawAmount { get; set; }
        public long? DepositAmount { get; set; }
        public long RemainigAmount { get; set; }
        public string Description { get; set; }
        public int? CurrenyId { get; set; }
        public int UserId { get; set; }
        public bool? WithdrawType { get; set; }
        public string BranchCode { get; set; }
        public string ReceiptNumber { get; set; }
        public long? UnkownAmount { get; set; }

        public virtual Currency Curreny { get; set; }
        public virtual Customer DestinitionCustomer { get; set; }
        public virtual Customer SourceCustomer { get; set; }
        public virtual User User { get; set; }
    }
}
