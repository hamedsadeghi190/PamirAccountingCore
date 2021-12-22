using AutoMapper;
using PamirAccounting.Domains;
using PamirAccounting.Infrastructures;

namespace PamirAccounting.Services.Services
{
    public class HeaderServices : Repository<Header>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PamirContext _context;

        #region BankServices
        public HeaderServices(PamirContext context, UnitOfWork unitOfWork, IMapper mapper) : base(context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;

        }
        #endregion
    }
}
