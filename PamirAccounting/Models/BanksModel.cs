using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamirAccounting.Models
{
    public class BanksModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string CountryName { get; set; }
        public string BaseCurrencyName { get; set; }
        public int? CountryId { get; set; }
        public int? BaseCurrencyId { get; set; }
    }
}
