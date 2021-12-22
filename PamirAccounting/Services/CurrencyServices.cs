using AutoMapper;
using PamirAccounting.Domains;
using PamirAccounting.Infrastructures;
using PamirAccounting.Models.ViewModels;
using System;

namespace PamirAccounting.Services.Services
{
    public  class CurrencyServices : Repository<Currency>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PamirContext _context;

        #region CurrencyServices
        public CurrencyServices(PamirContext context, UnitOfWork unitOfWork, IMapper mapper) : base(context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;

        }
        #endregion

        public bool CreateUpdate(CurrenciesViewModel model)
        {
            try
            {
                var currency = _mapper.Map<Currency>(model);
                if (model.Id == null)
                {
                    Insert(currency);
                }
                else
                {
                    Update(currency);
                }
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
