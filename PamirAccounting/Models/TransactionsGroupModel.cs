using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamirAccounting.Models
{
    public class TransactionsGroupModel
    {
        public int Id { get; set; }

        public long TotalWithdrawAmount { get; set; }
        public long TotalDepositAmount { get; set; }
        public long RemainigAmount { get; set; }
        public string Description { get; set; }
        public string CurrenyName { get; set; }
        public string Status { get; set; }
    }
}
