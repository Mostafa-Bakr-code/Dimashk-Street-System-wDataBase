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
            this.toolStripShowOrderItems = new System.Windows.Forms.ToolStripMenuItem();
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
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTotalRange = new System.Windows.Forms.Button();
            this.btnAllTimeTotal = new System.Windows.Forms.Button();
            this.panelOrdersTotal = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.btnTaxValueDateRange = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.btnTaxValue = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnFreeOrdersTotalRange = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnFreeOrdersTotal = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbItemName = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnTotalbyItemNameAndDateRange = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnTotalbyItemName = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbItemCategory = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnTotalbyCategory = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnTotalbyCategoryAndDateRange = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnUsersMenu = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.dgvUsersMenu = new System.Windows.Forms.DataGridView();
            this.contextMenuUsers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripEditUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDeleteUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.contextMenuOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.contextMenuCategories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).BeginInit();
            this.contextMenuOrderItems.SuspendLayout();
            this.panelOrdersTotal.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersMenu)).BeginInit();
            this.contextMenuUsers.SuspendLayout();
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
            this.dgvListItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvListItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvListItems.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvListItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListItems.ContextMenuStrip = this.contextMenuStripItems;
            this.dgvListItems.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvListItems.Location = new System.Drawing.Point(163, 164);
            this.dgvListItems.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvListItems.Name = "dgvListItems";
            this.dgvListItems.ReadOnly = true;
            this.dgvListItems.RowHeadersWidth = 62;
            this.dgvListItems.Size = new System.Drawing.Size(908, 779);
            this.dgvListItems.TabIndex = 0;
            this.dgvListItems.Visible = false;
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(1, 193);
            this.btnAddItem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(152, 52);
            this.btnAddItem.TabIndex = 2;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Visible = false;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnCategoriesMenu
            // 
            this.btnCategoriesMenu.Location = new System.Drawing.Point(7, 37);
            this.btnCategoriesMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCategoriesMenu.Name = "btnCategoriesMenu";
            this.btnCategoriesMenu.Size = new System.Drawing.Size(152, 52);
            this.btnCategoriesMenu.TabIndex = 3;
            this.btnCategoriesMenu.Text = "Categories Menu";
            this.btnCategoriesMenu.UseVisualStyleBackColor = true;
            this.btnCategoriesMenu.Click += new System.EventHandler(this.btnCategoriesMenu_Click);
            // 
            // btnItemsMenu
            // 
            this.btnItemsMenu.Location = new System.Drawing.Point(177, 37);
            this.btnItemsMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnItemsMenu.Name = "btnItemsMenu";
            this.btnItemsMenu.Size = new System.Drawing.Size(152, 52);
            this.btnItemsMenu.TabIndex = 4;
            this.btnItemsMenu.Text = "Items Menu";
            this.btnItemsMenu.UseVisualStyleBackColor = true;
            this.btnItemsMenu.Click += new System.EventHandler(this.btnItemsMenu_Click);
            // 
            // btnOrdersMenu
            // 
            this.btnOrdersMenu.Location = new System.Drawing.Point(348, 37);
            this.btnOrdersMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOrdersMenu.Name = "btnOrdersMenu";
            this.btnOrdersMenu.Size = new System.Drawing.Size(152, 52);
            this.btnOrdersMenu.TabIndex = 5;
            this.btnOrdersMenu.Text = "Orders Menu";
            this.btnOrdersMenu.UseVisualStyleBackColor = true;
            this.btnOrdersMenu.Click += new System.EventHandler(this.btnOrdersMenu_Click);
            // 
            // btnOrderItems
            // 
            this.btnOrderItems.Location = new System.Drawing.Point(517, 37);
            this.btnOrderItems.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOrderItems.Name = "btnOrderItems";
            this.btnOrderItems.Size = new System.Drawing.Size(152, 52);
            this.btnOrderItems.TabIndex = 6;
            this.btnOrderItems.Text = "OrderItems Menu";
            this.btnOrderItems.UseVisualStyleBackColor = true;
            this.btnOrderItems.Click += new System.EventHandler(this.btnOrderItems_Click);
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
            this.dgvOrders.Location = new System.Drawing.Point(163, 164);
            this.dgvOrders.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersWidth = 62;
            this.dgvOrders.Size = new System.Drawing.Size(590, 784);
            this.dgvOrders.TabIndex = 17;
            this.dgvOrders.Visible = false;
            this.dgvOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellClick);
            this.dgvOrders.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvOrders_CellFormatting);
            // 
            // contextMenuOrders
            // 
            this.contextMenuOrders.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuOrders.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripEditOrder,
            this.toolStripDeleteOrder,
            this.toolStripShowOrderItems});
            this.contextMenuOrders.Name = "contextMenuOrders";
            this.contextMenuOrders.Size = new System.Drawing.Size(222, 100);
            // 
            // toolStripEditOrder
            // 
            this.toolStripEditOrder.Name = "toolStripEditOrder";
            this.toolStripEditOrder.Size = new System.Drawing.Size(221, 32);
            this.toolStripEditOrder.Text = "Edit";
            this.toolStripEditOrder.Click += new System.EventHandler(this.toolStripEditOrder_Click);
            // 
            // toolStripDeleteOrder
            // 
            this.toolStripDeleteOrder.Name = "toolStripDeleteOrder";
            this.toolStripDeleteOrder.Size = new System.Drawing.Size(221, 32);
            this.toolStripDeleteOrder.Text = "Delete";
            // 
            // toolStripShowOrderItems
            // 
            this.toolStripShowOrderItems.Name = "toolStripShowOrderItems";
            this.toolStripShowOrderItems.Size = new System.Drawing.Size(221, 32);
            this.toolStripShowOrderItems.Text = "View Order Items";
            this.toolStripShowOrderItems.Click += new System.EventHandler(this.toolStripShowOrderItems_Click);
            // 
            // dgvCategories
            // 
            this.dgvCategories.AllowUserToAddRows = false;
            this.dgvCategories.AllowUserToDeleteRows = false;
            this.dgvCategories.AllowUserToOrderColumns = true;
            this.dgvCategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCategories.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCategories.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCategories.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategories.ContextMenuStrip = this.contextMenuCategories;
            this.dgvCategories.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvCategories.Location = new System.Drawing.Point(163, 164);
            this.dgvCategories.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.ReadOnly = true;
            this.dgvCategories.RowHeadersWidth = 62;
            this.dgvCategories.Size = new System.Drawing.Size(500, 784);
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
            this.dgvOrderItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvOrderItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvOrderItems.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvOrderItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderItems.ContextMenuStrip = this.contextMenuOrderItems;
            this.dgvOrderItems.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvOrderItems.Location = new System.Drawing.Point(163, 164);
            this.dgvOrderItems.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvOrderItems.Name = "dgvOrderItems";
            this.dgvOrderItems.ReadOnly = true;
            this.dgvOrderItems.RowHeadersWidth = 62;
            this.dgvOrderItems.Size = new System.Drawing.Size(833, 779);
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
            // 
            // toolStripDeleteOrderItem
            // 
            this.toolStripDeleteOrderItem.Name = "toolStripDeleteOrderItem";
            this.toolStripDeleteOrderItem.Size = new System.Drawing.Size(134, 32);
            this.toolStripDeleteOrderItem.Text = "Delete";
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Location = new System.Drawing.Point(3, 193);
            this.btnAddCategory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(152, 52);
            this.btnAddCategory.TabIndex = 20;
            this.btnAddCategory.Text = "Add Category";
            this.btnAddCategory.UseVisualStyleBackColor = true;
            this.btnAddCategory.Visible = false;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.BackColor = System.Drawing.Color.Turquoise;
            this.btnAddOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddOrder.Location = new System.Drawing.Point(1306, 65);
            this.btnAddOrder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(241, 91);
            this.btnAddOrder.TabIndex = 23;
            this.btnAddOrder.Text = "Add Order";
            this.btnAddOrder.UseVisualStyleBackColor = false;
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(16, 55);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(300, 26);
            this.dateTimePickerStart.TabIndex = 25;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(464, 55);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(300, 26);
            this.dateTimePickerEnd.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 27;
            this.label1.Text = "Start Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(460, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 28;
            this.label2.Text = "End Date";
            // 
            // btnTotalRange
            // 
            this.btnTotalRange.Location = new System.Drawing.Point(364, 25);
            this.btnTotalRange.Name = "btnTotalRange";
            this.btnTotalRange.Size = new System.Drawing.Size(80, 31);
            this.btnTotalRange.TabIndex = 30;
            this.btnTotalRange.Text = "View";
            this.btnTotalRange.UseVisualStyleBackColor = true;
            this.btnTotalRange.Click += new System.EventHandler(this.btnTotalRange_Click);
            // 
            // btnAllTimeTotal
            // 
            this.btnAllTimeTotal.Location = new System.Drawing.Point(364, 76);
            this.btnAllTimeTotal.Name = "btnAllTimeTotal";
            this.btnAllTimeTotal.Size = new System.Drawing.Size(80, 31);
            this.btnAllTimeTotal.TabIndex = 31;
            this.btnAllTimeTotal.Text = "View";
            this.btnAllTimeTotal.UseVisualStyleBackColor = true;
            this.btnAllTimeTotal.Click += new System.EventHandler(this.btnAllTimeTotal_Click);
            // 
            // panelOrdersTotal
            // 
            this.panelOrdersTotal.Controls.Add(this.panel1);
            this.panelOrdersTotal.Controls.Add(this.groupBox3);
            this.panelOrdersTotal.Controls.Add(this.groupBox4);
            this.panelOrdersTotal.Controls.Add(this.groupBox2);
            this.panelOrdersTotal.Controls.Add(this.label2);
            this.panelOrdersTotal.Controls.Add(this.groupBox1);
            this.panelOrdersTotal.Controls.Add(this.label1);
            this.panelOrdersTotal.Controls.Add(this.dateTimePickerEnd);
            this.panelOrdersTotal.Controls.Add(this.dateTimePickerStart);
            this.panelOrdersTotal.Location = new System.Drawing.Point(780, 164);
            this.panelOrdersTotal.Name = "panelOrdersTotal";
            this.panelOrdersTotal.Size = new System.Drawing.Size(951, 779);
            this.panelOrdersTotal.TabIndex = 32;
            this.panelOrdersTotal.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.btnTaxValueDateRange);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.btnTaxValue);
            this.panel1.Location = new System.Drawing.Point(526, 102);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(411, 124);
            this.panel1.TabIndex = 54;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label15.Location = new System.Drawing.Point(17, 80);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 20);
            this.label15.TabIndex = 51;
            this.label15.Text = "Tax Value";
            // 
            // btnTaxValueDateRange
            // 
            this.btnTaxValueDateRange.BackColor = System.Drawing.Color.Red;
            this.btnTaxValueDateRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaxValueDateRange.ForeColor = System.Drawing.Color.Snow;
            this.btnTaxValueDateRange.Location = new System.Drawing.Point(315, 24);
            this.btnTaxValueDateRange.Name = "btnTaxValueDateRange";
            this.btnTaxValueDateRange.Size = new System.Drawing.Size(80, 31);
            this.btnTaxValueDateRange.TabIndex = 53;
            this.btnTaxValueDateRange.Text = "View";
            this.btnTaxValueDateRange.UseVisualStyleBackColor = false;
            this.btnTaxValueDateRange.Click += new System.EventHandler(this.btnTaxValueDateRange_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label14.Location = new System.Drawing.Point(17, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(190, 20);
            this.label14.TabIndex = 51;
            this.label14.Text = "Tax Value by Date Range";
            // 
            // btnTaxValue
            // 
            this.btnTaxValue.BackColor = System.Drawing.Color.Red;
            this.btnTaxValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaxValue.ForeColor = System.Drawing.Color.Snow;
            this.btnTaxValue.Location = new System.Drawing.Point(315, 80);
            this.btnTaxValue.Name = "btnTaxValue";
            this.btnTaxValue.Size = new System.Drawing.Size(80, 31);
            this.btnTaxValue.TabIndex = 52;
            this.btnTaxValue.Text = "View";
            this.btnTaxValue.UseVisualStyleBackColor = false;
            this.btnTaxValue.Click += new System.EventHandler(this.btnTaxValue_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Turquoise;
            this.groupBox3.Controls.Add(this.btnFreeOrdersTotalRange);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.btnFreeOrdersTotal);
            this.groupBox3.Location = new System.Drawing.Point(15, 668);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(489, 96);
            this.groupBox3.TabIndex = 50;
            this.groupBox3.TabStop = false;
            // 
            // btnFreeOrdersTotalRange
            // 
            this.btnFreeOrdersTotalRange.Location = new System.Drawing.Point(365, 62);
            this.btnFreeOrdersTotalRange.Name = "btnFreeOrdersTotalRange";
            this.btnFreeOrdersTotalRange.Size = new System.Drawing.Size(80, 31);
            this.btnFreeOrdersTotalRange.TabIndex = 41;
            this.btnFreeOrdersTotalRange.Text = "View";
            this.btnFreeOrdersTotalRange.UseVisualStyleBackColor = true;
            this.btnFreeOrdersTotalRange.Click += new System.EventHandler(this.btnFreeOrdersTotalRange_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(244, 20);
            this.label11.TabIndex = 48;
            this.label11.Text = "Free Orders Total by Date Range";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(192, 20);
            this.label10.TabIndex = 47;
            this.label10.Text = "Free Orders All Time Total";
            // 
            // btnFreeOrdersTotal
            // 
            this.btnFreeOrdersTotal.Location = new System.Drawing.Point(365, 17);
            this.btnFreeOrdersTotal.Name = "btnFreeOrdersTotal";
            this.btnFreeOrdersTotal.Size = new System.Drawing.Size(80, 31);
            this.btnFreeOrdersTotal.TabIndex = 40;
            this.btnFreeOrdersTotal.Text = "View";
            this.btnFreeOrdersTotal.UseVisualStyleBackColor = true;
            this.btnFreeOrdersTotal.Click += new System.EventHandler(this.btnFreeOrdersTotal_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Turquoise;
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.btnAllTimeTotal);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.btnTotalRange);
            this.groupBox4.Location = new System.Drawing.Point(16, 101);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(489, 128);
            this.groupBox4.TabIndex = 51;
            this.groupBox4.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(5, 108);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(288, 17);
            this.label13.TabIndex = 50;
            this.label13.Text = "Total Orders count include free orders";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(155, 20);
            this.label12.TabIndex = 49;
            this.label12.Text = "Total by Date Range";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 20);
            this.label9.TabIndex = 46;
            this.label9.Text = "All Time Total";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Turquoise;
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cbItemName);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btnTotalbyItemNameAndDateRange);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btnTotalbyItemName);
            this.groupBox2.Location = new System.Drawing.Point(15, 454);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(488, 191);
            this.groupBox2.TabIndex = 51;
            this.groupBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.TabIndex = 35;
            this.label4.Text = "Item Name";
            // 
            // cbItemName
            // 
            this.cbItemName.FormattingEnabled = true;
            this.cbItemName.Location = new System.Drawing.Point(109, 25);
            this.cbItemName.Name = "cbItemName";
            this.cbItemName.Size = new System.Drawing.Size(210, 28);
            this.cbItemName.TabIndex = 36;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(268, 20);
            this.label8.TabIndex = 45;
            this.label8.Text = "Total by Item Name and Date Range";
            // 
            // btnTotalbyItemNameAndDateRange
            // 
            this.btnTotalbyItemNameAndDateRange.Location = new System.Drawing.Point(365, 102);
            this.btnTotalbyItemNameAndDateRange.Name = "btnTotalbyItemNameAndDateRange";
            this.btnTotalbyItemNameAndDateRange.Size = new System.Drawing.Size(80, 31);
            this.btnTotalbyItemNameAndDateRange.TabIndex = 39;
            this.btnTotalbyItemNameAndDateRange.Text = "View";
            this.btnTotalbyItemNameAndDateRange.UseVisualStyleBackColor = true;
            this.btnTotalbyItemNameAndDateRange.Click += new System.EventHandler(this.btnTotalbyItemNameAndDateRange_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(205, 20);
            this.label7.TabIndex = 44;
            this.label7.Text = "All Time Total by Item Name";
            // 
            // btnTotalbyItemName
            // 
            this.btnTotalbyItemName.Location = new System.Drawing.Point(365, 148);
            this.btnTotalbyItemName.Name = "btnTotalbyItemName";
            this.btnTotalbyItemName.Size = new System.Drawing.Size(80, 31);
            this.btnTotalbyItemName.TabIndex = 37;
            this.btnTotalbyItemName.Text = "View";
            this.btnTotalbyItemName.UseVisualStyleBackColor = true;
            this.btnTotalbyItemName.Click += new System.EventHandler(this.btnTotalbyItemName_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Turquoise;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbItemCategory);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnTotalbyCategory);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnTotalbyCategoryAndDateRange);
            this.groupBox1.Location = new System.Drawing.Point(14, 249);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 179);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 33;
            this.label3.Text = "Category";
            // 
            // cbItemCategory
            // 
            this.cbItemCategory.FormattingEnabled = true;
            this.cbItemCategory.Location = new System.Drawing.Point(110, 22);
            this.cbItemCategory.Name = "cbItemCategory";
            this.cbItemCategory.Size = new System.Drawing.Size(210, 28);
            this.cbItemCategory.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(191, 20);
            this.label5.TabIndex = 42;
            this.label5.Text = "All Time Total by Category";
            // 
            // btnTotalbyCategory
            // 
            this.btnTotalbyCategory.Location = new System.Drawing.Point(366, 92);
            this.btnTotalbyCategory.Name = "btnTotalbyCategory";
            this.btnTotalbyCategory.Size = new System.Drawing.Size(80, 31);
            this.btnTotalbyCategory.TabIndex = 34;
            this.btnTotalbyCategory.Text = "View";
            this.btnTotalbyCategory.UseVisualStyleBackColor = true;
            this.btnTotalbyCategory.Click += new System.EventHandler(this.btnTotalbyCategory_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(254, 20);
            this.label6.TabIndex = 43;
            this.label6.Text = "Total by Category and Date Range";
            // 
            // btnTotalbyCategoryAndDateRange
            // 
            this.btnTotalbyCategoryAndDateRange.Location = new System.Drawing.Point(366, 142);
            this.btnTotalbyCategoryAndDateRange.Name = "btnTotalbyCategoryAndDateRange";
            this.btnTotalbyCategoryAndDateRange.Size = new System.Drawing.Size(80, 31);
            this.btnTotalbyCategoryAndDateRange.TabIndex = 38;
            this.btnTotalbyCategoryAndDateRange.Text = "View";
            this.btnTotalbyCategoryAndDateRange.UseVisualStyleBackColor = true;
            this.btnTotalbyCategoryAndDateRange.Click += new System.EventHandler(this.btnTotalbyCategoryAndDateRange_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Turquoise;
            this.groupBox5.Controls.Add(this.btnUsersMenu);
            this.groupBox5.Controls.Add(this.btnCategoriesMenu);
            this.groupBox5.Controls.Add(this.btnOrdersMenu);
            this.groupBox5.Controls.Add(this.btnItemsMenu);
            this.groupBox5.Controls.Add(this.btnOrderItems);
            this.groupBox5.Location = new System.Drawing.Point(163, 59);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(965, 97);
            this.groupBox5.TabIndex = 33;
            this.groupBox5.TabStop = false;
            // 
            // btnUsersMenu
            // 
            this.btnUsersMenu.Location = new System.Drawing.Point(691, 37);
            this.btnUsersMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUsersMenu.Name = "btnUsersMenu";
            this.btnUsersMenu.Size = new System.Drawing.Size(152, 52);
            this.btnUsersMenu.TabIndex = 7;
            this.btnUsersMenu.Text = "Users Menu";
            this.btnUsersMenu.UseVisualStyleBackColor = true;
            this.btnUsersMenu.Click += new System.EventHandler(this.btnUsersMenu_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(1, 193);
            this.btnAddUser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(152, 52);
            this.btnAddUser.TabIndex = 34;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Visible = false;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // dgvUsersMenu
            // 
            this.dgvUsersMenu.AllowUserToAddRows = false;
            this.dgvUsersMenu.AllowUserToDeleteRows = false;
            this.dgvUsersMenu.AllowUserToOrderColumns = true;
            this.dgvUsersMenu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvUsersMenu.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvUsersMenu.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvUsersMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvUsersMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsersMenu.ContextMenuStrip = this.contextMenuUsers;
            this.dgvUsersMenu.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvUsersMenu.Location = new System.Drawing.Point(163, 164);
            this.dgvUsersMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvUsersMenu.Name = "dgvUsersMenu";
            this.dgvUsersMenu.ReadOnly = true;
            this.dgvUsersMenu.RowHeadersWidth = 62;
            this.dgvUsersMenu.Size = new System.Drawing.Size(534, 784);
            this.dgvUsersMenu.TabIndex = 35;
            this.dgvUsersMenu.Visible = false;
            // 
            // contextMenuUsers
            // 
            this.contextMenuUsers.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuUsers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripEditUsers,
            this.toolStripDeleteUsers});
            this.contextMenuUsers.Name = "contextMenuOrders";
            this.contextMenuUsers.Size = new System.Drawing.Size(135, 68);
            // 
            // toolStripEditUsers
            // 
            this.toolStripEditUsers.Name = "toolStripEditUsers";
            this.toolStripEditUsers.Size = new System.Drawing.Size(240, 32);
            this.toolStripEditUsers.Text = "Edit";
            this.toolStripEditUsers.Click += new System.EventHandler(this.toolStripEditUsers_Click);
            // 
            // toolStripDeleteUsers
            // 
            this.toolStripDeleteUsers.Name = "toolStripDeleteUsers";
            this.toolStripDeleteUsers.Size = new System.Drawing.Size(240, 32);
            this.toolStripDeleteUsers.Text = "Delete";
            this.toolStripDeleteUsers.Click += new System.EventHandler(this.toolStripDeleteUsers_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1743, 952);
            this.Controls.Add(this.dgvUsersMenu);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.panelOrdersTotal);
            this.Controls.Add(this.dgvOrderItems);
            this.Controls.Add(this.dgvCategories);
            this.Controls.Add(this.btnAddOrder);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.btnAddCategory);
            this.Controls.Add(this.dgvListItems);
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
            this.panelOrdersTotal.ResumeLayout(false);
            this.panelOrdersTotal.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersMenu)).EndInit();
            this.contextMenuUsers.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem toolStripShowOrderItems;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTotalRange;
        private System.Windows.Forms.Button btnAllTimeTotal;
        private System.Windows.Forms.Panel panelOrdersTotal;
        private System.Windows.Forms.ComboBox cbItemCategory;
        private System.Windows.Forms.Button btnTotalbyCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnTotalbyItemName;
        private System.Windows.Forms.ComboBox cbItemName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTotalbyCategoryAndDateRange;
        private System.Windows.Forms.Button btnTotalbyItemNameAndDateRange;
        private System.Windows.Forms.Button btnFreeOrdersTotalRange;
        private System.Windows.Forms.Button btnFreeOrdersTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnTaxValueDateRange;
        private System.Windows.Forms.Button btnTaxValue;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnUsersMenu;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.DataGridView dgvUsersMenu;
        private System.Windows.Forms.ContextMenuStrip contextMenuUsers;
        private System.Windows.Forms.ToolStripMenuItem toolStripEditUsers;
        private System.Windows.Forms.ToolStripMenuItem toolStripDeleteUsers;
    }
}

