using AutoMapper;
using PamirAccounting.Domains;
using PamirAccounting.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamirAccounting.Services
{
   public class DraftsServices : Repository<Draft>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PamirContext _context;

        #region BankServices
        public DraftsServices(PamirContext context, UnitOfWork unitOfWork, IMapper mapper) : base(context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;

        }
        #endregion

    }
}
