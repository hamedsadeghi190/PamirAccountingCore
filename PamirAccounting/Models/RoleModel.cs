using PamirAccounting.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamirAccounting.Models
{
  public class RoleModel
    {
        public int Id { get; set; }
        public int? RowId { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }

        public List<UserInRole> UserInRoles { get; set; }
    }
}
