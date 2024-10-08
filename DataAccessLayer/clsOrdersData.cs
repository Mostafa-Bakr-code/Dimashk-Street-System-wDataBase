﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;


namespace DataAccessLayer
{
    public class clsOrdersData
    {

        public static bool GetOrderInfoByID(int ID, ref DateTime date, ref decimal Total, ref int serialNumber)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Orders WHERE OrderID = @ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", ID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        isFound = true;

                        ID = (int)reader["OrderID"];
                        date = (DateTime)reader["Date"];
                        Total = (decimal)reader["Total"];
                        serialNumber = reader["SerialNumber"] != DBNull.Value ? (int)reader["SerialNumber"] : 0;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    isFound = false;
                }
            }

            return isFound;
        }

        public static int AddNewOrder(DateTime date, decimal Total, int serialNumber, string activeUser)
        {
            int ID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
            INSERT INTO Orders (Date, Total, SerialNumber, ActiveUser)
            VALUES (@date, @Total, @serialNumber, @activeUser);
            SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@Total", Total);
                command.Parameters.AddWithValue("@serialNumber", serialNumber);
                command.Parameters.AddWithValue("@activeUser", activeUser);

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
            }

            return ID;
        }

        public static int GetNextSerialNumber(DateTime date)
        {
            int serialNumber = 1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
            SELECT ISNULL(MAX(SerialNumber), 0) + 1 
            FROM Orders 
            WHERE CAST(Date AS DATE) = @date";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@date", date.Date);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        serialNumber = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return serialNumber;
        }

        public static void UpdateOrderTotal(int OrderID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            
                try
                {
                    connection.Open();

                    string updateOrderTotalQuery = @"UPDATE Orders 
                                             SET Total = (SELECT SUM(TotalItemsPrice) 
                                                          FROM OrderItems 
                                                          WHERE OrderID = @OrderID)
                                             WHERE OrderID = @OrderID";

                    SqlCommand updateCommand = new SqlCommand(updateOrderTotalQuery, connection);
                    updateCommand.Parameters.AddWithValue("@OrderID", OrderID);
                    updateCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            
        }

        public static bool UpdateOrders(int ID, DateTime date, decimal Total)

        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update Orders 
                            set Date = @date,
                                Total = @Total
                               
                                where OrderID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@date", date);
            command.Parameters.AddWithValue("@Total", Total);


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

        public static DataTable GetAllOrders()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Orders";

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

        public static DataTable GetOrdersByDateRange(DateTime startDate, DateTime endDate)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            
            string query = @"
        SELECT * 
        FROM Orders
        WHERE CAST(Date AS DATE) BETWEEN @startDate AND @endDate;";

            SqlCommand command = new SqlCommand(query, connection);

            // Add parameters to prevent SQL injection and safely pass the date range
            command.Parameters.AddWithValue("@startDate", startDate);
            command.Parameters.AddWithValue("@endDate", endDate);

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
                // Consider using a logging framework instead of commenting out the error handling
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static bool DeleteOrder(int ID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Orders
                                where OrderID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {

                connection.Close();

            }

            return (rowsAffected > 0);

        }

        public static bool IsOrderExist(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Orders WHERE OrderID = @ID";

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
                Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static decimal GetTotalForAllOrders()
        {
            decimal total = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT SUM(Total) 
                     FROM Orders";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    total = Convert.ToDecimal(result);
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

            return total;
        }

        public static decimal GetTotalByDateRange(DateTime startDate, DateTime endDate)
        {
            decimal total = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT SUM(Total) 
                     FROM Orders 
                     WHERE CAST([Date] AS DATE) BETWEEN @startDate AND @endDate";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@startDate", startDate.Date); // Ensure the time part is ignored
            command.Parameters.AddWithValue("@endDate", endDate.Date);     // Ensure the time part is ignored

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    total = Convert.ToDecimal(result);
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

            return total;
        }

        public static int GetTotalNumberOfOrders()
        {
            int orderCount = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT COUNT(*) FROM Orders";

                SqlCommand command = new SqlCommand(query, connection);

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

        public static int GetTotalNumberOfOrdersByDateRange(DateTime startDate, DateTime endDate)
        {
            int orderCount = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT COUNT(*) 
                         FROM Orders 
                         WHERE CAST([Date] AS DATE) BETWEEN @startDate AND @endDate";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@startDate", startDate.Date); // Ensure the time part is ignored
                command.Parameters.AddWithValue("@endDate", endDate.Date);     // Ensure the time part is ignored

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

        public static DateTime GetEarliestOrderDate()
        {
            DateTime earliestDate = DateTime.MaxValue;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT MIN([Date]) FROM Orders";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    earliestDate = Convert.ToDateTime(result);
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

            return earliestDate;
        }

        public static DateTime GetLatestOrderDate()
        {
            DateTime latestDate = DateTime.MinValue;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT MAX([Date]) FROM Orders";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    latestDate = Convert.ToDateTime(result);
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

            return latestDate;
        }

        public static decimal GetTotalOfFreeOrders()
        {
            decimal totalFreeAmount = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
            SELECT SUM(OrderItems.TotalItemsPrice)
            FROM OrderItems
            INNER JOIN Orders ON OrderItems.OrderID = Orders.OrderID
            WHERE Orders.Total = 0";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        totalFreeAmount = Convert.ToDecimal(result);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return totalFreeAmount;
        }

        public static decimal GetTotalOfFreeOrdersByDateRange(DateTime startDate, DateTime endDate)
        {
            decimal totalFreeAmount = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
            SELECT SUM(OrderItems.TotalItemsPrice)
            FROM OrderItems
            INNER JOIN Orders ON OrderItems.OrderID = Orders.OrderID
            WHERE Orders.Total = 0
            AND CAST(Orders.Date AS DATE) BETWEEN @StartDate AND @EndDate";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StartDate", startDate.Date); // Ensure the time part is ignored
                command.Parameters.AddWithValue("@EndDate", endDate.Date);     // Ensure the time part is ignored

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        totalFreeAmount = Convert.ToDecimal(result);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return totalFreeAmount;
        }

        public static int GetCountOfFreeOrders()
        {
            int countFreeOrders = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                    SELECT COUNT(*)
                     FROM Orders
                        WHERE Total = 0";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        countFreeOrders = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return countFreeOrders;
        }

        public static int GetCountOfFreeOrdersByDateRange(DateTime startDate, DateTime endDate)
        {
            int countFreeOrders = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                            SELECT COUNT(*)
                             FROM Orders
                             WHERE Total = 0
                             AND CAST(Date AS DATE) BETWEEN @StartDate AND @EndDate";
    
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StartDate", startDate.Date);
                command.Parameters.AddWithValue("@EndDate", endDate.Date);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        countFreeOrders = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return countFreeOrders;
        }

        public static decimal GetTotalTaxValueByDateRange(DateTime startDate, DateTime endDate)
        {
            decimal total = GetTotalByDateRange(startDate, endDate);

            decimal initialPrice = total / 1.14m;

            decimal taxValue = initialPrice * 0.14M; // 14% tax rate

            return taxValue;
        }

        public static decimal GetTotalTaxValueForAllOrders()
        {
            decimal total = GetTotalForAllOrders();

            decimal initialPrice = total / 1.14m;

            decimal taxValue = initialPrice * 0.14M; // 14% tax rate

            return taxValue;
        }

        public static (decimal InitialPrice, decimal TaxValue) GetInitialPriceAndTaxValueForOrder(int orderId)
        {

            decimal initialPrice = 0;
            decimal taxValue = 0;
            decimal totalItemsPriceWithTax = 0;
            const decimal taxRate = 14M; // 14%



            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
            SELECT SUM(TotalItemsPrice) 
            FROM OrderItems
            WHERE OrderID = @orderId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@orderId", orderId);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        totalItemsPriceWithTax = Convert.ToDecimal(result);

                        // Calculate tax value and initial price

                         initialPrice = totalItemsPriceWithTax / (1 + (taxRate / 100));
                         taxValue = initialPrice * (taxRate / 100);

                        //taxValue = totalItemsPriceWithTax * taxRate;
                        //initialPrice = totalItemsPriceWithTax - taxValue;


                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return (initialPrice, taxValue);

        }




    }
}
