using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PamirAccounting.Domains;
using PamirAccounting.Infrastructures;
using PamirAccounting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamirAccounting.Services.Services
{
    public class ContactServices : Repository<Contact>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PamirContext _context;
        #region ContactServices
        public ContactServices(PamirContext context, UnitOfWork unitOfWork, IMapper mapper) : base(context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;

        }
        #endregion

        public bool CreateUpdate(ContactModel model)
        {
            try
            {
                var contact = _mapper.Map<Contact>(model);
                if (model.Id == null)
                {
                    Insert(contact);
                }
                else
                {
                    Update(contact);
                }
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        //public ContactModel FindById(int id)
        //{
        //    try
        //    {
        //        var contact = FindFirstOrDefault(x => x.Id == id, "Country,Currency");
        //        if (contact == null)
        //            return null;

        //        var result = _mapper.Map<ContactModel>(contact);
        //        result.CountryName = contact.Country.NameFa;
        //        result.BaseCurrencyName = contact.BaseCurrency.Name;
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }

        //}

        public List<ContactModel> GetAll()
        {
            try
            {
                var contacts = _context.Contacts.ToList();
                var contact = FindAllReadonly().Include(x => x.FirstName).Include(x => x.FirstName).Select(x => new ContactModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    FatherName = x.FatherName,
                    Phone = x.Phone,
                    Address = x.Address,
                    Mobile = x.Mobile,
                    Dsc = x.Dsc,

                }).ToList();

                return contact;
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
                var contact = FindFirstOrDefault(x => x.Id == id);
                if (id == null)
                {
                    return false;
                }
                else
                {
                    Delete(contact);

                }
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        public ContactModel IsNameInUse(string Name)
        {
            try
            {
                var contact = FindFirstOrDefault(x => x.FirstName == Name);
                if (contact == null)
                    return null;

                var result = _mapper.Map<ContactModel>(contact);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
