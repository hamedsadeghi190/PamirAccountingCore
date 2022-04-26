using AutoMapper;
using DNTPersianUtils.Core;
using Microsoft.EntityFrameworkCore;
using PamirAccounting.Domains;
using PamirAccounting.Infrastructures;
using PamirAccounting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;

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


        public List<ComboBoxModel> GetAllNotDefaults()
        {
            try
            {
                var dataList = FindAll(x => !AppSetting.DocumnetAndDraftsGroupID.Contains(x.GroupId.Value))
                .Select(x => new ComboBoxModel() { Id = x.Id, Title = $"{x.FirstName} {x.LastName}" }).ToList();

                return dataList;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

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
        public List<CustomerModel> GetAll(int? groupId)
        {
            try
            {
                if (groupId == null)
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
                        IsPrimery = x.IsPrimery

                    }).ToList();

                    return dataList;
                }
                else
                {
                    var dataList = FindAllReadonly(x => x.IsDeleted == false && x.GroupId == groupId).Include(x => x.Group).Select(x => new CustomerModel
                    {
                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        FullName = x.FirstName + " " + x.LastName,
                        Phone = x.Phone,
                        Mobile = x.Mobile,
                        GroupName = x.Group.Name,
                        IsPrimery = x.IsPrimery

                    }).ToList();

                    return dataList;
                }


            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<CustomerModel> GetAllReport()
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
                int r = 1;
                dataList = dataList.Select(x => new CustomerModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    FullName = x.FirstName + " " + x.LastName,
                    Phone = x.Phone,
                    Mobile = x.Mobile,
                    Radif=r++,
                    GroupName=x.GroupName,
                }).ToList();

                return dataList;

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public string GetCustomerName(int? id)
        {
            try
            {

                var customer = FindAllReadonly().Where(x => x.Id == id).Select(x => new CustomerModel
                {

                    FullName = x.FirstName + " " + x.LastName,
                }).ToString();

                return customer;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
