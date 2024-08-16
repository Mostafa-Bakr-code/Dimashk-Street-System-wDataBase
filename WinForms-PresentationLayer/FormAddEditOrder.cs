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
        public FormAddEditOrder(int orderID)
        {
            InitializeComponent();

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

        private void LoadData()
        {

            // Add Mode
            if (_Mode == enMode.AddNew)
            {
                lbMode.Text = "Add Order";
                _Order = new clsOrderBusiness();

                lbOrderID.Text = _orderID.ToString();
                lbOrderDate.Text = DateTime.Now.ToString();
                lbOrderTotal.Text = "0";

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

                lbOrderID.Text = _orderID.ToString();
                lbOrderDate.Text = DateTime.Now.ToString();
                lbOrderTotal.Text = _Order.Total.ToString();

            }

        }

        private void FormNewOrder_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
