using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class clsLogsData
    {

        public static int AddNewLog(int userID, DateTime logIN, DateTime lodOut)
        {
            int logID = -1;


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
                INSERT INTO Logs (UserID, LogIn, LogOut)
                VALUES (@userID, @LogIn, @LogOut);
                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@userID", userID);
            command.Parameters.AddWithValue("@LogIn", logIN);
            command.Parameters.AddWithValue("@LogOut", lodOut);


            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    logID = insertedID;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return logID;
        }

        public static DataTable GetAllLogs()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
                         SELECT 
                         Users.UserName, 
                        Logs.LogIn, 
                        Logs.LogOut
                        FROM 
                        Logs
                        INNER JOIN 
                        Users ON Logs.UserID = Users.ID; ";


            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                // Consider using a logging framework or mechanism instead of Console.WriteLine in production code
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static DataTable GetTodaysLogs()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

           
            DateTime today = DateTime.Today;

            
            string query = @"
                            SELECT 
                            Users.UserName, 
                            Logs.LogIn, 
                            Logs.LogOut
                            FROM 
                            Logs
                            INNER JOIN 
                            Users ON Logs.UserID = Users.ID
                            WHERE 
                            CAST(Logs.LogIn AS DATE) = @TodayDate
                            OR 
                            CAST(Logs.LogOut AS DATE) = @TodayDate;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TodayDate", today);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                // Consider using a logging framework or mechanism instead of Console.WriteLine in production code
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }


    }
}
