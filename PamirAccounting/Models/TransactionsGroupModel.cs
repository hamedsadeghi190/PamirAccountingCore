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

        public Int64 RowId { get; set; }
        public int SourceCustomerId { get; set; }
        public long DocumentId { get; set; }
        public int TransactionType { get; set; }
        public string TransactionTypeName { get; set; }
        public string TransactionDateTime { get; set; }
        public string Date { get; set; }
        public long? WithdrawAmount { get; set; }
        public long? DepositAmount { get; set; }
        public int? CurrenyId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
    }
}
