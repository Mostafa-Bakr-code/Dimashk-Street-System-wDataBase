using System;
using System.Data;
using DataAccessLayer;

namespace BuisnessLayer
{
    public class clsCategoryBusiness
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { set; get; }
        public string Name { set; get; }

        public clsCategoryBusiness()

        {
            this.ID = -1;
            this.Name = "";


            Mode = enMode.AddNew;

        }

        private clsCategoryBusiness(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;


            Mode = enMode.Update;

        }

        private bool _AddNewCategory()
        {
            //call DataAccess Layer 

            this.ID = clsCategoryDataAccess.AddNewCategory(this.Name);

            return (this.ID != -1);
        }

        private bool _UpdateCategory()
        {
            //call DataAccess Layer 


            return clsCategoryDataAccess.UpdateCategory(this.ID, this.Name);

        }

        public static clsCategoryBusiness Find(int ID)
        {

            string Name = "";
           

            if (clsCategoryDataAccess.GetCategoryInfoByID(ID, ref Name))

                return new clsCategoryBusiness(ID, Name);

            else
                return null;

        }

        public static clsCategoryBusiness Find(string CategoryName)
        {

            int ID = -1;
        
           
            if (clsCategoryDataAccess.GetCategoryInfoByName(CategoryName, ref ID))

                return new clsCategoryBusiness(ID, CategoryName);
            else
                return null;

        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCategory())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateCategory();

            }




            return false;
        }

        public static DataTable GetAllCategories()
        {

            return clsCategoryDataAccess.GetAllCategories();

        }

        public static bool DeleteCategory(int ID)
        {

            return clsCategoryDataAccess.DeleteCategory(ID);

        }

        public static bool isCategoryExist(int ID)
        {

            return clsCategoryDataAccess.IsCategoryExist(ID);

        }

    }
}
