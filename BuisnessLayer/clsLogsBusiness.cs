using System;
using System.Data;
using DataAccessLayer;

namespace BuisnessLayer
{
    public class clsLogsBusiness
    {

        public int logID { set; get; }
        public int userID { set; get; }
        public DateTime LogIn { set; get; }
        public DateTime LogOut { set; get; }


        public clsLogsBusiness()

        {
            this.logID = -1;
            this.userID = -1;
            this.LogIn = DateTime.Now;
            this.LogOut = DateTime.Now;

        }


        public static int AddNewLog(int userID, DateTime logIN, DateTime lodOut)
        {
            return clsLogsData.AddNewLog(userID, logIN, lodOut);
        }

        public static DataTable GetAllLogs()
        {
            return clsLogsData.GetAllLogs();
        }

        public static DataTable GetTodaysLogs()
        {
            return clsLogsData.GetTodaysLogs();
        }

    }
}
