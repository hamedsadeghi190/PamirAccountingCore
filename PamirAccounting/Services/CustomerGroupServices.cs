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
    public class CustomerGroupServices : Repository<CustomerGroup>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PamirContext _context;

        #region CurrencyServices
        public CustomerGroupServices(PamirContext context, UnitOfWork unitOfWork, IMapper mapper) : base(context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;

        }
        #endregion

        public bool CreateUpdate(CustomerGroupModel model)
        {
            try
            {
                var customerGroup = _mapper.Map<CustomerGroup>(model);
                if (model.Id == null)
                {
                    Insert(customerGroup);
                }
                else
                {
                    Update(customerGroup);
                }
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public CustomerGroupModel FindById(int id)
        {
            try
            {
                var customerGroup = FindFirstOrDefault(x => x.Id == id);
                if (customerGroup == null)
                    return null;

                var result = _mapper.Map<CustomerGroupModel>(customerGroup);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<CustomerGroupModel> GetAll()
        {
            try
            {
                var customerGroup = FindAllReadonly().Select(x => new CustomerGroupModel { Name = x.Name, Id = x.Id }).ToList();

                return customerGroup;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public bool Delete(int? id)
        {
            try
            {
                var customerGroup = FindFirstOrDefault(x => x.Id == id);
                if (id == null)
                {
                    return false;
                }
                else
                {
                    Delete(customerGroup);

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
