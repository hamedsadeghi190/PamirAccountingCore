using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamirAccounting.Models
{
    public class ComboBoxModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
    public class ComboBoxBoolModel
    {
        public Boolean value { get; set; }
        public string Title { get; set; }
    }

    public class CurrencyViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double? BaseRate { get; set; }
        public byte? Action { get; set; }


    }
}
