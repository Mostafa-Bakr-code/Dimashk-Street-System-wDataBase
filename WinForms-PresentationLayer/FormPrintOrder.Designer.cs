namespace WinForms_PresentationLayer
{
    partial class FormPrintOrder
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
            this.components = new System.ComponentModel.Container();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.contextMenuOrders = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripEditOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDeleteOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripShowOrderItems = new System.Windows.Forms.ToolStripMenuItem();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.btnshowOrdersByDate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.contextMenuOrders.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.AllowUserToOrderColumns = true;
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvOrders.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvOrders.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvOrders.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.ContextMenuStrip = this.contextMenuOrders;
            this.dgvOrders.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvOrders.Location = new System.Drawing.Point(44, 106);
            this.dgvOrders.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersWidth = 62;
            this.dgvOrders.Size = new System.Drawing.Size(745, 483);
            this.dgvOrders.TabIndex = 18;
            // 
            // contextMenuOrders
            // 
            this.contextMenuOrders.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuOrders.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripEditOrder,
            this.toolStripDeleteOrder,
            this.toolStripShowOrderItems});
            this.contextMenuOrders.Name = "contextMenuOrders";
            this.contextMenuOrders.Size = new System.Drawing.Size(241, 133);
            // 
            // toolStripEditOrder
            // 
            this.toolStripEditOrder.Name = "toolStripEditOrder";
            this.toolStripEditOrder.Size = new System.Drawing.Size(240, 32);
            this.toolStripEditOrder.Text = "تعديل";
            // 
            // toolStripDeleteOrder
            // 
            this.toolStripDeleteOrder.Name = "toolStripDeleteOrder";
            this.toolStripDeleteOrder.Size = new System.Drawing.Size(240, 32);
            this.toolStripDeleteOrder.Text = "مسح";
            // 
            // toolStripShowOrderItems
            // 
            this.toolStripShowOrderItems.Name = "toolStripShowOrderItems";
            this.toolStripShowOrderItems.Size = new System.Drawing.Size(240, 32);
            this.toolStripShowOrderItems.Text = "عرض منتجات الطلب";
            this.toolStripShowOrderItems.Click += new System.EventHandler(this.toolStripShowOrderItems_Click);
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(44, 72);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(300, 26);
            this.dateTimePickerStart.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(116, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 25);
            this.label1.TabIndex = 28;
            this.label1.Text = "التاريخ من";
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(475, 72);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(300, 26);
            this.dateTimePickerEnd.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(561, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 25);
            this.label2.TabIndex = 30;
            this.label2.Text = "التاريخ الي";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label19.Location = new System.Drawing.Point(832, 145);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(120, 25);
            this.label19.TabIndex = 54;
            this.label19.Text = "المبيعات بالتاريخ";
            // 
            // btnshowOrdersByDate
            // 
            this.btnshowOrdersByDate.Location = new System.Drawing.Point(856, 173);
            this.btnshowOrdersByDate.Name = "btnshowOrdersByDate";
            this.btnshowOrdersByDate.Size = new System.Drawing.Size(80, 31);
            this.btnshowOrdersByDate.TabIndex = 55;
            this.btnshowOrdersByDate.Text = "View";
            this.btnshowOrdersByDate.UseVisualStyleBackColor = true;
            this.btnshowOrdersByDate.Click += new System.EventHandler(this.btnshowOrdersByDate_Click);
            // 
            // FormPrintOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 603);
            this.Controls.Add(this.btnshowOrdersByDate);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.dgvOrders);
            this.Name = "FormPrintOrder";
            this.Text = "FormPrintOrder";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.contextMenuOrders.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.ContextMenuStrip contextMenuOrders;
        private System.Windows.Forms.ToolStripMenuItem toolStripEditOrder;
        private System.Windows.Forms.ToolStripMenuItem toolStripDeleteOrder;
        private System.Windows.Forms.ToolStripMenuItem toolStripShowOrderItems;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnshowOrdersByDate;
    }
}