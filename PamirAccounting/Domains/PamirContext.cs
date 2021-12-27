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
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<CurrencyAgency> CurrencyAgencies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerGroup> CustomerGroups { get; set; }
        public virtual DbSet<Header> Headers { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\sql2019;Database=PamirAccounting;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Persian_100_CI_AS_SC_UTF8");

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

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.NameEn).HasMaxLength(100);

                entity.Property(e => e.NameFa).HasMaxLength(100);
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<CurrencyAgency>(entity =>
            {
                entity.HasIndex(e => e.AgencyId, "IX_CurrencyAgencies_AgencyId");

                entity.HasIndex(e => e.DestiniationCurrenyId, "IX_CurrencyAgencies_DestiniationCurrenyId");

                entity.HasOne(d => d.Agency)
                    .WithMany(p => p.CurrencyAgencies)
                    .HasForeignKey(d => d.AgencyId)
                    .HasConstraintName("FK_CurrencyAgencies_agents");

                entity.HasOne(d => d.DestiniationCurreny)
                    .WithMany(p => p.CurrencyAgencyDestiniationCurrenies)
                    .HasForeignKey(d => d.DestiniationCurrenyId)
                    .HasConstraintName("FK_CurrencyAgencies_Currencies_source");

                entity.HasOne(d => d.SourceCurreny)
                    .WithMany(p => p.CurrencyAgencySourceCurrenies)
                    .HasForeignKey(d => d.SourceCurrenyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CurrencyAgencies_Currencies");
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

            modelBuilder.Entity<Header>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(300);

                entity.Property(e => e.Mobile).HasMaxLength(200);

                entity.Property(e => e.Phone).HasMaxLength(30);
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.Property(e => e.BackupDirectory).HasMaxLength(1000);

                entity.Property(e => e.DateCalenderType).HasDefaultValueSql("((1))");

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

                entity.Property(e => e.UnkownAmount).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Curreny)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.CurrenyId);

                entity.HasOne(d => d.DestinitionCustomer)
                    .WithMany(p => p.TransactionDestinitionCustomers)
                    .HasForeignKey(d => d.DestinitionCustomerId)
                    .HasConstraintName("FK_Transactions_Customers_dest");

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
