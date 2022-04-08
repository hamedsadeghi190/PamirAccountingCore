using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamirAccounting.Models
{
    public class AgencyModel
    {
        public int Id { get; set; }
        public int? RowId { get; set; }
        public string Name { get; set; }
        public string CurrenyName { get; set; }
        public int? CurrenyId { get; set; }
        public string Phone { get; set; }
    }
}
