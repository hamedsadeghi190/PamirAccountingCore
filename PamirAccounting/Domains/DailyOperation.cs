using System;
using System.Collections.Generic;

#nullable disable

namespace PamirAccounting.Domains
{
    public partial class DailyOperation
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan? Time { get; set; }
        public long TransactionId { get; set; }
        public long? DocumentId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }

        public virtual Transaction Transaction { get; set; }
        public virtual User User { get; set; }
    }
}
