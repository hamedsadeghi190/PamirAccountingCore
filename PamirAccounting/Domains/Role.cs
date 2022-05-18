using System;
using System.Collections.Generic;

#nullable disable

namespace PamirAccounting.Domains
{
    public partial class Role
    {
        public Role()
        {
            UserInRoles = new HashSet<UserInRole>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Form { get; set; }
        public int Code { get; set; }

        public virtual ICollection<UserInRole> UserInRoles { get; set; }
    }
}
