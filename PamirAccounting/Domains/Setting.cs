using System;
using System.Collections.Generic;

#nullable disable

namespace PamirAccounting.Domains
{
    public partial class Setting
    {
        public int Id { get; set; }
        public int? BaseCurencyId { get; set; }
        public string BackupDirectory { get; set; }
        public bool PasswordRequired { get; set; }
        public double? ProfitPercent { get; set; }
        public byte DateCalenderType { get; set; }
        public string Language { get; set; }
        public int? CostsAccountId { get; set; }
        public int? NotRunnedRemittanceId { get; set; }
        public string FlashBackupDirectory { get; set; }

        public virtual Currency BaseCurency { get; set; }
        public virtual Customer CostsAccount { get; set; }
        public virtual Customer NotRunnedRemittance { get; set; }
    }
}
