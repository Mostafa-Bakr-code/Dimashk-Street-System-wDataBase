using System;
using System.Data;
using System.Windows.Forms;
using BuisnessLayer;

namespace WinForms_PresentationLayer
{
    public partial class FormAddEditItem : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        int _itemID;
        clsItemBusiness _Item;

        //Constructor
        public FormAddEditItem(int itemID)
        {
            InitializeComponent();

            _itemID = itemID;

            if (_itemID == -1)
            {

                _Mode = enMode.AddNew;
            }
            else
            {
                _Mode = enMode.Update;
            }
        }

        private void _FillCategoriesInComoboBox()
        {
            DataTable dtCategories = clsCategoryBusiness.GetAllCategories();

            foreach (DataRow row in dtCategories.Rows)
            {

                cbItemCategory.Items.Add(row["CategoryName"]);

            }

        }

        private void LoadData()
        {

            _FillCategoriesInComoboBox();
            cbItemCategory.SelectedIndex = 0;

            // Add Mode
            if (_Mode == enMode.AddNew)
            {
                lbMode.Text = "Add Item";
                _Item = new clsItemBusiness();
                return;
            }


            // Update Mode
            else
            {

                lbMode.Text = $"Update Item {_itemID}";

                _Item = clsItemBusiness.Find(_itemID);

                if (_Item == null)
                {
                    MessageBox.Show("This form will be closed because No Item with ID = " + _itemID);
                    this.Close();

                    return;
                }

                lbItemID.Text = _itemID.ToString();
                txtItemName.Text = _Item.Name;
                txtItemPrice.Text = _Item.Price.ToString();

                cbItemCategory.SelectedIndex = cbItemCategory.FindString(clsCategoryBusiness.Find(_Item.CategoryID).Name);
             

            }

        }

        private void FormAddEditItem_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            int categoryID = clsCategoryBusiness.Find(cbItemCategory.Text).ID;

            _Item.CategoryID = categoryID;

            _Item.Name = txtItemName.Text.Trim(); 

            if (string.IsNullOrEmpty(_Item.Name))
            {
                MessageBox.Show("Item Name cannot be empty. Please enter a valid name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            decimal price;

            if (decimal.TryParse(txtItemPrice.Text, out price))
            {
                _Item.Price = price;
            }
            else
            {
                MessageBox.Show("Please enter a valid Price.");
                return;
            }

         

            if (_Item.Save())
            {
                MessageBox.Show("Saved Succssefully");
                lbItemID.Text = _Item.ID.ToString();


            }

            else
            {
                MessageBox.Show("Save Failed");
            }

            _Mode = enMode.Update;
            lbMode.Text = "Update Mode";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }


    }
}
