﻿using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;
using BuisnessLayer;

namespace WinForms_PresentationLayer
{
    public partial class FormMain : Form
    {
        public FormMain()
        {

            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

        }


        private void _RefreshItemsList()
        {

            if (cbCategory1.SelectedItem != null)
            {
                
                dgvListItems.DataSource = clsItemBusiness.GetItemsByCategoryName(cbCategory1.SelectedItem.ToString());
            }
            else
            {
               
                dgvListItems.DataSource = null;  
              
            }


        }

        private void _RefreshCategoriesList()
        {

            dgvCategories.DataSource = clsCategoryBusiness.GetAllCategories();

        }

        public void _RefreshOrderList()
        {
            dgvOrders.DataSource = clsOrderBusiness.GetAllOrders();
        }

        public void _RefreshOrderItemsList()
        {
            dgvOrderItems.DataSource = clsOrderItemsBusiness.GetAllOrderItems();
        }

        private void _RefreshUsersList()
        {

            dgvUsersMenu.DataSource = clsUserBusiness.GetAllUsers();

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //_RefreshItemsList();
            _FillCategoriesInComboBox(cbCategory);
            _FillItemsNameInComoboBox();
            panelDateRange.Visible = false;

            if (clsUserBusiness.ActiveUser != null)
            {
                lbActiveUserName.Text = clsUserBusiness.ActiveUser.userName;
                lbActiveTime.Text = clsUserBusiness.ActiveUser.LogInTime.ToString("hh:mm tt");
            }
            else
            {
                lbActiveUserName.Text = "???"; 
            }

        }

        private void CheckPermissionsAndExecute(Button clickedButton, Action action)
        {
            int requiredPermission = Convert.ToInt32(clickedButton.Tag);

            if ((clsUserBusiness.ActiveUser.permissions & requiredPermission) == requiredPermission)
            {
                action(); 
            }
            else
            {
                MessageBox.Show("ليس لديك صلاحية الدخول علي القائمة");
            }
        }

        private void btnItemsMenu_Click(object sender, EventArgs e)
        {
            CheckPermissionsAndExecute((Button)sender, () =>
            {
                dgvOrders.Visible = false;
                dgvOrderItems.Visible = false;
                dgvCategories.Visible = false;
                dgvListItems.Visible = true;
                dgvUsersMenu.Visible = false;
                dgvLogs.Visible = false;
                dgvTodaysLogs.Visible = false;
                panelOrdersTotal.Visible = false;
                panelOrdersBtns.Visible = false;
                panelLogsBtns.Visible = false;

                btnAddItem.Visible = true;
                btnAddCategory.Visible = false;
                btnAddUser.Visible = false;
                dgvLogs.DataSource = null;

                panelListItemByCategory.Visible = true;
                _FillCategoriesInComboBox(cbCategory1);
                panelDateRange.Visible = false;
                

            });
        }

        private void btnShowItemsByCategory_Click(object sender, EventArgs e)
        {

            string selectedCategory = "";

            if (cbCategory1.SelectedItem != null)
            {

                selectedCategory = cbCategory1.SelectedItem.ToString();

            }
            else
            {

                MessageBox.Show("Please select a category from the dropdown.", "Category Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            dgvListItems.DataSource = clsItemBusiness.GetItemsByCategoryName(selectedCategory);

        }

        private void btnViewAllItems_Click(object sender, EventArgs e)
        {
            dgvListItems.DataSource = clsItemBusiness.GetAllItems();
        }

        private void btnOrdersMenu_Click(object sender, EventArgs e)
        {

            CheckPermissionsAndExecute((Button)sender, () =>
            {
                dgvListItems.Visible = false;
                dgvOrderItems.Visible = false;
                dgvCategories.Visible = false;
                dgvOrders.Visible = true;
                dgvUsersMenu.Visible = false;
                dgvLogs.Visible = false;
                dgvTodaysLogs.Visible = false;

                panelOrdersBtns.Visible = true;
                panelLogsBtns.Visible = false;

                //dgvOrders.DataSource = clsOrderBusiness.GetAllOrders();



                panelOrdersTotal.Visible = true;

                btnAddItem.Visible = false;
                btnAddCategory.Visible = false;
                btnAddUser.Visible = false;
                panelListItemByCategory.Visible = false;
                dgvListItems.DataSource = null;
                dgvLogs.DataSource = null;
                panelDateRange.Visible = true;
               

            });



        }

        private void btnshowOrdersByDate_Click(object sender, EventArgs e)
        {

            DateTime startDate = dateTimePickerStart.Value.Date;
            DateTime endDate = dateTimePickerEnd.Value.Date;

            if (endDate < startDate)
            {
                MessageBox.Show("التاريخ الي لا يمكن ان يكون فبل التاريخ من.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvOrders.DataSource = clsOrderBusiness.GetOrdersByDateRange(startDate, endDate);

          
        }

        private void btnOrderItems_Click(object sender, EventArgs e)
        {


            //CheckPermissionsAndExecute((Button)sender, () =>
            //{
            //    dgvListItems.Visible = false;
            //    dgvCategories.Visible = false;
            //    dgvOrders.Visible = false;
            //    dgvOrderItems.Visible = true;
            //    dgvUsersMenu.Visible = false;
            //    dgvLogs.Visible = false;
            //    dgvTodaysLogs.Visible = false;

            //    dgvOrderItems.DataSource = clsOrderItemsBusiness.GetAllOrderItems();
            //    panelOrdersTotal.Visible = false;
            //panelOrdersBtns.Visible = false;

            //    btnAddItem.Visible = false;
            //    btnAddCategory.Visible = false;
            //    btnAddUser.Visible = false;
            //    panelListItemByCategory.Visible = false;
            //    dgvListItems.DataSource = null;
            //panelDateRange.Visible = false;
            //panelLogsBtns.Visible = false;
            //dgvLogs.DataSource = null;

            //});


        }

        private void btnCategoriesMenu_Click(object sender, EventArgs e)
        {

            CheckPermissionsAndExecute((Button)sender, () =>
            {
                dgvListItems.Visible = false;
                dgvOrderItems.Visible = false;
                dgvOrders.Visible = false;
                dgvCategories.Visible = true;
                dgvUsersMenu.Visible = false;
                dgvLogs.Visible = false;
                dgvTodaysLogs.Visible = false;
                dgvCategories.DataSource = clsCategoryBusiness.GetAllCategories();
                panelOrdersTotal.Visible = false;
                panelOrdersBtns.Visible = false;
                panelLogsBtns.Visible = false;

                btnAddItem.Visible = false;
                btnAddUser.Visible = false;
                btnAddCategory.Visible = true;
                panelListItemByCategory.Visible = false;
                dgvListItems.DataSource = null;
                panelDateRange.Visible = false;
                
                dgvLogs.DataSource = null;

            });



        }

        private void btnUsersMenu_Click(object sender, EventArgs e)
        {


            CheckPermissionsAndExecute((Button)sender, () =>
            {
                dgvListItems.Visible = false;
                dgvOrderItems.Visible = false;
                dgvOrders.Visible = false;
                dgvCategories.Visible = false;
                dgvUsersMenu.Visible = true;
                panelOrdersTotal.Visible = false;
                dgvLogs.Visible = false;
                dgvTodaysLogs.Visible = false;
                panelOrdersBtns.Visible = false;
                panelLogsBtns.Visible = false;

                dgvUsersMenu.DataSource = clsUserBusiness.GetAllUsers();

                btnAddItem.Visible = false;
                btnAddCategory.Visible = false;
                btnAddUser.Visible = true;
                panelListItemByCategory.Visible = false;
                dgvListItems.DataSource = null;
                panelDateRange.Visible = false;
               
                dgvLogs.DataSource = null;

            });


        }

        private void btnLogMenu_Click(object sender, EventArgs e)
        {

            dgvListItems.Visible = false;
            dgvOrderItems.Visible = false;
            dgvOrders.Visible = false;
            dgvCategories.Visible = false;
            dgvUsersMenu.Visible = false;
            dgvLogs.Visible = true;
            dgvTodaysLogs.Visible = true;
            panelOrdersTotal.Visible = false;


            panelDateRange.Visible = true;
            panelOrdersBtns.Visible = false;
            panelLogsBtns.Visible=true;
            
            dgvTodaysLogs.DataSource = clsLogsBusiness.GetTodaysLogs();

            btnAddItem.Visible = false;
            btnAddCategory.Visible = false;
            btnAddUser.Visible = false;
            panelListItemByCategory.Visible = false;
            dgvListItems.DataSource = null;
          


        }

        private void btnShowLogsByDate_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePickerStart.Value.Date;
            DateTime endDate = dateTimePickerEnd.Value.Date;

            if (endDate < startDate)
            {
                MessageBox.Show("End date cannot be before start date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvLogs.DataSource = clsLogsBusiness.GetLogsByDateRange(startDate,endDate);
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            FormAddEditCategories frm = new FormAddEditCategories(-1);
            frm.ShowDialog();
            _RefreshCategoriesList();
   
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            FormAddEditItem frm = new FormAddEditItem(-1);
            frm.ShowDialog();
            _RefreshItemsList();

      
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            FormAddEditUser frm = new FormAddEditUser(-1);
            frm.ShowDialog();
            _RefreshItemsList();
        }

        private void btnAllTimeTotal_Click(object sender, EventArgs e)
        {
            decimal total = clsOrderBusiness.GetTotalForAllOrders();
            int numOfOrders = clsOrderBusiness.GetTotalNumberOfOrders();

            DateTime earliestDate = clsOrderBusiness.GetEarliestOrderDate();
            DateTime latestDate = clsOrderBusiness.GetLatestOrderDate();


            MessageBox.Show($"اجمالي جميع الطلبات: {total}\n" +
                            $"عدد الطلبات: {numOfOrders}\n" +
                            $"من: {earliestDate.ToShortDateString()}\n" +
                            $"الي: {latestDate.ToShortDateString()}",
                            "Total Orders Free not included",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void btnTotalRange_Click(object sender, EventArgs e)
        {

            DateTime startDate = dateTimePickerStart.Value.Date;
            DateTime endDate = dateTimePickerEnd.Value.Date;

            if (endDate < startDate)
            {
                MessageBox.Show("التاريخ الي لا يمكن ان يكون فبل التاريخ من.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            decimal total = clsOrderBusiness.GetTotalByDateRange(startDate, endDate);
            int numOfOrders = clsOrderBusiness.GetTotalNumberOfOrdersByDateRange(startDate,endDate);


            MessageBox.Show($"الاجمالي من {startDate.ToShortDateString()} الي {endDate.ToShortDateString()}: {total}\n" + $"عدد الطلبات: {numOfOrders}\n"

                , "Total Orders Free not included", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTotalbyCategory_Click(object sender, EventArgs e)
        {

            if (cbCategory.SelectedItem != null)
            {

                DateTime earliestDate = clsOrderBusiness.GetEarliestOrderDate();
                DateTime latestDate = clsOrderBusiness.GetLatestOrderDate();

                string selectedCategory = cbCategory.SelectedItem.ToString();


                decimal total = clsOrderItemsBusiness.GetTotalByCategoryName(selectedCategory);
                int countOfCategory = clsCategoryBusiness.GetCategoryCount(selectedCategory);


                MessageBox.Show($"اجمالي الاصناف '{selectedCategory}': {total}\n" + 
                    $"العدد {countOfCategory} \n" +
                    $"من: {earliestDate.ToShortDateString()}\n" +
                            $"الي: {latestDate.ToShortDateString()}", "Total by Category Free not included", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show("برجاء اختيار الصنف من اللسته.", "Category Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTotalbyItemName_Click(object sender, EventArgs e)
        {
            if (cbItemName.SelectedItem != null)
            {
                DateTime earliestDate = clsOrderBusiness.GetEarliestOrderDate();
                DateTime latestDate = clsOrderBusiness.GetLatestOrderDate();

                string selectedItem = cbItemName.SelectedItem.ToString();


                decimal total = clsOrderItemsBusiness.GetTotalByItemName(selectedItem);
                int count = clsOrderItemsBusiness.GetItemCountByName(selectedItem);


                MessageBox.Show($"اجمالي الاطباق '{selectedItem}': {total}\n" + $"من: {earliestDate.ToShortDateString()}\n" +

                            $"Count: {count}\n" +
                            $"الي: {latestDate.ToShortDateString()}", "Total by ItemName Free Not Included", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show("برجاء اختيار الطبق من اللسته.", "ItemName Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTotalbyItemNameAndDateRange_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePickerStart.Value.Date;
            DateTime endDate = dateTimePickerEnd.Value.Date;

            if (endDate < startDate)
            {
                MessageBox.Show("التاريخ الي لا يمكن ان يكون فبل التاريخ من.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string selectedItemName = "";

            if (cbItemName.SelectedItem != null)
            {

                selectedItemName = cbItemName.SelectedItem.ToString();

            }
            else
            {

                MessageBox.Show("برجاء اختيار الطبق من اللسته.", "ItemName Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            decimal total = clsOrderItemsBusiness.GetTotalByItemNameAndDateRange(selectedItemName, startDate, endDate);
            int count = clsOrderItemsBusiness.GetItemCountByNameAndDateRange(selectedItemName,startDate,endDate);

            string message = $"اجمالي الطبق '{selectedItemName}' من {startDate:MM/dd/yyyy} الي {endDate:MM/dd/yyyy}: {total}\n"
                + $"العدد: {count}\n";


            MessageBox.Show(message, "Total by Item Name and Date Range Free Items Not Included", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTotalbyCategoryAndDateRange_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePickerStart.Value.Date;
            DateTime endDate = dateTimePickerEnd.Value.Date;

            if (endDate < startDate)
            {
                MessageBox.Show("التاريخ الي لا يمكن ان يكون فبل التاريخ من", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string selectedCategory = "";

            if (cbCategory.SelectedItem != null)
            {

                selectedCategory = cbCategory.SelectedItem.ToString();

            }
            else
            {

                MessageBox.Show("برجاء اختيارالصنف من اللسته.", "Category Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            decimal total = clsOrderItemsBusiness.GetTotalByCategoryNameAndDateRange(selectedCategory, startDate, endDate);
            int count = clsCategoryBusiness.GetCountOfOrdersByCategoryAndDateRange(selectedCategory, startDate, endDate);

            string message = $"اجمالي الصنف '{selectedCategory}' من {startDate:MM/dd/yyyy} الي {endDate:MM/dd/yyyy}: {total}\n"
                + $"العدد: {count}";
                

            MessageBox.Show(message, "Total by Category and Date Range Free Not Included", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnFreeOrdersTotal_Click(object sender, EventArgs e)
        {
            decimal total = clsOrderBusiness.GetTotalOfFreeOrders();
            int numOfFreeOrders = clsOrderBusiness.GetCountOfFreeOrders();


            DateTime earliestDate = clsOrderBusiness.GetEarliestOrderDate();
            DateTime latestDate = clsOrderBusiness.GetLatestOrderDate();


            MessageBox.Show($"اجمالي الطلبات المجانيه: {total}\n" +
                            $"عدد الطلبات المجانيه: {numOfFreeOrders}\n" +
                            $"من: {earliestDate.ToShortDateString()}\n" +
                            $"الي: {latestDate.ToShortDateString()}",
                            "الطلبات المجانيه",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void btnFreeOrdersTotalRange_Click(object sender, EventArgs e)
        {

            DateTime startDate = dateTimePickerStart.Value.Date;
            DateTime endDate = dateTimePickerEnd.Value.Date;

            decimal total = clsOrderBusiness.GetTotalOfFreeOrdersByDateRange(startDate, endDate);
            int numOfFreeOrders = clsOrderBusiness.GetCountOfFreeOrdersByDateRange(startDate,endDate);

            if (endDate < startDate)
            {
                MessageBox.Show("التاريخ الي لا يمكن ان يكون فبل التاريخ من.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show($"اجمالي الطلبات المجانيه: {total}\n" +
                 $"عدد الطلبات المجانيه: {numOfFreeOrders}\n" +
                $"من: {startDate.ToShortDateString()}\n" +
                $"الي: {endDate.ToShortDateString()}",
                "الطلبات المجانيه",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            FormAddEditOrder frm = new FormAddEditOrder(-1);
            frm.ShowDialog();
        }

        private void toolStripEditOrder_Click(object sender, EventArgs e)
        {
            // function works but on hold for now

            //FormAddEditOrder frm = new FormAddEditOrder((int)dgvOrders.CurrentRow.Cells[0].Value);
            //frm.ShowDialog();
        }

        private void toolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
           
            FormAddEditItem frm = new FormAddEditItem((int)dgvListItems.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshItemsList();

        }

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            string itemID = dgvListItems.CurrentRow.Cells[0].Value.ToString();

            DialogResult result =
            MessageBox.Show($"هل انت متاكد مسح الطبق {itemID}",
                "Delete Item", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                if (clsItemBusiness.DeleteItem(int.Parse(itemID)))
                    MessageBox.Show("تم المسح بنجاح");
                _RefreshItemsList();
            }
        }

        private void toolStripMenuEditCategory_Click(object sender, EventArgs e)
        {
            FormAddEditCategories frm = new FormAddEditCategories((int)dgvCategories.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshCategoriesList();
        }

        private void toolStripMenuDeleteCategory_Click(object sender, EventArgs e)
        {
            string categoryID = dgvCategories.CurrentRow.Cells[0].Value.ToString();
            DialogResult result =
            MessageBox.Show($"هل انت متاكد مسح الصنف {categoryID}",
                "Delete Item", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                if (clsCategoryBusiness.DeleteCategory((int)dgvCategories.CurrentRow.Cells[0].Value))
                    MessageBox.Show("تم المسح بنجاح");
                _RefreshCategoriesList();
            }
        }

        private void toolStripShowOrderItems_Click(object sender, EventArgs e)
        {
            int orderID = -1; 

            if (dgvOrders.CurrentRow != null)
            {
                orderID = Convert.ToInt32(dgvOrders.CurrentRow.Cells[0].Value);

                MessageBox.Show($"Selected OrderID: {orderID}");

                FormViewOrderItems frm = new FormViewOrderItems(orderID);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select an order first.");
            }


        }

        private void toolStripDeleteUsers_Click(object sender, EventArgs e)
        {
            string userID = dgvUsersMenu.CurrentRow.Cells[0].Value.ToString();

            DialogResult result =
            MessageBox.Show($"هل انت متاكد مسح المستخدم{userID}",
                "Delete User", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                if (clsUserBusiness.DeleteUser(int.Parse(userID)))
                    MessageBox.Show("تم المسح بنجاح");
                _RefreshUsersList();
            }
        }

        private void toolStripEditUsers_Click(object sender, EventArgs e)
        {
            FormAddEditUser frm = new FormAddEditUser((int)dgvUsersMenu.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshUsersList();
        }

        private void _FillCategoriesInComboBox(ComboBox comboBox)
        {
            
            comboBox.Items.Clear();

            
            DataTable dtCategories = clsCategoryBusiness.GetAllCategories();

            
            foreach (DataRow row in dtCategories.Rows)
            {
                comboBox.Items.Add(row["CategoryName"]);
            }
        }

        private void _FillItemsNameInComoboBox()
        {
            DataTable dtCategories = clsItemBusiness.GetAllItems();

            foreach (DataRow row in dtCategories.Rows)
            {

                cbItemName.Items.Add(row["ItemName"]);

            }

        }

        private void dgvOrders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           
            if (e.ColumnIndex == dgvOrders.Columns["Total"].Index && e.Value != null)
            {
                decimal orderTotal;
                if (decimal.TryParse(e.Value.ToString(), out orderTotal))
                {
                    if (orderTotal == 0)
                    {
                        // Apply formatting to the entire row
                        dgvOrders.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                        dgvOrders.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;


                    }
                }
            }
        }

        private void btnTaxValue_Click(object sender, EventArgs e)
        {
            decimal total = clsOrderBusiness.GetTotalTaxValueForAllOrders();
       

            DateTime earliestDate = clsOrderBusiness.GetEarliestOrderDate();
            DateTime latestDate = clsOrderBusiness.GetLatestOrderDate();


            // Round the total to 2 decimal places
            decimal roundedTotal = Math.Round(total, 2);

   

            MessageBox.Show($"Tax for all orders: {roundedTotal}\n" +
                           
                            $"Earliest order date: {earliestDate.ToShortDateString()}\n" +
                            $"Latest order date: {latestDate.ToShortDateString()}",
                            "Total Tax value",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void btnTaxValueDateRange_Click(object sender, EventArgs e)
        {

            DateTime startDate = dateTimePickerStart.Value.Date;
            DateTime endDate = dateTimePickerEnd.Value.Date;

            if (endDate < startDate)
            {
                MessageBox.Show("End date cannot be before start date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            decimal total = clsOrderBusiness.GetTotalTaxValueByDateRange(startDate, endDate);

            // Round the total to 2 decimal places
            decimal roundedTotal = Math.Round(total, 2);

            MessageBox.Show($"Tax Value from {startDate.ToShortDateString()} to {endDate.ToShortDateString()}: {roundedTotal}\n",
                            "Total Tax Value",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

 
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the click is on a valid row and the first column (OrderID)
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                // Retrieve the OrderID from the clicked cell
                int orderId = Convert.ToInt32(dgvOrders.Rows[e.RowIndex].Cells[0].Value);

                // Call the function to get the initial price and tax value
                (decimal InitialPrice, decimal TaxValue) result = clsOrderBusiness.GetInitialPriceAndTaxValueForOrder(orderId);

                // Extract the InitialPrice and TaxValue from the tuple
                decimal initialPrice = result.Item1;
                decimal taxValue = result.Item2;

                // Display the results
                MessageBox.Show($"Order ID: {orderId}\nInitial Price: {initialPrice:C}\nTax Value: {taxValue:C}",
                                "Order Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLogIN_Click(object sender, EventArgs e)
        {
            FormLogIn frm = new FormLogIn();
            frm.ShowDialog();
        }

        private void LogOutUser()
        {
            if (clsUserBusiness.ActiveUser != null)
            {
                DateTime logOutTime = DateTime.Now;

                int userID = clsUserBusiness.ActiveUser.ID;

                DateTime logInTime = clsUserBusiness.ActiveUser.LogInTime;

                clsLogsBusiness.AddNewLog(userID, logInTime, logOutTime);

                clsUserBusiness.ClearActiveUser();
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
                           
            LogOutUser();
            
            FormLogIn loginForm = new FormLogIn();
            loginForm.Show();
            this.Close();

        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogOutUser();
        }

        private void btnPrintOrder_Click(object sender, EventArgs e)
        {
            FormPrintOrder frm = new FormPrintOrder();
            frm.ShowDialog();
        }




    }
}

