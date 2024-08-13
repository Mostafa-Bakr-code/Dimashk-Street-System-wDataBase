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
            //call DataAccess Layer 

            this.ID = clsOrdersData.AddNewOrder(this.date, this.Total);

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


            if (clsOrdersData.GetOrderInfoByID(ID, ref date, ref Total))

                return new clsOrderBusiness(ID, date, Total);

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

        public static bool DeleteOrder(int ID)
        {

            return clsOrdersData.DeleteOrder(ID);

        }

        public static bool isOrderExist(int ID)
        {

            return clsOrdersData.IsOrderExist(ID);

        }
    }
}
