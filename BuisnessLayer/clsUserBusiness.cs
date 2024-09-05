using System;
using System.Data;
using DataAccessLayer;

namespace BuisnessLayer
{
    public class clsUserBusiness
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { set; get; }
        public string userName { set; get; }
        public string password { set; get; }
        public int permissions { set; get; }


        public clsUserBusiness()

        {
            this.ID = -1;
            this.userName = "";
            this.password = "";
            this.permissions = 0;

            Mode = enMode.AddNew;

        }


        private clsUserBusiness(int ID, string userName, string password, int permissions)
        {
            this.ID = ID;
            this.userName = userName;
            this.password = password;
            this.permissions = permissions;

            Mode = enMode.Update;
        }

        private bool _AddNewUser()
        {
            this.ID = clsUsersData.AddNewUser(this.userName, this.password, this.permissions);
            return (this.ID != -1);
        }

        private bool _UpdateUser()
        {
            return clsUsersData.UpdateUser(this.ID, this.userName, this.password, this.permissions);
        }

        public static clsUserBusiness Find(int ID)
        {
            string userName = "";
            string password = "";
            int permissions = -1;


            if (clsUsersData.GetUserInfoByID(ID, ref userName, ref password, ref permissions))
                return new clsUserBusiness(ID, userName, password, permissions);
            else
                return null;
        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateUser();

            }




            return false;
        }

        public static DataTable GetAllUsers()
        {

            return clsUsersData.GetAllUsers();

        }


        public static bool DeleteUser(int ID)
        {

            return clsUsersData.DeleteUser(ID);

        }

        public static bool isUserExist(int ID)
        {

            return clsUsersData.IsUserExist(ID);

        }


    }
}
