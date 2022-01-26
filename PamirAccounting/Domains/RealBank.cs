using System;
using System.Collections.Generic;

#nullable disable

namespace PamirAccounting.Domains
{
    public partial class RealBank
    {
        public RealBank()
        {
            Cheques = new HashSet<Cheque>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Cheque> Cheques { get; set; }
    }
}
