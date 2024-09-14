using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class clsItemDataAccess
    {


        public static bool GetItemInfoByID(int ID, ref string Name, ref int CategoryID, ref decimal Price, ref decimal InitialPrice, ref decimal TaxValue, ref decimal TaxRate)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT ItemName, CategoryID, Price, InitialPrice, TaxValue, TaxRate FROM Items WHERE ItemID = @ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;

                    Name = reader["ItemName"] != DBNull.Value ? (string)reader["ItemName"] : string.Empty;
                    CategoryID = reader["CategoryID"] != DBNull.Value ? Convert.ToInt32(reader["CategoryID"]) : -1;
                    Price = reader["Price"] != DBNull.Value ? Convert.ToDecimal(reader["Price"]) : 0m;  // Convert smallmoney to decimal
                    InitialPrice = reader["InitialPrice"] != DBNull.Value ? Convert.ToDecimal(reader["InitialPrice"]) : 0m;
                    TaxValue = reader["TaxValue"] != DBNull.Value ? Convert.ToDecimal(reader["TaxValue"]) : 0m;
                    TaxRate = reader["TaxRate"] != DBNull.Value ? Convert.ToDecimal(reader["TaxRate"]) : 0m;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                // Handle exception
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static int AddNewItem(string Name, int CategoryID, decimal Price)
        {
            int ItemID = -1;
            decimal TaxRate = 14.00m; // Tax rate is 14%

            decimal InitialPrice = Price / (1 + (TaxRate / 100));
            decimal TaxValue = InitialPrice * (TaxRate / 100);

            

            //decimal TaxValue = Price * (TaxRate / 100);
            //decimal InitialPrice = Price - TaxValue;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
                INSERT INTO Items (ItemName, CategoryID, Price, InitialPrice, TaxRate, TaxValue)
                 VALUES (@Name, @CategoryID, @Price, @InitialPrice, @TaxRate, @TaxValue);
                    SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@CategoryID", CategoryID);
            command.Parameters.AddWithValue("@Price", Price);
            command.Parameters.AddWithValue("@InitialPrice", InitialPrice);
            command.Parameters.AddWithValue("@TaxRate", TaxRate);
            command.Parameters.AddWithValue("@TaxValue", TaxValue);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ItemID = insertedID;
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

            return ItemID;
        }

        public static bool UpdateItem(int ID, string Name, int CategoryID, decimal Price)
        {
            int rowsAffected = 0;
            decimal TaxRate = 14.00m; // Tax rate is 14%

            decimal InitialPrice = Price / (1 + (TaxRate / 100));
            decimal TaxValue = InitialPrice * (TaxRate / 100);

            //decimal TaxValue = Price * (TaxRate / 100);
            //decimal InitialPrice = Price - TaxValue;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
        UPDATE Items 
        SET ItemName = @Name, 
            CategoryID = @CategoryID, 
            Price = @Price,
            InitialPrice = @InitialPrice,
            TaxRate = @TaxRate,
            TaxValue = @TaxValue
        WHERE ItemID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@CategoryID", CategoryID);
            command.Parameters.AddWithValue("@Price", Price);
            command.Parameters.AddWithValue("@InitialPrice", InitialPrice);
            command.Parameters.AddWithValue("@TaxRate", TaxRate);
            command.Parameters.AddWithValue("@TaxValue", TaxValue);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static DataTable GetAllItems()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
        SELECT 
            Items.ItemID, 
            Items.ItemName, 
            Categories.CategoryName, 
            Items.Price, 
            Items.InitialPrice, 
            Items.TaxValue, 
            Items.TaxRate
        FROM Items 
        INNER JOIN Categories ON Items.CategoryID = Categories.CategoryID";

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

        public static DataTable GetAllItemsWithoutAllDetails()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
                 SELECT 
                Items.ItemID, 
                Items.ItemName, 
                Categories.CategoryName, 
                Items.Price
        
                 FROM Items 
                INNER JOIN Categories ON Items.CategoryID = Categories.CategoryID";

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

        public static DataTable GetItemsByCategoryName(string categoryName)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            //    string query = @"
            //SELECT 
            //    Items.ItemID, 
            //    Items.ItemName, 
            //    Categories.CategoryName, 
            //    Items.Price,
            //    Items.InitialPrice,
            //    Items.TaxValue,
            //    Items.TaxRate

            //FROM Items 
            //INNER JOIN Categories ON Items.CategoryID = Categories.CategoryID
            //WHERE Categories.CategoryName = @CategoryName";

            string query = @"
    SELECT 
        Items.ItemID, 
        Items.ItemName, 
        Categories.CategoryName, 
        Items.Price
    FROM Items 
    INNER JOIN Categories ON Items.CategoryID = Categories.CategoryID
    WHERE Categories.CategoryName = @CategoryName";

            SqlCommand command = new SqlCommand(query, connection);

            // Add the category name as a parameter to avoid SQL injection
            command.Parameters.AddWithValue("@CategoryName", categoryName);

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

        public static bool DeleteItem(int ID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Items 
                                where ItemID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {

                connection.Close();

            }

            return (rowsAffected > 0);

        }

        public static bool IsItemExist(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Items WHERE ItemID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }


    }
}
