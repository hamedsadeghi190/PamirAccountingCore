using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

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
            try
            {
                var backQuery = $"BACKUP DATABASE {dataBaseName} TO DISK = '{backupPath}'; ";
                var result = unitOfWork.GetContext().Database.ExecuteSqlRaw(backQuery);

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }
       


        public void BackupDatabase(SqlConnectionStringBuilder csb, string destinationPath)
        {
            ServerConnection connection = new ServerConnection(csb.DataSource, csb.UserID, csb.Password);
            Server sqlServer = new Server(connection);

            Backup bkpDatabase = new Backup();
            bkpDatabase.Action = BackupActionType.Database;
            bkpDatabase.Database = csb.InitialCatalog;
            BackupDeviceItem bkpDevice = new BackupDeviceItem(destinationPath, DeviceType.File);
            bkpDatabase.Devices.Add(bkpDevice);
            bkpDatabase.SqlBackup(sqlServer);
            connection.Disconnect();

        }

        public bool RestoreDatabase(String databaseName, String backUpFile, String serverName)
        {
            try
            {
                ServerConnection connection = new ServerConnection(serverName);
                Server sqlServer = new Server(connection);
                Restore rstDatabase = new Restore();
                rstDatabase.Action = RestoreActionType.Database;
                rstDatabase.Database = databaseName;
                BackupDeviceItem bkpDevice = new BackupDeviceItem(backUpFile, DeviceType.File);
                rstDatabase.Devices.Add(bkpDevice);
                rstDatabase.ReplaceDatabase = true;
                rstDatabase.SqlRestore(sqlServer);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        public bool Restore(string Filepath)
        {
            try
            {
                var con = new SqlConnection(AppSetting.ConnectionString);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd1 = new SqlCommand(" ALTER DATABASE [PamirAccounting] SET SINGLE_USER WITH ROLLBACK IMMEDIATE ", con);
                cmd1.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand("USE MASTER RESTORE DATABASE [PamirAccounting] FROM DISK='" + Filepath + "' WITH REPLACE", con);
                cmd2.ExecuteNonQuery();
                SqlCommand cmd3 = new SqlCommand(" ALTER DATABASE [PamirAccounting] SET MULTI_USER", con);
                cmd3.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
