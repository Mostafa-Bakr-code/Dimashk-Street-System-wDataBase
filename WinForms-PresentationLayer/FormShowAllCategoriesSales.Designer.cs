namespace WinForms_PresentationLayer
{
    partial class FormShowAllCategoriesSales
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelDateRange = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.btnTotalbyCategory = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnTotalbyCategoryAndDateRange = new System.Windows.Forms.Button();
            this.btnExporttoExcelDateRange = new System.Windows.Forms.Button();
            this.btnExporttoExcel = new System.Windows.Forms.Button();
            this.btnSalesReportDateincluded = new System.Windows.Forms.Button();
            this.btnExcelSalesReportModifedDateIncluded = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelDateRange.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 99);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1006, 649);
            this.dataGridView1.TabIndex = 0;
            // 
            // panelDateRange
            // 
            this.panelDateRange.BackColor = System.Drawing.Color.DarkGreen;
            this.panelDateRange.Controls.Add(this.label2);
            this.panelDateRange.Controls.Add(this.dateTimePickerStart);
            this.panelDateRange.Controls.Add(this.label3);
            this.panelDateRange.Controls.Add(this.dateTimePickerEnd);
            this.panelDateRange.Location = new System.Drawing.Point(12, 22);
            this.panelDateRange.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelDateRange.Name = "panelDateRange";
            this.panelDateRange.Size = new System.Drawing.Size(776, 62);
            this.panelDateRange.TabIndex = 56;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 27;
            this.label2.Text = "التاريخ من";
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(9, 30);
            this.dateTimePickerStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(267, 22);
            this.dateTimePickerStart.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(661, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 28;
            this.label3.Text = "التاريخ الي";
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(474, 30);
            this.dateTimePickerEnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(267, 22);
            this.dateTimePickerEnd.TabIndex = 26;
            // 
            // btnTotalbyCategory
            // 
            this.btnTotalbyCategory.Location = new System.Drawing.Point(1098, 582);
            this.btnTotalbyCategory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTotalbyCategory.Name = "btnTotalbyCategory";
            this.btnTotalbyCategory.Size = new System.Drawing.Size(71, 25);
            this.btnTotalbyCategory.TabIndex = 57;
            this.btnTotalbyCategory.Text = "View";
            this.btnTotalbyCategory.UseVisualStyleBackColor = true;
            this.btnTotalbyCategory.Click += new System.EventHandler(this.btnTotalbyCategory_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1095, 554);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 16);
            this.label5.TabIndex = 58;
            this.label5.Text = "All Time Sales Report";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1080, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(166, 16);
            this.label6.TabIndex = 59;
            this.label6.Text = "Sales Report Summary";
            // 
            // btnTotalbyCategoryAndDateRange
            // 
            this.btnTotalbyCategoryAndDateRange.Location = new System.Drawing.Point(1098, 135);
            this.btnTotalbyCategoryAndDateRange.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTotalbyCategoryAndDateRange.Name = "btnTotalbyCategoryAndDateRange";
            this.btnTotalbyCategoryAndDateRange.Size = new System.Drawing.Size(71, 25);
            this.btnTotalbyCategoryAndDateRange.TabIndex = 60;
            this.btnTotalbyCategoryAndDateRange.Text = "View";
            this.btnTotalbyCategoryAndDateRange.UseVisualStyleBackColor = true;
            this.btnTotalbyCategoryAndDateRange.Click += new System.EventHandler(this.btnTotalbyCategoryAndDateRange_Click);
            // 
            // btnExporttoExcelDateRange
            // 
            this.btnExporttoExcelDateRange.BackColor = System.Drawing.Color.Gold;
            this.btnExporttoExcelDateRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExporttoExcelDateRange.Location = new System.Drawing.Point(1175, 135);
            this.btnExporttoExcelDateRange.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExporttoExcelDateRange.Name = "btnExporttoExcelDateRange";
            this.btnExporttoExcelDateRange.Size = new System.Drawing.Size(71, 25);
            this.btnExporttoExcelDateRange.TabIndex = 61;
            this.btnExporttoExcelDateRange.Text = "Excel";
            this.btnExporttoExcelDateRange.UseVisualStyleBackColor = false;
            this.btnExporttoExcelDateRange.Click += new System.EventHandler(this.btnExporttoExcelDateRange_Click);
            // 
            // btnExporttoExcel
            // 
            this.btnExporttoExcel.BackColor = System.Drawing.Color.Gold;
            this.btnExporttoExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExporttoExcel.Location = new System.Drawing.Point(1175, 582);
            this.btnExporttoExcel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExporttoExcel.Name = "btnExporttoExcel";
            this.btnExporttoExcel.Size = new System.Drawing.Size(71, 25);
            this.btnExporttoExcel.TabIndex = 62;
            this.btnExporttoExcel.Text = "Excel";
            this.btnExporttoExcel.UseVisualStyleBackColor = false;
            this.btnExporttoExcel.Click += new System.EventHandler(this.btnExporttoExcel_Click);
            // 
            // btnSalesReportDateincluded
            // 
            this.btnSalesReportDateincluded.BackColor = System.Drawing.Color.Transparent;
            this.btnSalesReportDateincluded.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalesReportDateincluded.Location = new System.Drawing.Point(15, 36);
            this.btnSalesReportDateincluded.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSalesReportDateincluded.Name = "btnSalesReportDateincluded";
            this.btnSalesReportDateincluded.Size = new System.Drawing.Size(71, 25);
            this.btnSalesReportDateincluded.TabIndex = 63;
            this.btnSalesReportDateincluded.Text = "View";
            this.btnSalesReportDateincluded.UseVisualStyleBackColor = false;
            this.btnSalesReportDateincluded.Click += new System.EventHandler(this.btnSalesReportDateincluded_Click);
            // 
            // btnExcelSalesReportModifedDateIncluded
            // 
            this.btnExcelSalesReportModifedDateIncluded.BackColor = System.Drawing.Color.Gold;
            this.btnExcelSalesReportModifedDateIncluded.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcelSalesReportModifedDateIncluded.Location = new System.Drawing.Point(92, 36);
            this.btnExcelSalesReportModifedDateIncluded.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExcelSalesReportModifedDateIncluded.Name = "btnExcelSalesReportModifedDateIncluded";
            this.btnExcelSalesReportModifedDateIncluded.Size = new System.Drawing.Size(71, 25);
            this.btnExcelSalesReportModifedDateIncluded.TabIndex = 65;
            this.btnExcelSalesReportModifedDateIncluded.Text = "Excel";
            this.btnExcelSalesReportModifedDateIncluded.UseVisualStyleBackColor = false;
            this.btnExcelSalesReportModifedDateIncluded.Click += new System.EventHandler(this.btnExcelSalesReportModifedDateIncluded_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.MintCream;
            this.groupBox1.Controls.Add(this.btnSalesReportDateincluded);
            this.groupBox1.Controls.Add(this.btnExcelSalesReportModifedDateIncluded);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1083, 368);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(197, 79);
            this.groupBox1.TabIndex = 66;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sales Report With Dates";
            // 
            // FormShowAllCategoriesSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(1338, 779);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExporttoExcel);
            this.Controls.Add(this.btnExporttoExcelDateRange);
            this.Controls.Add(this.btnTotalbyCategoryAndDateRange);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnTotalbyCategory);
            this.Controls.Add(this.panelDateRange);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormShowAllCategoriesSales";
            this.Text = "FormShowAllCategoriesSales";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelDateRange.ResumeLayout(false);
            this.panelDateRange.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panelDateRange;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Button btnTotalbyCategory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnTotalbyCategoryAndDateRange;
        private System.Windows.Forms.Button btnExporttoExcelDateRange;
        private System.Windows.Forms.Button btnExporttoExcel;
        private System.Windows.Forms.Button btnSalesReportDateincluded;
        private System.Windows.Forms.Button btnExcelSalesReportModifedDateIncluded;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}