using System;
using System.Data;
using DataAccessLayer;
using ClosedXML.Excel;
using System.IO;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Runtime.InteropServices.ComTypes;

namespace BuisnessLayer
{
    public class clsOrderItemsBusiness
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { set; get; }

        public int OrderID { set; get; }

        public int ItemID { set; get; }

        public int Quantity { set; get; }
        
        public decimal Price { set; get; }

        public decimal TotalItemsPrice { set; get; }

        public string Comment { set; get; }


        public clsOrderItemsBusiness()

        {
            this.ID = -1;
            this.OrderID = -1;
            this.ItemID = -1;
            this.Quantity = 1;            
            //this.Price = 0;
            //this.TotalItemsPrice = 0;


            Mode = enMode.AddNew;

        }

        private clsOrderItemsBusiness(int ID, int orderID, int itemID, int quantity)
        {
            this.ID = ID;
            this.OrderID = orderID;
            this.ItemID = itemID;
            this.Quantity = quantity;


            Mode = enMode.Update;

        }

        private bool _AddNewOrderItem()
        {
            //call DataAccess Layer 

            this.ID = clsOrderItemsData.AddNewOrderItems(this.OrderID, this.ItemID, this.Quantity);

            return (this.ID != -1);
        }

        private bool _UpdateOrderItem()
        {
            //call DataAccess Layer 


            return clsOrderItemsData.UpdateOrderItem(this.ID, this.OrderID, this.ItemID, this.Quantity, this.Price, this.TotalItemsPrice, this.Comment);

        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewOrderItem())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateOrderItem();

            }




            return false;
        }

        public static clsOrderItemsBusiness Find(int ID)
        {

            int OrderID = -1;
            int ItemID = -1;
            int quantity = -1;
            decimal price = -1;
            decimal totalItemPrice = -1;


            if (clsOrderItemsData.GetOrderItemInfoByID(ID, ref OrderID, ref ItemID, ref quantity, ref price, ref totalItemPrice))

                return new clsOrderItemsBusiness(ID, OrderID, ItemID, quantity);

            else
                return null;

        }

        public static DataTable GetAllOrderItems()
        {

            return clsOrderItemsData.GetAllOrderItems();

        }

        public static DataTable GetAllOrderItemsbyID(int OrderID)

        {

            return clsOrderItemsData.GetAllOrderItemsByOrderID(OrderID);

        }

        public static bool DeleteOrderItem(int ID, int OrderID)
        {

            return clsOrderItemsData.DeleteOrderItem(ID, OrderID);

        }

        public static bool DeleteAllOrderItemsByOrderID(int orderID)
        {

            return clsOrderItemsData.DeleteAllOrderItemsByOrderID(orderID);

        }

        public static bool isOrderItemsExist(int ID)
        {

            return clsOrderItemsData.IsOrderItemsExist(ID);

        }

        public static decimal GetTotalByCategoryName(string categoryName)
        {
            return clsOrderItemsData.GetTotalByCategoryName(categoryName);
        }

        public static decimal GetTotalByCategoryNameAndDateRange(string categoryName, DateTime startDate, DateTime endDate) 
        { 
            return clsOrderItemsData.GetTotalByCategoryNameAndDateRange(categoryName,startDate,endDate);
        }

        public static decimal GetTotalByItemName(string itemName)
        {
            return clsOrderItemsData.GetTotalByItemName(itemName);
        }

        public static decimal GetTotalByItemNameAndDateRange(string itemName, DateTime startDate, DateTime endDate)
        {
            return clsOrderItemsData.GetTotalByItemNameAndDateRange(itemName,startDate,endDate);
        }

        public static int GetItemCountByNameAndDateRange(string itemName, DateTime startDate, DateTime endDate)
        {
            return clsOrderItemsData.GetCountOfItemsByNameAndDateRange(itemName, startDate, endDate);
        }

        public static int GetItemCountByName(string itemName)
        {
            return clsOrderItemsData.GetCountOfItemsByName(itemName);
        }

        //--------------------------------------------------------------------


        // method to get category name for item to be used for printerchief2

        public static string GetCategoryNameByItemID(int itemID)
        {
            return clsOrderItemsData.GetCategoryNameByItemID(itemID);
        }

        public static string GetCategoryNameByItemName(string itemName)
        {
            return clsOrderItemsData.GetCategoryNameByItemName(itemName);
        }


        //---------------------------------------------------------------
        // adding functions for FormshowAllCategoriesSales

        public static DataTable GetSalesReportByDateRange(DateTime startDate, DateTime endDate)
        {
            return clsOrderItemsData.GetSalesReportByDateRange(startDate,endDate);
        }

        public static DataTable GetSalesReport()
        {
            return clsOrderItemsData.GetSalesReport();
        }


        // adding for excel sheet

        private static string GetDesktopReportsPath()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string reportsPath = Path.Combine(desktopPath, "Reports");

            if (!Directory.Exists(reportsPath))
                Directory.CreateDirectory(reportsPath);

            return reportsPath;
        }

        public static bool ExportSalesReportByDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
               

                DataTable rawData = clsOrderItemsData.GetSalesReportByDateRange(startDate, endDate);

                // Reorder the columns
                DataTable data = rawData.DefaultView.ToTable(false,
                    "CategoryName", "ItemName", "Quantity", "CurrentPrice", "Total");


                string formattedStart = startDate.ToString("yyyy-MM-dd");
                string formattedEnd = endDate.ToString("yyyy-MM-dd");

                string fileName = $"Daily Report ({formattedStart} to {formattedEnd})_Summary.xlsx";
                string filePath = Path.Combine(GetDesktopReportsPath(), fileName);

                using (var workbook = new XLWorkbook())
                {

                    string worksheetName = $"{formattedStart} to {formattedEnd}";
                    var worksheet = workbook.Worksheets.Add(worksheetName);
                    worksheet.Cell(1, 1).InsertTable(data);


                    // Auto-fit all columns
                    worksheet.Columns().AdjustToContents();


                    workbook.SaveAs(filePath);
                }

                return true;
            }
            catch (Exception ex)
            {
                // Optionally log ex.Message
                return false;
            }
        }

        public static bool ExportAllTimeSalesReport()
        {
            try
            {
               

                DataTable rawData = clsOrderItemsData.GetSalesReport();

                // Reorder the columns
                DataTable data = rawData.DefaultView.ToTable(false,
                    "CategoryName", "ItemName", "Quantity", "CurrentPrice", "Total");

                string filePath = Path.Combine(GetDesktopReportsPath(), "All Time Report.xlsx");

                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("All Time Report");
                    worksheet.Cell(1, 1).InsertTable(data);


                    // Auto-fit all columns
                    worksheet.Columns().AdjustToContents();

                    workbook.SaveAs(filePath);


                }

                return true;
            }
            catch (Exception ex)
            {
                // Optionally log ex.Message
                return false;
            }
        }

        //-------------------------------------------------------
        // adding sales report modifed to include start and end dates to be included in the excel and datagrid reports


        public static DataTable GetSalesReportByDateRangeInludeDates(DateTime startDate, DateTime endDate)
        {
            return clsOrderItemsData.GetSalesReportByDateRangeInludeDates(startDate, endDate);
        }


        public static bool ExportSalesReportByDateRangeModifiedDateIncluded(DateTime startDate, DateTime endDate)
        {
            try
            {
                DataTable rawData = clsOrderItemsData.GetSalesReportByDateRangeInludeDates(startDate, endDate);

                // Reorder the columns
                DataTable data = rawData.DefaultView.ToTable(false,
                    "OrderDate", "CategoryName", "ItemName", "Quantity", "CurrentPrice", "Total");

                string formattedStart = startDate.ToString("yyyy-MM-dd");
                string formattedEnd = endDate.ToString("yyyy-MM-dd");

                string fileName = $"Daily Report ({formattedStart} to {formattedEnd})_WithDates.xlsx";
                string filePath = Path.Combine(GetDesktopReportsPath(), fileName);

                using (var workbook = new XLWorkbook())
                {
                    string worksheetName = $"{formattedStart} to {formattedEnd}";
                    var worksheet = workbook.Worksheets.Add(worksheetName);
                    var table = worksheet.Cell(1, 1).InsertTable(data);

                    // Format OrderDate column (Column 1)
                    worksheet.Column(1).Style.DateFormat.Format = "dd-MM-yyyy";

                    // Auto-fit all columns
                    worksheet.Columns().AdjustToContents();

                    workbook.SaveAs(filePath);
                }

                return true;
            }
            catch (Exception ex)
            {
                // Optionally log ex.Message
                return false;
            }
        }






    }
}
