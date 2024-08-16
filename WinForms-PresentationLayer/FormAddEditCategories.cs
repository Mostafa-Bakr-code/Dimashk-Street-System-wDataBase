using BuisnessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_PresentationLayer
{
    public partial class FormAddEditCategories : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        int _categoryID;
        clsCategoryBusiness _Category;

        //Constructor
        public FormAddEditCategories(int categoryID)
        {
            InitializeComponent();

            _categoryID = categoryID;

            if (_categoryID == -1)
            {

                _Mode = enMode.AddNew;
            }
            else
            {
                _Mode = enMode.Update;
            }
        }

        private void LoadData()
        {



            // Add Mode
            if (_Mode == enMode.AddNew)
            {
                lbMode.Text = "Add Category";
                _Category = new clsCategoryBusiness();
                return;
            }


            // Update Mode
            else
            {

                lbMode.Text = $"Update Category {_categoryID}";

                _Category = clsCategoryBusiness.Find(_categoryID);

                if (_Category == null)
                {
                    MessageBox.Show("This form will be closed because No Category with ID = " + _categoryID);
                    this.Close();

                    return;
                }

                lbCategoryID.Text = _categoryID.ToString();
                txtCategoryName.Text = _Category.Name;

            }

        }

        private void FormCategories_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            _Category.Name = txtCategoryName.Text.Trim();

            if (string.IsNullOrEmpty(_Category.Name))
            {
                MessageBox.Show("Category Name cannot be empty. Please enter a valid name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (_Category.Save())
            {
                MessageBox.Show("Saved Succssefully");
                lbCategoryID.Text = _Category.ID.ToString();


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
