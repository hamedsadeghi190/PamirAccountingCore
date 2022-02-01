using System;
using System.Collections.Generic;

#nullable disable

namespace PamirAccounting.Domains
{
    public partial class Draft
    {
        public long Id { get; set; }
        public byte Type { get; set; }
        public int AgencyId { get; set; }
        public long Number { get; set; }
        public string OtherNumber { get; set; }
        public string Sender { get; set; }
        public string Reciver { get; set; }
        public string FatherName { get; set; }
        public string PayPlace { get; set; }
        public string Description { get; set; }
        public int TypeCurrencyId { get; set; }
        public long DraftAmount { get; set; }
        public long Rate { get; set; }
        public long Rent { get; set; }
        public double? DepositAmount { get; set; }
        public int? DepositCurrencyId { get; set; }
        public bool? Status { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? RunningDate { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? OdatDate { get; set; }
        public DateTime? AssignmentDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Currency DepositCurrency { get; set; }
        public virtual Currency TypeCurrency { get; set; }
    }
}
