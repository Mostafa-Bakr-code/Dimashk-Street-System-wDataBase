namespace WinForms_PresentationLayer
{
    partial class FormAddEditUser
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
            this.lbMode = new System.Windows.Forms.Label();
            this.labeluserID = new System.Windows.Forms.Label();
            this.lbUserID = new System.Windows.Forms.Label();
            this.lbUserName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxCategories = new System.Windows.Forms.CheckBox();
            this.checkBoxItems = new System.Windows.Forms.CheckBox();
            this.checkBoxOrders = new System.Windows.Forms.CheckBox();
            this.checkBoxOrderItems = new System.Windows.Forms.CheckBox();
            this.checkBoxUsers = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.checkBoxFullAccess = new System.Windows.Forms.CheckBox();
            this.lbPermissions = new System.Windows.Forms.Label();
            this.panelPermissions = new System.Windows.Forms.Panel();
            this.panelPermissions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbMode
            // 
            this.lbMode.AutoSize = true;
            this.lbMode.Location = new System.Drawing.Point(306, 34);
            this.lbMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMode.Name = "lbMode";
            this.lbMode.Size = new System.Drawing.Size(108, 20);
            this.lbMode.TabIndex = 1;
            this.lbMode.Text = "Add/Edit User";
            // 
            // labeluserID
            // 
            this.labeluserID.AutoSize = true;
            this.labeluserID.Location = new System.Drawing.Point(72, 116);
            this.labeluserID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labeluserID.Name = "labeluserID";
            this.labeluserID.Size = new System.Drawing.Size(64, 20);
            this.labeluserID.TabIndex = 2;
            this.labeluserID.Text = "User ID";
            // 
            // lbUserID
            // 
            this.lbUserID.AutoSize = true;
            this.lbUserID.Location = new System.Drawing.Point(321, 116);
            this.lbUserID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbUserID.Name = "lbUserID";
            this.lbUserID.Size = new System.Drawing.Size(36, 20);
            this.lbUserID.TabIndex = 9;
            this.lbUserID.Text = "???";
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Location = new System.Drawing.Point(72, 183);
            this.lbUserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(89, 20);
            this.lbUserName.TabIndex = 10;
            this.lbUserName.Text = "User Name";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(240, 177);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(220, 26);
            this.txtUserName.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 244);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Password";
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.Location = new System.Drawing.Point(240, 238);
            this.txtUserPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.Size = new System.Drawing.Size(220, 26);
            this.txtUserPassword.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 310);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Permissions";
            // 
            // checkBoxCategories
            // 
            this.checkBoxCategories.AutoSize = true;
            this.checkBoxCategories.Location = new System.Drawing.Point(14, 15);
            this.checkBoxCategories.Name = "checkBoxCategories";
            this.checkBoxCategories.Size = new System.Drawing.Size(156, 24);
            this.checkBoxCategories.TabIndex = 15;
            this.checkBoxCategories.Tag = "1";
            this.checkBoxCategories.Text = "Categories Menu";
            this.checkBoxCategories.UseVisualStyleBackColor = true;
            // 
            // checkBoxItems
            // 
            this.checkBoxItems.AutoSize = true;
            this.checkBoxItems.Location = new System.Drawing.Point(14, 61);
            this.checkBoxItems.Name = "checkBoxItems";
            this.checkBoxItems.Size = new System.Drawing.Size(119, 24);
            this.checkBoxItems.TabIndex = 16;
            this.checkBoxItems.Tag = "2";
            this.checkBoxItems.Text = "Items Menu";
            this.checkBoxItems.UseVisualStyleBackColor = true;
            // 
            // checkBoxOrders
            // 
            this.checkBoxOrders.AutoSize = true;
            this.checkBoxOrders.Location = new System.Drawing.Point(14, 110);
            this.checkBoxOrders.Name = "checkBoxOrders";
            this.checkBoxOrders.Size = new System.Drawing.Size(127, 24);
            this.checkBoxOrders.TabIndex = 17;
            this.checkBoxOrders.Tag = "4";
            this.checkBoxOrders.Text = "Orders Menu";
            this.checkBoxOrders.UseVisualStyleBackColor = true;
            // 
            // checkBoxOrderItems
            // 
            this.checkBoxOrderItems.AutoSize = true;
            this.checkBoxOrderItems.Location = new System.Drawing.Point(188, 15);
            this.checkBoxOrderItems.Name = "checkBoxOrderItems";
            this.checkBoxOrderItems.Size = new System.Drawing.Size(159, 24);
            this.checkBoxOrderItems.TabIndex = 18;
            this.checkBoxOrderItems.Tag = "8";
            this.checkBoxOrderItems.Text = "OrderItems Menu";
            this.checkBoxOrderItems.UseVisualStyleBackColor = true;
            // 
            // checkBoxUsers
            // 
            this.checkBoxUsers.AutoSize = true;
            this.checkBoxUsers.Location = new System.Drawing.Point(188, 61);
            this.checkBoxUsers.Name = "checkBoxUsers";
            this.checkBoxUsers.Size = new System.Drawing.Size(121, 24);
            this.checkBoxUsers.TabIndex = 19;
            this.checkBoxUsers.Tag = "16";
            this.checkBoxUsers.Text = "Users Menu";
            this.checkBoxUsers.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(128, 585);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(186, 86);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(360, 585);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(186, 86);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // checkBoxFullAccess
            // 
            this.checkBoxFullAccess.AutoSize = true;
            this.checkBoxFullAccess.Location = new System.Drawing.Point(188, 110);
            this.checkBoxFullAccess.Name = "checkBoxFullAccess";
            this.checkBoxFullAccess.Size = new System.Drawing.Size(116, 24);
            this.checkBoxFullAccess.TabIndex = 22;
            this.checkBoxFullAccess.Text = "Full Access";
            this.checkBoxFullAccess.UseVisualStyleBackColor = true;
            // 
            // lbPermissions
            // 
            this.lbPermissions.AutoSize = true;
            this.lbPermissions.Location = new System.Drawing.Point(321, 310);
            this.lbPermissions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPermissions.Name = "lbPermissions";
            this.lbPermissions.Size = new System.Drawing.Size(36, 20);
            this.lbPermissions.TabIndex = 23;
            this.lbPermissions.Text = "???";
            // 
            // panelPermissions
            // 
            this.panelPermissions.Controls.Add(this.checkBoxCategories);
            this.panelPermissions.Controls.Add(this.checkBoxItems);
            this.panelPermissions.Controls.Add(this.checkBoxFullAccess);
            this.panelPermissions.Controls.Add(this.checkBoxOrders);
            this.panelPermissions.Controls.Add(this.checkBoxOrderItems);
            this.panelPermissions.Controls.Add(this.checkBoxUsers);
            this.panelPermissions.Location = new System.Drawing.Point(200, 363);
            this.panelPermissions.Name = "panelPermissions";
            this.panelPermissions.Size = new System.Drawing.Size(361, 149);
            this.panelPermissions.TabIndex = 24;
            // 
            // FormAddEditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 703);
            this.Controls.Add(this.panelPermissions);
            this.Controls.Add(this.lbPermissions);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUserPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lbUserName);
            this.Controls.Add(this.lbUserID);
            this.Controls.Add(this.labeluserID);
            this.Controls.Add(this.lbMode);
            this.Name = "FormAddEditUser";
            this.Text = "FormAddEditUser";
            this.Load += new System.EventHandler(this.FormAddEditUser_Load);
            this.panelPermissions.ResumeLayout(false);
            this.panelPermissions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbMode;
        private System.Windows.Forms.Label labeluserID;
        private System.Windows.Forms.Label lbUserID;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxCategories;
        private System.Windows.Forms.CheckBox checkBoxItems;
        private System.Windows.Forms.CheckBox checkBoxOrders;
        private System.Windows.Forms.CheckBox checkBoxOrderItems;
        private System.Windows.Forms.CheckBox checkBoxUsers;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox checkBoxFullAccess;
        private System.Windows.Forms.Label lbPermissions;
        private System.Windows.Forms.Panel panelPermissions;
    }
}