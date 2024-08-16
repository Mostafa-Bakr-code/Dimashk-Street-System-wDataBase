using System;
using System.Data;
using DataAccessLayer;

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


        public clsOrderItemsBusiness()

        {
            this.ID = -1;
            this.OrderID = -1;
            this.ItemID = -1;
            this.Quantity = 0;            
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


            return clsOrderItemsData.UpdateOrderItem(this.ID, this.OrderID, this.ItemID, this.Quantity, this.Price, this.TotalItemsPrice);

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

        public static DataTable GetAllOrderItems()
        {

            return clsOrderItemsData.GetAllOrderItems();

        }

        public static bool DeleteOrderItems(int ID)
        {

            return clsOrderItemsData.DeleteOrderItems(ID);

        }

        public static bool isOrderItemsExist(int ID)
        {

            return clsOrderItemsData.IsOrderItemsExist(ID);

        }



    }
}
