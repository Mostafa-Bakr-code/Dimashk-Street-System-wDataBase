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
                    "هل تريد اغلاق الصفحه ومسح الطلب الحالي?",
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
            //PrintOrderInfoForChief();
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
                MessageBox.Show("يجب اضافة منتج واحد علي الاقل");
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
                    MessageBox.Show("تم اضافة الاوردر بنجاح");
                    _orderPlaced = true;

                    this.Close();
                }
                else
                {
                    MessageBox.Show("هناك خطأ اعد المحاولة");
                }
            }
            else if (_Mode == enMode.Update)
            {
                // Update the existing order
                success = _Order.Save();

                if (success)
                {
                    MessageBox.Show("تم اضافة الاوردر بنجاح");

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to update the order. Please try again.");
                }
            }

            PrintOrderInfoForUser();
            //PrintOrderInfoForChief();
        }


        private void PrintOrderInfoForUser()
        {
            if (_Order == null)
            {
                MessageBox.Show("Order data is not available.");
                return;
            }

            // Initialize the PrintDocument object
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = "XP-76";
            printDoc.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0); // Set all margins to zero

            // Event handler for PrintPage to define the table format
            printDoc.PrintPage += (sender, e) =>
            {
                Font font = new Font("Arial", 9); // Times New Roman with font size 9
                float x = e.MarginBounds.Left;
                float y = e.MarginBounds.Top;
                float rowHeight = font.GetHeight(e.Graphics) + 12; // Increased row height to add space between rows

                // Header Information with increased spacing
                e.Graphics.DrawString("....أكله جملي....", font, Brushes.Black, x, y);
                y += rowHeight * 2; // Extra space below shop name

                e.Graphics.DrawString($"Date: {_Order.date.ToString("yyyy-MM-dd")}", font, Brushes.Black, x, y);
                y += rowHeight;

                e.Graphics.DrawString($"Order ID: {_Order.SerialNumber}", font, Brushes.Black, x, y);
                y += rowHeight * 2; // Extra space after Order ID

                e.Graphics.DrawString(" _______________________", font, Brushes.Black, x, y);
                y += rowHeight;

                // Adjusted column widths and spacing for 80mm paper
                float itemNameWidth = 100;    // Adjusted width for item names
                float quantityWidth = 35;     // Width for quantity
                float priceWidth = 45;        // Width for price
                float totalWidth = 50;        // Width for total
                float columnSpacing = 10;     // Space between columns

                // Print table header row
                e.Graphics.DrawString("Item", font, Brushes.Black, x, y);
                e.Graphics.DrawString("Qty", font, Brushes.Black, x + itemNameWidth + columnSpacing, y);
                e.Graphics.DrawString("Price", font, Brushes.Black, x + itemNameWidth + quantityWidth + columnSpacing * 2, y);
                e.Graphics.DrawString("Total", font, Brushes.Black, x + itemNameWidth + quantityWidth + priceWidth + columnSpacing * 3, y);
                y += rowHeight * 1.5f; // Extra space below header

                // Print each row of order items with increased spacing
                foreach (DataGridViewRow row in dgvOrderItems.Rows)
                {
                    string itemName = row.Cells["ItemName"].Value.ToString();
                    string quantity = row.Cells["Quantity"].Value.ToString();
                    string price = FormatPrice(Convert.ToDecimal(row.Cells["Price"].Value));
                    string total = FormatPrice(Convert.ToDecimal(row.Cells["TotalItemsPrice"].Value));

                    e.Graphics.DrawString(itemName, font, Brushes.Black, x, y);
                    e.Graphics.DrawString(quantity, font, Brushes.Black, x + itemNameWidth + columnSpacing, y);
                    e.Graphics.DrawString(price, font, Brushes.Black, x + itemNameWidth + quantityWidth + columnSpacing * 2, y);
                    e.Graphics.DrawString(total, font, Brushes.Black, x + itemNameWidth + quantityWidth + priceWidth + columnSpacing * 3, y);

                    y += rowHeight * 1.5f; // Add extra space between rows
                }

                // Print subtotal, tax, and total at the bottom
                y += rowHeight; // Space after items
                e.Graphics.DrawString(" _______________________", font, Brushes.Black, x, y);
                y += rowHeight;
                e.Graphics.DrawString($"Total: {FormatPrice(_Order.Total)}", font, Brushes.Black, x, y);
                y += rowHeight * 2; // Extra space before footer

                // Footer Message
                e.Graphics.DrawString("شكرا لزيارتكم أكله جملي ", font, Brushes.Black, x, y);
            };

            // Attempt to print, handling any errors
            try
            {
                printDoc.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطأ اثناء الطباعه: " + ex.Message);
            }
        }


        // Helper method to format price, removing trailing zeros if not needed
        private string FormatPrice(decimal price)
        {
            return price % 1 == 0 ? price.ToString("F0") : price.ToString("F2");
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

                orderInfo.AppendLine($"{itemName}, الكمية: {quantity},\n {comment}\n_________________________\n");
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
                MessageBox.Show("هناك خطأ اثناء الطباعه: " + ex.Message);
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
