using AutoMapper;
using PamirAccounting.Domains;
using PamirAccounting.Infrastructures;
using PamirAccounting.Mapper;
using PamirAccounting.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamirAccounting.Services
{
    public class UnitOfWork
    {
        #region props 
        private readonly PamirContext _context;
        private readonly IMapper _mapper;
        #endregion

        #region custrator
        public UnitOfWork()
        {
            var mapCfg = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });
            _mapper = mapCfg.CreateMapper();

            _context = new PamirContext();
        }
        #endregion

        #region SaveChanges
        public void SaveChanges()
        {
            //_context.ApplyCorrectYeKe();
            _context.SaveChanges();
        }
        #endregion

        #region GetContext
        public PamirContext GetContext()
        {
            return _context;
        }
        #endregion

        #region Currency
        private IRepository<Currency> _currencies;

        public IRepository<Currency> Currencies
        {
            get { return _currencies = _currencies ?? new CurrencyServices(_context, this, _mapper); }
        }
        public CurrencyServices CurrencyServices => (CurrencyServices)Currencies;

        #endregion

        #region CustomerGroup
        private IRepository<CustomerGroup> _customerGroup;

        public IRepository<CustomerGroup> CustomerGroups
        {
            get { return _customerGroup = _customerGroup ?? new CustomerGroupServices(_context, this, _mapper); }
        }
        public CustomerGroupServices CustomerGroupServices => (CustomerGroupServices)CustomerGroups;

        #endregion

        #region Country
        private IRepository<Country> _countries;

        public IRepository<Country> Countries
        {
            get { return _countries = _countries ?? new CountryServices(_context, this, _mapper); }
        }
        public CountryServices CountryServices => (CountryServices)Countries;

        #endregion

        #region Bank
        private IRepository<Bank> _banks;

        public IRepository<Bank> Banks
        {
            get { return _banks = _banks ?? new BankServices(_context, this, _mapper); }
        }
        public BankServices BankServices => (BankServices)Banks;

        #endregion

        #region Agency

        private IRepository<Agency> _agency;

        public IRepository<Agency> Agencies
        {
            get { return _agency = _agency ?? new AgencyServices(_context, this, _mapper); }
        }
        public AgencyServices AgencyServices => (AgencyServices)Agencies;
        #endregion

        #region CurrenciesMappingServices

        private IRepository<CurrenciesMapping> _currenciesMappings;

        public IRepository<CurrenciesMapping> CurrenciesMappings
        {
            get { return _currenciesMappings = _currenciesMappings ?? new CurrenciesMappingServices(_context, this, _mapper); }
        }
        public CurrenciesMappingServices CurrenciesMappingServices => (CurrenciesMappingServices)CurrenciesMappings;
        #endregion

        #region Header

        private IRepository<Header> _header;

        public IRepository<Header> Headers
        {
            get { return _header = _header ?? new HeaderServices(_context, this, _mapper); }
        }
        public HeaderServices HeaderServices => (HeaderServices)Headers;
        #endregion

        #region Customer

        private IRepository<Customer> _Customer;

        public IRepository<Customer> Customers
        {
            get { return _Customer = _Customer ?? new CustomerServices(_context, this, _mapper); }
        }
        public CustomerServices CustomerServices => (CustomerServices)Customers;
        #endregion

        #region SettingServices

        private IRepository<Setting> _Setting;

        public IRepository<Setting> Setting
        {
            get { return _Setting = _Setting ?? new SettingServices(_context, this, _mapper); }
        }
        public SettingServices SettingServices => (SettingServices)Setting;
        #endregion

        #region UserServices

        private IRepository<User> _Users;

        public IRepository<User> Users
        {
            get { return _Users = _Users ?? new UserServices(_context, this, _mapper); }
        }
        public UserServices UserServices => (UserServices)Users;
        #endregion

        #region TransactionServices

        private IRepository<Transaction> _Transactions;

        public IRepository<Transaction> Transactions
        {
            get { return _Transactions = _Transactions ?? new TransactionServices(_context, this, _mapper); }
        }
        public TransactionServices TransactionServices => (TransactionServices)Transactions;
        #endregion


        #region ContactServices

        private IRepository<Contact> _Contacts;

        public IRepository<Contact> Contacts
        {
            get { return _Contacts = _Contacts ?? new ContactServices(_context, this, _mapper); }
        }
        public ContactServices ContactServices => (ContactServices)Contacts;
        #endregion

        #region DraftsServices

        private IRepository<Draft> _Drafts;

        public IRepository<Draft> Drafts
        {
            get { return _Drafts = _Drafts ?? new DraftsServices(_context, this, _mapper); }
        }
        public DraftsServices DraftsServices => (DraftsServices)Drafts;
        #endregion

        #region RealBankServices

        private IRepository<RealBank> _RealBanks;

        public IRepository<RealBank> RealBanks
        {
            get { return _RealBanks = _RealBanks ?? new RealBankServices(_context, this, _mapper); }
        }
        public RealBankServices RealBankServices => (RealBankServices)RealBanks;
        #endregion

        #region ChequeServices

        private IRepository<Cheque> _Cheque;

        public IRepository<Cheque> Cheque
        {
            get { return _Cheque = _Cheque ?? new ChequeServices(_context, this, _mapper); }
        }
        public ChequeServices ChequeServices => (ChequeServices)Cheque;
        #endregion

        #region DailyOperationServices
        private IRepository<DailyOperation> _dailyOpration;

        public IRepository<DailyOperation> DailyOperations
        {
            get { return _dailyOpration = _dailyOpration ?? new DailyOperationServices(_context, this, _mapper); }
        }
        public DailyOperationServices DailyOperationServices => (DailyOperationServices)DailyOperations;

        #endregion

        #region RoleServices
        private IRepository<Role> _role;

        public IRepository<Role> Role
        {
            get { return _role = _role ?? new RolesServices(_context, this, _mapper); }
        }
        public RolesServices RolesServices => (RolesServices)Role;

        #endregion

        #region UserInRoleServices
        private IRepository<UserInRole> _userInRole;

        public IRepository<UserInRole> UserInRole
        {
            get { return _userInRole = _userInRole ?? new UserInRoleServices(_context, this, _mapper); }
        }
        public UserInRoleServices   UserInRoleServices => (UserInRoleServices)Role;

        #endregion
    }
}
