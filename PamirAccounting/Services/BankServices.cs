using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PamirAccounting.Domains;
using PamirAccounting.Infrastructures;
using PamirAccounting.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PamirAccounting.Services.Services
{
    public class BankServices : Repository<Bank>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PamirContext _context;

        #region BankServices
        public BankServices(PamirContext context, UnitOfWork unitOfWork, IMapper mapper) : base(context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;

        }
        #endregion

        public bool CreateUpdate(BanksModel model)
        {
            try
            {
                var bank = _mapper.Map<Bank>(model);
                if (model.Id == null)
                {
                    Insert(bank);
                }
                else
                {
                    Update(bank);
                }
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public BanksModel FindById(int id)
        {
            try
            {
                var bank = FindFirstOrDefault(x => x.Id == id, "Country,Currency");
                if (bank == null)
                    return null;

                var result = _mapper.Map<BanksModel>(bank);
                result.CountryName = bank.Country.NameFa;
                result.BaseCurrencyName = bank.BaseCurrency.Name;
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<BanksModel> GetAll()
        {
            try
            {
                var banks = _context.Banks.ToList();
                var bank = FindAllReadonly().Include(x => x.BaseCurrency).Include(x => x.Country).Select(x => new BanksModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    CountryId = x.CountryId,
                    BaseCurrencyId = x.BaseCurrencyId,
                    BaseCurrencyName = x.BaseCurrency.Name,
                    CountryName = x.Country.NameFa

                }).ToList();
                int row = 1;
                var tmpdataList = bank.Select(x => new BanksModel
                {
                    RowId = row++,
                    Id = x.Id,
                    Name = x.Name,
                    CountryId = x.CountryId,
                    BaseCurrencyId = x.BaseCurrencyId,
                    BaseCurrencyName = x.BaseCurrencyName,
                    CountryName = x.CountryName

                }).ToList();
           
                return tmpdataList;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<BanksModel> Search(string name)
        {
            try
            {
                var banks = _context.Banks.ToList();
                var bank = FindAllReadonly().Include(x => x.BaseCurrency).Include(x => x.Country).Select(x => new BanksModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    CountryId = x.CountryId,
                    BaseCurrencyId = x.BaseCurrencyId,
                    BaseCurrencyName = x.BaseCurrency.Name,
                    CountryName = x.Country.NameFa

                }).Where(x=>x.Name.Contains(name)).ToList();
                int row = 1;
                var tmpdataList = bank.Select(x => new BanksModel
                {
                    RowId = row++,
                    Id = x.Id,
                    Name = x.Name,
                    CountryId = x.CountryId,
                    BaseCurrencyId = x.BaseCurrencyId,
                    BaseCurrencyName = x.BaseCurrencyName,
                    CountryName = x.CountryName

                }).ToList();

                return tmpdataList;
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
                var bank = FindFirstOrDefault(x => x.Id == id);
                if (id == null)
                {
                    return false;
                }
                else
                {
                    Delete(bank);

                }
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        public BanksModel IsNameInUse(string Name)
        {
            try
            {
                var bank = FindFirstOrDefault(x => x.Name == Name);
                if (bank == null)
                    return null;

                var result = _mapper.Map<BanksModel>(bank);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public string GetAccountNumber(int id)
        {
            var bank = _unitOfWork.Banks.FindFirstOrDefault(x => x.Id == id);
            string accountNumber = bank.AccountNumber?.ToString();
            return accountNumber;

        }

        public long FindBalance(int? bankId)
        {
            var bank = _unitOfWork.BankServices.Find(bankId);
            var balance = bank.Balance;
            return (long)balance;
        }
    }
}
