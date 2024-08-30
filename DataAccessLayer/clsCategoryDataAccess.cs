using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class clsCategoryDataAccess
    {

        public static bool GetCategoryInfoByID(int ID, ref string Name)

        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Categories WHERE CategoryID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    Name = (string)reader["CategoryName"];
                    ID = (int)reader["CategoryID"];
                   


                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

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

        public static bool GetCategoryInfoByName(string CategoryName, ref int ID)
                                        
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Categories WHERE CategoryName = @CategoryName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CategoryName", CategoryName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    ID = (int)reader["CategoryID"];

                    if (reader["CategoryName"] != DBNull.Value)
                    {
                        CategoryName = (string)reader["CategoryName"];
                    }
                    else
                    {
                        CategoryName = "";
                    }



                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

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

        public static int AddNewCategory(string Name)

        {
            //this function will return the new ItemID if succeeded and -1 if not.
            int ID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Categories (CategoryName)
                             VALUES (@CategoryName);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CategoryName", Name);
       
         

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ID = insertedID;
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


            return ID;
        }

        public static bool UpdateCategory(int ID, string Name)

        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update Categories 
                            set CategoryName = @Name
                               
                                where CategoryID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@Name", Name);


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

        public static DataTable GetAllCategories()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Categories";

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
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static bool DeleteCategory(int ID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Categories
                                where CategoryID = @ID";

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

        public static bool IsCategoryExist(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Categories WHERE CategoryID = @ID";

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

        public static int GetCategoryIDByName(string categoryName)
        {
            int categoryID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT CategoryID FROM Categories WHERE CategoryName = @CategoryName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CategoryName", categoryName);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    categoryID = Convert.ToInt32(result);
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

            return categoryID;
        }

        public static int GetCountOfOrdersByCategory(string categoryName)
        {
            int orderCount = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                //string query = @"
                // SELECT COUNT(*)
                // FROM Orders
                // INNER JOIN OrderItems ON Orders.OrderID = OrderItems.OrderID
                // INNER JOIN Items ON OrderItems.ItemID = Items.ItemID
                // INNER JOIN Categories ON Items.CategoryID = Categories.CategoryID
                //WHERE Categories.CategoryName = @CategoryName
                //AND Orders.Total > 0";  // Exclude orders with a total of 0


                string query = @"
            SELECT SUM(OrderItems.Quantity)
            FROM Orders
            INNER JOIN OrderItems ON Orders.OrderID = OrderItems.OrderID
            INNER JOIN Items ON OrderItems.ItemID = Items.ItemID
            INNER JOIN Categories ON Items.CategoryID = Categories.CategoryID
            WHERE Categories.CategoryName = @CategoryName
            AND Orders.Total > 0";  // Exclude orders with a total of 0


                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CategoryName", categoryName);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        orderCount = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return orderCount;
        }

        public static int GetCountOfOrdersByCategoryAndDateRange(string categoryName, DateTime startDate, DateTime endDate)
        {
            int orderCount = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {


                //string query = @"
                //        SELECT COUNT(*)
                //        FROM Orders
                //        INNER JOIN OrderItems ON Orders.OrderID = OrderItems.OrderID
                //        INNER JOIN Items ON OrderItems.ItemID = Items.ItemID
                //        INNER JOIN Categories ON Items.CategoryID = Categories.CategoryID
                //        WHERE Categories.CategoryName = @CategoryName
                //        AND Orders.Total > 0  -- Exclude free orders
                //        AND CAST(Orders.Date AS DATE) >= @StartDate  -- Filter by date range
                //        AND CAST(Orders.Date AS DATE) <= @EndDate";


                string query = @"
            SELECT SUM(OrderItems.Quantity)
            FROM Orders
            INNER JOIN OrderItems ON Orders.OrderID = OrderItems.OrderID
            INNER JOIN Items ON OrderItems.ItemID = Items.ItemID
            INNER JOIN Categories ON Items.CategoryID = Categories.CategoryID
            WHERE Categories.CategoryName = @CategoryName
            AND Orders.Total > 0  -- Exclude free orders
            AND CAST(Orders.Date AS DATE) >= @StartDate  -- Filter by date range
            AND CAST(Orders.Date AS DATE) <= @EndDate";



                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CategoryName", categoryName);
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        orderCount = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return orderCount;
        }





    }
}
