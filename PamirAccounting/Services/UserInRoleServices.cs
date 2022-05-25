using AutoMapper;
using PamirAccounting.Domains;
using PamirAccounting.Infrastructures;
using PamirAccounting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamirAccounting.Services
{
    public class UserInRoleServices : Repository<UserInRole>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PamirContext _context;

        #region Constructor
        public UserInRoleServices(PamirContext context, UnitOfWork unitOfWork, IMapper mapper) : base(context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;

        }
        #endregion

        public List<UserInRoleModel> GetUserInRolls(int? id)
        {
            try
            {
                var userInRole = new List<UserInRoleModel>();
                if (id.HasValue)
                {
                
                    userInRole = FindAllReadonly(x => x.UserId == id).Select(x => new UserInRoleModel()
                    {
                        UserId = x.UserId,
                        RoleId = x.RoleId,
                        Id = x.Id,
                        RoleName=x.Role.Name,
                        Code=x.Role.Code,

                    }).ToList();
                  
                }
                return userInRole;
            }
            catch (Exception ex)
            {
                return null;
            }


        }
        //public int FindRole(int? id)
        //{
        //    var roleId = FindAllReadonly().Where(x => x.UserId == id).ToList();
        //    return roleId;
        //}
    }
}
