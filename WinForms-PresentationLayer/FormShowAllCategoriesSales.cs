using BuisnessLayer;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_PresentationLayer
{
    public partial class FormShowAllCategoriesSales : Form
    {

        
        public FormShowAllCategoriesSales()
        {
            InitializeComponent();
           
        }

        private void dataGridDisplayProperties()
        {
            dataGridView1.Columns["CategoryName"].DisplayIndex = 0;
            dataGridView1.Columns["ItemName"].DisplayIndex = 1;
            dataGridView1.Columns["Quantity"].DisplayIndex = 2;
            dataGridView1.Columns["CurrentPrice"].DisplayIndex = 3;
            dataGridView1.Columns["Total"].DisplayIndex = 4;
        }

        private void LoadSalesReportByDateRange()
        {
            DateTime startDate = dateTimePickerStart.Value.Date;
            DateTime endDate = dateTimePickerEnd.Value.Date;

            if (endDate < startDate)
            {
                MessageBox.Show("التاريخ الي لا يمكن ان يكون فبل التاريخ من", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable data = clsOrderItemsBusiness.GetSalesReportByDateRange(startDate, endDate);
            dataGridView1.DataSource = data;
            dataGridDisplayProperties();
        }

        private void LoadSalesReport()
        {
            DataTable data = clsOrderItemsBusiness.GetSalesReport();
            dataGridView1.DataSource = data;
            dataGridDisplayProperties();
        }

        private void btnTotalbyCategory_Click(object sender, EventArgs e)
        {
            LoadSalesReport();

        }

        private void btnTotalbyCategoryAndDateRange_Click(object sender, EventArgs e)
        {

            LoadSalesReportByDateRange();
        }

        private void btnExporttoExcelDateRange_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePickerStart.Value.Date;
            DateTime endDate = dateTimePickerEnd.Value.Date;

            if (endDate < startDate)
            {
                MessageBox.Show("التاريخ الي لا يمكن ان يكون فبل التاريخ من", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           

            bool success = clsOrderItemsBusiness.ExportSalesReportByDateRange(startDate, endDate);

            if (success)
            {
                MessageBox.Show("تم تصدير التقرير بنجاح إلى سطح المكتب.", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("حدث خطأ أثناء تصدير التقرير.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnExporttoExcel_Click(object sender, EventArgs e)
        {
            

            bool success = clsOrderItemsBusiness.ExportAllTimeSalesReport();

            if (success)
            {
                MessageBox.Show("تم تصدير التقرير بنجاح إلى سطح المكتب.", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("حدث خطأ أثناء تصدير التقرير.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        //-------------------------------------------------------
        // adding sales report modifed to include start and end dates to be included in the excel report

        private void dataGridDisplayPropertiesModifedReportInludeDates()
        {
            dataGridView1.Columns["OrderDate"].DisplayIndex = 0;
            dataGridView1.Columns["CategoryName"].DisplayIndex = 1;
            dataGridView1.Columns["ItemName"].DisplayIndex = 2;
            dataGridView1.Columns["Quantity"].DisplayIndex = 3;
            dataGridView1.Columns["CurrentPrice"].DisplayIndex = 4;
            dataGridView1.Columns["Total"].DisplayIndex = 5;

        }

        private void btnSalesReportDateincluded_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePickerStart.Value.Date;
            DateTime endDate = dateTimePickerEnd.Value.Date;

            if (endDate < startDate)
            {
                MessageBox.Show("التاريخ الي لا يمكن ان يكون فبل التاريخ من", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable data = clsOrderItemsBusiness.GetSalesReportByDateRangeInludeDates(startDate, endDate);
            dataGridView1.DataSource = data;
            dataGridDisplayPropertiesModifedReportInludeDates();
        }

        private void btnExcelSalesReportModifedDateIncluded_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePickerStart.Value.Date;
            DateTime endDate = dateTimePickerEnd.Value.Date;

            if (endDate < startDate)
            {
                MessageBox.Show("التاريخ الي لا يمكن ان يكون فبل التاريخ من", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            bool success = clsOrderItemsBusiness.ExportSalesReportByDateRangeModifiedDateIncluded(startDate, endDate);

            if (success)
            {
                MessageBox.Show("تم تصدير التقرير بنجاح إلى سطح المكتب.", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("حدث خطأ أثناء تصدير التقرير.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
