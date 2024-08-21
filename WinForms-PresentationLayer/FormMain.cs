using System;
using System.Data;
using System.Windows.Forms;
using BuisnessLayer;

namespace WinForms_PresentationLayer
{
    public partial class FormMain : Form
    {
        public FormMain()
        {


            InitializeComponent();
           
        }

        private void _RefreshItemsList()
        {

            dgvListItems.DataSource = clsItemBusiness.GetAllItems();
            //dgvListItems.DataSource = clsCategoryBusiness.GetAllCategories();

        }

        private void _RefreshCategoriesList()
        {

            dgvCategories.DataSource = clsCategoryBusiness.GetAllCategories();

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            _RefreshItemsList();
            _FillCategoriesInComoboBox();
            _FillItemsNameInComoboBox();
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
            MessageBox.Show($"Are you sure you want to delete Item {itemID}",
                "Delete Item", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                if (clsItemBusiness.DeleteItem(int.Parse(itemID)))
                    MessageBox.Show("Deleted Sucssefully");
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
            MessageBox.Show($"Are you sure you want to delete Category {categoryID}",
                "Delete Item", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                if (clsCategoryBusiness.DeleteCategory((int)dgvCategories.CurrentRow.Cells[0].Value))
                    MessageBox.Show("Deleted Sucssefully");
                _RefreshCategoriesList();
            }
        }

        private void btnItemsMenu_Click(object sender, EventArgs e)
        {
            dgvOrders.Visible = false;
            dgvOrderItems.Visible = false;
            dgvCategories.Visible = false;
            dgvListItems.Visible = true;
            dgvListItems.DataSource = clsItemBusiness.GetAllItems();
            panelOrdersTotal.Visible = false;
        }

        private void btnOrdersMenu_Click(object sender, EventArgs e)
        {
            dgvListItems.Visible=false;
            dgvOrderItems.Visible = false;
            dgvCategories.Visible = false;
            dgvOrders.Visible = true;
            dgvOrders.DataSource = clsOrderBusiness.GetAllOrders();
            panelOrdersTotal.Visible = true;

        }

        private void btnOrderItems_Click(object sender, EventArgs e)
        {
            dgvListItems.Visible = false;
            dgvCategories.Visible = false;
            dgvOrders.Visible = false;
            dgvOrderItems.Visible = true;
            dgvOrderItems.DataSource = clsOrderItemsBusiness.GetAllOrderItems();
            panelOrdersTotal.Visible = false;
        }

        private void btnCategoriesMenu_Click(object sender, EventArgs e)
        {
            dgvListItems.Visible = false;
            dgvOrderItems.Visible = false;
            dgvOrders.Visible = false;
            dgvCategories.Visible = true;
            dgvCategories.DataSource = clsCategoryBusiness.GetAllCategories();
            panelOrdersTotal.Visible = false;
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

        private void toolStripEditOrder_Click(object sender, EventArgs e)
        {

        }

        private void toolStripDeleteOrder_Click(object sender, EventArgs e)
        {

        }

        private void toolStripEditOrderItems_Click(object sender, EventArgs e)
        {

        }

        private void toolStripDeleteOrderItem_Click(object sender, EventArgs e)
        {

        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            FormAddEditOrder frm = new FormAddEditOrder(-1);
            frm.ShowDialog();
        }

        private void btnAddOrderItems_Click(object sender, EventArgs e)
        {



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

        private void btnAllTimeTotal_Click(object sender, EventArgs e)
        {
            decimal total = clsOrderBusiness.GetTotalForAllOrders();

   
            DateTime earliestDate = clsOrderBusiness.GetEarliestOrderDate();
            DateTime latestDate = clsOrderBusiness.GetLatestOrderDate();


            MessageBox.Show($"Total for all orders: {total}\n" +
                            $"Earliest order date: {earliestDate.ToShortDateString()}\n" +
                            $"Latest order date: {latestDate.ToShortDateString()}",
                            "Total Orders",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void btnTotalRange_Click(object sender, EventArgs e)
        {
      
            DateTime startDate = dateTimePickerStart.Value.Date;
            DateTime endDate = dateTimePickerEnd.Value.Date;

            if (endDate < startDate)
            {
                MessageBox.Show("End date cannot be before start date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

      
            decimal total = clsOrderBusiness.GetTotalByDateRange(startDate, endDate);


            MessageBox.Show($"Total from {startDate.ToShortDateString()} to {endDate.ToShortDateString()}: {total}", "Total Orders", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void _FillCategoriesInComoboBox()
        {
            DataTable dtCategories = clsCategoryBusiness.GetAllCategories();

            foreach (DataRow row in dtCategories.Rows)
            {

                cbItemCategory.Items.Add(row["CategoryName"]);

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

        private void btnTotalbyCategory_Click(object sender, EventArgs e)
        {

            if (cbItemCategory.SelectedItem != null)
            {

                string selectedCategory = cbItemCategory.SelectedItem.ToString();


                decimal total = clsOrderItemsBusiness.GetTotalByCategoryName(selectedCategory);


                MessageBox.Show($"Total for category '{selectedCategory}': {total}", "Total by Category", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show("Please select a category from the dropdown.", "Category Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTotalbyItemName_Click(object sender, EventArgs e)
        {
            if (cbItemName.SelectedItem != null)
            {

                string selectedCategory = cbItemName.SelectedItem.ToString();


                decimal total = clsOrderItemsBusiness.GetTotalByItemName(selectedCategory);


                MessageBox.Show($"Total for Item '{selectedCategory}': {total}", "Total by ItemName", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show("Please select ItemName from the dropdown.", "ItemName Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        // start logic of calc sum total by item name isnt working, it returns 0
    }
}

