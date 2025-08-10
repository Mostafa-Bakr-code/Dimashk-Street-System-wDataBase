using System;
using System.Data;
using System.Data.SqlClient;


namespace DataAccessLayer
{
    public class clsOrderItemsData
    {

        public static bool GetOrderItemInfoByID(int ID,ref int OrderID, ref int itemID, ref int quantity, ref decimal price, ref decimal totalItemsPrice)

        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM OrderItems WHERE ID = @ID";

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

                    OrderID = (int)reader["OrderID"];
                    itemID = (int)reader["ItemID"];
                    quantity = (int)reader["Quantity"];
                    price = (decimal)reader["Price"];
                    totalItemsPrice = (decimal)reader["TotalItemsPrice"];


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

        public static int AddNewOrderItems(int OrderID, int itemID, int quantity)

        {
            
            int ID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            try
            {
                connection.Open();

                // Step 1: Retrieve the price from the Items table
                string getPriceQuery = "SELECT Price FROM Items WHERE ItemID = @itemID";
                SqlCommand getPriceCommand = new SqlCommand(getPriceQuery, connection);
                getPriceCommand.Parameters.AddWithValue("@itemID", itemID);

                object priceResult = getPriceCommand.ExecuteScalar();
                if (priceResult == null)
                {
                    throw new Exception("Item not found.");
                }

                decimal price = (decimal)priceResult;

                // Calculate totalItemsPrice
                decimal totalItemsPrice = price * quantity;

                // Step 2: Insert the new OrderItem
                string query = @"INSERT INTO OrderItems (OrderID, ItemID, Quantity, Price, TotalItemsPrice)
                         VALUES (@OrderID, @itemID, @quantity, @price, @totalItemsPrice);
                         SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderID", OrderID);
                command.Parameters.AddWithValue("@itemID", itemID);
                command.Parameters.AddWithValue("@quantity", quantity);
                command.Parameters.AddWithValue("@price", price);
                command.Parameters.AddWithValue("@totalItemsPrice", totalItemsPrice);

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ID = insertedID;
                }

                clsOrdersData.UpdateOrderTotal(OrderID);
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

        public static bool UpdateOrderItem(int ID, int OrderID, int itemID, int quantity, decimal price, decimal totalItemsPrice, string comment)

        {

            bool updateSuccessful = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            // Retrieve the price from the Items table
            string getPriceQuery = "SELECT Price FROM Items WHERE ItemID = @itemID";
            SqlCommand getPriceCommand = new SqlCommand(getPriceQuery, connection);
            getPriceCommand.Parameters.AddWithValue("@itemID", itemID);

            decimal itemPrice = 0;
            try
            {
                connection.Open();

                object priceResult = getPriceCommand.ExecuteScalar();
                if (priceResult == null)
                {
                    throw new Exception("Item not found.");
                }

                itemPrice = (decimal)priceResult;

                // Calculate totalItemsPrice based on the retrieved price
                totalItemsPrice = itemPrice * quantity;

                // Update the OrderItem
                string updateQuery = @"UPDATE OrderItems
                               SET OrderID = @OrderID, 
                                   ItemID = @ItemID, 
                                   Quantity = @quantity, 
                                   Price = @price, 
                                   TotalItemsPrice = @totalItemsPrice,
                                   Comment = @comment
                               WHERE ID = @ID";

                SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                updateCommand.Parameters.AddWithValue("@ID", ID);
                updateCommand.Parameters.AddWithValue("@OrderID", OrderID);
                updateCommand.Parameters.AddWithValue("@ItemID", itemID);
                updateCommand.Parameters.AddWithValue("@quantity", quantity);
                updateCommand.Parameters.AddWithValue("@price", itemPrice);
                updateCommand.Parameters.AddWithValue("@totalItemsPrice", totalItemsPrice);
                updateCommand.Parameters.AddWithValue("@comment", comment ?? (object)DBNull.Value);

                int rowsAffected = updateCommand.ExecuteNonQuery();
                updateSuccessful = (rowsAffected > 0);

                clsOrdersData.UpdateOrderTotal(OrderID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return updateSuccessful;
        }

        public static DataTable GetAllOrderItems()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT OrderItems.ID, OrderItems.OrderID, Items.ItemName, OrderItems.Quantity, " +
                "OrderItems.Price, OrderItems.TotalItemsPrice\r\nFROM  " +
                "Items INNER JOIN\r\n OrderItems ON Items.ItemID = OrderItems.ItemID";

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
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static DataTable GetAllOrderItemsByOrderID(int OrderID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT OrderItems.ID, /*OrderItems.OrderID,*/ Items.ItemName, OrderItems.Quantity, " +
                           "OrderItems.Price, OrderItems.TotalItemsPrice, OrderItems.Comment " +
                           "FROM Items INNER JOIN OrderItems ON Items.ItemID = OrderItems.ItemID " +
                           "WHERE OrderItems.OrderID = @OrderID";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@OrderID", OrderID);

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
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static bool DeleteOrderItem(int ID, int OrderID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete OrderItems 
                                where ID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

                clsOrdersData.UpdateOrderTotal(OrderID);

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

        public static bool DeleteAllOrderItemsByOrderID(int orderID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete OrderItems 
                                where OrderID = @orderID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@orderID", orderID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

                clsOrdersData.UpdateOrderTotal(orderID);

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

        public static bool IsOrderItemsExist(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM OrderItems WHERE ID = @ID";

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

        public static decimal GetTotalByCategoryName(string categoryName)
        {
            decimal total = 0;
            int categoryID = clsCategoryDataAccess.GetCategoryIDByName(categoryName);
            if (categoryID == -1) return total; // Return 0 if the category is not found

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
                SELECT SUM(OrderItems.TotalItemsPrice)
                FROM OrderItems
                INNER JOIN Items ON OrderItems.ItemID = Items.ItemID
                INNER JOIN Orders ON OrderItems.OrderID = Orders.OrderID
                WHERE Items.CategoryID = @CategoryID
                AND Orders.Total > 0";  // Exclude free orders

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CategoryID", categoryID);

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

        public static decimal GetTotalByCategoryNameAndDateRange(string categoryName, DateTime startDate, DateTime endDate)
        {
            decimal total = 0;
            int categoryID = clsCategoryDataAccess.GetCategoryIDByName(categoryName);
            if (categoryID == -1) return total; // Return 0 if the category is not found

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                  SELECT SUM(OrderItems.TotalItemsPrice)
                  FROM OrderItems
                  INNER JOIN Items ON OrderItems.ItemID = Items.ItemID
                  INNER JOIN Categories ON Items.CategoryID = Categories.CategoryID
                  INNER JOIN Orders ON OrderItems.OrderID = Orders.OrderID
                  WHERE Categories.CategoryName = @CategoryName
                  AND CAST(Orders.Date AS DATE) BETWEEN @StartDate AND @EndDate
                  AND Orders.Total > 0";  // Exclude free orders

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CategoryName", categoryName); // Corrected parameter name
                command.Parameters.AddWithValue("@StartDate", startDate.Date); // Ensure the time part is ignored
                command.Parameters.AddWithValue("@EndDate", endDate.Date);     // Ensure the time part is ignored

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
            }

            return total;
        }

        public static decimal GetTotalByItemName(string itemName)
        {
            decimal total = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT SUM(OrderItems.TotalItemsPrice)
                     FROM OrderItems
                     INNER JOIN Items ON OrderItems.ItemID = Items.ItemID
                     INNER JOIN Orders ON OrderItems.OrderID = Orders.OrderID
                     WHERE Items.ItemName = @ItemName
                     AND Orders.Total > 0";  // Exclude free orders

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ItemName", itemName);

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

        public static decimal GetTotalByItemNameAndDateRange(string itemName, DateTime startDate, DateTime endDate)
        {
            decimal total = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                 SELECT SUM(OrderItems.TotalItemsPrice)
                FROM OrderItems
                INNER JOIN Items ON OrderItems.ItemID = Items.ItemID
                INNER JOIN Orders ON OrderItems.OrderID = Orders.OrderID
                WHERE Items.ItemName = @ItemName
                AND CAST(Orders.Date AS DATE) BETWEEN @StartDate AND @EndDate
                AND Orders.Total > 0";  // Exclude free orders

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemName", itemName);
                command.Parameters.AddWithValue("@StartDate", startDate.Date); // Ensure the time part is ignored
                command.Parameters.AddWithValue("@EndDate", endDate.Date);     // Ensure the time part is ignored

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
            }

            return total;
        }

        public static int GetCountOfItemsByName(string itemName)
        {
            int itemCount = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {


                string query = @"
            SELECT SUM(OrderItems.Quantity)
            FROM OrderItems
            INNER JOIN Orders ON OrderItems.OrderID = Orders.OrderID
            INNER JOIN Items ON OrderItems.ItemID = Items.ItemID
            WHERE Items.ItemName = @ItemName
            AND Orders.Total > 0";  // Exclude free orders

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemName", itemName);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        itemCount = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return itemCount;
        }

        public static int GetCountOfItemsByNameAndDateRange(string itemName, DateTime startDate, DateTime endDate)
        {
            int itemCount = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                //string query = @"
                // SELECT COUNT(*)
                // FROM OrderItems
                // INNER JOIN Orders ON OrderItems.OrderID = Orders.OrderID
                // INNER JOIN Items ON OrderItems.ItemID = Items.ItemID
                // WHERE Items.ItemName = @ItemName
                // AND Orders.Total > 0  -- Exclude free orders
                // AND CAST(Orders.Date AS DATE) >= @StartDate  -- Filter by date range
                // AND CAST(Orders.Date AS DATE) <= @EndDate";


                string query = @"
            SELECT SUM(OrderItems.Quantity)
            FROM OrderItems
            INNER JOIN Orders ON OrderItems.OrderID = Orders.OrderID
            INNER JOIN Items ON OrderItems.ItemID = Items.ItemID
            WHERE Items.ItemName = @ItemName
            AND Orders.Total > 0  -- Exclude free orders
            AND CAST(Orders.Date AS DATE) >= @StartDate  -- Filter by date range
            AND CAST(Orders.Date AS DATE) <= @EndDate";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemName", itemName);
                command.Parameters.AddWithValue("@StartDate", startDate.Date);  // Use only the date part
                command.Parameters.AddWithValue("@EndDate", endDate.Date);      // Use only the date part

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        itemCount = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return itemCount;
        }


        //----------------------------------------------------------------------

        // method to get category name for item to be used for printerchief2

        public static string GetCategoryNameByItemID(int itemID)
        {
            string categoryName = null;
            int categoryID = -1;
            

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string getCategoryIDQuery = "SELECT CategoryID FROM Items WHERE ItemID = @ItemID";
                using (SqlCommand cmd = new SqlCommand(getCategoryIDQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ItemID", itemID);
                    try
                    {
                        conn.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            categoryID = Convert.ToInt32(result);
                        }
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error getting CategoryID", ex);
                    }
                }
            }

            if (categoryID != -1)
            {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string getCategoryNameQuery = "SELECT CategoryName FROM Categories WHERE CategoryID = @CategoryID";
                    using (SqlCommand cmd = new SqlCommand(getCategoryNameQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@CategoryID", categoryID);
                        try
                        {
                            conn.Open();
                            object result = cmd.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                            {
                                categoryName = result.ToString();
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Error getting CategoryName", ex);
                        }
                    }
                }
            }

            return categoryName;
        }

        public static string GetCategoryNameByItemName(string itemName)
        {
            string categoryName = null;
            int categoryID = -1;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string getCategoryIDQuery = "SELECT CategoryID FROM Items WHERE ItemName = @ItemName";
                using (SqlCommand cmd = new SqlCommand(getCategoryIDQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ItemName", itemName);
                    try
                    {
                        conn.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            categoryID = Convert.ToInt32(result);
                        }
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error getting CategoryID by ItemName", ex);
                    }
                }
            }

            if (categoryID != -1)
            {
                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string getCategoryNameQuery = "SELECT CategoryName FROM Categories WHERE CategoryID = @CategoryID";
                    using (SqlCommand cmd = new SqlCommand(getCategoryNameQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@CategoryID", categoryID);
                        try
                        {
                            conn.Open();
                            object result = cmd.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                            {
                                categoryName = result.ToString();
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Error getting CategoryName by CategoryID", ex);
                        }
                    }
                }
            }

            return categoryName;
        }


        //-------------------------------------------------------------------
        // adding for excel sheet report and datagrid report

        public static DataTable GetSalesReportByDateRange(DateTime startDate, DateTime endDate)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
          SELECT 
              Categories.CategoryName,
              Items.ItemName, 
              Items.Price AS CurrentPrice,
              SUM(OrderItems.TotalItemsPrice) AS Total, 
              SUM(OrderItems.Quantity) AS Quantity
          FROM OrderItems
          INNER JOIN Items ON OrderItems.ItemID = Items.ItemID
          INNER JOIN Categories ON Items.CategoryID = Categories.CategoryID
          INNER JOIN Orders ON OrderItems.OrderID = Orders.OrderID
          WHERE CAST(Orders.Date AS DATE) BETWEEN @StartDate AND @EndDate
          AND Orders.Total > 0
          GROUP BY Categories.CategoryName, Items.ItemName, Items.Price
          ORDER BY Categories.CategoryName, Items.ItemName";




                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StartDate", startDate.Date);
                command.Parameters.AddWithValue("@EndDate", endDate.Date);

                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return dataTable;
        }
        public static DataTable GetSalesReport()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
          SELECT 
              Categories.CategoryName,
              Items.ItemName, 
              Items.Price AS CurrentPrice,
              SUM(OrderItems.TotalItemsPrice) AS Total, 
              SUM(OrderItems.Quantity) AS Quantity
          FROM OrderItems
          INNER JOIN Items ON OrderItems.ItemID = Items.ItemID
          INNER JOIN Categories ON Items.CategoryID = Categories.CategoryID
          INNER JOIN Orders ON OrderItems.OrderID = Orders.OrderID
          WHERE Orders.Total > 0
          GROUP BY Categories.CategoryName, Items.ItemName, Items.Price
          ORDER BY Categories.CategoryName, Items.ItemName";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return dataTable;
        }


        //-------------------------------------------------------
        // adding sales report modifed to include start and end dates to be included in the excel report and datagrid report

        public static DataTable GetSalesReportByDateRangeInludeDates(DateTime startDate, DateTime endDate)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"

                            SELECT 
                            CAST(Orders.Date AS DATE) AS OrderDate,
                            Categories.CategoryName,
                            Items.ItemName, 
                            OrderItems.Price AS CurrentPrice,
                            SUM(OrderItems.TotalItemsPrice) AS Total, 
                            SUM(OrderItems.Quantity) AS Quantity
                            FROM OrderItems
                            INNER JOIN Items ON OrderItems.ItemID = Items.ItemID
                            INNER JOIN Categories ON Items.CategoryID = Categories.CategoryID
                            INNER JOIN Orders ON OrderItems.OrderID = Orders.OrderID
                            WHERE CAST(Orders.Date AS DATE) BETWEEN @StartDate AND @EndDate
                            AND Orders.Total > 0
                            GROUP BY 
                            CAST(Orders.Date AS DATE),
                            Categories.CategoryName,
                            Items.ItemName,
                            OrderItems.Price
                            ORDER BY 
                            OrderDate,
                            Categories.CategoryName,
                            Items.ItemName;

                      ";
 

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StartDate", startDate.Date);
                command.Parameters.AddWithValue("@EndDate", endDate.Date);

                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return dataTable;
        }




    }
}
