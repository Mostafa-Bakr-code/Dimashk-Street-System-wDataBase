namespace WinForms_PresentationLayer
{
    partial class FormViewOrderItems
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
            this.dgvShowOrderItems = new System.Windows.Forms.DataGridView();
            this.btnPrintOrder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowOrderItems)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvShowOrderItems
            // 
            this.dgvShowOrderItems.AllowUserToAddRows = false;
            this.dgvShowOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShowOrderItems.Location = new System.Drawing.Point(0, 12);
            this.dgvShowOrderItems.Name = "dgvShowOrderItems";
            this.dgvShowOrderItems.RowHeadersWidth = 62;
            this.dgvShowOrderItems.RowTemplate.Height = 28;
            this.dgvShowOrderItems.Size = new System.Drawing.Size(1012, 426);
            this.dgvShowOrderItems.TabIndex = 0;
            // 
            // btnPrintOrder
            // 
            this.btnPrintOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintOrder.Location = new System.Drawing.Point(448, 457);
            this.btnPrintOrder.Name = "btnPrintOrder";
            this.btnPrintOrder.Size = new System.Drawing.Size(127, 44);
            this.btnPrintOrder.TabIndex = 1;
            this.btnPrintOrder.Text = "طبع بون";
            this.btnPrintOrder.UseVisualStyleBackColor = true;
            this.btnPrintOrder.Click += new System.EventHandler(this.btnPrintOrder_Click);
            // 
            // FormViewOrderItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 528);
            this.Controls.Add(this.btnPrintOrder);
            this.Controls.Add(this.dgvShowOrderItems);
            this.Name = "FormViewOrderItems";
            this.Text = "FormViewOrderItems";
            this.Load += new System.EventHandler(this.FormViewOrderItems_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowOrderItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvShowOrderItems;
        private System.Windows.Forms.Button btnPrintOrder;
    }
}