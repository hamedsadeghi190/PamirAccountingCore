using System;
using System.Collections.Generic;

#nullable disable

namespace PamirAccounting.Domains
{
    public partial class CurrencyAgency
    {
        public int Id { get; set; }
        public int AgencyId { get; set; }
        public int SourceCurrenyId { get; set; }
        public int DestiniationCurrenyId { get; set; }
        public int Action { get; set; }
        public int ExchangeRate { get; set; }
        public int RoundLimit { get; set; }

        public virtual Agency Agency { get; set; }
        public virtual Currency DestiniationCurreny { get; set; }
        public virtual Currency SourceCurreny { get; set; }
    }
}
