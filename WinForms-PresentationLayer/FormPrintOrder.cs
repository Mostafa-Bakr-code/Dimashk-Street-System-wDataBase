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
    public partial class FormPrintOrder : Form
    {

        
        public FormPrintOrder()
        {
            InitializeComponent();
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
