using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamirAccounting.Models
{
    public class TransactionsToCustomerModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public long? Amount { get; set; }
        public string FullName { get; set; }

    }
}
