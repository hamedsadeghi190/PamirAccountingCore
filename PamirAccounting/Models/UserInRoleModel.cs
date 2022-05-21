using PamirAccounting.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamirAccounting.Models
{
    public class UserInRoleModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public List< Role> Role { get; set; }
        public List< User> User { get; set; }
    }
}
