using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class clsSettings
    {

        public static string GetSettingValue(string key)
        {
            string settingValue = null;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT [Value] FROM Settings WHERE [Key] = @key";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@key", key);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    settingValue = result.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching setting value: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return settingValue;
        }



    }
}
