using PamirAccounting.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamirAccounting.Models
{
    public class RealBankModel
    {
        public RealBankModel()
        {
            Cheques = new HashSet<Cheque>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Cheque> Cheques { get; set; }
    }
}
