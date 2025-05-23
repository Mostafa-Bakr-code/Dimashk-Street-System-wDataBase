﻿namespace WinForms_PresentationLayer
{
    partial class FormAddEditItem
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
            this.lbMode = new System.Windows.Forms.Label();
            this.labeliteam = new System.Windows.Forms.Label();
            this.lbItemName = new System.Windows.Forms.Label();
            this.lbItemCategory = new System.Windows.Forms.Label();
            this.lbItemPrice = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.txtItemPrice = new System.Windows.Forms.TextBox();
            this.lbItemID = new System.Windows.Forms.Label();
            this.cbItemCategory = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbMode
            // 
            this.lbMode.AutoSize = true;
            this.lbMode.Location = new System.Drawing.Point(285, 40);
            this.lbMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMode.Name = "lbMode";
            this.lbMode.Size = new System.Drawing.Size(106, 20);
            this.lbMode.TabIndex = 0;
            this.lbMode.Text = "Add/Edit Item";
            // 
            // labeliteam
            // 
            this.labeliteam.AutoSize = true;
            this.labeliteam.Location = new System.Drawing.Point(42, 166);
            this.labeliteam.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labeliteam.Name = "labeliteam";
            this.labeliteam.Size = new System.Drawing.Size(59, 20);
            this.labeliteam.TabIndex = 1;
            this.labeliteam.Text = "رقم الطبق";
            // 
            // lbItemName
            // 
            this.lbItemName.AutoSize = true;
            this.lbItemName.Location = new System.Drawing.Point(42, 249);
            this.lbItemName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbItemName.Name = "lbItemName";
            this.lbItemName.Size = new System.Drawing.Size(60, 20);
            this.lbItemName.TabIndex = 2;
            this.lbItemName.Text = "اسم الطبق";
            // 
            // lbItemCategory
            // 
            this.lbItemCategory.AutoSize = true;
            this.lbItemCategory.Location = new System.Drawing.Point(42, 337);
            this.lbItemCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbItemCategory.Name = "lbItemCategory";
            this.lbItemCategory.Size = new System.Drawing.Size(69, 20);
            this.lbItemCategory.TabIndex = 3;
            this.lbItemCategory.Text = "اسم الصنف";
            // 
            // lbItemPrice
            // 
            this.lbItemPrice.AutoSize = true;
            this.lbItemPrice.Location = new System.Drawing.Point(42, 438);
            this.lbItemPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbItemPrice.Name = "lbItemPrice";
            this.lbItemPrice.Size = new System.Drawing.Size(65, 20);
            this.lbItemPrice.TabIndex = 4;
            this.lbItemPrice.Text = "سعر الطبق";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(182, 243);
            this.txtItemName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(220, 26);
            this.txtItemName.TabIndex = 6;
            // 
            // txtItemPrice
            // 
            this.txtItemPrice.Location = new System.Drawing.Point(182, 428);
            this.txtItemPrice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtItemPrice.Name = "txtItemPrice";
            this.txtItemPrice.Size = new System.Drawing.Size(220, 26);
            this.txtItemPrice.TabIndex = 7;
            // 
            // lbItemID
            // 
            this.lbItemID.AutoSize = true;
            this.lbItemID.Location = new System.Drawing.Point(177, 166);
            this.lbItemID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbItemID.Name = "lbItemID";
            this.lbItemID.Size = new System.Drawing.Size(36, 20);
            this.lbItemID.TabIndex = 8;
            this.lbItemID.Text = "???";
            // 
            // cbItemCategory
            // 
            this.cbItemCategory.FormattingEnabled = true;
            this.cbItemCategory.Location = new System.Drawing.Point(184, 335);
            this.cbItemCategory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbItemCategory.Name = "cbItemCategory";
            this.cbItemCategory.Size = new System.Drawing.Size(216, 28);
            this.cbItemCategory.TabIndex = 9;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(104, 622);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(186, 86);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(352, 622);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(186, 86);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormAddEditItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 771);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbItemCategory);
            this.Controls.Add(this.lbItemID);
            this.Controls.Add(this.txtItemPrice);
            this.Controls.Add(this.txtItemName);
            this.Controls.Add(this.lbItemPrice);
            this.Controls.Add(this.lbItemCategory);
            this.Controls.Add(this.lbItemName);
            this.Controls.Add(this.labeliteam);
            this.Controls.Add(this.lbMode);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormAddEditItem";
            this.Text = "Add/Edit Item";
            this.Load += new System.EventHandler(this.FormAddEditItem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbMode;
        private System.Windows.Forms.Label labeliteam;
        private System.Windows.Forms.Label lbItemName;
        private System.Windows.Forms.Label lbItemCategory;
        private System.Windows.Forms.Label lbItemPrice;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.TextBox txtItemPrice;
        private System.Windows.Forms.Label lbItemID;
        private System.Windows.Forms.ComboBox cbItemCategory;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
    }
}