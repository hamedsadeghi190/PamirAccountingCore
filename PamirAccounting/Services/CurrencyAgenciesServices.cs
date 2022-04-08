using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PamirAccounting.Commons.Enums;
using PamirAccounting.Domains;
using PamirAccounting.Infrastructures;
using PamirAccounting.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PamirAccounting.Services.Services
{
    public class CurrenciesMappingServices : Repository<CurrenciesMapping>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PamirContext _context;

        #region CurrenciesMappingServices
        public CurrenciesMappingServices(PamirContext context, UnitOfWork unitOfWork, IMapper mapper) : base(context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;

        }
        #endregion

        public List<AgencyCurencyModel> GetAll()
        {
            try
            {

                var dataList = FindAllReadonly()
                    .Include(x => x.SourceCurreny)
                    .Include(x => x.DestiniationCurreny)

                    .Select(x => new AgencyCurencyModel
                    {
                        Id = x.Id,
                        SourceCurrenyName = x.SourceCurreny.Name,
                        DestiniationCurrenyName = x.DestiniationCurreny.Name,
                        ActionId = x.Action,
                        ActionName = (x.Action == (int)Settings.MappingActions.Division) ? "تقسیم" : (x.Action == (int)Settings.MappingActions.Multiplication) ? "ضرب" : "جمع",
                        RoundLimitShow = (x.RoundLimit == 10) ? "رند به تغریب 10" : (x.RoundLimit == 100) ? "رند به تغریب 100" : (x.RoundLimit == 1000) ? "رند به تغریب 1000" : (x.RoundLimit == 10000) ? "رند به تغریب 10000" : "رند عادی",
                        ExchangeRate = x.ExchangeRate,
                        RoundLimit = x.RoundLimit

                    }).ToList();
                int row = 1;
                var tmpdataList = dataList.Select(x => new AgencyCurencyModel
                {
                    RowId = row++,
                    Id = x.Id,
                    SourceCurrenyName = x.SourceCurrenyName,
                    DestiniationCurrenyName = x.DestiniationCurrenyName,
                    ActionId = x.ActionId,
                    ActionName =x.ActionName,
                    RoundLimitShow = x.RoundLimitShow,
                    ExchangeRate = x.ExchangeRate,
                    RoundLimit = x.RoundLimit

                }).ToList();
               

                return tmpdataList;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<AgencyCurencyModel> Search(string name)
        {
            try
            {

                var dataList = FindAllReadonly()
                    .Include(x => x.SourceCurreny)
                    .Include(x => x.DestiniationCurreny)

                    .Select(x => new AgencyCurencyModel
                    {
                        Id = x.Id,
                        SourceCurrenyName = x.SourceCurreny.Name,
                        DestiniationCurrenyName = x.DestiniationCurreny.Name,
                        ActionId = x.Action,
                        ActionName = (x.Action == (int)Settings.MappingActions.Division) ? "تقسیم" : (x.Action == (int)Settings.MappingActions.Multiplication) ? "ضرب" : "جمع",
                        RoundLimitShow = (x.RoundLimit == 10) ? "رند به تغریب 10" : (x.RoundLimit == 100) ? "رند به تغریب 100" : (x.RoundLimit == 1000) ? "رند به تغریب 1000" : (x.RoundLimit == 10000) ? "رند به تغریب 10000" : "رند عادی",
                        ExchangeRate = x.ExchangeRate,
                        RoundLimit = x.RoundLimit

                    }).Where(x=>x.SourceCurrenyName.Contains(name)).ToList();
                int row = 1;
                var tmpdataList = dataList.Select(x => new AgencyCurencyModel
                {
                    RowId = row++,
                    Id = x.Id,
                    SourceCurrenyName = x.SourceCurrenyName,
                    DestiniationCurrenyName = x.DestiniationCurrenyName,
                    ActionId = x.ActionId,
                    ActionName = x.ActionName,
                    RoundLimitShow = x.RoundLimitShow,
                    ExchangeRate = x.ExchangeRate,
                    RoundLimit = x.RoundLimit

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

