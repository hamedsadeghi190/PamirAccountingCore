using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamirAccounting.Models
{
    public class AgencyCurencyModel
    {
        public int Id { get; set; }
        public string AgencyName { get; set; }
        public string SourceCurrenyName { get; set; }
        public string DestiniationCurrenyName { get; set; }
        public int ActionId { get; set; }
        public string ActionName { get; set; }
        public int ExchangeRate { get; set; }
        public string ExchangeRateShow { get; set; }
        public int RoundLimit { get; set; }
        public string RoundLimitShow { get; set; }
        public int? RowId { get; set; }
    }
}
