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
        public double Rate { get; set; }
        public double Rent { get; set; }
        public double? DepositAmount { get; set; }
        public int? DepositCurrencyId { get; set; }
        public bool? Status { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? RunningDate { get; set; }
        public DateTime? Date { get; set; }
        public int? ConvertedCurrencyId { get; set; }
        public double? ConvertedRate { get; set; }
        public long? ConvertedAmount { get; set; }
        public DateTime? ConvertedDate { get; set; }
        public string ExtraDescription { get; set; }

        public virtual Currency ConvertedCurrency { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Currency DepositCurrency { get; set; }
        public virtual Currency TypeCurrency { get; set; }
    }
}
