using System;
using System.Collections.Generic;

#nullable disable

namespace PamirAccounting.Domains
{
    public partial class Transaction
    {
        public Transaction()
        {
            DailyOperations = new HashSet<DailyOperation>();
            Drafts = new HashSet<Draft>();
            InverseDoubleTransaction = new HashSet<Transaction>();
        }

        public long Id { get; set; }
        public int SourceCustomerId { get; set; }
        public int TransactionType { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public DateTime Date { get; set; }
        public long? WithdrawAmount { get; set; }
        public long? DepositAmount { get; set; }
        public string Description { get; set; }
        public int? CurrenyId { get; set; }
        public int UserId { get; set; }
        public bool? WithdrawType { get; set; }
        public string BranchCode { get; set; }
        public string ReceiptNumber { get; set; }
        public long? UnkownAmount { get; set; }
        public long? DoubleTransactionId { get; set; }
        public int? DestinitionCustomerId { get; set; }
        public long DocumentId { get; set; }
        public double? Rate { get; set; }
        public long? OriginalTransactionId { get; set; }

        public virtual Currency Curreny { get; set; }
        public virtual Customer DestinitionCustomer { get; set; }
        public virtual Transaction DoubleTransaction { get; set; }
        public virtual Customer SourceCustomer { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<DailyOperation> DailyOperations { get; set; }
        public virtual ICollection<Draft> Drafts { get; set; }
        public virtual ICollection<Transaction> InverseDoubleTransaction { get; set; }
    }
}
