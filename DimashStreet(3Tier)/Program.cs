
using System;
using System.Data;
using BuisnessLayer;

namespace DimashStreet_3Tier_
{
    internal class Program
    {

        // Test ITems
        static void testFindItem(int ID)

        {
            clsItemBusiness Item1 = clsItemBusiness.Find(ID);

            if (Item1 != null)
            {
                Console.WriteLine(Item1.ID);
                Console.WriteLine(Item1.Name);
                Console.WriteLine(Item1.Price);
                Console.WriteLine(Item1.CategoryID);


            }
            else
            {
                Console.WriteLine("Item [" + ID + "] Not found!");
            }
        }

        static void testAddNewItem()


        {
            clsItemBusiness Item1 = new clsItemBusiness();

            Item1.Name = "ZingerSupreme";
            Item1.Price = 30;
            Item1.CategoryID = 2;


            if (Item1.Save())
            {

                Console.WriteLine("Item Added Successfully with id=" + Item1.ID);
            }

        }

        static void testUpdateItem(int ID)

        {
            clsItemBusiness Item1 = clsItemBusiness.Find(ID);

            if (Item1 != null)
            {
                //update whatever info you want
                Item1.Name = "Pizza ranch";
                Item1.Price = 55;
                Item1.CategoryID = 3;


                if (Item1.Save())
                {

                    Console.WriteLine("Item updated Successfully ");
                }

            }
            else
            {
                Console.WriteLine("Not found!");
            }
        }

        static void testDeleteItem(int ID)

        {

            if (clsItemBusiness.isItemExist(ID))

                if (clsItemBusiness.DeleteItem(ID))

                    Console.WriteLine("Item Deleted Successfully.");
                else
                    Console.WriteLine("Faild to delete Item.");

            else
                Console.WriteLine("The Item with id = " + ID + " is not found");

        }

        static void ListItems()
        {

            DataTable dataTable = clsItemBusiness.GetAllItems();

            Console.WriteLine("Items Data:");

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{row["ItemID"]},  {row["ItemName"]} {row["Price"]} {row["CategoryID"]}");
            }

        }

        static void testIsItemExist(int ID)

        {

            if (clsItemBusiness.isItemExist(ID))

                Console.WriteLine("Yes, Item is there.");

            else
                Console.WriteLine("No, Item Is not there.");

        }


        // Test Category

        static void testFindCategory(int ID)

        {
            clsCategoryBusiness Category1 = clsCategoryBusiness.Find(ID);

            if (Category1 != null)
            {
                Console.WriteLine(Category1.ID);
                Console.WriteLine(Category1.Name);

            }
            else
            {
                Console.WriteLine("Category [" + ID + "] Not found!");
            }
        }

        static void testFindCategory(string categoryName)

        {
            clsCategoryBusiness Category1 = clsCategoryBusiness.Find(categoryName);

            if (Category1 != null)
            {
                Console.WriteLine(Category1.ID);
                Console.WriteLine(Category1.Name);

            }
            else
            {
                Console.WriteLine("Category [" + categoryName + "] Not found!");
            }
        }

        static void testAddNewCategory()


        {
            clsCategoryBusiness Category1 = new clsCategoryBusiness();

            Category1.Name = "Western";



            if (Category1.Save())
            {

                Console.WriteLine("Category Added Successfully with id=" + Category1.ID);
            }

        }

        static void testUpdateCategory(int ID)

        {
            clsCategoryBusiness Category1 = clsCategoryBusiness.Find(ID);

            if (Category1 != null)
            {
                //update whatever info you want
                Category1.Name = "Western Sandwiches";
      
                if (Category1.Save())
                {

                    Console.WriteLine("Category updated Successfully ");
                }

            }
            else
            {
                Console.WriteLine("Not found!");
            }
        }

        static void testDeleteCategory(int ID)

        {

            if (clsCategoryBusiness.isCategoryExist(ID))

                if (clsCategoryBusiness.DeleteCategory(ID))

                    Console.WriteLine("Category Deleted Successfully.");
                else
                    Console.WriteLine("Faild to delete Category.");

            else
                Console.WriteLine("The Category with id = " + ID + " is not found");

        }

        static void ListCategories()
        {

            DataTable dataTable = clsCategoryBusiness.GetAllCategories();

            Console.WriteLine("Categories Data:");

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{row["CategoryID"]},  {row["CategoryName"]}");
            }

        }

        static void testIsCategoryExist(int ID)

        {

            if (clsCategoryBusiness.isCategoryExist(ID))

                Console.WriteLine("Yes, Category is there.");

            else
                Console.WriteLine("No, Category Is not there.");

        }

        // Test Orders

        static void testFindOrder(int ID)

        {
            clsOrderBusiness Order1 = clsOrderBusiness.Find(ID);

            if (Order1 != null)
            {
                Console.WriteLine(Order1.ID);
                Console.WriteLine(Order1.date);
                Console.WriteLine(Order1.Total);
                
            }
            else
            {
                Console.WriteLine("Order [" + ID + "] Not found!");
            }
        }

        static void testAddNewOrder()


        {
            clsOrderBusiness Order1 = new clsOrderBusiness();

            Order1.date = DateTime.Now;
            Order1.Total = 590;
         


            if (Order1.Save())
            {

                Console.WriteLine("Order Added Successfully with id=" + Order1.ID);
            }

        }

        static void testUpdateOrder(int ID)

        {
            clsOrderBusiness Order1 = clsOrderBusiness.Find(ID);

            if (Order1 != null)
            {
                //update whatever info you want
                
                Order1.Total = 55;
                


                if (Order1.Save())
                {

                    Console.WriteLine("Order updated Successfully ");
                }

            }
            else
            {
                Console.WriteLine("Not found!");
            }
        }

        static void testDeleteOrder(int ID)

        {

            if (clsOrderBusiness.isOrderExist(ID))

                if (clsOrderBusiness.DeleteOrder(ID))

                    Console.WriteLine("Order Deleted Successfully.");
                else
                    Console.WriteLine("Faild to delete Order.");

            else
                Console.WriteLine("The Order with id = " + ID + " is not found");

        }

        static void ListOrders()
        {

            DataTable dataTable = clsOrderBusiness.GetAllOrders();

            Console.WriteLine("Orders Data:");

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{row["OrderID"]},  {row["Date"]} {row["Total"]}");
            }

        }

        static void testIsOrderExist(int ID)

        {

            if (clsOrderBusiness.isOrderExist(ID))

                Console.WriteLine("Yes, Order is there.");

            else
                Console.WriteLine("No, Order Is not there.");

        }


        // Test OrderItems

        static void testAddNewOrderItems()


        {
            clsOrderItemsBusiness orderItem1 = new clsOrderItemsBusiness();

                orderItem1.OrderID = 1;
                orderItem1.ItemID = 1;
                orderItem1.Quantity = 3;
                orderItem1.Price = 0;
                orderItem1.TotalItemsPrice = 0;


            if (orderItem1.Save())
            {

                Console.WriteLine("OrderItem Added Successfully with id=" + orderItem1.ID);
            }

        }

        static void testUpdateOrderItems(int ID)

        {
            clsOrderItemsBusiness orderItem1 = clsOrderItemsBusiness.Find(ID);

            if (orderItem1 != null)
            {
                //update whatever info you want
                orderItem1.OrderID = 1;
                orderItem1.ItemID = 1;
                orderItem1.Quantity = 13;
                orderItem1.Price = 1000;
                orderItem1.TotalItemsPrice = 20000;


                if (orderItem1.Save())
                {

                    Console.WriteLine("OrderItem updated Successfully ");
                }

            }
            else
            {
                Console.WriteLine("Not found!");
            }
        }

        static void testDeleteOrderItems(int ID, int OrderID)

        {

            if (clsOrderItemsBusiness.isOrderItemsExist(ID))

                if (clsOrderItemsBusiness.DeleteOrderItem(ID, OrderID))

                    Console.WriteLine("OrderItem Deleted Successfully.");
                else
                    Console.WriteLine("Faild to delete OrderItem.");

            else
                Console.WriteLine("The OrderItem with id = " + ID + " is not found");

        }

        static void ListOrderItems()
        {

            DataTable dataTable = clsOrderItemsBusiness.GetAllOrderItems();

            Console.WriteLine("OrderItems Data:");

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{row["ID"]},  {row["OrderID"]} {row["ItemName"]} {row["Quantity"]} {row["Price"]} {row["TotalItemsPrice"]}");
            }

        }

        static void ListOrderItemsByID(int OrderID)
        {

            DataTable dataTable = clsOrderItemsBusiness.GetAllOrderItemsbyID(OrderID);

            Console.WriteLine("OrderItems Data:");

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{row["ID"]},  {row["OrderID"]} {row["ItemName"]} {row["Quantity"]} {row["Price"]} {row["TotalItemsPrice"]}");
            }

        }

        // Test Get Orders Total

        static void getOrdersTotal()
        {
            Console.WriteLine(clsOrderBusiness.GetTotalForAllOrders());
        }

        static void GetTotalByDateRange(DateTime startDate, DateTime endDate)
        {
            Console.WriteLine(clsOrderBusiness.GetTotalByDateRange(startDate,endDate));
        }

        public static decimal GetTotalByCategoryName(string categoryName)
        {
            return clsOrderItemsBusiness.GetTotalByCategoryName(categoryName);
        }
        static void Main(string[] args)
        {

            // Test Items

            //ListItems();

            //testAddNewItem();

            //testUpdateItem(6);

            //testDeleteItem(11);

            //testIsItemExist(11);

            //---------------------------------------------------

            // Test Categories

            //ListCategories();

            //testAddNewCategory();

            //testUpdateCategory(5);

            //testDeleteCategory(5);

            //testIsCategoryExist(3);

            //testFindCategory("pizza");

            //---------------------------------------------------

            // Test Orders

            //ListOrders();

            //testAddNewOrder();

            //testUpdateOrder(1002);

            //testDeleteOrder(1003);

            //testIsOrderExist(1002);

            //---------------------------------------------------

            // Test OrderItems

            //testAddNewOrderItems();

            //testDeleteOrderItems(1146,1094);

            //testUpdateOrderItems(1006);

            //ListOrderItems();

            //ListOrderItemsByID(1014);

            //---------------------------------------------------

            // Test Orders Total

            //getOrdersTotal();

            //GetTotalByDateRange(new DateTime(2024, 8, 21), new DateTime(2024, 8, 21));

            Console.WriteLine(GetTotalByCategoryName("other"));

            Console.ReadKey();
        }

       


    }
}
