namespace barmanagement
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button btnDisplayShortcodes;

        // Nav bar components:
        private System.Windows.Forms.MenuStrip menuStripDashboard;
        private System.Windows.Forms.ToolStripMenuItem masterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoryMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tableMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemMasterToolStripMenuItem;

        // Table selection controls:
        private System.Windows.Forms.Label lblTableNumber;
        private System.Windows.Forms.TextBox txtTableNumber;
        private System.Windows.Forms.Button btnLoadTable;
        // DataGridView to display active orders:
        private System.Windows.Forms.DataGridView dgvActiveOrders;
        // GroupBox for the item adder section:
        private System.Windows.Forms.GroupBox groupBoxItemAdder;
        private System.Windows.Forms.Label lblItemCode;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.Button btnSearchItem;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Button btnAddItem;

        // New: DataGridView for occupied tables and their order totals.
        private System.Windows.Forms.DataGridView dgvOccupiedTables;
        private System.Windows.Forms.Label lblOccupiedTables;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.menuStripDashboard = new System.Windows.Forms.MenuStrip();
            this.masterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoryMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTableNumber = new System.Windows.Forms.Label();
            this.txtTableNumber = new System.Windows.Forms.TextBox();
            this.btnLoadTable = new System.Windows.Forms.Button();
            this.dgvActiveOrders = new System.Windows.Forms.DataGridView();
            this.groupBoxItemAdder = new System.Windows.Forms.GroupBox();
            this.lblItemCode = new System.Windows.Forms.Label();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.btnSearchItem = new System.Windows.Forms.Button();
            this.lblItemName = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnDisplayShortcodes = new System.Windows.Forms.Button();
            // New occupied tables grid and label.
            this.dgvOccupiedTables = new System.Windows.Forms.DataGridView();
            this.lblOccupiedTables = new System.Windows.Forms.Label();

            this.menuStripDashboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActiveOrders)).BeginInit();
            this.groupBoxItemAdder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOccupiedTables)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStripDashboard
            // 
            this.menuStripDashboard.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripDashboard.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masterToolStripMenuItem});
            this.menuStripDashboard.Location = new System.Drawing.Point(0, 0);
            this.menuStripDashboard.Name = "menuStripDashboard";
            this.menuStripDashboard.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStripDashboard.Size = new System.Drawing.Size(1238, 28);
            this.menuStripDashboard.TabIndex = 0;
            this.menuStripDashboard.Text = "menuStripDashboard";
            // 
            // masterToolStripMenuItem
            // 
            this.masterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.categoryMasterToolStripMenuItem,
            this.tableMasterToolStripMenuItem,
            this.itemMasterToolStripMenuItem});
            this.masterToolStripMenuItem.Name = "masterToolStripMenuItem";
            this.masterToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.masterToolStripMenuItem.Text = "Master";
            // 
            // categoryMasterToolStripMenuItem
            // 
            this.categoryMasterToolStripMenuItem.Name = "categoryMasterToolStripMenuItem";
            this.categoryMasterToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.categoryMasterToolStripMenuItem.Text = "Category Master";
            this.categoryMasterToolStripMenuItem.Click += new System.EventHandler(this.CategoryMasterToolStripMenuItem_Click);
            // 
            // tableMasterToolStripMenuItem
            // 
            this.tableMasterToolStripMenuItem.Name = "tableMasterToolStripMenuItem";
            this.tableMasterToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.tableMasterToolStripMenuItem.Text = "Table Master";
            this.tableMasterToolStripMenuItem.Click += new System.EventHandler(this.TableMasterToolStripMenuItem_Click);
            // 
            // itemMasterToolStripMenuItem
            // 
            this.itemMasterToolStripMenuItem.Name = "itemMasterToolStripMenuItem";
            this.itemMasterToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.itemMasterToolStripMenuItem.Text = "Item Master";
            this.itemMasterToolStripMenuItem.Click += new System.EventHandler(this.ItemMasterToolStripMenuItem_Click);
            // 
            // lblTableNumber
            // 
            this.lblTableNumber.AutoSize = true;
            this.lblTableNumber.Location = new System.Drawing.Point(23, 43);
            this.lblTableNumber.Name = "lblTableNumber";
            this.lblTableNumber.Size = new System.Drawing.Size(97, 16);
            this.lblTableNumber.TabIndex = 1;
            this.lblTableNumber.Text = "Table Number:";
            // 
            // txtTableNumber
            // 
            this.txtTableNumber.Location = new System.Drawing.Point(137, 39);
            this.txtTableNumber.Name = "txtTableNumber";
            this.txtTableNumber.Size = new System.Drawing.Size(114, 22);
            this.txtTableNumber.TabIndex = 2;
            // 
            // btnLoadTable
            // 
            this.btnLoadTable.Location = new System.Drawing.Point(263, 37);
            this.btnLoadTable.Name = "btnLoadTable";
            this.btnLoadTable.Size = new System.Drawing.Size(114, 27);
            this.btnLoadTable.TabIndex = 3;
            this.btnLoadTable.Text = "Load Table";
            this.btnLoadTable.UseVisualStyleBackColor = true;
            this.btnLoadTable.Click += new System.EventHandler(this.btnLoadTable_Click);
            // 
            // dgvActiveOrders
            // 
            this.dgvActiveOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActiveOrders.Location = new System.Drawing.Point(26, 304);
            this.dgvActiveOrders.Name = "dgvActiveOrders";
            this.dgvActiveOrders.RowHeadersWidth = 51;
            this.dgvActiveOrders.RowTemplate.Height = 25;
            this.dgvActiveOrders.Size = new System.Drawing.Size(571, 160);
            this.dgvActiveOrders.TabIndex = 4;
            // 
            // groupBoxItemAdder
            // 
            this.groupBoxItemAdder.Controls.Add(this.lblItemCode);
            this.groupBoxItemAdder.Controls.Add(this.txtItemCode);
            this.groupBoxItemAdder.Controls.Add(this.btnSearchItem);
            this.groupBoxItemAdder.Controls.Add(this.lblItemName);
            this.groupBoxItemAdder.Controls.Add(this.txtItemName);
            this.groupBoxItemAdder.Controls.Add(this.lblType);
            this.groupBoxItemAdder.Controls.Add(this.cmbType);
            this.groupBoxItemAdder.Controls.Add(this.lblPrice);
            this.groupBoxItemAdder.Controls.Add(this.txtPrice);
            this.groupBoxItemAdder.Controls.Add(this.lblQuantity);
            this.groupBoxItemAdder.Controls.Add(this.numQuantity);
            this.groupBoxItemAdder.Controls.Add(this.btnAddItem);
            this.groupBoxItemAdder.Location = new System.Drawing.Point(26, 79);
            this.groupBoxItemAdder.Name = "groupBoxItemAdder";
            this.groupBoxItemAdder.Size = new System.Drawing.Size(571, 192);
            this.groupBoxItemAdder.TabIndex = 5;
            this.groupBoxItemAdder.TabStop = false;
            this.groupBoxItemAdder.Text = "Item Adder";
            // 
            // lblItemCode
            // 
            this.lblItemCode.AutoSize = true;
            this.lblItemCode.Location = new System.Drawing.Point(23, 32);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.Size = new System.Drawing.Size(71, 16);
            this.lblItemCode.TabIndex = 0;
            this.lblItemCode.Text = "Item Code:";
            // 
            // txtItemCode
            // 
            this.txtItemCode.Location = new System.Drawing.Point(114, 29);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(114, 22);
            this.txtItemCode.TabIndex = 1;
            // 
            // btnSearchItem
            // 
            this.btnSearchItem.Location = new System.Drawing.Point(240, 28);
            this.btnSearchItem.Name = "btnSearchItem";
            this.btnSearchItem.Size = new System.Drawing.Size(86, 27);
            this.btnSearchItem.TabIndex = 2;
            this.btnSearchItem.Text = "Search";
            this.btnSearchItem.UseVisualStyleBackColor = true;
            this.btnSearchItem.Click += new System.EventHandler(this.btnSearchItem_Click);
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Location = new System.Drawing.Point(23, 69);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(75, 16);
            this.lblItemName.TabIndex = 3;
            this.lblItemName.Text = "Item Name:";
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(114, 66);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.ReadOnly = true;
            this.txtItemName.Size = new System.Drawing.Size(228, 22);
            this.txtItemName.TabIndex = 4;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(23, 107);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(42, 16);
            this.lblType.TabIndex = 5;
            this.lblType.Text = "Type:";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(114, 103);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(171, 24);
            this.cmbType.TabIndex = 6;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(23, 144);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(41, 16);
            this.lblPrice.TabIndex = 7;
            this.lblPrice.Text = "Price:";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(114, 141);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(114, 22);
            this.txtPrice.TabIndex = 8;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(263, 144);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(58, 16);
            this.lblQuantity.TabIndex = 9;
            this.lblQuantity.Text = "Quantity:";
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(331, 142);
            this.numQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(69, 22);
            this.numQuantity.TabIndex = 10;
            this.numQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(434, 139);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(114, 32);
            this.btnAddItem.TabIndex = 11;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnDisplayShortcodes
            // 
            this.btnDisplayShortcodes.Location = new System.Drawing.Point(26, 623);
            this.btnDisplayShortcodes.Name = "btnDisplayShortcodes";
            this.btnDisplayShortcodes.Size = new System.Drawing.Size(171, 32);
            this.btnDisplayShortcodes.TabIndex = 6;
            this.btnDisplayShortcodes.Text = "Display Shortcodes";
            this.btnDisplayShortcodes.UseVisualStyleBackColor = true;
            this.btnDisplayShortcodes.Click += new System.EventHandler(this.btnDisplayShortcodes_Click);
            // 
            // dgvOccupiedTables (New)
            // 
            this.dgvOccupiedTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOccupiedTables.Location = new System.Drawing.Point(630, 79);
            this.dgvOccupiedTables.Name = "dgvOccupiedTables";
            this.dgvOccupiedTables.RowHeadersWidth = 51;
            this.dgvOccupiedTables.RowTemplate.Height = 25;
            this.dgvOccupiedTables.Size = new System.Drawing.Size(580, 385);
            this.dgvOccupiedTables.TabIndex = 7;
            // 
            // lblOccupiedTables (New)
            // 
            this.lblOccupiedTables.AutoSize = true;
            this.lblOccupiedTables.Location = new System.Drawing.Point(630, 43);
            this.lblOccupiedTables.Name = "lblOccupiedTables";
            this.lblOccupiedTables.Size = new System.Drawing.Size(123, 16);
            this.lblOccupiedTables.TabIndex = 8;
            this.lblOccupiedTables.Text = "Occupied Tables List:";
            // 
            // DashboardForm
            // 
            this.ClientSize = new System.Drawing.Size(1238, 687);
            this.Controls.Add(this.lblOccupiedTables);
            this.Controls.Add(this.dgvOccupiedTables);
            this.Controls.Add(this.btnDisplayShortcodes);
            this.Controls.Add(this.groupBoxItemAdder);
            this.Controls.Add(this.dgvActiveOrders);
            this.Controls.Add(this.btnLoadTable);
            this.Controls.Add(this.txtTableNumber);
            this.Controls.Add(this.lblTableNumber);
            this.Controls.Add(this.menuStripDashboard);
            this.MainMenuStrip = this.menuStripDashboard;
            this.Name = "DashboardForm";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.menuStripDashboard.ResumeLayout(false);
            this.menuStripDashboard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActiveOrders)).EndInit();
            this.groupBoxItemAdder.ResumeLayout(false);
            this.groupBoxItemAdder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOccupiedTables)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
    }
}
