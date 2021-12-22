using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PamirAccounting.Domains;
using PamirAccounting.Infrastructures;
using PamirAccounting.Models;
using PamirAccounting.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PamirAccounting.Services.Services
{
    public class CountryServices : Repository<Country>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PamirContext _context;

        #region CurrencyServices
        public CountryServices(PamirContext context, UnitOfWork unitOfWork, IMapper mapper) : base(context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;

        }
        #endregion

        public List<CountriesViewModel> GetAll()
        {
            try
            {
                var country = FindAllReadonly().Select(x => new CountriesViewModel { Id = x.Id, NameEn = x.NameEn, NameFa = x.NameFa }).ToList();

                return country;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
