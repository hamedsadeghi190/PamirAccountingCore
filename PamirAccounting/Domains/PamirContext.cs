using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PamirAccounting.Domains
{
    public partial class PamirContext : DbContext
    {
        public PamirContext()
        {
        }

        public PamirContext(DbContextOptions<PamirContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agency> Agencies { get; set; }
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<Cheque> Cheques { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<CurrenciesMapping> CurrenciesMappings { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerGroup> CustomerGroups { get; set; }
        public virtual DbSet<DailyOperation> DailyOperations { get; set; }
        public virtual DbSet<Draft> Drafts { get; set; }
        public virtual DbSet<Header> Headers { get; set; }
        public virtual DbSet<RealBank> RealBanks { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserInRole> UserInRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-DHSQIEN\\SQL2019;Database=PamirAccounting;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Persian_100_CI_AI");

            modelBuilder.Entity<Agency>(entity =>
            {
                entity.HasIndex(e => e.CurrenyId, "IX_Agencies_CurrenyId");

                entity.Property(e => e.Active)
                    .HasDefaultValueSql("((1))")
                    .HasComment("فعال یا غیر");

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.Dsc).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.NameEn).HasMaxLength(150);

                entity.Property(e => e.OrderType).HasDefaultValueSql("((1))");

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.HasOne(d => d.Curreny)
                    .WithMany(p => p.Agencies)
                    .HasForeignKey(d => d.CurrenyId)
                    .HasConstraintName("FK_Agents_Currencies");
            });

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.HasIndex(e => e.CountryId, "IX_Banks_CountryId");

                entity.Property(e => e.AccountNumber).HasMaxLength(100);

                entity.Property(e => e.BranchName).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.BaseCurrency)
                    .WithMany(p => p.Banks)
                    .HasForeignKey(d => d.BaseCurrencyId)
                    .HasConstraintName("FK_Banks_Currencies");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Banks)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_Banks_Countries");
            });

            modelBuilder.Entity<Cheque>(entity =>
            {
                entity.Property(e => e.AssignmentDate).HasColumnType("datetime");

                entity.Property(e => e.BankAccountNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BankName).HasMaxLength(50);

                entity.Property(e => e.BargashtDate).HasColumnType("datetime");

                entity.Property(e => e.BranchName).HasMaxLength(1000);

                entity.Property(e => e.ChequeNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.IssueDate).HasColumnType("datetime");

                entity.Property(e => e.OdatDate).HasColumnType("datetime");

                entity.Property(e => e.PassDate).HasColumnType("datetime");

                entity.Property(e => e.RegisterDateTime).HasColumnType("datetime");

                entity.Property(e => e.VosoolDate).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Cheques)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cheques_Customers");

                entity.HasOne(d => d.RealBank)
                    .WithMany(p => p.Cheques)
                    .HasForeignKey(d => d.RealBankId)
                    .HasConstraintName("FK_Cheques_RealBanks");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.Dsc).HasMaxLength(1000);

                entity.Property(e => e.FatherName).HasMaxLength(200);

                entity.Property(e => e.FirstName).HasMaxLength(200);

                entity.Property(e => e.LastName).HasMaxLength(200);

                entity.Property(e => e.Mobile).HasMaxLength(20);

                entity.Property(e => e.Phone).HasMaxLength(20);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.NameEn).HasMaxLength(100);

                entity.Property(e => e.NameFa).HasMaxLength(100);
            });

            modelBuilder.Entity<CurrenciesMapping>(entity =>
            {
                entity.ToTable("CurrenciesMapping");

                entity.HasIndex(e => e.DestiniationCurrenyId, "IX_CurrencyAgencies_DestiniationCurrenyId");

                entity.HasOne(d => d.DestiniationCurreny)
                    .WithMany(p => p.CurrenciesMappingDestiniationCurrenies)
                    .HasForeignKey(d => d.DestiniationCurrenyId)
                    .HasConstraintName("FK_CurrencyAgencies_Currencies_source");

                entity.HasOne(d => d.SourceCurreny)
                    .WithMany(p => p.CurrenciesMappingSourceCurrenies)
                    .HasForeignKey(d => d.SourceCurrenyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CurrencyAgencies_Currencies");
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.CountryId, "IX_Customers_CountryId");

                entity.HasIndex(e => e.CreditCurrencyId, "IX_Customers_CreditCurrencyId");

                entity.HasIndex(e => e.GroupId, "IX_Customers_GroupId");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.Dsc).HasMaxLength(1000);

                entity.Property(e => e.FirstName).HasMaxLength(200);

                entity.Property(e => e.LastName).HasMaxLength(200);

                entity.Property(e => e.Mobile).HasMaxLength(30);

                entity.Property(e => e.NationalCode).HasMaxLength(30);

                entity.Property(e => e.Phone).HasMaxLength(30);

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.BankId)
                    .HasConstraintName("FK_Customers_Banks");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_Customers_Contries_CountryId");

                entity.HasOne(d => d.CreditCurrency)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CreditCurrencyId)
                    .HasConstraintName("FK_Customers_Currencies");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_Customers_CustomerGroups");
            });

            modelBuilder.Entity<CustomerGroup>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<DailyOperation>(entity =>
            {
                entity.Property(e => e.ActionText).HasMaxLength(30);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(3000);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.DailyOperations)
                    .HasForeignKey(d => d.TransactionId)
                    .HasConstraintName("FK_DailyOperations_Transactions");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DailyOperations)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DailyOperations_Users");
            });

            modelBuilder.Entity<Draft>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.ExtraDescription).HasMaxLength(500);

                entity.Property(e => e.FatherName).HasMaxLength(250);

                entity.Property(e => e.OtherNumber).HasMaxLength(50);

                entity.Property(e => e.PayPlace).HasMaxLength(150);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.Reciver).HasMaxLength(250);

                entity.Property(e => e.RelatedDraftId).HasColumnName("RelatedDraftID");

                entity.Property(e => e.RunningDesc).HasMaxLength(500);

                entity.Property(e => e.Sender).HasMaxLength(250);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Tazkare).HasMaxLength(50);

                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

                entity.HasOne(d => d.Agency)
                    .WithMany(p => p.Drafts)
                    .HasForeignKey(d => d.AgencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Drafts_Agencies");

                entity.HasOne(d => d.ConvertedCurrency)
                    .WithMany(p => p.DraftConvertedCurrencies)
                    .HasForeignKey(d => d.ConvertedCurrencyId)
                    .HasConstraintName("FK_Drafts_Currencies_ConvertedCurenncy");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Drafts)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Drafts_Customers");

                entity.HasOne(d => d.DepositCurrency)
                    .WithMany(p => p.DraftDepositCurrencies)
                    .HasForeignKey(d => d.DepositCurrencyId)
                    .HasConstraintName("FK_Drafts_Currencies_DepositCurreny");

                entity.HasOne(d => d.RelatedDraft)
                    .WithMany(p => p.InverseRelatedDraft)
                    .HasForeignKey(d => d.RelatedDraftId);

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.Drafts)
                    .HasForeignKey(d => d.TransactionId)
                    .HasConstraintName("FK_Drafts_Transactions");

                entity.HasOne(d => d.TypeCurrency)
                    .WithMany(p => p.DraftTypeCurrencies)
                    .HasForeignKey(d => d.TypeCurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Drafts_Currencies_typeCurrency");
            });

            modelBuilder.Entity<Header>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(300);

                entity.Property(e => e.Mobile).HasMaxLength(200);

                entity.Property(e => e.Phone).HasMaxLength(30);
            });

            modelBuilder.Entity<RealBank>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Form)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(500);
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.Property(e => e.BackupDirectory).HasMaxLength(1000);

                entity.Property(e => e.DateCalenderType).HasDefaultValueSql("((1))");

                entity.Property(e => e.FlashBackupDirectory).HasMaxLength(1000);

                entity.Property(e => e.Language).HasMaxLength(5);

                entity.HasOne(d => d.BaseCurency)
                    .WithMany(p => p.Settings)
                    .HasForeignKey(d => d.BaseCurencyId)
                    .HasConstraintName("FK_Settings_Currencies");

                entity.HasOne(d => d.CostsAccount)
                    .WithMany(p => p.SettingCostsAccounts)
                    .HasForeignKey(d => d.CostsAccountId)
                    .HasConstraintName("FK_Settings_Customers");

                entity.HasOne(d => d.NotRunnedRemittance)
                    .WithMany(p => p.SettingNotRunnedRemittances)
                    .HasForeignKey(d => d.NotRunnedRemittanceId)
                    .HasConstraintName("FK_Settings_Customers1");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasIndex(e => e.CurrenyId, "IX_Transactions_CurrenyId");

                entity.HasIndex(e => e.UserId, "IX_Transactions_UserId");

                entity.Property(e => e.DocumentId)
                    .HasColumnName("DocumentID")
                    .HasComment("شماره سند");

                entity.Property(e => e.DoubleTransactionId).HasColumnName("DoubleTransactionID");

                entity.Property(e => e.OriginalTransactionId).HasColumnName("OriginalTransactionID");

                entity.Property(e => e.UnkownAmount).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Curreny)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.CurrenyId);

                entity.HasOne(d => d.DestinitionCustomer)
                    .WithMany(p => p.TransactionDestinitionCustomers)
                    .HasForeignKey(d => d.DestinitionCustomerId)
                    .HasConstraintName("FK_Transactions_Customers_DestinitionCustomer");

                entity.HasOne(d => d.DoubleTransaction)
                    .WithMany(p => p.InverseDoubleTransaction)
                    .HasForeignKey(d => d.DoubleTransactionId)
                    .HasConstraintName("FK_Transactions_Transactions_Double");

                entity.HasOne(d => d.SourceCustomer)
                    .WithMany(p => p.TransactionSourceCustomers)
                    .HasForeignKey(d => d.SourceCustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transactions_Customers_source");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transactions_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FirstName).HasMaxLength(150);

                entity.Property(e => e.LastName).HasMaxLength(150);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.PasswordSalt).HasMaxLength(150);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Agent)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.AgentId)
                    .HasConstraintName("FK_Users_Agencies");

                entity.HasOne(d => d.Curreny)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CurrenyId)
                    .HasConstraintName("FK_Users_Currencies");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Users_Customers");
            });

            modelBuilder.Entity<UserInRole>(entity =>
            {
                entity.ToTable("UserInRole");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserInRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserInRole_UserInRole");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserInRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserInRole_Users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
