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
    public class RealBankServices : Repository<RealBank>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PamirContext _context;
       
        #region RealBankServices
        public RealBankServices(PamirContext context, UnitOfWork unitOfWork, IMapper mapper) : base(context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;

        }
        #endregion
        public List<RealBankModel> GetAll()
        {
            try
            {
                var dataList = FindAllReadonly().Select(x => new RealBankModel
                {
                    Id = x.Id,
                    Name = x.Name,
               

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
