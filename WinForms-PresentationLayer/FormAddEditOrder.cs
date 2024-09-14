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
using Microsoft.VisualBasic;
using System.Data.Common;

namespace WinForms_PresentationLayer
{
    public partial class FormAddEditOrder : Form
    {


        private BindingSource bindingSource = new BindingSource();
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        int _orderID;
        clsOrderBusiness _Order;

        private bool _orderPlaced = false;

        public FormAddEditOrder(int orderID)
        {
            InitializeComponent();

            dgvOrderItems.CellValueChanged += dgvOrderItems_CellValueChanged;
            
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

            //dgvOrderItems.DataSource = clsOrderItemsBusiness.GetAllOrderItemsbyID(orderID);

            //// Make the DataGridView editable
            //dgvOrderItems.ReadOnly = false;

            //// Loop through each column to set ReadOnly property
            //foreach (DataGridViewColumn column in dgvOrderItems.Columns)
            //{
            //    // Allow editing only for the Quantity and Comment columns
            //    if (column.Name == "Quantity" || column.Name == "Comment")
            //    {
            //        column.ReadOnly = false;
            //    }
            //    else
            //    {
            //        column.ReadOnly = true;
            //    }
            //}

            //HideIDColumn();


            // i used the binding source because when i set the comment it works but when i delete it and leave it empty i get an error
            // Set data to the BindingSource
            bindingSource.DataSource = clsOrderItemsBusiness.GetAllOrderItemsbyID(orderID);

            // Bind the BindingSource to the DataGridView
            dgvOrderItems.DataSource = bindingSource;

            // Make the DataGridView editable
            dgvOrderItems.ReadOnly = false;

            // Loop through each column to set ReadOnly property
            foreach (DataGridViewColumn column in dgvOrderItems.Columns)
            {
                // Allow editing only for the Quantity and Comment columns
                if (column.Name == "Quantity" || column.Name == "Comment")
                {
                    column.ReadOnly = false;
                }
                else
                {
                    column.ReadOnly = true;
                }


                switch (column.Name)
                {
                    case "Quantity":
                        column.Width = 60; // Short width for Quantity
                        break;
                    case "Comment":
                        column.Width = 300; // Larger width for Comment
                        break;
                    case "ID":
                        column.Width = 30; // Adjust as needed
                        break;
                    case "ItemName":
                        column.Width = 90; // Adjust as needed
                        break;
                    case "Price":
                        column.Width = 50; // Adjust as needed
                        break;
                    case "TotalItemsPrice":
                        column.Width = 90; // Adjust as needed
                        break;
                    default:
                        column.Width = 100; // Default width for other columns
                        break;
                }
            }





        }

        private void updateOrderDataDisplay()
        {
            

            lbOrderID.Text = _Order.SerialNumber.ToString();
            lbOrderDate.Text = _Order.date.ToString("yyyy-MM-dd");
            lbOrderTotal.Text = _Order.Total.ToString();
            updateOrderTax();

        }

        private void updateOrderTax()
        {

            (decimal InitialPrice, decimal TaxValue) result = clsOrderBusiness.GetInitialPriceAndTaxValueForOrder(_Order.ID);

      
            decimal initialPrice = result.Item1;
            decimal taxValue = result.Item2;

            lbSubTotal.Text = Math.Round(initialPrice, 2).ToString("F2");
            lbTaxValue.Text = Math.Round(taxValue, 2).ToString("F2");

        }

        private void LoadData()
        {

            LoadCategoriesAndCreateButtons();

            //dgvListItems.DataSource = clsItemBusiness.GetAllItemsWithoutAllDetails();
           

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

        private void dgvOrderItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            //{
            //    DataGridViewCell cell = dgvOrderItems.Rows[e.RowIndex].Cells[e.ColumnIndex];
            //    object cellValue = cell.Value;


            //    if (e.ColumnIndex == dgvOrderItems.Columns["Quantity"].Index)
            //    {
            //        int orderItemID = Convert.ToInt32(dgvOrderItems.Rows[e.RowIndex].Cells[0].Value); // Assuming ID is in column 0


            //        int newQuantity = Convert.ToInt32(cellValue);

            //        // Update the quantity in the business logic
            //        clsOrderItemsBusiness orderItem = clsOrderItemsBusiness.Find(orderItemID);
            //        orderItem.Quantity = newQuantity;
            //        orderItem.Save();

            //        _Order = clsOrderBusiness.Find(_Order.ID);


            //        listOrderItems(_Order.ID);
            //        updateOrderDataDisplay();
            //    }
            //}


            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dgvOrderItems.Rows[e.RowIndex].Cells[e.ColumnIndex];
                object cellValue = cell.Value;

                // Check if the cell's column is the Quantity column
                if (e.ColumnIndex == dgvOrderItems.Columns["Quantity"].Index)
                {
                    int orderItemID = Convert.ToInt32(dgvOrderItems.Rows[e.RowIndex].Cells[0].Value); // Assuming ID is in column 0
                    int newQuantity = Convert.ToInt32(cellValue);

                    // Update the quantity in the business logic
                    clsOrderItemsBusiness orderItem = clsOrderItemsBusiness.Find(orderItemID);
                    orderItem.Quantity = newQuantity;
                    orderItem.Save();

                    _Order = clsOrderBusiness.Find(_Order.ID);

                    listOrderItems(_Order.ID);
                    updateOrderDataDisplay();
                }
                // Check if the cell's column is the Comment column
                else if (e.ColumnIndex == dgvOrderItems.Columns["Comment"].Index)
                {
                    int orderItemID = Convert.ToInt32(dgvOrderItems.Rows[e.RowIndex].Cells[0].Value); // Assuming ID is in column 0
                    string newComment = cellValue?.ToString(); // Convert cell value to string

                    // Update the comment in the business logic
                    clsOrderItemsBusiness orderItem = clsOrderItemsBusiness.Find(orderItemID);
                    orderItem.Comment = newComment;
                    orderItem.Save();

                    _Order = clsOrderBusiness.Find(_Order.ID);

                    listOrderItems(_Order.ID);
                    updateOrderDataDisplay();
                }
            }

        }

        private void FormAddEditOrder_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
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
                    //MessageBox.Show("Order deleted successfully.");
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
                    //MessageBox.Show("OrderItems deleted successfully.");
                }
                else
                {
                    //MessageBox.Show("Failed to delete the orderItems.");
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
                MessageBox.Show("يجب اضافة منتج واحد علي الاقل");
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
                    //MessageBox.Show("Order placed successfully!");
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

            PrintOrderInfoForUser();
            PrintOrderInfoForChief();
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


            //MessageBox.Show(orderItemID);

            //DialogResult result =
            //MessageBox.Show($"Are you sure you want to delete this Order Item {orderItemID}",
            //    "Delete Order Item", MessageBoxButtons.OKCancel);

            //if (result == DialogResult.OK)
            //{
                if (clsOrderItemsBusiness.DeleteOrderItem(int.Parse(orderItemID),_Order.ID))
                    //MessageBox.Show("Deleted Sucssefully");

                    _Order = clsOrderBusiness.Find(_Order.ID);
                   
                    listOrderItems(_Order.ID);


                if (dgvOrderItems.Rows.Count == 0)
                {
                    _Order.Total = 0;
                    
                }

                updateOrderDataDisplay();
            //}

        }

        private void toolStripMenuItemQuantityOrderItem_Click(object sender, EventArgs e)
        {

                


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

            PrintOrderInfoForUser();
            PrintOrderInfoForChief();
        }

        private void PrintOrderInfoForUser()
        {
            if (_Order == null)
            {
                MessageBox.Show("Order data is not available.");
                return;
            }

            // Start creating the order info string
            StringBuilder orderInfo = new StringBuilder();

            //orderInfo.AppendLine("******************************\n");
            //orderInfo.AppendLine("******************************\n");
            //orderInfo.AppendLine("******************************\n");
            orderInfo.AppendLine("\n\n....FROM DIMASHK .... \n\n");
            //orderInfo.AppendLine("Invoice Tax\n");
            orderInfo.AppendLine($"Cashier: {clsUserBusiness.ActiveUser.userName}");
            orderInfo.AppendLine($"{_Order.date.ToString("yyyy-dd-MM")}\n\n");
            orderInfo.AppendLine($"ID: {_Order.SerialNumber}\n\n");
            orderInfo.AppendLine("\n _______________________\n");

            // Loop through order items and add them to the string
            foreach (DataGridViewRow row in dgvOrderItems.Rows)
            {
                string itemName = row.Cells["ItemName"].Value.ToString();
                string quantity = row.Cells["Quantity"].Value.ToString();
                string price = Convert.ToDecimal(row.Cells["Price"].Value).ToString("F2");
                string total = Convert.ToDecimal(row.Cells["TotalItemsPrice"].Value).ToString("F2");

                orderInfo.AppendLine($"{itemName}, Quantity: {quantity}, Price: {price}, Total: {total}");
            }

            orderInfo.AppendLine("\n _________________________\n");
            orderInfo.AppendLine($"\n\nSubTotal: {decimal.Parse(lbSubTotal.Text).ToString("F2")}");
            orderInfo.AppendLine($"\n\nTax Value: {decimal.Parse(lbTaxValue.Text).ToString("F2")}");
            orderInfo.AppendLine($"\n\nVat: {lbVat.Text}");
            orderInfo.AppendLine($"\n\nTotal: {_Order.Total.ToString("F2")}");
            orderInfo.AppendLine($"\n\nThank you for choosing us!");
            orderInfo.AppendLine("\n\n....FROM DIMASHK .... \n\n");
            //orderInfo.AppendLine($"{_Order.date.ToString("yyyy-dd-MM")}\n\n");
            //orderInfo.AppendLine($"\n\nID: {_Order.SerialNumber}\n");
            //orderInfo.AppendLine("Invoice Tax\n");
            //orderInfo.AppendLine($"Cashier: {clsUserBusiness.ActiveUser.userName}");
            //orderInfo.AppendLine("******************************\n");
            //orderInfo.AppendLine("******************************\n");
            //orderInfo.AppendLine("******************************\n");
            //orderInfo.AppendLine("******************************\n");
            orderInfo.AppendLine("******************************\n");
            orderInfo.AppendLine("******************************\n");

            // Convert the StringBuilder to a string for printing
            string orderInfoText = orderInfo.ToString();

            // Create a PrintDocument object
            PrintDocument printDoc = new PrintDocument();

            // Set the printer name directly
            printDoc.PrinterSettings.PrinterName = "XP-80";

            // Adjust margins to reduce top space and add a buffer at the bottom
            printDoc.DefaultPageSettings.Margins = new Margins(10, 10, 10, 10); // Adjusted top margin to 20 and bottom margin to 40

            printDoc.PrintPage += (sender, e) =>
            {
                Font font = new Font("Arial", 12);
                float x = e.MarginBounds.Left;
                float y = e.MarginBounds.Top - 50;

                // Define the maximum width and height for the text
                float width = e.MarginBounds.Width;
                float height = e.MarginBounds.Height - 40; // Adjust height to reserve space for the last line

                // Create a StringFormat object to handle text wrapping
                StringFormat stringFormat = new StringFormat
                {
                    LineAlignment = StringAlignment.Near,
                    Alignment = StringAlignment.Near,
                    FormatFlags = StringFormatFlags.LineLimit
                };

                // Calculate how many characters will fit on the page
                int charsFitted, linesFilled;
                e.Graphics.MeasureString(orderInfoText, font, new SizeF(width, height), stringFormat, out charsFitted, out linesFilled);

                // Print the current page's content
                e.Graphics.DrawString(orderInfoText, font, Brushes.Black, new RectangleF(x, y, width, height), stringFormat);

                // Remove the printed content from the orderInfo string
                orderInfoText = orderInfoText.Substring(charsFitted);

                // Check if there's more content to print
                e.HasMorePages = orderInfoText.Length > 0;

                // If more pages exist, store the remaining text for the next page
                if (e.HasMorePages)
                {
                    e.Graphics.DrawString("Continued on next page...", font, Brushes.Black, new RectangleF(x, y + height - 20, width, 20), stringFormat);
                }
            };

            try
            {
                // Print directly to the specified printer without showing the PrintDialog
                printDoc.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while printing: " + ex.Message);
            }
        }

        private void PrintOrderInfoForChief()
        {
            if (_Order == null)
            {
                MessageBox.Show("Order data is not available.");
                return;
            }

            // Start creating the order info string
            StringBuilder orderInfo = new StringBuilder();
            //orderInfo.AppendLine("******************************\n");
            //orderInfo.AppendLine("******************************\n");
            //orderInfo.AppendLine("******************************\n");

            orderInfo.AppendLine($"\n\n{_Order.date}");
            orderInfo.AppendLine($"ID: {_Order.SerialNumber}");

            orderInfo.AppendLine($"ID: {_Order.SerialNumber}");
            orderInfo.AppendLine("\n\n _________________________\n");

            // Loop through order items and add them to the string
            foreach (DataGridViewRow row in dgvOrderItems.Rows)
            {
                string itemName = row.Cells["ItemName"].Value.ToString();
                string quantity = row.Cells["Quantity"].Value.ToString();
                //string price = row.Cells["Price"].Value.ToString();
                //string total = row.Cells["TotalItemsPrice"].Value.ToString();

                string comment = row.Cells["Comment"].Value.ToString();

                orderInfo.AppendLine($"{itemName}, Quan: {quantity},\n {comment}\n_________________________\n");
            }

            orderInfo.AppendLine($"\n\n{_Order.date}");
            orderInfo.AppendLine($"ID: {_Order.SerialNumber}");
            orderInfo.AppendLine("******************************\n");
            //orderInfo.AppendLine("******************************\n");
            //orderInfo.AppendLine("******************************\n");

            // Convert the StringBuilder to a string for printing
            string orderInfoText = orderInfo.ToString();

            // Create a PrintDocument object
            PrintDocument printDoc = new PrintDocument();

            // Set the printer name directly
            printDoc.PrinterSettings.PrinterName = "XP-80.51";

            // Set custom margins (minimal margins)
            printDoc.DefaultPageSettings.Margins = new Margins(10, 10, 10, 10);

            printDoc.PrintPage += (sender, e) =>
            {
                // Define font and position
                Font font = new Font("Arial", 12);
                float x = e.MarginBounds.Left;
                float y = e.MarginBounds.Top;

                // Define the maximum width and height for the text
                float width = e.PageBounds.Width;
                float height = e.PageBounds.Height;

                // Print the order info string
                e.Graphics.DrawString(orderInfoText, font, Brushes.Black, new RectangleF(x, y, width, height));
            };

            try
            {
                // Print directly to the specified printer
                printDoc.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while printing: " + ex.Message);
            }
        }

        private void CategoryButton_Click(object sender, EventArgs e, string categoryName)
        {
            dgvListItems.DataSource = clsItemBusiness.GetItemsByCategoryName(categoryName);
        }

        private void LoadCategoriesAndCreateButtons()
        {
          
            DataTable categoriesTable = clsCategoryBusiness.GetAllCategories();

            // Dynamically create buttons based on the categories retrieved
            int buttonX = 10; // Starting X position for the first button
            int buttonY = 50; // Starting Y position for the first button
            int buttonHeight = 30; // Height of the buttons
            int buttonWidth = 80; // Width of the buttons
            int buttonSpacing = 10; // Spacing between buttons

            foreach (DataRow row in categoriesTable.Rows)
            {
                string categoryName = row["CategoryName"].ToString();

                Button categoryButton = new Button
                {
                    Text = categoryName,
                    Width = buttonWidth,
                    Height = buttonHeight,
                    Location = new System.Drawing.Point(buttonX, buttonY),
                    ForeColor = System.Drawing.Color.White,
                    Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold)
                };

                categoryButton.Click += (sender, e) => CategoryButton_Click(sender, e, categoryName);

                this.Controls.Add(categoryButton); // Add the button to the form or a container control

                buttonY += buttonHeight + buttonSpacing; // Move the Y position for the next button
            }
        }






    }
}
