using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PamirAccounting.Commons.Enums;
using PamirAccounting.Domains;
using PamirAccounting.Infrastructures;
using PamirAccounting.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PamirAccounting.Services
{
    public class ChequeServices : Repository<Cheque>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PamirContext _context;

        #region ChequeServices
        public ChequeServices(PamirContext context, UnitOfWork unitOfWork, IMapper mapper) : base(context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;

        }
        #endregion

        public List<ChequeModel> GetAll()
        {
            try
            {

                var cheque = FindAllReadonly().Select(x => new ChequeModel
                {
                    Id = x.Id,
                    Amount = x.Amount,
                    BankAccountNumber = x.BankAccountNumber,
                    Description = x.Description,
                    BranchName = x.BranchName,
                    ChequeNumber = x.ChequeNumber,
                    CustomerId = x.CustomerId,
                    DocumentId = x.DocumentId,
                    DueDate = x.DueDate,
                    IssueDate = x.IssueDate,
                    RealBankId = x.RealBankId,
                    RegisterDateTime = x.RegisterDateTime,
                    Type = x.Type,
                    UserId = x.UserId,
                    RealBankName=x.RealBank.Name,
                    CustomerName=x.Customer.FirstName+" "+x.Customer.LastName,



                }).ToList();

                return cheque;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<ChequeModel> GetAllDaryaftani()
        {
            try
            {

                var cheque = FindAllReadonly().Where(x=>x.Status == (int)Settings.ChequeStatus.New).Select(x => new ChequeModel
                {
                    Id = x.Id,
                    Amount = x.Amount,
                    BankAccountNumber = x.BankAccountNumber,
                    Description = x.Description,
                    BranchName = x.BranchName,
                    ChequeNumber = x.ChequeNumber,
                    CustomerId = x.CustomerId,
                    DocumentId = x.DocumentId,
                    DueDate = x.DueDate,
                    IssueDate = x.IssueDate,
                    RealBankId = x.RealBankId,
                    RegisterDateTime = x.RegisterDateTime,
                    Type = x.Type,
                    UserId = x.UserId,
                    RealBankName = x.RealBank.Name,
                    CustomerName = x.Customer.FirstName + " " + x.Customer.LastName,



                }).ToList();

                return cheque;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<ChequeModel> GetAllSareHesab()
        {
            try
            {

                var cheque = FindAllReadonly().Where(x => x.Status == (int)Settings.ChequeStatus.DarJaryanVosol).Select(x => new ChequeModel
                {
                    Id = x.Id,
                    Amount = x.Amount,
                    BankAccountNumber = x.BankAccountNumber,
                    Description = x.Description,
                    BranchName = x.BranchName,
                    ChequeNumber = x.ChequeNumber,
                    CustomerId = x.CustomerId,
                    DocumentId = x.DocumentId,
                    DueDate = x.DueDate,
                    IssueDate = x.IssueDate,
                    RealBankId = x.RealBankId,
                    RegisterDateTime = x.RegisterDateTime,
                    Type = x.Type,
                    UserId = x.UserId,
                    RealBankName = x.RealBank.Name,
                    CustomerName = x.Customer.FirstName + " " + x.Customer.LastName,



                }).ToList();

                return cheque;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<ChequeModel> GetAllVosool()
        {
            try
            {

                var cheque = FindAllReadonly().Where(x => x.Status == (int)Settings.ChequeStatus.Vosol).Select(x => new ChequeModel
                {
                    Id = x.Id,
                    Amount = x.Amount,
                    BankAccountNumber = x.BankAccountNumber,
                    Description = x.Description,
                    BranchName = x.BranchName,
                    ChequeNumber = x.ChequeNumber,
                    CustomerId = x.CustomerId,
                    DocumentId = x.DocumentId,
                    DueDate = x.DueDate,
                    IssueDate = x.IssueDate,
                    RealBankId = x.RealBankId,
                    RegisterDateTime = x.RegisterDateTime,
                    Type = x.Type,
                    UserId = x.UserId,
                    RealBankName = x.RealBank.Name,
                    CustomerName = x.Customer.FirstName + " " + x.Customer.LastName,



                }).ToList();

                return cheque;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<ChequeModel> GetAllVagozariAsnadDaryaftani()
        {
            try
            {

                var cheque = FindAllReadonly().Where(x => x.Status == (int)Settings.ChequeStatus.VagozariAsnadDaryaftani).Select(x => new ChequeModel
                {
                    Id = x.Id,
                    Amount = x.Amount,
                    BankAccountNumber = x.BankAccountNumber,
                    Description = x.Description,
                    BranchName = x.BranchName,
                    ChequeNumber = x.ChequeNumber,
                    CustomerId = x.CustomerId,
                    DocumentId = x.DocumentId,
                    DueDate = x.DueDate,
                    IssueDate = x.IssueDate,
                    RealBankId = x.RealBankId,
                    RegisterDateTime = x.RegisterDateTime,
                    Type = x.Type,
                    UserId = x.UserId,
                    RealBankName = x.RealBank.Name,
                    CustomerName = x.Customer.FirstName + " " + x.Customer.LastName,



                }).ToList();

                return cheque;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
