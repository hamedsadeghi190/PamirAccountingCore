using AutoMapper;
using PamirAccounting.Domains;
using PamirAccounting.Infrastructures;

namespace PamirAccounting.Services
{
    public class SettingServices : Repository<Setting>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PamirContext _context;

        #region SettingServices
        public SettingServices(PamirContext context, UnitOfWork unitOfWork, IMapper mapper) : base(context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;

        }
        #endregion
    }
}
