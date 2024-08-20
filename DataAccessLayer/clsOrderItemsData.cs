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
            // This function will return the new OrderItemID if successful and -1 if not.
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

        public static bool UpdateOrderItem(int ID, int OrderID, int itemID, int quantity, decimal price, decimal totalItemsPrice)

        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update OrderItems
                            set OrderID = @OrderID, 
                                ItemID = @ItemID, 
                                Quantity = @quantity, 
                                Price = @price, 
                                TotalItemsPrice = @totalItemsPrice

                                where ID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@OrderID", OrderID);
            command.Parameters.AddWithValue("@ItemID", itemID);
            command.Parameters.AddWithValue("@quantity", quantity);
            command.Parameters.AddWithValue("@price", price);
            command.Parameters.AddWithValue("@totalItemsPrice", totalItemsPrice);


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

            string query = "SELECT OrderItems.ID, OrderItems.OrderID, Items.ItemName, OrderItems.Quantity, " +
                           "OrderItems.Price, OrderItems.TotalItemsPrice " +
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

        public static bool DeleteOrderItems(int ID)
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

        public static bool DeleteOrderItemsByOrderID(int orderID)
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
    }
}
