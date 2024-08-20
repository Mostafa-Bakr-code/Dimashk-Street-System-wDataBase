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
    public partial class FormAddEditOrder : Form
    {

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        int _orderID;
        clsOrderBusiness _Order;

        private bool _orderPlaced = false;

        public FormAddEditOrder(int orderID)
        {
            InitializeComponent();

            this.FormClosing += FormAddEditOrder_FormClosing;

            _orderID = orderID;


            if (_orderID == -1)
            {

                _Mode = enMode.AddNew;
            }
            else
            {
                _Mode = enMode.Update;
            }
        }

        private void listOrderItems(int orderID)
        {

            dgvOrderItems.DataSource = clsOrderItemsBusiness.GetAllOrderItemsbyID(orderID);

            dgvOrderItems.ReadOnly = true;

            if (dgvOrderItems.Columns.Contains("Quantity"))
            {
                dgvOrderItems.Columns["Quantity"].ReadOnly = false;
            }
        }

        private void updateOrderDataDisplay()
        {
            

            lbOrderID.Text = _Order.ID.ToString();
            lbOrderDate.Text = _Order.date.ToString();
            lbOrderTotal.Text = _Order.Total.ToString();

        }

        private void LoadData()
        {

            dgvListItems.DataSource = clsItemBusiness.GetAllItems();
           

            // Add Mode
            if (_Mode == enMode.AddNew)
            {
                lbMode.Text = "Add Order";
                _Order = new clsOrderBusiness();
                _Order.Save();

                updateOrderDataDisplay();

                listOrderItems(_Order.ID);
                return;
            }


            // Update Mode
            else
            {

                lbMode.Text = $"Update Order {_orderID}";

                _Order = clsOrderBusiness.Find(_orderID);

                if (_Order == null)
                {
                    MessageBox.Show("This form will be closed because No Order with ID = " + _orderID);
                    //this.Close();

                    return;
                }

                updateOrderDataDisplay();

            }

        }

        private void dgvListItems_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
            if (e.RowIndex >= 0)
            {
             
                DataGridView dgvListItems = sender as DataGridView;

             
                if (dgvListItems != null)
                {
                 
                    int itemIDColumnIndex = 0; 

                   
                    object itemIDValue = dgvListItems.Rows[e.RowIndex].Cells[itemIDColumnIndex].Value;

                    if (itemIDValue != null)
                    {
                  
                        int itemID = Convert.ToInt32(itemIDValue);

                        clsOrderItemsBusiness orderItem = new clsOrderItemsBusiness();

                        orderItem.ItemID = itemID;
                        orderItem.OrderID = _Order.ID;
                        orderItem.Save();

                        _Order = clsOrderBusiness.Find(_Order.ID);
                        updateOrderDataDisplay();
                        listOrderItems(_Order.ID);

                    }
                    else
                    {
                        MessageBox.Show("ItemID is null.");
                    }
                }
            }
        }

        private void FormAddEditOrder_Load(object sender, EventArgs e)
        {
            LoadData(); 
        }

        private void FormAddEditOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_orderPlaced) {


                DialogResult result = MessageBox.Show(
              "Are you sure you want to delete this order and all its items?",
                 "Confirm Delete",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Warning
                                        );


                if (result == DialogResult.Yes)
                {
                    deleteOrderItems();
                    deleteOrder();
                    MessageBox.Show("Order and its items have been deleted successfully.");
                }
                else
                {

                    e.Cancel = true;
                }
            }


        }

        private void deleteOrder()
        {
            
            if (_Order != null)
            {
                bool success = clsOrderBusiness.DeleteOrder(_Order.ID);

                if (success)
                {
                    MessageBox.Show("Order deleted successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to delete the order.");
                }
            }
            else
            {
                MessageBox.Show("Order data is not available.");
            }
        }

        private void deleteOrderItems()

        {
            if (_Order != null)
            {
                bool success = clsOrderItemsBusiness.DeleteOrderItemsByOrderID(_Order.ID);

                if (success)
                {
                    MessageBox.Show("OrderItems deleted successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to delete the orderItems.");
                }
            }
            else
            {
                MessageBox.Show("OrderItems data is not available.");
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (_Order == null)
            {
                MessageBox.Show("Order data is not available.");
                return;
            }

            if (dgvOrderItems.Rows.Count == 0)
            {
                MessageBox.Show("You must add at least one item to the order.");
                return;
            }

            _Order.UpdateOrderTotal();

            bool success = _Order.Save();

            if (success)
            {
                MessageBox.Show("Order placed successfully!");

                _orderPlaced = true;

                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to place the order. Please try again.");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItemDeleteOrderItem_Click(object sender, EventArgs e)
        {
            string orderItemID = dgvOrderItems.CurrentRow.Cells[0].Value.ToString();

            MessageBox.Show(orderItemID);

            DialogResult result =
            MessageBox.Show($"Are you sure you want to delete this Order Item {orderItemID}",
                "Delete Order Item", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                if (clsOrderItemsBusiness.DeleteOrderItems(int.Parse(orderItemID)))
                    MessageBox.Show("Deleted Sucssefully");
                    listOrderItems(_Order.ID);
            }

        }



    }
}
