﻿using AutoMapper;
using DNTPersianUtils.Core;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using PamirAccounting.Domains;
using PamirAccounting.Infrastructures;
using PamirAccounting.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using static PamirAccounting.Commons.Enums.Settings;

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
                       Date2 = x.Date,
                       TransactionDateTime2 = x.TransactionDateTime,
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
                                     Date2 = x.Date,
                                     TransactionDateTime2 = x.TransactionDateTime,
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
                    Date = x.Date2.ToShortPersianDateString(true),
                    TransactionDateTime = x.TransactionDateTime2.ToShortPersianDateString(),
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

        [Obsolete]
        public List<TransactionModel> Filterd(int userId, int? currencyId, long? DocumentId, DateTime? startDate, DateTime? endDate)
        {
            try
            {

                var predicate = PredicateBuilder.New<Transaction>(true);

                predicate.And(x => x.SourceCustomerId == userId);

                if (currencyId != null)
                {
                    predicate = predicate.And(x => x.CurrenyId == currencyId);
                }
                if (DocumentId != null)
                {
                    predicate = predicate.And(x => x.DocumentId == DocumentId);
                }
                //if (startDate != null)
                //{
                //    predicate= predicate.And(x => x.TransactionDateTime >= startDate);
                //}
                //if (endDate != null)
                //{
                //    predicate= predicate.And(x => x.TransactionDateTime<= endDate);
                //}




                var dataList = _context.Transactions.Where(predicate)
                  .Include(x => x.Curreny)
                  .Include(x => x.User)
                 .Select(x => new TransactionModel
                 {
                     Id = x.Id,
                     Description = x.Description,
                     DepositAmount = x.DepositAmount,
                     WithdrawAmount = x.WithdrawAmount,
                     Date = x.Date.ToString(),
                     Date2 = x.Date,
                     TransactionDateTime2 = x.TransactionDateTime,
                     TransactionDateTime = x.TransactionDateTime.ToString(),
                     CurrenyId = x.CurrenyId,
                     CurrenyName = x.Curreny.Name,
                     UserId = x.UserId,
                     UserName = x.User.UserName,
                     TransactionType = x.TransactionType,
                     DocumentId = x.DocumentId

                 }).ToList();

                int row = 1;
                var tmpdataList = dataList.Select(x => new TransactionModel
                {
                    RowId = row++,
                    Id = x.Id,
                    Description = x.Description,
                    DepositAmount = x.DepositAmount,
                    WithdrawAmount = x.WithdrawAmount,
                    RemainigAmount = x.RemainigAmount,
                    Date = x.Date2.ToShortPersianDateString(true),
                    TransactionDateTime = x.TransactionDateTime2.ToShortPersianDateString(),
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

                dataList = FindAllReadonly(x => x.TransactionType == (int)TransaActionType.UnkwonReciveBank)
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
                                 DocumentId = x.DocumentId

                             }).ToList();
                int row = 1;
                dataList = dataList.Select(x => new UnKownTransactionModel
                {
                    RowId = row++,
                    Id = x.Id,
                    Date = (DateTime.Parse(x.Date.ToString())).ToFarsiFormat(),
                    BankName = x.BankName,
                    BranchCode = x.BranchCode,
                    ReceiptNumber = x.ReceiptNumber,
                    Amount = x.Amount,
                    CurrenyName = x.CurrenyName,
                    Description = x.Description,
                    DocumentId = x.DocumentId
                }).ToList();
                return dataList;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<TransactionModel> GetAllReport(int userId, int? currencyId)
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
                                 }).ToList();
                }
                int row = 1;
                dataList = dataList.Select(x => new TransactionModel
                {
                    RowId = row++,
                    Id = x.Id,
                    Description = x.Description,
                    DepositAmount = x.DepositAmount,
                    WithdrawAmount = x.WithdrawAmount,
                    RemainigAmount = x.RemainigAmount,
                    Date = (DateTime.Parse(x.Date.ToString())).ToShortPersianDateString(),
                    TransactionDateTime = (DateTime.Parse(x.TransactionDateTime.ToString()).ToShortPersianDateString()),
                    CurrenyId = x.CurrenyId,
                    CurrenyName = x.CurrenyName,
                    UserId = x.UserId,
                    UserName = x.UserName,
                    TransactionType = x.TransactionType,
                    Status = (x.WithdrawAmount.Value == 0 && x.DepositAmount.Value == 0) ? "" : (x.WithdrawAmount.Value > 0) ? "بدهکار" : "طلبکار"

                }).ToList();
                return dataList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<TransactionModel> FindUserName(int SourceCustomerId)
        {
            try
            {
                var dataList = new List<TransactionModel>();
                dataList = _context.Transactions.Where(x => x.SourceCustomerId == SourceCustomerId).Include(x => x.SourceCustomer)
                 .Select(x => new TransactionModel
                 {
                     FullName = x.SourceCustomer.FirstName + " " + x.SourceCustomer.LastName,
                 }).ToList();
                return dataList;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public List<TransactionModel> GetAllTotalWithdraw(int? currencyId)
        {
            try
            {
                var dataList = new List<TransactionModel>();
                if (currencyId == null)
                {
                    dataList = FindAllReadonly(x => x.Id > 0)
                    .Include(x => x.Curreny)
                   .Select(x => new TransactionModel
                   {

                       Id = x.Id,
                       Description = x.Description,
                       DepositAmount = x.DepositAmount,
                       WithdrawAmount = x.WithdrawAmount,
                       Phone = x.SourceCustomer.Phone,
                       Mobile = x.SourceCustomer.Mobile,
                       CurrenyId = x.CurrenyId,
                       CurrenyName = x.Curreny.Name,
                       FullName = x.SourceCustomer.FirstName + " " + x.SourceCustomer.LastName,
                       SourceCustomerId = x.SourceCustomerId,


                   }).Where(x => x.WithdrawAmount > 0).ToList();
                }
                else
                {
                    dataList = FindAllReadonly(x => x.CurrenyId == currencyId)
                                 .Include(x => x.Curreny)

                                 .Select(x => new TransactionModel
                                 {
                                     Id = x.Id,
                                     Description = x.Description,
                                     DepositAmount = x.DepositAmount,
                                     WithdrawAmount = x.WithdrawAmount,
                                     Phone = x.SourceCustomer.Phone,
                                     Mobile = x.SourceCustomer.Mobile,
                                     CurrenyId = x.CurrenyId,
                                     CurrenyName = x.Curreny.Name,
                                     FullName = x.SourceCustomer.FirstName + " " + x.SourceCustomer.LastName,
                                     SourceCustomerId = x.SourceCustomerId,
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
                    Phone = x.Phone,
                    Mobile = x.Mobile,
                    CurrenyId = x.CurrenyId,
                    CurrenyName = x.CurrenyName,
                    FullName = x.FullName,
                    SourceCustomerId = x.SourceCustomerId,


                }).ToList();
                return tmpdataList;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<TransactionModel> GetAllWithdraw(int? CurrenyId, int? GroupId)
        {
            try
            {
                var dataList = new List<TransactionModel>();

                dataList = FindAllReadonly(x => x.Id > 0)
                .Include(x => x.Curreny)
               .Select(x => new TransactionModel
               {

                   Id = x.Id,
                   Description = x.Description,
                   DepositAmount = x.DepositAmount,
                   WithdrawAmount = x.WithdrawAmount,
                   Phone = x.SourceCustomer.Phone,
                   Mobile = x.SourceCustomer.Mobile,
                   CurrenyId = x.CurrenyId,
                   CurrenyName = x.Curreny.Name,
                   FullName = x.SourceCustomer.FirstName + " " + x.SourceCustomer.LastName,
                   SourceCustomerId = x.SourceCustomerId,
                   GroupName = x.SourceCustomer.Group.Name,
                   GroupId = x.SourceCustomer.Group.Id,


               }).Where(x => x.CurrenyId == CurrenyId && x.GroupId == GroupId).ToList();


                int row = 1;
                var tmpdataList = dataList.Select(x => new TransactionModel
                {
                    RowId = row++,
                    Id = x.Id,
                    Description = x.Description,
                    DepositAmount = x.DepositAmount,
                    WithdrawAmount = x.WithdrawAmount,
                    Phone = x.Phone,
                    Mobile = x.Mobile,
                    CurrenyId = x.CurrenyId,
                    CurrenyName = x.CurrenyName,
                    FullName = x.FullName,
                    SourceCustomerId = x.SourceCustomerId,
                    GroupId = x.GroupId,
                    GroupName = x.GroupName,

                }).ToList();
                return tmpdataList;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<TransactionModel> GetAllDeposit(int? currencyId)
        {
            try
            {
                var dataList = new List<TransactionModel>();
                if (currencyId == null)
                {
                    dataList = FindAllReadonly(x => x.Id > 0)
                    .Include(x => x.Curreny)
                   .Select(x => new TransactionModel
                   {

                       Id = x.Id,
                       Description = x.Description,
                       DepositAmount = x.DepositAmount,
                       WithdrawAmount = x.WithdrawAmount,
                       Phone = x.SourceCustomer.Phone,
                       Mobile = x.SourceCustomer.Mobile,
                       Date = x.Date.ToString(),
                       TransactionDateTime = x.TransactionDateTime.ToString(),
                       CurrenyId = x.CurrenyId,
                       CurrenyName = x.Curreny.Name,
                       FullName = x.SourceCustomer.FirstName + " " + x.SourceCustomer.LastName,
                       SourceCustomerId = x.SourceCustomerId,


                   }).ToList();
                }
                else
                {
                    dataList = FindAllReadonly(x => x.CurrenyId == currencyId)
                                 .Include(x => x.Curreny)

                                 .Select(x => new TransactionModel
                                 {
                                     Id = x.Id,
                                     Description = x.Description,
                                     DepositAmount = x.DepositAmount,
                                     WithdrawAmount = x.WithdrawAmount,
                                     Phone = x.SourceCustomer.Phone,
                                     Mobile = x.SourceCustomer.Mobile,
                                     CurrenyId = x.CurrenyId,
                                     CurrenyName = x.Curreny.Name,
                                     FullName = x.SourceCustomer.FirstName + " " + x.SourceCustomer.LastName,
                                     SourceCustomerId = x.SourceCustomerId,
                                 }).ToList();
                }
                int row = 1;
                var tmpdataList = dataList.Select(x => new TransactionModel
                {
                    RowId = row++,
                    Id = x.Id,
                    DepositAmount = x.DepositAmount,
                    WithdrawAmount = x.WithdrawAmount,
                    Phone = x.Phone,
                    Mobile = x.Mobile,
                    CurrenyId = x.CurrenyId,
                    CurrenyName = x.CurrenyName,
                    FullName = x.FullName,
                    SourceCustomerId = x.SourceCustomerId,


                }).ToList();
                return tmpdataList;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<TransactionModel> GetAllTotal(int? currencyId)
        {
            try
            {
                var dataList = new List<TransactionModel>();
                if (currencyId == null)
                {
                    dataList = FindAllReadonly()
                    .Include(x => x.Curreny)
                   .Select(x => new TransactionModel
                   {

                       Id = x.Id,
                       Description = x.Description,
                       DepositAmount = x.DepositAmount,
                       WithdrawAmount = x.WithdrawAmount,
                       Phone = x.SourceCustomer.Phone,
                       Mobile = x.SourceCustomer.Mobile,
                       CurrenyId = x.CurrenyId,
                       CurrenyName = x.Curreny.Name,
                       FullName = x.SourceCustomer.FirstName + " " + x.SourceCustomer.LastName,
                       SourceCustomerId = x.SourceCustomerId,


                   }).ToList();
                }
                else
                {
                    dataList = FindAllReadonly(x => x.CurrenyId == currencyId)
                                 .Include(x => x.Curreny)

                                 .Select(x => new TransactionModel
                                 {
                                     Id = x.Id,
                                     Description = x.Description,
                                     DepositAmount = x.DepositAmount,
                                     WithdrawAmount = x.WithdrawAmount,
                                     Phone = x.SourceCustomer.Phone,
                                     Mobile = x.SourceCustomer.Mobile,
                                     CurrenyId = x.CurrenyId,
                                     CurrenyName = x.Curreny.Name,
                                     FullName = x.SourceCustomer.FirstName + " " + x.SourceCustomer.LastName,
                                     SourceCustomerId = x.SourceCustomerId,
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
                    Phone = x.Phone,
                    Mobile = x.Mobile,
                    CurrenyId = x.CurrenyId,
                    CurrenyName = x.CurrenyName,
                    FullName = x.FullName,
                    SourceCustomerId = x.SourceCustomerId,


                }).ToList();
                return tmpdataList;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<TransactionModel> GetAllWithdrawCustomers(string search, int? CurrenyId, int? GroupId)
        {
            try
            {
                var dataList = new List<TransactionModel>();

                dataList = FindAllReadonly(x => x.Id > 0)
                .Include(x => x.Curreny)
               .Select(x => new TransactionModel
               {

                   Id = x.Id,
                   Description = x.Description,
                   DepositAmount = x.DepositAmount,
                   WithdrawAmount = x.WithdrawAmount,
                   Phone = x.SourceCustomer.Phone,
                   Mobile = x.SourceCustomer.Mobile,
                   CurrenyId = x.CurrenyId,
                   CurrenyName = x.Curreny.Name,
                   FullName = x.SourceCustomer.FirstName + " " + x.SourceCustomer.LastName,
                   SourceCustomerId = x.SourceCustomerId,
                   GroupName = x.SourceCustomer.Group.Name,
                   GroupId = x.SourceCustomer.Group.Id,


               }).Where(x => x.FullName.Contains(search) && x.CurrenyId == CurrenyId && x.GroupId == GroupId).ToList();


                int row = 1;
                var tmpdataList = dataList.Select(x => new TransactionModel
                {
                    RowId = row++,
                    Id = x.Id,
                    Description = x.Description,
                    DepositAmount = x.DepositAmount,
                    WithdrawAmount = x.WithdrawAmount,
                    Phone = x.Phone,
                    Mobile = x.Mobile,
                    CurrenyId = x.CurrenyId,
                    CurrenyName = x.CurrenyName,
                    FullName = x.FullName,
                    SourceCustomerId = x.SourceCustomerId,
                    GroupId = x.GroupId,
                    GroupName = x.GroupName,

                }).ToList();
                return tmpdataList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public List<TransactionModel> GetAllDepositCustomers(string search)
        {
            try
            {
                var dataList = new List<TransactionModel>();
                dataList = FindAllReadonly(x => x.DepositAmount > 0)
                .Include(x => x.Curreny)
               .Select(x => new TransactionModel
               {
                   Id = x.Id,
                   Description = x.Description,
                   DepositAmount = x.DepositAmount,
                   WithdrawAmount = x.WithdrawAmount,
                   Phone = x.SourceCustomer.Phone,
                   Mobile = x.SourceCustomer.Mobile,
                   CurrenyId = x.CurrenyId,
                   CurrenyName = x.Curreny.Name,
                   FullName = x.SourceCustomer.FirstName + " " + x.SourceCustomer.LastName,
                   SourceCustomerId = x.SourceCustomerId,
               }).Where(x => x.FullName.Contains(search)).ToList();
                int row = 1;
                var tmpdataList = dataList.Select(x => new TransactionModel
                {
                    RowId = row++,
                    Id = x.Id,
                    Description = x.Description,
                    DepositAmount = x.DepositAmount,
                    WithdrawAmount = x.WithdrawAmount,
                    Phone = x.Phone,
                    Mobile = x.Mobile,
                    CurrenyId = x.CurrenyId,
                    CurrenyName = x.CurrenyName,
                    FullName = x.FullName,
                    SourceCustomerId = x.SourceCustomerId,
                }).ToList();
                return tmpdataList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public List<TransactionModel> GetAllTotalCustomers(string search)
        {
            try
            {
                var dataList = new List<TransactionModel>();
                dataList = FindAllReadonly()
                .Include(x => x.Curreny)
               .Select(x => new TransactionModel
               {
                   Id = x.Id,
                   Description = x.Description,
                   DepositAmount = x.DepositAmount,
                   WithdrawAmount = x.WithdrawAmount,
                   Phone = x.SourceCustomer.Phone,
                   Mobile = x.SourceCustomer.Mobile,
                   CurrenyId = x.CurrenyId,
                   CurrenyName = x.Curreny.Name,
                   FullName = x.SourceCustomer.FirstName + " " + x.SourceCustomer.LastName,
                   SourceCustomerId = x.SourceCustomerId,
               }).Where(x => x.FullName.Contains(search)).ToList();
                int row = 1;
                var tmpdataList = dataList.Select(x => new TransactionModel
                {
                    RowId = row++,
                    Id = x.Id,
                    Description = x.Description,
                    DepositAmount = x.DepositAmount,
                    WithdrawAmount = x.WithdrawAmount,
                    Phone = x.Phone,
                    Mobile = x.Mobile,
                    CurrenyId = x.CurrenyId,
                    CurrenyName = x.CurrenyName,
                    FullName = x.FullName,
                    SourceCustomerId = x.SourceCustomerId,
                }).ToList();
                return tmpdataList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public List<TransactionModel> GetAllPayAndReciveCash(int? currencyId)
        {
            try
            {
                PersianCalendar pc = new PersianCalendar();
                var dataList = new List<TransactionModel>();
                if (currencyId == null)
                {
                    dataList = FindAllReadonly()
                    .Include(x => x.Curreny).Where(x => x.TransactionType == (int)TransaActionType.PayAndReciveCash && x.SourceCustomerId == 4)
                   .Select(x => new TransactionModel
                   {

                       Id = x.Id,
                       Description = x.Description,
                       DepositAmount = x.DepositAmount,
                       WithdrawAmount = x.WithdrawAmount,
                       TransactionDateTime = pc.GetYear(x.TransactionDateTime).ToString() + "/" + pc.GetMonth(x.TransactionDateTime).ToString() + "/" + pc.GetDayOfMonth(x.TransactionDateTime).ToString(),
                       CurrenyId = x.CurrenyId,
                       CurrenyName = x.Curreny.Name,
                       FullName = x.SourceCustomer.FirstName + " " + x.SourceCustomer.LastName,
                       SourceCustomerId = x.SourceCustomerId,



                   }).ToList();
                }
                else
                {
                    dataList = FindAllReadonly(x => x.TransactionType == (int)TransaActionType.PayAndReciveCash && x.SourceCustomerId == 4 && x.CurrenyId == currencyId)
                                 .Include(x => x.Curreny)

                                 .Select(x => new TransactionModel
                                 {
                                     Id = x.Id,
                                     Description = x.Description,
                                     DepositAmount = x.DepositAmount,
                                     WithdrawAmount = x.WithdrawAmount,
                                     CurrenyId = x.CurrenyId,
                                     CurrenyName = x.Curreny.Name,
                                     FullName = x.SourceCustomer.FirstName + " " + x.SourceCustomer.LastName,
                                     TransactionDateTime = pc.GetYear(x.TransactionDateTime).ToString() + "/" + pc.GetMonth(x.TransactionDateTime).ToString() + "/" + pc.GetDayOfMonth(x.TransactionDateTime).ToString(),
                                     SourceCustomerId = x.SourceCustomerId,
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
                    TransactionDateTime = x.TransactionDateTime.ToString(),
                    CurrenyId = x.CurrenyId,
                    CurrenyName = x.CurrenyName,
                    FullName = x.FullName,
                    SourceCustomerId = x.SourceCustomerId,


                }).ToList();
                return tmpdataList;
            }
            catch (Exception ex)
            {
                return null;
            }

        }


        public List<TransactionModel> GetAllPayAndReciveCashDate(string date)
        {
            try
            {
                PersianCalendar pc = new PersianCalendar();
                var dDate = date.Split('/');
                var TransactionDateTime = pc.ToDateTime(int.Parse(dDate[0]), int.Parse(dDate[1]), int.Parse(dDate[2]), 0, 0, 0, 0);
                var dataList = new List<TransactionModel>();
                dataList = FindAllReadonly()
                .Include(x => x.Curreny)
                .Where(x => x.TransactionType == (int)TransaActionType.PayAndReciveCash && x.SourceCustomerId != 4 && x.TransactionDateTime == TransactionDateTime)
               .Select(x => new TransactionModel
               {

                   Id = x.Id,
                   Description = x.Description,
                   DepositAmount = x.DepositAmount,
                   WithdrawAmount = x.WithdrawAmount,
                   TransactionDateTime = pc.GetYear(x.TransactionDateTime).ToString() + "/" + pc.GetMonth(x.TransactionDateTime).ToString() + "/" + pc.GetDayOfMonth(x.TransactionDateTime).ToString(),
                   CurrenyId = x.CurrenyId,
                   CurrenyName = x.Curreny.Name,
                   FullName = x.SourceCustomer.FirstName + " " + x.SourceCustomer.LastName,
                   SourceCustomerId = x.SourceCustomerId,




               }).ToList();


                int row = 1;
                var tmpdataList = dataList.Select(x => new TransactionModel
                {
                    RowId = row++,
                    Id = x.Id,
                    Description = x.Description,
                    DepositAmount = x.DepositAmount,
                    WithdrawAmount = x.WithdrawAmount,
                    TransactionDateTime = x.TransactionDateTime.ToString(),
                    CurrenyId = x.CurrenyId,
                    CurrenyName = x.CurrenyName,
                    FullName = x.FullName,
                    SourceCustomerId = x.SourceCustomerId,


                }).ToList();
                return tmpdataList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public List<TransactionModel> GetAllPayAndReciveBank(int? bankId)
        {
            try
            {
                PersianCalendar pc = new PersianCalendar();
                var dataList = new List<TransactionModel>();
                if (bankId == null)
                {
                    dataList = FindAllReadonly()
                    .Include(x => x.Curreny).Where(x => x.TransactionType == (int)TransaActionType.PayAndReciveBank)
                   .Select(x => new TransactionModel
                   {

                       Id = x.Id,
                       Description = x.Description,
                       DepositAmount = x.DepositAmount,
                       WithdrawAmount = x.WithdrawAmount,
                       TransactionDateTime = pc.GetYear(x.TransactionDateTime).ToString() + "/" + pc.GetMonth(x.TransactionDateTime).ToString() + "/" + pc.GetDayOfMonth(x.TransactionDateTime).ToString(),
                       CurrenyId = x.CurrenyId,
                       CurrenyName = x.Curreny.Name,
                       FullName = x.SourceCustomer.FirstName + " " + x.SourceCustomer.LastName,
                       SourceCustomerId = x.SourceCustomerId,
                       BranchCode = x.BranchCode,
                       ReceiptNumber = x.ReceiptNumber,
                       DocumentId = x.DocumentId,
                       TransactionDateTime2 = x.TransactionDateTime,

                   }).ToList();
                }
                else
                {
                    dataList = FindAllReadonly(x => x.SourceCustomerId == bankId && x.TransactionType == (int)TransaActionType.PayAndReciveBank)
                                 .Include(x => x.Curreny)

                                 .Select(x => new TransactionModel
                                 {
                                     Id = x.Id,
                                     Description = x.Description,
                                     DepositAmount = x.DepositAmount,
                                     WithdrawAmount = x.WithdrawAmount,
                                     CurrenyId = x.CurrenyId,
                                     CurrenyName = x.Curreny.Name,
                                     FullName = x.SourceCustomer.FirstName + " " + x.SourceCustomer.LastName,
                                     TransactionDateTime = pc.GetYear(x.TransactionDateTime).ToString() + "/" + pc.GetMonth(x.TransactionDateTime).ToString() + "/" + pc.GetDayOfMonth(x.TransactionDateTime).ToString(),
                                     SourceCustomerId = x.SourceCustomerId,
                                     BranchCode = x.BranchCode,
                                     ReceiptNumber = x.ReceiptNumber,
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
                    TransactionDateTime = x.TransactionDateTime2.ToFarsiFormat(),
                    CurrenyId = x.CurrenyId,
                    CurrenyName = x.CurrenyName,
                    FullName = x.FullName,
                    SourceCustomerId = x.SourceCustomerId,
                    BranchCode = x.BranchCode,
                    ReceiptNumber = x.ReceiptNumber,
                    DocumentId = x.DocumentId

                }).ToList();
                return tmpdataList;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<TransactionModel> GetAllPayAndReciveBankSearch(string date)
        {
            try
            {
                PersianCalendar pc = new PersianCalendar();
                var dDate = date.Split('/');
                var TransactionDateTime = pc.ToDateTime(int.Parse(dDate[0]), int.Parse(dDate[1]), int.Parse(dDate[2]), 0, 0, 0, 0);
                var dataList = new List<TransactionModel>();


                dataList = FindAllReadonly()
                .Include(x => x.Curreny)
               .Select(x => new TransactionModel
               {

                   Id = x.Id,
                   Description = x.Description,
                   DepositAmount = x.DepositAmount,
                   WithdrawAmount = x.WithdrawAmount,
                   TransactionDateTime = x.TransactionDateTime.ToString(),
                   TransactionDateTime2 = x.TransactionDateTime,
                   CurrenyId = x.CurrenyId,
                   CurrenyName = x.Curreny.Name,
                   FullName = x.SourceCustomer.FirstName + " " + x.SourceCustomer.LastName,
                   SourceCustomerId = x.SourceCustomerId,
                   BranchCode = x.BranchCode,
                   ReceiptNumber = x.ReceiptNumber,
                   DocumentId = x.DocumentId,
                   TransactionType = x.TransactionType


               }).Where(x => x.TransactionDateTime2 == TransactionDateTime && x.TransactionType == (int)TransaActionType.PayAndReciveBank).ToList();
                int row = 1;
                var tmpdataList = dataList.Select(x => new TransactionModel
                {
                    RowId = row++,
                    Id = x.Id,
                    Description = x.Description,
                    DepositAmount = x.DepositAmount,
                    WithdrawAmount = x.WithdrawAmount,
                    TransactionDateTime = x.TransactionDateTime2.ToFarsiFormat(),
                    CurrenyId = x.CurrenyId,
                    CurrenyName = x.CurrenyName,
                    FullName = x.FullName,
                    SourceCustomerId = x.SourceCustomerId,
                    BranchCode = x.BranchCode,
                    ReceiptNumber = x.ReceiptNumber,
                    DocumentId = x.DocumentId

                }).ToList();
                return tmpdataList;
            }


            catch (Exception ex)
            {
                return null;
            }

        }
        public List<TransactionModel> GetAllWGroupList(int? currencyId, int? groupId)
        {
            try
            {
                var dataList = new List<TransactionModel>();
                if (groupId == null || currencyId == null)
                {
                    dataList = FindAllReadonly(x => x.Id > 0)
             .Include(x => x.Curreny)
            .Select(x => new TransactionModel
            {

                Id = x.Id,
                Description = x.Description,
                DepositAmount = x.DepositAmount,
                WithdrawAmount = x.WithdrawAmount,
                CurrenyId = x.CurrenyId,
                CurrenyName = x.Curreny.Name,
                FullName = x.SourceCustomer.FirstName + " " + x.SourceCustomer.LastName,
                SourceCustomerId = x.SourceCustomerId,
                GroupId = x.SourceCustomer.GroupId,
                GroupName = x.SourceCustomer.Group.Name,
            }).ToList();

                }
                if (groupId != null)
                {
                    dataList = FindAllReadonly(x => x.Id > 0)
                            .Include(x => x.Curreny)
                           .Select(x => new TransactionModel
                           {

                               Id = x.Id,
                               Description = x.Description,
                               DepositAmount = x.DepositAmount,
                               WithdrawAmount = x.WithdrawAmount,
                               CurrenyId = x.CurrenyId,
                               CurrenyName = x.Curreny.Name,
                               FullName = x.SourceCustomer.FirstName + " " + x.SourceCustomer.LastName,
                               SourceCustomerId = x.SourceCustomerId,
                               GroupId = x.SourceCustomer.GroupId,
                               GroupName = x.SourceCustomer.Group.Name,
                           }).Where(x => x.GroupId == groupId).ToList();

                }
                if (currencyId != null)
                {
                    dataList = FindAllReadonly(x => x.Id > 0)
                            .Include(x => x.Curreny)
                           .Select(x => new TransactionModel
                           {

                               Id = x.Id,
                               Description = x.Description,
                               DepositAmount = x.DepositAmount,
                               WithdrawAmount = x.WithdrawAmount,
                               CurrenyId = x.CurrenyId,
                               CurrenyName = x.Curreny.Name,
                               FullName = x.SourceCustomer.FirstName + " " + x.SourceCustomer.LastName,
                               SourceCustomerId = x.SourceCustomerId,
                               GroupId = x.SourceCustomer.GroupId,
                               GroupName = x.SourceCustomer.Group.Name,
                           }).Where(x => x.CurrenyId == currencyId).ToList();

                }
                int row = 1;
                var tmpdataList = dataList.Select(x => new TransactionModel
                {
                    RowId = row++,
                    Id = x.Id,
                    Description = x.Description,
                    DepositAmount = x.DepositAmount,
                    WithdrawAmount = x.WithdrawAmount,
                    CurrenyId = x.CurrenyId,
                    CurrenyName = x.CurrenyName,
                    FullName = x.FullName,
                    SourceCustomerId = x.SourceCustomerId,
                    GroupId = x.GroupId,
                    GroupName = x.GroupName,


                }).ToList();
                return tmpdataList;
            }
            catch (Exception ex)
            {
                return null;
            }

        }


        public List<TransactionModel> GetAllSellAndBuyCurrency(int? currencyId)
        {
            try
            {
                PersianCalendar pc = new PersianCalendar();
                var dataList = new List<TransactionModel>();
                if (currencyId == null)
                {
                    dataList = FindAllReadonly()
                    .Include(x => x.Curreny).Where(x => x.TransactionType == (int)TransaActionType.SellCurrency || x.TransactionType == (int)TransaActionType.BuyCurrency)
                   .Select(x => new TransactionModel
                   {

                       Id = x.Id,
                       Description = x.Description,
                       DepositAmount = x.DepositAmount,
                       WithdrawAmount = x.WithdrawAmount,
                       TransactionDateTime = pc.GetYear(x.TransactionDateTime).ToString() + "/" + pc.GetMonth(x.TransactionDateTime).ToString() + "/" + pc.GetDayOfMonth(x.TransactionDateTime).ToString(),
                       CurrenyId = x.CurrenyId,
                       CurrenyName = x.Curreny.Name,
                       FullName = x.SourceCustomer.FirstName + " " + x.SourceCustomer.LastName,
                       SourceCustomerId = x.SourceCustomerId,
                       DocumentId = x.DocumentId


                   }).ToList();
                }
                else
                {
                    dataList = FindAllReadonly(x =>(x.TransactionType == (int)TransaActionType.SellCurrency || x.TransactionType == (int)TransaActionType.BuyCurrency) && x.CurrenyId == currencyId)
                                 .Include(x => x.Curreny)

                         .Select(x => new TransactionModel
                         {
                             Id = x.Id,
                             Description = x.Description,
                             DepositAmount = x.DepositAmount,
                             WithdrawAmount = x.WithdrawAmount,
                             CurrenyId = x.CurrenyId,
                             CurrenyName = x.Curreny.Name,
                             FullName = x.SourceCustomer.FirstName + " " + x.SourceCustomer.LastName,
                             TransactionDateTime = pc.GetYear(x.TransactionDateTime).ToString() + "/" + pc.GetMonth(x.TransactionDateTime).ToString() + "/" + pc.GetDayOfMonth(x.TransactionDateTime).ToString(),
                             SourceCustomerId = x.SourceCustomerId,
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
                    TransactionDateTime = x.TransactionDateTime.ToString(),
                    CurrenyId = x.CurrenyId,
                    CurrenyName = x.CurrenyName,
                    FullName = x.FullName,
                    SourceCustomerId = x.SourceCustomerId,
                    DocumentId = x.DocumentId



                }).ToList();
                return tmpdataList;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<TransactionModel> GetBalance(int? CustomerId)
        {
            try
            {
                var dataList = new List<TransactionModel>();
                var customer = _unitOfWork.Customers.FindFirstOrDefault(x => x.BankId == CustomerId).Id;
                if (CustomerId != null)
                {
                    dataList = FindAllReadonly(x => x.SourceCustomerId == customer && x.CurrenyId == 2)
                    .Include(x => x.Curreny)
                    .Include(x => x.User)
                   .Select(x => new TransactionModel
                   {

                       Id = x.Id,
                       Description = x.Description,
                       DepositAmount = x.DepositAmount,
                       WithdrawAmount = x.WithdrawAmount,
                       Date = x.Date.ToString(),
                       Date2 = x.Date,
                       TransactionDateTime2 = x.TransactionDateTime,
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
                    Date = x.Date2.ToShortPersianDateString(true),
                    TransactionDateTime = x.TransactionDateTime2.ToShortPersianDateString(),
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
    }
}