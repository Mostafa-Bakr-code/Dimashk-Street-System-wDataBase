using BuisnessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_PresentationLayer
{
    public partial class FormViewOrderItems : Form

    {
        private int _orderID;
        private clsOrderBusiness _Order;
        public FormViewOrderItems(int orderID)
        {
            InitializeComponent();
            _orderID = orderID;
        }

        private void LoadData()
        {
            dgvShowOrderItems.DataSource = clsOrderItemsBusiness.GetAllOrderItemsbyID(_orderID);
            _Order = clsOrderBusiness.Find(_orderID);
        }

        private void FormViewOrderItems_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnPrintOrder_Click(object sender, EventArgs e)
        {
            PrintOrderInfoForUser();
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
                foreach (DataGridViewRow row in dgvShowOrderItems.Rows)
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








        private string FormatPrice(decimal price)
        {
            return price % 1 == 0 ? price.ToString("F0") : price.ToString("F2");
        }




  






    }
}
