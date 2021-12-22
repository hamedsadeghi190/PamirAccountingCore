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


        public List<TransactionModel> GetAll(int userId)
        {
            try
            {
                var dataList = FindAllReadonly(x => x.SourceCustomerId == userId)
                .Include(x => x.Curreny)
                .Include(x => x.User)
               .Select(x => new TransactionModel
               {
                   Id = x.Id,
                   Description = x.Description,
                   DepositAmount = x.DepositAmount,
                   WithdrawAmount = x.WithdrawAmount,
                   RemainigAmount = x.RemainigAmount,
                   Date = x.Date.ToString(),
                   TransactionDateTime = x.TransactionDateTime.ToString(),
                   CurrenyId = x.CurrenyId,
                   CurrenyName = x.Curreny.Name,
                   UserId = x.UserId,
                   UserName = x.User.UserName,

               }).ToList();

                dataList = dataList.Select(x => new TransactionModel
                {
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
                    Status = (x.WithdrawAmount != null) ? "بدهکار" : "طلبکار"

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