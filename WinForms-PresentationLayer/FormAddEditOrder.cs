using BuisnessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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

            
            dgvOrderItems.ReadOnly = false;

          
            foreach (DataGridViewColumn column in dgvOrderItems.Columns)
            {
                if (column.Name != "Quantity")
                {
                    column.ReadOnly = true;
                }
            }
        }

        private void updateOrderDataDisplay()
        {
            

            lbOrderID.Text = _Order.SerialNumber.ToString();
            lbOrderDate.Text = _Order.date.ToString();
            lbOrderTotal.Text = _Order.Total.ToString();
            updateOrderTax();

        }

        private void updateOrderTax()
        {

            (decimal InitialPrice, decimal TaxValue) result = clsOrderBusiness.GetInitialPriceAndTaxValueForOrder(_Order.ID);

      
            decimal initialPrice = result.Item1;
            decimal taxValue = result.Item2;

            lbSubTotal.Text = initialPrice.ToString();
            lbTaxValue.Text = taxValue.ToString();
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


            // Update Mode currently no need
            else
            {

                lbMode.Text = $"Update Order {_orderID}";

                _Order = clsOrderBusiness.Find(_orderID);

                updateOrderDataDisplay();

                listOrderItems(_Order.ID);

                if (_Order == null)
                {
                    MessageBox.Show("This form will be closed because No Order with ID = " + _orderID);
                  

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


            if (_Mode == enMode.AddNew && !_orderPlaced) // Only prompt for deletion if in AddNew mode
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this order and all its items?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    deleteAllOrderItems();
                    deleteOrder();
                    //MessageBox.Show("Order and its items have been deleted successfully.");
                }
                else
                {
                    e.Cancel = true;
                }
            }
            // If in Update mode, simply close the form without deleting the order


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

        private void deleteAllOrderItems()

        {
            if (_Order != null)
            {
                bool success = clsOrderItemsBusiness.DeleteAllOrderItemsByOrderID(_Order.ID);

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
            PrintOrderInfo();

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

            bool success = false;

            if (_Mode == enMode.AddNew)
            {
                // Place a new order
                success = _Order.Save();

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
            else if (_Mode == enMode.Update)
            {
                // Update the existing order
                success = _Order.Save();

                if (success)
                {
                    MessageBox.Show("Order updated successfully!");

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to update the order. Please try again.");
                }
            }


        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            deleteAllOrderItems();
            _Order = clsOrderBusiness.Find(_Order.ID);
            _Order.Total = 0;
            updateOrderDataDisplay();
            listOrderItems(_Order.ID);
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
                if (clsOrderItemsBusiness.DeleteOrderItem(int.Parse(orderItemID),_Order.ID))
                    MessageBox.Show("Deleted Sucssefully");

                    _Order = clsOrderBusiness.Find(_Order.ID);
                    listOrderItems(_Order.ID);
                    updateOrderDataDisplay();
            }

        }

        private void btnFreeOrder_Click(object sender, EventArgs e)
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

            _Order.Total = 0;

            bool success = false;

            if (_Mode == enMode.AddNew)
            {
                // Place a new order
                success = _Order.Save();

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
            else if (_Mode == enMode.Update)
            {
                // Update the existing order
                success = _Order.Save();

                if (success)
                {
                    MessageBox.Show("Order updated successfully!");

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to update the order. Please try again.");
                }
            }
        }

        private void PrintOrderInfo()
        {
            if (_Order == null)
            {
                MessageBox.Show("Order data is not available.");
                return;
            }

            // Start creating the order info string
            StringBuilder orderInfo = new StringBuilder();
            orderInfo.AppendLine($"Dimashk Street\n\n ");
            orderInfo.AppendLine($"Order ID: {_Order.SerialNumber}");
            orderInfo.AppendLine($"Order Date: {_Order.date}");
            orderInfo.AppendLine($"SubTotal: {lbSubTotal.Text}");
            orderInfo.AppendLine($"Tax Value: {lbTaxValue.Text}");
            orderInfo.AppendLine($"Vat: {lbVat.Text}");
            orderInfo.AppendLine("\nItems:");


            // Loop through order items and add them to the string
            foreach (DataGridViewRow row in dgvOrderItems.Rows)
            {
                string itemName = row.Cells["ItemName"].Value.ToString();
                string quantity = row.Cells["Quantity"].Value.ToString();
                string price = row.Cells["Price"].Value.ToString();
                string total = row.Cells["TotalItemsPrice"].Value.ToString();

                orderInfo.AppendLine($"Item: {itemName}, Quantity: {quantity}, Price: {price}, Total: {total}");
            }

            orderInfo.AppendLine($"\n\nOrder Total: {_Order.Total}");
            orderInfo.AppendLine($"\n\nThank you for your trust :) ");
            orderInfo.AppendLine($"\nComment: {txtComment.Text}");

            // Display the formatted string in a MessageBox
            MessageBox.Show(orderInfo.ToString(), "Order Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


            // Create a PrintDocument object
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += (sender, e) =>
            {
                // Define font and position
                Font font = new Font("Arial", 12);
                float x = e.MarginBounds.Left;
                float y = e.MarginBounds.Top;

                // Print the order info string
                e.Graphics.DrawString(orderInfo.ToString(), font, Brushes.Black, new RectangleF(x, y, e.PageBounds.Width, e.PageBounds.Height));
            };

            // Create a PrintDialog object
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDoc;

            // Show the print dialog to the user
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDoc.Print();
            }


        }







    }
}
