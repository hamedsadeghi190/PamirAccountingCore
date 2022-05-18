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
   public class RolesServices: Repository<Role>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PamirContext _context;

        #region Constructor
        public RolesServices(PamirContext context, UnitOfWork unitOfWork, IMapper mapper) : base(context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;

        }
        #endregion

        public List<RoleModel> GetAll()
        {
            try
            {
               // var role = _context.Banks.ToList();
                var role = FindAllReadonly().Select(x => new RoleModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Code=x.Code
               

                }).ToList();
                int row = 1;
                var tmpdataList = role.Select(x => new RoleModel
                {
                    RowId = row++,
                    Id = x.Id,
                    Name = x.Name,
                    Code=x.Code,
              

                }).ToList();

                return tmpdataList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    
    }
}
