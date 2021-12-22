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
    public class CustomerServices : Repository<Customer>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PamirContext _context;

        #region BankServices
        public CustomerServices(PamirContext context, UnitOfWork unitOfWork, IMapper mapper) : base(context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;

        }
        #endregion


        public List<CustomerModel> GetAll()
        {
            try
            {
                var dataList = FindAllReadonly(x => x.IsDeleted == false).Include(x => x.Group).Select(x => new CustomerModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    FullName = x.FirstName + " " + x.LastName,
                    Phone = x.Phone,
                    Mobile = x.Mobile,
                    GroupName = x.Group.Name,

                }).ToList();

                return dataList;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
