using System;
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
        }

        private void btnOrdersMenu_Click(object sender, EventArgs e)
        {
            dgvListItems.Visible=false;
            dgvOrderItems.Visible = false;
            dgvCategories.Visible = false;
            dgvOrders.Visible = true;
            dgvOrders.DataSource = clsOrderBusiness.GetAllOrders();
        }

        private void btnOrderItems_Click(object sender, EventArgs e)
        {
            dgvListItems.Visible = false;
            dgvCategories.Visible = false;
            dgvOrders.Visible = false;
            dgvOrderItems.Visible = true;
            dgvOrderItems.DataSource = clsOrderItemsBusiness.GetAllOrderItems();
        }

        private void btnCategoriesMenu_Click(object sender, EventArgs e)
        {
            dgvListItems.Visible = false;
            dgvOrderItems.Visible = false;
            dgvOrders.Visible = false;
            dgvCategories.Visible = true;
            dgvCategories.DataSource = clsCategoryBusiness.GetAllCategories();
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
    }
}

// start when deleteting orderitem you must update the totalprice