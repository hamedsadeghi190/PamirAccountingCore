using AutoMapper;
using PamirAccounting.Domains;
using PamirAccounting.Infrastructures;
using PamirAccounting.Models;
using PamirAccounting.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PamirAccounting.Services.Services
{
    public class DailyOperationServices : Repository<DailyOperation>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PamirContext _context;

        #region DailyOperationServices
        public DailyOperationServices(PamirContext context, UnitOfWork unitOfWork, IMapper mapper) : base(context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;

        }
        #endregion

        public List<DailyOperationModel> GetAll()
        {
            try
            {
                int row = 1;
                var daily = new List<DailyOperationModel>();
                PersianCalendar pc = new PersianCalendar();
                daily = FindAllReadonly().Select(x => new DailyOperationModel
                {
                    Id = x.Id,
                    Date = x.Date,
                    Description = x.Description,
                    Time = x.Time,
                    DocumentId = x.DocumentId,
                    TransactionId = x.TransactionId.GetValueOrDefault(),
                    UserName = x.UserName,
                    UserId = x.UserId,
                    DatePersian = pc.GetYear(x.Date).ToString() + "/" + pc.GetMonth(x.Date).ToString() + "/" + pc.GetDayOfMonth(x.Date).ToString(),
                    ActionText = x.ActionText,
                    TimePersian = x.Time.HasValue == true ? x.Time.Value.ToString(@"hh\:mm\:ss") : "",

                }).ToList();

                daily = daily.Select(x => new DailyOperationModel
                {
                    RowId = row++,
                    Id = x.Id,
                    Time = x.Time,
                    Description = x.Description,
                    DocumentId = x.DocumentId,
                    TransactionId = x.TransactionId,
                    UserName = x.UserName,
                    UserId = x.UserId,
                    DatePersian = x.DatePersian,
                    ActionText = x.ActionText,
                    TimePersian = x.TimePersian
                }).ToList();
                return daily;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
