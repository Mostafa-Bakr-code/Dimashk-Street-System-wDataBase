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


        public clsItemBusiness()

        {
            this.ID = -1;
            this.Name = "";
            this.CategoryID = -1;
            this.Price = 0;

            Mode = enMode.AddNew;

        }

        private clsItemBusiness(int ID, string Name, int CategoryID, decimal Price)
        {
            this.ID = ID;
            this.Name = Name;
            this.CategoryID = CategoryID;
            this.Price = Price;


            Mode = enMode.Update;

        }

        private bool _AddNewItem()
        {
            //call DataAccess Layer 

            this.ID = clsItemDataAccess.AddNewItem(this.Name, this.CategoryID, this.Price);

            return (this.ID != -1);
        }

        private bool _UpdateItem()
        {
            //call DataAccess Layer 


            return clsItemDataAccess.UpdateItem(this.ID, this.Name, this.CategoryID, this.Price);

        }

        public static clsItemBusiness Find(int ID)
        {

            string Name = "";
            int CategoryID = -1;
            decimal Price = -1;
            

            if(clsItemDataAccess.GetItemInfoByID(ID,ref Name, ref CategoryID, ref Price))

                    return new clsItemBusiness(ID, Name, CategoryID, Price);

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
