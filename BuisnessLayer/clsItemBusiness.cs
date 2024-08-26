using System;
using System.Data;
using DataAccessLayer;

namespace BuisnessLayer
{
    public class clsItemBusiness
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { set; get; }
        public string Name { set; get; }
        public int CategoryID { set; get; }
        public decimal Price { set; get; }
        public decimal InitialPrice { set; get; }
        public decimal TaxValue { set; get; }
        public decimal TaxRate { set; get; }

        public clsItemBusiness()

        {
            this.ID = -1;
            this.Name = "";
            this.CategoryID = -1;
            this.Price = 0;
            this.InitialPrice = 0;
            this.TaxValue = 0;
            this.TaxRate = 14.00m; // Default tax rate
            Mode = enMode.AddNew;

        }


        private clsItemBusiness(int ID, string Name, int CategoryID, decimal Price, decimal InitialPrice, decimal TaxValue, decimal TaxRate)
        {
            this.ID = ID;
            this.Name = Name;
            this.CategoryID = CategoryID;
            this.Price = Price;
            this.InitialPrice = InitialPrice;
            this.TaxValue = TaxValue;
            this.TaxRate = TaxRate;
            Mode = enMode.Update;
        }

        private bool _AddNewItem()
        {
            this.ID = clsItemDataAccess.AddNewItem(this.Name, this.CategoryID, this.Price);
            return (this.ID != -1);
        }

        private bool _UpdateItem()
        {
            return clsItemDataAccess.UpdateItem(this.ID, this.Name, this.CategoryID, this.Price);
        }

        public static clsItemBusiness Find(int ID)
        {
            string Name = "";
            int CategoryID = -1;
            decimal Price = -1;
            decimal InitialPrice = -1;
            decimal TaxValue = -1;
            decimal TaxRate = -1;

            if (clsItemDataAccess.GetItemInfoByID(ID, ref Name, ref CategoryID, ref Price, ref InitialPrice, ref TaxValue, ref TaxRate))
                return new clsItemBusiness(ID, Name, CategoryID, Price, InitialPrice, TaxValue, TaxRate);
            else
                return null;
        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewItem())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateItem();

            }




            return false;
        }

        public static DataTable GetAllItems()
        {
            
            return clsItemDataAccess.GetAllItems();

        }

        public static bool DeleteItem(int ID)
        {
            
            return clsItemDataAccess.DeleteItem(ID);

        }

        public static bool isItemExist(int ID)
        {

            return clsItemDataAccess.IsItemExist(ID);   

        }




    }
}
