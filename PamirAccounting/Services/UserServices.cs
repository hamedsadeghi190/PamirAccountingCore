using AutoMapper;
using PamirAccounting.Domains;
using PamirAccounting.Infrastructures;
using PamirAccounting.Models;
using System.Collections.Generic;
using System.Linq;

namespace PamirAccounting.Services
{
    public class UserServices : Repository<User>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PamirContext _context;

        #region Constructor
        public UserServices(PamirContext context, UnitOfWork unitOfWork, IMapper mapper) : base(context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;

        }
        #endregion

        public List<UserModel> GetAll()
        {
            try
            {
                var bank = FindAllReadonly(x => x.IsDeleted == false).Select(x => new UserModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserName = x.UserName,
                    Password = x.Password

                }).ToList();

                return bank;
            }
            catch
            {
                return null;
            }

        }

    }
}
