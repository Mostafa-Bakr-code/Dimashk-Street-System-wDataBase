using System;
using System.Data;
using DataAccessLayer;


namespace BuisnessLayer
{
    public class clsOrderBusiness
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { set; get; }
        public DateTime date { set; get; }
        public decimal Total { set; get; }

        public int SerialNumber { get; set; }


        public clsOrderBusiness()

        {
            this.ID = -1;

            this.date = DateTime.Now;

            this.Total = 0;

            Mode = enMode.AddNew;

        }

        private clsOrderBusiness(int ID, DateTime date, decimal Total)
        {
            this.ID = ID;

            this.date = date;

            this.Total = Total;

            Mode = enMode.Update;

        }

        private bool _AddNewOrder()
        {
           
            this.SerialNumber = clsOrdersData.GetNextSerialNumber(this.date);

            this.ID = clsOrdersData.AddNewOrder(this.date, this.Total, this.SerialNumber);

            return (this.ID != -1);
        }

        private bool _UpdateOrder()
        {
            //call DataAccess Layer

            return clsOrdersData.UpdateOrders(this.ID, this.date, this.Total);

        }

        public static clsOrderBusiness Find(int ID)
        {


            DateTime date = DateTime.Now;
            decimal Total = 0;
            int serialNumber = 0;

            if (clsOrdersData.GetOrderInfoByID(ID, ref date, ref Total, ref serialNumber))
                return new clsOrderBusiness(ID, date, Total) { SerialNumber = serialNumber };

            else
                return null;

        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewOrder())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateOrder();

            }




            return false;
        }

        public static DataTable GetAllOrders()
        {

            return clsOrdersData.GetAllOrders();

        }

        public static DataTable GetOrdersByDateRange(DateTime startDate, DateTime endDate)
        {
            return clsOrdersData.GetOrdersByDateRange(startDate, endDate);
        }

        public static bool DeleteOrder(int ID)
        {

            return clsOrdersData.DeleteOrder(ID);

        }

        public static bool isOrderExist(int ID)
        {

            return clsOrdersData.IsOrderExist(ID);

        }

        public void UpdateOrderTotal()
        {
            clsOrdersData.UpdateOrderTotal(ID);
       
        }

        public static decimal GetTotalForAllOrders()
        {
            return clsOrdersData.GetTotalForAllOrders();
        }

        public static decimal GetTotalByDateRange(DateTime startDate, DateTime endDate)
        {
            return clsOrdersData.GetTotalByDateRange(startDate, endDate);
        }

        public static DateTime GetEarliestOrderDate()
        {
            return clsOrdersData.GetEarliestOrderDate();
        }

        public static DateTime GetLatestOrderDate()
        {
            return clsOrdersData.GetLatestOrderDate();
        }

        public static decimal GetTotalOfFreeOrders()
        {
            return clsOrdersData.GetTotalOfFreeOrders();
        }

        public static decimal  GetTotalOfFreeOrdersByDateRange(DateTime startDate, DateTime endDate)
        {
            return clsOrdersData.GetTotalOfFreeOrdersByDateRange(startDate,endDate);
        }

        public static int GetTotalNumberOfOrders()
        {
            return clsOrdersData.GetTotalNumberOfOrders();
        }

        public static int GetTotalNumberOfOrdersByDateRange(DateTime startDate, DateTime endDate)
        {
            return clsOrdersData.GetTotalNumberOfOrdersByDateRange(startDate, endDate);
        }

        public static int GetCountOfFreeOrders()
        {
            return clsOrdersData.GetCountOfFreeOrders();
        }

        public static int GetCountOfFreeOrdersByDateRange(DateTime startDate, DateTime endDate)
        {
            return clsOrdersData.GetCountOfFreeOrdersByDateRange(startDate, endDate);
        }

        public static decimal GetTotalTaxValueByDateRange(DateTime startDate, DateTime endDate)
        {
            return clsOrdersData.GetTotalTaxValueByDateRange(startDate, endDate);
        }

        public static decimal GetTotalTaxValueForAllOrders()
        {
            return clsOrdersData.GetTotalTaxValueForAllOrders();
        }

        public static (decimal InitialPrice, decimal TaxValue) GetInitialPriceAndTaxValueForOrder(int orderId)
        {
            return clsOrdersData.GetInitialPriceAndTaxValueForOrder((int)orderId);
        }

    }
}
