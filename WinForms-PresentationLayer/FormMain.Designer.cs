namespace WinForms_PresentationLayer
{
    partial class FormMain
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
            this.contextMenuStripItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvListItems = new System.Windows.Forms.DataGridView();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnCategoriesMenu = new System.Windows.Forms.Button();
            this.btnItemsMenu = new System.Windows.Forms.Button();
            this.btnOrdersMenu = new System.Windows.Forms.Button();
            this.btnOrderItems = new System.Windows.Forms.Button();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.contextMenuOrders = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripEditOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDeleteOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvCategories = new System.Windows.Forms.DataGridView();
            this.contextMenuCategories = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuEditCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuDeleteCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvOrderItems = new System.Windows.Forms.DataGridView();
            this.contextMenuOrderItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripEditOrderItems = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDeleteOrderItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.btnAddOrderItems = new System.Windows.Forms.Button();
            this.toolStripShowOrderItems = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.contextMenuOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.contextMenuCategories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).BeginInit();
            this.contextMenuOrderItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStripItems
            // 
            this.contextMenuStripItems.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemEdit,
            this.toolStripMenuItemDelete});
            this.contextMenuStripItems.Name = "contextMenuStrip1";
            this.contextMenuStripItems.Size = new System.Drawing.Size(135, 68);
            // 
            // toolStripMenuItemEdit
            // 
            this.toolStripMenuItemEdit.Name = "toolStripMenuItemEdit";
            this.toolStripMenuItemEdit.Size = new System.Drawing.Size(134, 32);
            this.toolStripMenuItemEdit.Text = "Edit";
            this.toolStripMenuItemEdit.Click += new System.EventHandler(this.toolStripMenuItemEdit_Click);
            // 
            // toolStripMenuItemDelete
            // 
            this.toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
            this.toolStripMenuItemDelete.Size = new System.Drawing.Size(134, 32);
            this.toolStripMenuItemDelete.Text = "Delete";
            this.toolStripMenuItemDelete.Click += new System.EventHandler(this.toolStripMenuItemDelete_Click);
            // 
            // dgvListItems
            // 
            this.dgvListItems.AllowUserToAddRows = false;
            this.dgvListItems.AllowUserToDeleteRows = false;
            this.dgvListItems.AllowUserToOrderColumns = true;
            this.dgvListItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListItems.ContextMenuStrip = this.contextMenuStripItems;
            this.dgvListItems.Location = new System.Drawing.Point(18, 254);
            this.dgvListItems.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvListItems.Name = "dgvListItems";
            this.dgvListItems.ReadOnly = true;
            this.dgvListItems.RowHeadersWidth = 62;
            this.dgvListItems.Size = new System.Drawing.Size(1029, 606);
            this.dgvListItems.TabIndex = 0;
            this.dgvListItems.Visible = false;
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(18, 869);
            this.btnAddItem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(152, 52);
            this.btnAddItem.TabIndex = 2;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnCategoriesMenu
            // 
            this.btnCategoriesMenu.Location = new System.Drawing.Point(18, 192);
            this.btnCategoriesMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCategoriesMenu.Name = "btnCategoriesMenu";
            this.btnCategoriesMenu.Size = new System.Drawing.Size(152, 52);
            this.btnCategoriesMenu.TabIndex = 3;
            this.btnCategoriesMenu.Text = "Categories";
            this.btnCategoriesMenu.UseVisualStyleBackColor = true;
            this.btnCategoriesMenu.Click += new System.EventHandler(this.btnCategoriesMenu_Click);
            // 
            // btnItemsMenu
            // 
            this.btnItemsMenu.Location = new System.Drawing.Point(192, 192);
            this.btnItemsMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnItemsMenu.Name = "btnItemsMenu";
            this.btnItemsMenu.Size = new System.Drawing.Size(152, 52);
            this.btnItemsMenu.TabIndex = 4;
            this.btnItemsMenu.Text = "Items";
            this.btnItemsMenu.UseVisualStyleBackColor = true;
            this.btnItemsMenu.Click += new System.EventHandler(this.btnItemsMenu_Click);
            // 
            // btnOrdersMenu
            // 
            this.btnOrdersMenu.Location = new System.Drawing.Point(366, 192);
            this.btnOrdersMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOrdersMenu.Name = "btnOrdersMenu";
            this.btnOrdersMenu.Size = new System.Drawing.Size(152, 52);
            this.btnOrdersMenu.TabIndex = 5;
            this.btnOrdersMenu.Text = "Orders";
            this.btnOrdersMenu.UseVisualStyleBackColor = true;
            this.btnOrdersMenu.Click += new System.EventHandler(this.btnOrdersMenu_Click);
            // 
            // btnOrderItems
            // 
            this.btnOrderItems.Location = new System.Drawing.Point(542, 192);
            this.btnOrderItems.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOrderItems.Name = "btnOrderItems";
            this.btnOrderItems.Size = new System.Drawing.Size(152, 52);
            this.btnOrderItems.TabIndex = 6;
            this.btnOrderItems.Text = "OrderItems";
            this.btnOrderItems.UseVisualStyleBackColor = true;
            this.btnOrderItems.Click += new System.EventHandler(this.btnOrderItems_Click);
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.AllowUserToOrderColumns = true;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.ContextMenuStrip = this.contextMenuOrders;
            this.dgvOrders.Location = new System.Drawing.Point(18, 254);
            this.dgvOrders.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersWidth = 62;
            this.dgvOrders.Size = new System.Drawing.Size(1029, 606);
            this.dgvOrders.TabIndex = 17;
            this.dgvOrders.Visible = false;
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
            this.toolStripEditOrder.Text = "Edit";
            this.toolStripEditOrder.Click += new System.EventHandler(this.toolStripEditOrder_Click);
            // 
            // toolStripDeleteOrder
            // 
            this.toolStripDeleteOrder.Name = "toolStripDeleteOrder";
            this.toolStripDeleteOrder.Size = new System.Drawing.Size(240, 32);
            this.toolStripDeleteOrder.Text = "Delete";
            this.toolStripDeleteOrder.Click += new System.EventHandler(this.toolStripDeleteOrder_Click);
            // 
            // dgvCategories
            // 
            this.dgvCategories.AllowUserToAddRows = false;
            this.dgvCategories.AllowUserToDeleteRows = false;
            this.dgvCategories.AllowUserToOrderColumns = true;
            this.dgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategories.ContextMenuStrip = this.contextMenuCategories;
            this.dgvCategories.Location = new System.Drawing.Point(18, 254);
            this.dgvCategories.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.ReadOnly = true;
            this.dgvCategories.RowHeadersWidth = 62;
            this.dgvCategories.Size = new System.Drawing.Size(1029, 606);
            this.dgvCategories.TabIndex = 18;
            this.dgvCategories.Visible = false;
            // 
            // contextMenuCategories
            // 
            this.contextMenuCategories.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuCategories.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuEditCategory,
            this.toolStripMenuDeleteCategory});
            this.contextMenuCategories.Name = "contextMenuCategories";
            this.contextMenuCategories.Size = new System.Drawing.Size(135, 68);
            // 
            // toolStripMenuEditCategory
            // 
            this.toolStripMenuEditCategory.Name = "toolStripMenuEditCategory";
            this.toolStripMenuEditCategory.Size = new System.Drawing.Size(134, 32);
            this.toolStripMenuEditCategory.Text = "Edit";
            this.toolStripMenuEditCategory.Click += new System.EventHandler(this.toolStripMenuEditCategory_Click);
            // 
            // toolStripMenuDeleteCategory
            // 
            this.toolStripMenuDeleteCategory.Name = "toolStripMenuDeleteCategory";
            this.toolStripMenuDeleteCategory.Size = new System.Drawing.Size(134, 32);
            this.toolStripMenuDeleteCategory.Text = "Delete";
            this.toolStripMenuDeleteCategory.Click += new System.EventHandler(this.toolStripMenuDeleteCategory_Click);
            // 
            // dgvOrderItems
            // 
            this.dgvOrderItems.AllowUserToAddRows = false;
            this.dgvOrderItems.AllowUserToDeleteRows = false;
            this.dgvOrderItems.AllowUserToOrderColumns = true;
            this.dgvOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderItems.ContextMenuStrip = this.contextMenuOrderItems;
            this.dgvOrderItems.Location = new System.Drawing.Point(18, 254);
            this.dgvOrderItems.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvOrderItems.Name = "dgvOrderItems";
            this.dgvOrderItems.ReadOnly = true;
            this.dgvOrderItems.RowHeadersWidth = 62;
            this.dgvOrderItems.Size = new System.Drawing.Size(1029, 606);
            this.dgvOrderItems.TabIndex = 19;
            this.dgvOrderItems.Visible = false;
            // 
            // contextMenuOrderItems
            // 
            this.contextMenuOrderItems.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuOrderItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripEditOrderItems,
            this.toolStripDeleteOrderItem});
            this.contextMenuOrderItems.Name = "contextMenuOrders";
            this.contextMenuOrderItems.Size = new System.Drawing.Size(135, 68);
            // 
            // toolStripEditOrderItems
            // 
            this.toolStripEditOrderItems.Name = "toolStripEditOrderItems";
            this.toolStripEditOrderItems.Size = new System.Drawing.Size(134, 32);
            this.toolStripEditOrderItems.Text = "Edit";
            this.toolStripEditOrderItems.Click += new System.EventHandler(this.toolStripEditOrderItems_Click);
            // 
            // toolStripDeleteOrderItem
            // 
            this.toolStripDeleteOrderItem.Name = "toolStripDeleteOrderItem";
            this.toolStripDeleteOrderItem.Size = new System.Drawing.Size(134, 32);
            this.toolStripDeleteOrderItem.Text = "Delete";
            this.toolStripDeleteOrderItem.Click += new System.EventHandler(this.toolStripDeleteOrderItem_Click);
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Location = new System.Drawing.Point(192, 869);
            this.btnAddCategory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(152, 52);
            this.btnAddCategory.TabIndex = 20;
            this.btnAddCategory.Text = "Add Category";
            this.btnAddCategory.UseVisualStyleBackColor = true;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.Location = new System.Drawing.Point(366, 869);
            this.btnAddOrder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(152, 52);
            this.btnAddOrder.TabIndex = 23;
            this.btnAddOrder.Text = "Add Order";
            this.btnAddOrder.UseVisualStyleBackColor = true;
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
            // 
            // btnAddOrderItems
            // 
            this.btnAddOrderItems.Location = new System.Drawing.Point(542, 869);
            this.btnAddOrderItems.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddOrderItems.Name = "btnAddOrderItems";
            this.btnAddOrderItems.Size = new System.Drawing.Size(152, 52);
            this.btnAddOrderItems.TabIndex = 24;
            this.btnAddOrderItems.Text = "Add Order Items";
            this.btnAddOrderItems.UseVisualStyleBackColor = true;
            this.btnAddOrderItems.Click += new System.EventHandler(this.btnAddOrderItems_Click);
            // 
            // toolStripShowOrderItems
            // 
            this.toolStripShowOrderItems.Name = "toolStripShowOrderItems";
            this.toolStripShowOrderItems.Size = new System.Drawing.Size(240, 32);
            this.toolStripShowOrderItems.Text = "View Order Items";
            this.toolStripShowOrderItems.Click += new System.EventHandler(this.toolStripShowOrderItems_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1894, 1000);
            this.Controls.Add(this.btnAddOrderItems);
            this.Controls.Add(this.btnAddOrder);
            this.Controls.Add(this.btnAddCategory);
            this.Controls.Add(this.dgvOrderItems);
            this.Controls.Add(this.dgvCategories);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.dgvListItems);
            this.Controls.Add(this.btnOrderItems);
            this.Controls.Add(this.btnOrdersMenu);
            this.Controls.Add(this.btnItemsMenu);
            this.Controls.Add(this.btnCategoriesMenu);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMain";
            this.Text = "Dimashk Street";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.contextMenuStripItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.contextMenuOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.contextMenuCategories.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).EndInit();
            this.contextMenuOrderItems.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStripItems;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDelete;
        private System.Windows.Forms.DataGridView dgvListItems;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnCategoriesMenu;
        private System.Windows.Forms.Button btnItemsMenu;
        private System.Windows.Forms.Button btnOrdersMenu;
        private System.Windows.Forms.Button btnOrderItems;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.DataGridView dgvCategories;
        private System.Windows.Forms.DataGridView dgvOrderItems;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.ContextMenuStrip contextMenuCategories;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuEditCategory;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuDeleteCategory;
        private System.Windows.Forms.ContextMenuStrip contextMenuOrders;
        private System.Windows.Forms.ToolStripMenuItem toolStripEditOrder;
        private System.Windows.Forms.ToolStripMenuItem toolStripDeleteOrder;
        private System.Windows.Forms.ContextMenuStrip contextMenuOrderItems;
        private System.Windows.Forms.ToolStripMenuItem toolStripEditOrderItems;
        private System.Windows.Forms.ToolStripMenuItem toolStripDeleteOrderItem;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.Button btnAddOrderItems;
        private System.Windows.Forms.ToolStripMenuItem toolStripShowOrderItems;
    }
}

