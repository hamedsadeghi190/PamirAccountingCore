using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PamirAccounting.Domains;
using PamirAccounting.Infrastructures;
using PamirAccounting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using DNTPersianUtils.Core;

namespace PamirAccounting.Services
{
    public class TransactionServices : Repository<Transaction>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PamirContext _context;

        #region TransactionServices
        public TransactionServices(PamirContext context, UnitOfWork unitOfWork, IMapper mapper) : base(context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;

        }
        #endregion

        public long GetLatestDocumentId()
        {
            try
            {
                var DocumentId = _context.Transactions.Max(x => x.DocumentId);
                return DocumentId;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public long GetNewDocumentId()
        {
            try
            {
                var DocumentId = _context.Transactions.Max(x => x.DocumentId);
                return DocumentId + 1;
            }
            catch (Exception)
            {
                return 1;
            }
           
        }

        public List<TransactionModel> GetAll(int userId, int? currencyId)
        {
            try
            {
                var dataList = new List<TransactionModel>();
                if (currencyId == null)
                {
                    dataList = FindAllReadonly(x => x.SourceCustomerId == userId)
                    .Include(x => x.Curreny)
                    .Include(x => x.User)
                   .Select(x => new TransactionModel
                   {

                       Id = x.Id,
                       Description = x.Description,
                       DepositAmount = x.DepositAmount,
                       WithdrawAmount = x.WithdrawAmount,
                       Date = x.Date.ToString(),
                       TransactionDateTime = x.TransactionDateTime.ToString(),
                       CurrenyId = x.CurrenyId,
                       CurrenyName = x.Curreny.Name,
                       UserId = x.UserId,
                       UserName = x.User.UserName,
                       TransactionType = x.TransactionType,
                       DocumentId = x.DocumentId

                   }).ToList();
                }
                else
                {
                    dataList = FindAllReadonly(x => x.SourceCustomerId == userId && x.CurrenyId == currencyId)
                                 .Include(x => x.Curreny)
                                 .Include(x => x.User)
                                 .Select(x => new TransactionModel
                                 {
                                     Id = x.Id,
                                     Description = x.Description,
                                     DepositAmount = x.DepositAmount,
                                     WithdrawAmount = x.WithdrawAmount,
                                     Date = x.Date.ToString(),
                                     TransactionDateTime = x.TransactionDateTime.ToString(),
                                     CurrenyId = x.CurrenyId,
                                     CurrenyName = x.Curreny.Name,
                                     UserId = x.UserId,
                                     UserName = x.User.UserName,
                                     TransactionType = x.TransactionType,
                                     DocumentId = x.DocumentId
                                 }).ToList();
                }
                int row = 1;
                var tmpdataList = dataList.Select(x => new TransactionModel
                {
                    RowId = row++,
                    Id = x.Id,
                    Description = x.Description,
                    DepositAmount = x.DepositAmount,
                    WithdrawAmount = x.WithdrawAmount,
                    RemainigAmount = x.RemainigAmount,
                    Date = (DateTime.Parse(x.Date.ToString())).ToPersian(),
                    TransactionDateTime = (DateTime.Parse(x.TransactionDateTime.ToString())).ToPersian(),
                    CurrenyId = x.CurrenyId,
                    CurrenyName = x.CurrenyName,
                    UserId = x.UserId,
                    UserName = x.UserName,
                    DocumentId = x.DocumentId,
                    TransactionType = x.TransactionType,
                    Status = (x.WithdrawAmount.Value == 0 && x.DepositAmount.Value == 0) ? "" : (x.WithdrawAmount.Value > 0) ? "بدهکار" : "طلبکار"

                }).ToList();
                return tmpdataList;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public Transaction FindLastTransaction(int SourceCustomerId, int TransactionType, int CurrenyId)
        {
            var transaction = _context.Transactions.OrderBy(x => x.Id).LastOrDefault(x => x.SourceCustomerId == SourceCustomerId && x.TransactionType == TransactionType && x.CurrenyId == CurrenyId);
            return transaction;
        }
        public Transaction FindLastTransaction(int SourceCustomerId, int CurrenyId)
        {
            var transaction = _context.Transactions.OrderBy(x => x.Id).LastOrDefault(x => x.SourceCustomerId == SourceCustomerId && x.CurrenyId == CurrenyId);
            return transaction;
        }

        public List<UnKownTransactionModel> GetAllUnkowns()
        {
            try
            {
                var dataList = new List<UnKownTransactionModel>();

                dataList = FindAllReadonly(x => x.TransactionType == 4)
                             .Include(x => x.Curreny)
                             .Include(x => x.SourceCustomer)
                             .Select(x => new UnKownTransactionModel
                             {
                                 Id = x.Id,
                                 Date = x.Date.ToString(),
                                 BankName = x.SourceCustomer.FirstName + " " + x.SourceCustomer.LastName,
                                 BranchCode = x.BranchCode,
                                 ReceiptNumber = x.ReceiptNumber,
                                 Amount = x.WithdrawAmount.Value,
                                 CurrenyName = x.Curreny.Name,
                                 Description = x.Description,

                             }).ToList();

                dataList = dataList.Select(x => new UnKownTransactionModel
                {
                    Id = x.Id,
                    Date = (DateTime.Parse(x.Date.ToString())).ToShortPersianDateString(),
                    BankName = x.BankName,
                    BranchCode = x.BranchCode,
                    ReceiptNumber = x.ReceiptNumber,
                    Amount = x.Amount,
                    CurrenyName = x.CurrenyName,
                    Description = x.Description,

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