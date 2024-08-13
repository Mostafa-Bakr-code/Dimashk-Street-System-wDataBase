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

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            _RefreshItemsList();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            FormAddEditItem frm = new FormAddEditItem(-1);
            frm.ShowDialog();
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
                if (clsItemBusiness.DeleteItem((int)dgvListItems.CurrentRow.Cells[0].Value))
                    MessageBox.Show("Deleted Sucssefully");
                _RefreshItemsList();
            }
        }
    }
}
