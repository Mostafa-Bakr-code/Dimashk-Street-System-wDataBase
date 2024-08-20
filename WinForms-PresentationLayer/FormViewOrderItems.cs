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
    public partial class FormViewOrderItems : Form

    {
        private int _orderID;
        public FormViewOrderItems(int orderID)
        {
            InitializeComponent();
            _orderID = orderID;
        }

        private void LoadData()
        {
            dgvShowOrderItems.DataSource = clsOrderItemsBusiness.GetAllOrderItemsbyID(_orderID);
        }

        private void FormViewOrderItems_Load(object sender, EventArgs e)
        {
            LoadData();
        }


    }
}
