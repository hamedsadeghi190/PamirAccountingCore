using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace PamirAccounting.Services
{
    public class BackupService
    {
        UnitOfWork unitOfWork;
        public BackupService()
        {
            unitOfWork = new UnitOfWork();
        }
        public bool Backup(string dataBaseName, string backupPath)
        {
            var backQuery = $"BACKUP DATABASE {dataBaseName}1 TO DISK = '{backupPath}'; ";
            var result = unitOfWork.GetContext().Database.ExecuteSqlRaw(backQuery);

            return (result > 0) ? true : false;
        }

    }
}
