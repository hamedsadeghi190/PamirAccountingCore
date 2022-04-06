using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamirAccounting.Models.ViewModels
{
    public class CurrenciesViewModel
    {
        public int? Id { get; set; }
        public int? rowId { get; set; }
        public string Name { get; set; }
        public double? BaseRate { get; set; }
        public byte? Action { get; set; }

    }
}
