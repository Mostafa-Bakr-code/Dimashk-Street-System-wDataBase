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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WinForms_PresentationLayer
{
    public partial class FormAddEditUser : Form

    {

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        int _userID;
        clsUserBusiness _user;

        //Constructor
        public FormAddEditUser(int userID)
        {
            InitializeComponent();

            _userID = userID;

            if (_userID == -1)
            {

                _Mode = enMode.AddNew;
            }
            else
            {
                _Mode = enMode.Update;
            }



            foreach (Control control in panelPermissions.Controls)
            {
                if (control is System.Windows.Forms.CheckBox)  // Fully qualify CheckBox
                {
                    (control as System.Windows.Forms.CheckBox).CheckedChanged += new EventHandler(PermissionsCheckBox_CheckedChanged);
                }
            }


        }

        private void LoadData()
        {


            // Add Mode
            if (_Mode == enMode.AddNew)
            {
                lbMode.Text = "Add User";
                _user = new clsUserBusiness();
                return;
            }


            // Update Mode
            else
            {

                lbMode.Text = $"Update User {_userID}";

                _user = clsUserBusiness.Find(_userID);

                if (_user == null)
                {
                    MessageBox.Show("This form will be closed because No User with ID = " + _userID);
                    this.Close();

                    return;
                }

                lbUserID.Text = _userID.ToString();
                txtUserName.Text = _user.userName;
                txtUserPassword.Text = _user.password;
                lbPermissions.Text = _user.permissions.ToString();


                // Load permissions

               
                if (_user.permissions == -1)
                {
                    checkBoxFullAccess.Checked = true;
                    //// Optionally, disable other checkboxes if Full Access is granted
                    //checkBoxCategories.Checked = true;
                    //checkBoxOrders.Checked = true;
                    //checkBoxOrderItems.Checked = true;
                    //checkBoxUsers.Checked = true;
                    //checkBoxItems.Checked = true;
                }
                else
                {
                   
                    int permissions = _user.permissions;

                    checkBoxFullAccess.Checked = false;
                    checkBoxCategories.Checked = (permissions & Convert.ToInt32(checkBoxCategories.Tag)) != 0;
                    checkBoxOrders.Checked = (permissions & Convert.ToInt32(checkBoxOrders.Tag)) != 0;
                    checkBoxOrderItems.Checked = (permissions & Convert.ToInt32(checkBoxOrderItems.Tag)) != 0;
                    checkBoxUsers.Checked = (permissions & Convert.ToInt32(checkBoxUsers.Tag)) != 0;
                    checkBoxItems.Checked = (permissions & Convert.ToInt32(checkBoxItems.Tag)) != 0;
                }




            }

        }

        private void FormAddEditUser_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _user.userName = txtUserName.Text.Trim();

            if (string.IsNullOrEmpty(_user.userName))
            {
                MessageBox.Show("User Name cannot be empty. Please enter a valid user name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _user.password = txtUserPassword.Text.Trim();

            if (string.IsNullOrEmpty(_user.password))
            {
                MessageBox.Show("Password cannot be empty. Please enter a valid user name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // Validate permissions: Full Access or at least one individual permission must be checked
            if (!checkBoxFullAccess.Checked &&
                !checkBoxCategories.Checked &&
                !checkBoxOrders.Checked &&
                !checkBoxOrderItems.Checked &&
                !checkBoxUsers.Checked &&
                !checkBoxItems.Checked)
            {
                MessageBox.Show("You must assign at least one permission.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            _user.permissions = CalculatePermissions();
         

            if (_user.Save())
            {
                MessageBox.Show("Saved Succssefully");
                lbUserID.Text = _user.ID.ToString();


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

        private int CalculatePermissions()
        {
            int permissions = 0;

            if (checkBoxFullAccess.Checked)
            {
                permissions = -1;
            }
            else
            {
                foreach (Control control in panelPermissions.Controls)
                {
                    if (control is System.Windows.Forms.CheckBox checkBox && checkBox != checkBoxFullAccess)
                    {
                        if (checkBox.Checked)
                        {
                            int tagValue = Convert.ToInt32(checkBox.Tag);
                            permissions += tagValue;
                        }
                    }
                }
            }

            lbPermissions.Text = permissions.ToString();
            return permissions;
        }

        private void PermissionsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CalculatePermissions();
        }








    }
}
