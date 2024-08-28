namespace WinForms_PresentationLayer
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
            this.txtComment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.panel1.Controls.Add(this.txtComment);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.btnOrder);
            this.panel1.Controls.Add(this.dgvOrderItems);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(734, 72);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1001, 583);
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
            this.groupBox1.Location = new System.Drawing.Point(1, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(625, 163);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            // 
            // lbVat
            // 
            this.lbVat.AutoSize = true;
            this.lbVat.Location = new System.Drawing.Point(461, 80);
            this.lbVat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbVat.Name = "lbVat";
            this.lbVat.Size = new System.Drawing.Size(41, 20);
            this.lbVat.TabIndex = 17;
            this.lbVat.Text = "14%";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(350, 80);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 20);
            this.label10.TabIndex = 16;
            this.label10.Text = "Vat";
            // 
            // lbTaxValue
            // 
            this.lbTaxValue.AutoSize = true;
            this.lbTaxValue.Location = new System.Drawing.Point(461, 45);
            this.lbTaxValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTaxValue.Name = "lbTaxValue";
            this.lbTaxValue.Size = new System.Drawing.Size(36, 20);
            this.lbTaxValue.TabIndex = 15;
            this.lbTaxValue.Text = "???";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(327, 45);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Tax Value";
            // 
            // lbSubTotal
            // 
            this.lbSubTotal.AutoSize = true;
            this.lbSubTotal.Location = new System.Drawing.Point(461, 11);
            this.lbSubTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSubTotal.Name = "lbSubTotal";
            this.lbSubTotal.Size = new System.Drawing.Size(36, 20);
            this.lbSubTotal.TabIndex = 13;
            this.lbSubTotal.Text = "???";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(324, 11);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = " Sub Total";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Order ID ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 45);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Order Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 80);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Order Total";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 140);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Order Items";
            // 
            // lbOrderID
            // 
            this.lbOrderID.AutoSize = true;
            this.lbOrderID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOrderID.Location = new System.Drawing.Point(151, 11);
            this.lbOrderID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbOrderID.Name = "lbOrderID";
            this.lbOrderID.Size = new System.Drawing.Size(36, 20);
            this.lbOrderID.TabIndex = 9;
            this.lbOrderID.Text = "???";
            // 
            // lbOrderDate
            // 
            this.lbOrderDate.AutoSize = true;
            this.lbOrderDate.Location = new System.Drawing.Point(151, 45);
            this.lbOrderDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbOrderDate.Name = "lbOrderDate";
            this.lbOrderDate.Size = new System.Drawing.Size(36, 20);
            this.lbOrderDate.TabIndex = 10;
            this.lbOrderDate.Text = "???";
            // 
            // lbOrderTotal
            // 
            this.lbOrderTotal.AutoSize = true;
            this.lbOrderTotal.Location = new System.Drawing.Point(151, 80);
            this.lbOrderTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbOrderTotal.Name = "lbOrderTotal";
            this.lbOrderTotal.Size = new System.Drawing.Size(36, 20);
            this.lbOrderTotal.TabIndex = 11;
            this.lbOrderTotal.Text = "???";
            // 
            // btnFreeOrder
            // 
            this.btnFreeOrder.BackColor = System.Drawing.Color.Red;
            this.btnFreeOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFreeOrder.ForeColor = System.Drawing.Color.Yellow;
            this.btnFreeOrder.Location = new System.Drawing.Point(850, 21);
            this.btnFreeOrder.Name = "btnFreeOrder";
            this.btnFreeOrder.Size = new System.Drawing.Size(126, 40);
            this.btnFreeOrder.TabIndex = 17;
            this.btnFreeOrder.Text = "Free Order";
            this.btnFreeOrder.UseVisualStyleBackColor = false;
            this.btnFreeOrder.Click += new System.EventHandler(this.btnFreeOrder_Click);
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.Location = new System.Drawing.Point(3, 447);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(567, 123);
            this.txtComment.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 424);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Comment";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(632, 25);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(107, 33);
            this.btnReset.TabIndex = 14;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrder.Location = new System.Drawing.Point(818, 447);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(178, 77);
            this.btnOrder.TabIndex = 13;
            this.btnOrder.Text = "Order";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // dgvOrderItems
            // 
            this.dgvOrderItems.AllowUserToAddRows = false;
            this.dgvOrderItems.AllowUserToDeleteRows = false;
            this.dgvOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderItems.ContextMenuStrip = this.contextMenuStripOrderItems;
            this.dgvOrderItems.Location = new System.Drawing.Point(1, 172);
            this.dgvOrderItems.Name = "dgvOrderItems";
            this.dgvOrderItems.RowHeadersWidth = 62;
            this.dgvOrderItems.RowTemplate.Height = 28;
            this.dgvOrderItems.Size = new System.Drawing.Size(995, 229);
            this.dgvOrderItems.TabIndex = 12;
            // 
            // contextMenuStripOrderItems
            // 
            this.contextMenuStripOrderItems.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripOrderItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemDeleteOrderItem});
            this.contextMenuStripOrderItems.Name = "contextMenuStripOrderItems";
            this.contextMenuStripOrderItems.Size = new System.Drawing.Size(135, 36);
            // 
            // toolStripMenuItemDeleteOrderItem
            // 
            this.toolStripMenuItemDeleteOrderItem.Name = "toolStripMenuItemDeleteOrderItem";
            this.toolStripMenuItemDeleteOrderItem.Size = new System.Drawing.Size(134, 32);
            this.toolStripMenuItemDeleteOrderItem.Text = "Delete";
            this.toolStripMenuItemDeleteOrderItem.Click += new System.EventHandler(this.toolStripMenuItemDeleteOrderItem_Click);
            // 
            // lbMode
            // 
            this.lbMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMode.Location = new System.Drawing.Point(244, 19);
            this.lbMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMode.Name = "lbMode";
            this.lbMode.Size = new System.Drawing.Size(132, 34);
            this.lbMode.TabIndex = 12;
            this.lbMode.Text = "Add/Update Order";
            // 
            // dgvListItems
            // 
            this.dgvListItems.AllowUserToAddRows = false;
            this.dgvListItems.AllowUserToDeleteRows = false;
            this.dgvListItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListItems.Location = new System.Drawing.Point(8, 72);
            this.dgvListItems.Name = "dgvListItems";
            this.dgvListItems.ReadOnly = true;
            this.dgvListItems.RowHeadersWidth = 62;
            this.dgvListItems.RowTemplate.Height = 28;
            this.dgvListItems.Size = new System.Drawing.Size(709, 583);
            this.dgvListItems.TabIndex = 12;
            this.dgvListItems.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvListItems_CellMouseDoubleClick);
            // 
            // FormAddEditOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1742, 678);
            this.Controls.Add(this.dgvListItems);
            this.Controls.Add(this.lbMode);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(500, 104);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormAddEditOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Add/Edit Order";
            this.Load += new System.EventHandler(this.FormAddEditOrder_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label label1;
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