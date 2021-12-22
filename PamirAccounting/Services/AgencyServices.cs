using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PamirAccounting.Domains;
using PamirAccounting.Infrastructures;
using PamirAccounting.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PamirAccounting.Services
{
    public class AgencyServices : Repository<Agency>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PamirContext _context;

        #region BankServices
        public AgencyServices(PamirContext context, UnitOfWork unitOfWork, IMapper mapper) : base(context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;

        }
        #endregion

        public List<AgencyModel> GetAll()
        {
            try
            {
                var dataList = FindAllReadonly().Include(x => x.Curreny).Select(x => new AgencyModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    CurrenyName = x.Curreny.Name,
                    CurrenyId = x.CurrenyId,
                    Phone = x.Phone

                }).ToList();

                return dataList;
            }
            catch 
            {
                return null;
            }

        }
    }
}
