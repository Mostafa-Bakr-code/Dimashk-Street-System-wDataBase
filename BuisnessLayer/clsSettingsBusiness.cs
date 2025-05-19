using System;
using System.Data;
using DataAccessLayer;

namespace BuisnessLayer
{
    public class clsSettingsBusiness
    {

        public int ID { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        // Static properties to hold printer names
        public static string UserPrinterName { get; private set; }
        public static string ChefPrinterName { get; private set; }
        public static string ChefPrinterName2 { get; private set; }
        public static string ChefPrinter2Item { get; private set; }

        public clsSettingsBusiness() { }

        public clsSettingsBusiness(int id, string key, string value)
        {
            ID = id;
            Key = key;
            Value = value;
        }
        public static string GetValue(string key)
        {
            clsSettings dataAccess = new clsSettings();
            return clsSettings.GetSettingValue(key);
        }


        // New method to load printer settings into static properties
        public static void LoadPrinterSettings()
        {
            UserPrinterName = GetValue("UserPrinterName");
            ChefPrinterName = GetValue("ChefPrinterName");
            ChefPrinterName2 = GetValue("ChefPrinterName2");
        }

        public static void LoadChefPrinter2Item()
        {

            ChefPrinter2Item = GetValue("ChefPrinter2Item");
        }

    }
}

