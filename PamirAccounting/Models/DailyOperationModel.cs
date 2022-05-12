using PamirAccounting.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamirAccounting.Models
{
 public   class DailyOperationModel
    {
        public long Id { get; set; }
        public int RowId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan? Time { get; set; }
        public string DatePersian { get; set; }
        public string TimePersian { get; set; }
        public long TransactionId { get; set; }
        public long? DocumentId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public string ActionText { get; set; }
        public byte? ActionType { get; set; }
        public List <Transaction> Transactions { get; set; }
        public List < User> Users { get; set; }
    }
}
