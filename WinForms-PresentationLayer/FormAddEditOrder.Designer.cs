﻿namespace WinForms_PresentationLayer
{
    partial class FormAddEditOrder
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbVat = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbTaxValue = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbSubTotal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbOrderID = new System.Windows.Forms.Label();
            this.lbOrderDate = new System.Windows.Forms.Label();
            this.lbOrderTotal = new System.Windows.Forms.Label();
            this.btnFreeOrder = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.dgvOrderItems = new System.Windows.Forms.DataGridView();
            this.contextMenuStripOrderItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemDeleteOrderItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbMode = new System.Windows.Forms.Label();
            this.dgvListItems = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).BeginInit();
            this.contextMenuStripOrderItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListItems)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnFreeOrder);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.btnOrder);
            this.panel1.Controls.Add(this.dgvOrderItems);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(809, 60);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(890, 710);
            this.panel1.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Turquoise;
            this.groupBox1.Controls.Add(this.lbVat);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lbTaxValue);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lbSubTotal);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lbOrderID);
            this.groupBox1.Controls.Add(this.lbOrderDate);
            this.groupBox1.Controls.Add(this.lbOrderTotal);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(556, 130);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            // 
            // lbVat
            // 
            this.lbVat.AutoSize = true;
            this.lbVat.Location = new System.Drawing.Point(410, 64);
            this.lbVat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbVat.Name = "lbVat";
            this.lbVat.Size = new System.Drawing.Size(36, 17);
            this.lbVat.TabIndex = 17;
            this.lbVat.Text = "14%";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(311, 64);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 17);
            this.label10.TabIndex = 16;
            this.label10.Text = "Vat";
            // 
            // lbTaxValue
            // 
            this.lbTaxValue.AutoSize = true;
            this.lbTaxValue.Location = new System.Drawing.Point(410, 36);
            this.lbTaxValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTaxValue.Name = "lbTaxValue";
            this.lbTaxValue.Size = new System.Drawing.Size(32, 17);
            this.lbTaxValue.TabIndex = 15;
            this.lbTaxValue.Text = "???";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(291, 36);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Tax Value";
            // 
            // lbSubTotal
            // 
            this.lbSubTotal.AutoSize = true;
            this.lbSubTotal.Location = new System.Drawing.Point(410, 9);
            this.lbSubTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSubTotal.Name = "lbSubTotal";
            this.lbSubTotal.Size = new System.Drawing.Size(32, 17);
            this.lbSubTotal.TabIndex = 13;
            this.lbSubTotal.Text = "???";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(288, 9);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = " Sub Total";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "رقم الاوردر";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 36);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "تاريخ الاوردر";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 64);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "اجمالي الاوردر";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 112);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "الاطباق";
            // 
            // lbOrderID
            // 
            this.lbOrderID.AutoSize = true;
            this.lbOrderID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOrderID.Location = new System.Drawing.Point(134, 9);
            this.lbOrderID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbOrderID.Name = "lbOrderID";
            this.lbOrderID.Size = new System.Drawing.Size(32, 17);
            this.lbOrderID.TabIndex = 9;
            this.lbOrderID.Text = "???";
            // 
            // lbOrderDate
            // 
            this.lbOrderDate.AutoSize = true;
            this.lbOrderDate.Location = new System.Drawing.Point(134, 36);
            this.lbOrderDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbOrderDate.Name = "lbOrderDate";
            this.lbOrderDate.Size = new System.Drawing.Size(32, 17);
            this.lbOrderDate.TabIndex = 10;
            this.lbOrderDate.Text = "???";
            // 
            // lbOrderTotal
            // 
            this.lbOrderTotal.AutoSize = true;
            this.lbOrderTotal.Location = new System.Drawing.Point(134, 64);
            this.lbOrderTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbOrderTotal.Name = "lbOrderTotal";
            this.lbOrderTotal.Size = new System.Drawing.Size(32, 17);
            this.lbOrderTotal.TabIndex = 11;
            this.lbOrderTotal.Text = "???";
            // 
            // btnFreeOrder
            // 
            this.btnFreeOrder.BackColor = System.Drawing.Color.Red;
            this.btnFreeOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFreeOrder.ForeColor = System.Drawing.Color.Yellow;
            this.btnFreeOrder.Location = new System.Drawing.Point(756, 17);
            this.btnFreeOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFreeOrder.Name = "btnFreeOrder";
            this.btnFreeOrder.Size = new System.Drawing.Size(112, 32);
            this.btnFreeOrder.TabIndex = 17;
            this.btnFreeOrder.Text = "طلب مجاني";
            this.btnFreeOrder.UseVisualStyleBackColor = false;
            this.btnFreeOrder.Click += new System.EventHandler(this.btnFreeOrder_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(562, 20);
            this.btnReset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(95, 26);
            this.btnReset.TabIndex = 14;
            this.btnReset.Text = "مسح كلي";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrder.Location = new System.Drawing.Point(631, 637);
            this.btnOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(254, 62);
            this.btnOrder.TabIndex = 13;
            this.btnOrder.Text = "Order";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // dgvOrderItems
            // 
            this.dgvOrderItems.AllowUserToAddRows = false;
            this.dgvOrderItems.AllowUserToDeleteRows = false;
            this.dgvOrderItems.BackgroundColor = System.Drawing.Color.Honeydew;
            this.dgvOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderItems.ContextMenuStrip = this.contextMenuStripOrderItems;
            this.dgvOrderItems.Location = new System.Drawing.Point(1, 138);
            this.dgvOrderItems.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvOrderItems.Name = "dgvOrderItems";
            this.dgvOrderItems.RowHeadersWidth = 62;
            this.dgvOrderItems.RowTemplate.Height = 28;
            this.dgvOrderItems.Size = new System.Drawing.Size(884, 487);
            this.dgvOrderItems.TabIndex = 12;
            this.dgvOrderItems.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderItems_CellValueChanged);
            // 
            // contextMenuStripOrderItems
            // 
            this.contextMenuStripOrderItems.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripOrderItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemDeleteOrderItem});
            this.contextMenuStripOrderItems.Name = "contextMenuStripOrderItems";
            this.contextMenuStripOrderItems.Size = new System.Drawing.Size(123, 28);
            // 
            // toolStripMenuItemDeleteOrderItem
            // 
            this.toolStripMenuItemDeleteOrderItem.Name = "toolStripMenuItemDeleteOrderItem";
            this.toolStripMenuItemDeleteOrderItem.Size = new System.Drawing.Size(122, 24);
            this.toolStripMenuItemDeleteOrderItem.Text = "Delete";
            this.toolStripMenuItemDeleteOrderItem.Click += new System.EventHandler(this.toolStripMenuItemDeleteOrderItem_Click);
            // 
            // lbMode
            // 
            this.lbMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMode.ForeColor = System.Drawing.Color.White;
            this.lbMode.Location = new System.Drawing.Point(217, 15);
            this.lbMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMode.Name = "lbMode";
            this.lbMode.Size = new System.Drawing.Size(117, 27);
            this.lbMode.TabIndex = 12;
            this.lbMode.Text = "Add/Update Order";
            // 
            // dgvListItems
            // 
            this.dgvListItems.AllowUserToAddRows = false;
            this.dgvListItems.AllowUserToDeleteRows = false;
            this.dgvListItems.BackgroundColor = System.Drawing.Color.Honeydew;
            this.dgvListItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListItems.Location = new System.Drawing.Point(148, 60);
            this.dgvListItems.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvListItems.Name = "dgvListItems";
            this.dgvListItems.ReadOnly = true;
            this.dgvListItems.RowHeadersWidth = 62;
            this.dgvListItems.RowTemplate.Height = 28;
            this.dgvListItems.Size = new System.Drawing.Size(645, 710);
            this.dgvListItems.TabIndex = 12;
            this.dgvListItems.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvListItems_CellMouseDoubleClick);
            // 
            // FormAddEditOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1710, 811);
            this.Controls.Add(this.dgvListItems);
            this.Controls.Add(this.lbMode);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(500, 104);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormAddEditOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Add/Edit Order";
            this.Load += new System.EventHandler(this.FormAddEditOrder_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).EndInit();
            this.contextMenuStripOrderItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbOrderTotal;
        private System.Windows.Forms.Label lbOrderDate;
        private System.Windows.Forms.Label lbOrderID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbMode;
        private System.Windows.Forms.DataGridView dgvListItems;
        private System.Windows.Forms.DataGridView dgvOrderItems;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripOrderItems;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDeleteOrderItem;
        private System.Windows.Forms.Button btnFreeOrder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbVat;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbTaxValue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbSubTotal;
        private System.Windows.Forms.Label label6;
    }
}