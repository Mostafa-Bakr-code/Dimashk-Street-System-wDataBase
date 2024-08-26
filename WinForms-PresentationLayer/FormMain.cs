using System;
using System.Data;
using System.Drawing;
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

        private void FormMain_Load(object sender, EventArgs e)
        {
            _RefreshItemsList();
            _FillCategoriesInComoboBox();
            _FillItemsNameInComoboBox();
        }

        private void btnItemsMenu_Click(object sender, EventArgs e)
        {
            dgvOrders.Visible = false;
            dgvOrderItems.Visible = false;
            dgvCategories.Visible = false;
            dgvListItems.Visible = true;
            dgvListItems.DataSource = clsItemBusiness.GetAllItems();
            panelOrdersTotal.Visible = false;

            btnAddItem.Visible = true;
            btnAddCategory.Visible = false;
        }

        private void btnOrdersMenu_Click(object sender, EventArgs e)
        {
            dgvListItems.Visible=false;
            dgvOrderItems.Visible = false;
            dgvCategories.Visible = false;
            dgvOrders.Visible = true;
            dgvOrders.DataSource = clsOrderBusiness.GetAllOrders();
            panelOrdersTotal.Visible = true;

            btnAddItem.Visible = false;
            btnAddCategory.Visible = false;

        }

        private void btnOrderItems_Click(object sender, EventArgs e)
        {
            dgvListItems.Visible = false;
            dgvCategories.Visible = false;
            dgvOrders.Visible = false;
            dgvOrderItems.Visible = true;
            dgvOrderItems.DataSource = clsOrderItemsBusiness.GetAllOrderItems();
            panelOrdersTotal.Visible = false;

            btnAddItem.Visible = false;
            btnAddCategory.Visible = false;
        }

        private void btnCategoriesMenu_Click(object sender, EventArgs e)
        {
            dgvListItems.Visible = false;
            dgvOrderItems.Visible = false;
            dgvOrders.Visible = false;
            dgvCategories.Visible = true;
            dgvCategories.DataSource = clsCategoryBusiness.GetAllCategories();
            panelOrdersTotal.Visible = false;

            btnAddItem.Visible = false;
            btnAddCategory.Visible = true;
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

        private void btnAllTimeTotal_Click(object sender, EventArgs e)
        {
            decimal total = clsOrderBusiness.GetTotalForAllOrders();
            int numOfOrders = clsOrderBusiness.GetTotalNumberOfOrders();

            DateTime earliestDate = clsOrderBusiness.GetEarliestOrderDate();
            DateTime latestDate = clsOrderBusiness.GetLatestOrderDate();


            MessageBox.Show($"Total for all orders: {total}\n" +
                            $"Number of Orders: {numOfOrders}\n" +
                            $"Earliest order date: {earliestDate.ToShortDateString()}\n" +
                            $"Latest order date: {latestDate.ToShortDateString()}",
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
                MessageBox.Show("End date cannot be before start date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            decimal total = clsOrderBusiness.GetTotalByDateRange(startDate, endDate);
            int numOfOrders = clsOrderBusiness.GetTotalNumberOfOrdersByDateRange(startDate,endDate);


            MessageBox.Show($"Total from {startDate.ToShortDateString()} to {endDate.ToShortDateString()}: {total}\n" + $"Number of Orders: {numOfOrders}\n"

                , "Total Orders Free not included", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTotalbyCategory_Click(object sender, EventArgs e)
        {

            if (cbItemCategory.SelectedItem != null)
            {

                DateTime earliestDate = clsOrderBusiness.GetEarliestOrderDate();
                DateTime latestDate = clsOrderBusiness.GetLatestOrderDate();

                string selectedCategory = cbItemCategory.SelectedItem.ToString();


                decimal total = clsOrderItemsBusiness.GetTotalByCategoryName(selectedCategory);
                int countOfCategory = clsCategoryBusiness.GetCategoryCount(selectedCategory);


                MessageBox.Show($"Total for category '{selectedCategory}': {total}\n" + 
                    $"Count {countOfCategory} \n" +
                    $"Earliest order date: {earliestDate.ToShortDateString()}\n" +
                            $"Latest order date: {latestDate.ToShortDateString()}", "Total by Category Free not included", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                DateTime earliestDate = clsOrderBusiness.GetEarliestOrderDate();
                DateTime latestDate = clsOrderBusiness.GetLatestOrderDate();

                string selectedItem = cbItemName.SelectedItem.ToString();


                decimal total = clsOrderItemsBusiness.GetTotalByItemName(selectedItem);
                int count = clsOrderItemsBusiness.GetItemCountByName(selectedItem);


                MessageBox.Show($"Total for Item '{selectedItem}': {total}\n" + $"Earliest order date: {earliestDate.ToShortDateString()}\n" +

                            $"Count: {count}\n" +
                            $"Latest order date: {latestDate.ToShortDateString()}", "Total by ItemName Free Not Included", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show("Please select ItemName from the dropdown.", "ItemName Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTotalbyItemNameAndDateRange_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePickerStart.Value.Date;
            DateTime endDate = dateTimePickerEnd.Value.Date;

            if (endDate < startDate)
            {
                MessageBox.Show("End date cannot be before start date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string selectedItemName = "";

            if (cbItemName.SelectedItem != null)
            {

                selectedItemName = cbItemName.SelectedItem.ToString();

            }
            else
            {

                MessageBox.Show("Please select ItemName from the dropdown.", "ItemName Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            decimal total = clsOrderItemsBusiness.GetTotalByItemNameAndDateRange(selectedItemName, startDate, endDate);
            int count = clsOrderItemsBusiness.GetItemCountByNameAndDateRange(selectedItemName,startDate,endDate);

            string message = $"Total for ItemName '{selectedItemName}' from {startDate:MM/dd/yyyy} to {endDate:MM/dd/yyyy}: {total}\n"
                + $"Count: {count}\n";


            MessageBox.Show(message, "Total by Item Name and Date Range Free Items Not Included", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTotalbyCategoryAndDateRange_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePickerStart.Value.Date;
            DateTime endDate = dateTimePickerEnd.Value.Date;

            if (endDate < startDate)
            {
                MessageBox.Show("End date cannot be before start date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string selectedCategory = "";

            if (cbItemCategory.SelectedItem != null)
            {

                selectedCategory = cbItemCategory.SelectedItem.ToString();

            }
            else
            {

                MessageBox.Show("Please select a category from the dropdown.", "Category Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            decimal total = clsOrderItemsBusiness.GetTotalByCategoryNameAndDateRange(selectedCategory, startDate, endDate);
            int count = clsCategoryBusiness.GetCountOfOrdersByCategoryAndDateRange(selectedCategory, startDate, endDate);

            string message = $"Total for category '{selectedCategory}' from {startDate:MM/dd/yyyy} to {endDate:MM/dd/yyyy}: {total}\n"
                + $"Count: {count}";
                

            MessageBox.Show(message, "Total by Category and Date Range Free Not Included", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnFreeOrdersTotal_Click(object sender, EventArgs e)
        {
            decimal total = clsOrderBusiness.GetTotalOfFreeOrders();
            int numOfFreeOrders = clsOrderBusiness.GetCountOfFreeOrders();


            DateTime earliestDate = clsOrderBusiness.GetEarliestOrderDate();
            DateTime latestDate = clsOrderBusiness.GetLatestOrderDate();


            MessageBox.Show($"Total for all Free orders: {total}\n" +
                            $"Number of Free Orders: {numOfFreeOrders}\n" +
                            $"Earliest order date: {earliestDate.ToShortDateString()}\n" +
                            $"Latest order date: {latestDate.ToShortDateString()}",
                            "Total Orders",
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
                MessageBox.Show("End date cannot be before start date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show($"Total for all Free orders: {total}\n" +
                 $"Number of Free Orders: {numOfFreeOrders}\n" +
                $"Start date: {startDate.ToShortDateString()}\n" +
                $"End date: {endDate.ToShortDateString()}",
                "Total Free Orders",
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

            FormAddEditOrder frm = new FormAddEditOrder((int)dgvOrders.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
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
















        // add orderitems edit , prepare to refresh the orderitems when closing the form
    }
}

