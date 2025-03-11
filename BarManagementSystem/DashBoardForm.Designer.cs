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

        // DataGridView for occupied tables and their order totals.
        private System.Windows.Forms.DataGridView dgvOccupiedTables;
        private System.Windows.Forms.Label lblOccupiedTables;

        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.TextBox totalPriceText;
        private System.Windows.Forms.Button btnPrintBill;
        private System.Windows.Forms.Button btnPaid;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.dgvOccupiedTables = new System.Windows.Forms.DataGridView();
            this.lblOccupiedTables = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.totalPriceText = new System.Windows.Forms.TextBox();
            this.btnPrintBill = new System.Windows.Forms.Button();
            this.btnPaid = new System.Windows.Forms.Button();
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
            this.menuStripDashboard.Size = new System.Drawing.Size(1238, 30);
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
            this.lblTableNumber.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTableNumber.Location = new System.Drawing.Point(33, 58);
            this.lblTableNumber.Name = "lblTableNumber";
            this.lblTableNumber.Size = new System.Drawing.Size(113, 20);
            this.lblTableNumber.TabIndex = 1;
            this.lblTableNumber.Text = "Table Number:";
            // 
            // txtTableNumber
            // 
            this.txtTableNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTableNumber.Location = new System.Drawing.Point(157, 55);
            this.txtTableNumber.Name = "txtTableNumber";
            this.txtTableNumber.Size = new System.Drawing.Size(114, 30);
            this.txtTableNumber.TabIndex = 2;
            // 
            // btnLoadTable
            // 
            this.btnLoadTable.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnLoadTable.Location = new System.Drawing.Point(287, 53);
            this.btnLoadTable.Name = "btnLoadTable";
            this.btnLoadTable.Size = new System.Drawing.Size(114, 32);
            this.btnLoadTable.TabIndex = 3;
            this.btnLoadTable.Text = "Load Table";
            this.btnLoadTable.UseVisualStyleBackColor = true;
            this.btnLoadTable.Click += new System.EventHandler(this.btnLoadTable_Click);
            // 
            // dgvActiveOrders
            // 
            this.dgvActiveOrders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvActiveOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActiveOrders.Location = new System.Drawing.Point(26, 337);
            this.dgvActiveOrders.Name = "dgvActiveOrders";
            this.dgvActiveOrders.RowHeadersWidth = 51;
            this.dgvActiveOrders.RowTemplate.Height = 25;
            this.dgvActiveOrders.Size = new System.Drawing.Size(640, 180);
            this.dgvActiveOrders.TabIndex = 4;
            // 
            // groupBoxItemAdder
            // 
            this.groupBoxItemAdder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.groupBoxItemAdder.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxItemAdder.Location = new System.Drawing.Point(26, 115);
            this.groupBoxItemAdder.Name = "groupBoxItemAdder";
            this.groupBoxItemAdder.Size = new System.Drawing.Size(580, 200);
            this.groupBoxItemAdder.TabIndex = 5;
            this.groupBoxItemAdder.TabStop = false;
            this.groupBoxItemAdder.Text = "Item Adder";
            // 
            // lblItemCode
            // 
            this.lblItemCode.AutoSize = true;
            this.lblItemCode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblItemCode.Location = new System.Drawing.Point(20, 35);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.Size = new System.Drawing.Size(94, 23);
            this.lblItemCode.TabIndex = 0;
            this.lblItemCode.Text = "Item Code:";
            // 
            // txtItemCode
            // 
            this.txtItemCode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtItemCode.Location = new System.Drawing.Point(117, 32);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(114, 30);
            this.txtItemCode.TabIndex = 1;
            // 
            // btnSearchItem
            // 
            this.btnSearchItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSearchItem.Location = new System.Drawing.Point(247, 30);
            this.btnSearchItem.Name = "btnSearchItem";
            this.btnSearchItem.Size = new System.Drawing.Size(90, 32);
            this.btnSearchItem.TabIndex = 2;
            this.btnSearchItem.Text = "Search";
            this.btnSearchItem.UseVisualStyleBackColor = true;
            this.btnSearchItem.Click += new System.EventHandler(this.btnSearchItem_Click);
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblItemName.Location = new System.Drawing.Point(20, 75);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(100, 23);
            this.lblItemName.TabIndex = 3;
            this.lblItemName.Text = "Item Name:";
            // 
            // txtItemName
            // 
            this.txtItemName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtItemName.Location = new System.Drawing.Point(117, 72);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.ReadOnly = true;
            this.txtItemName.Size = new System.Drawing.Size(240, 30);
            this.txtItemName.TabIndex = 4;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblType.Location = new System.Drawing.Point(20, 115);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(49, 23);
            this.lblType.TabIndex = 5;
            this.lblType.Text = "Type:";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(117, 112);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(170, 31);
            this.cmbType.TabIndex = 6;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPrice.Location = new System.Drawing.Point(20, 155);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(51, 23);
            this.lblPrice.TabIndex = 7;
            this.lblPrice.Text = "Price:";
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPrice.Location = new System.Drawing.Point(117, 152);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(114, 30);
            this.txtPrice.TabIndex = 8;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblQuantity.Location = new System.Drawing.Point(247, 155);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(80, 23);
            this.lblQuantity.TabIndex = 9;
            this.lblQuantity.Text = "Quantity:";
            // 
            // numQuantity
            // 
            this.numQuantity.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numQuantity.Location = new System.Drawing.Point(337, 152);
            this.numQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(70, 30);
            this.numQuantity.TabIndex = 10;
            this.numQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAddItem
            // 
            this.btnAddItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAddItem.Location = new System.Drawing.Point(417, 150);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(120, 32);
            this.btnAddItem.TabIndex = 11;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnDisplayShortcodes
            // 
            this.btnDisplayShortcodes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDisplayShortcodes.Location = new System.Drawing.Point(37, 640);
            this.btnDisplayShortcodes.Name = "btnDisplayShortcodes";
            this.btnDisplayShortcodes.Size = new System.Drawing.Size(180, 35);
            this.btnDisplayShortcodes.TabIndex = 6;
            this.btnDisplayShortcodes.Text = "Display Shortcodes";
            this.btnDisplayShortcodes.UseVisualStyleBackColor = true;
            this.btnDisplayShortcodes.Click += new System.EventHandler(this.btnDisplayShortcodes_Click);
            // 
            // dgvOccupiedTables
            // 
            this.dgvOccupiedTables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOccupiedTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOccupiedTables.Location = new System.Drawing.Point(1013, 115);
            this.dgvOccupiedTables.Name = "dgvOccupiedTables";
            this.dgvOccupiedTables.RowHeadersWidth = 51;
            this.dgvOccupiedTables.RowTemplate.Height = 25;
            this.dgvOccupiedTables.Size = new System.Drawing.Size(190, 385);
            this.dgvOccupiedTables.TabIndex = 7;
            this.dgvOccupiedTables.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvActiveTables_CellClick);
            this.dgvOccupiedTables.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvActiveTables_CellClick);
            this.dgvOccupiedTables.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvActiveTables_CellClick);
            // 
            // lblOccupiedTables
            // 
            this.lblOccupiedTables.AutoSize = true;
            this.lblOccupiedTables.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOccupiedTables.Location = new System.Drawing.Point(1009, 80);
            this.lblOccupiedTables.Name = "lblOccupiedTables";
            this.lblOccupiedTables.Size = new System.Drawing.Size(178, 23);
            this.lblOccupiedTables.TabIndex = 8;
            this.lblOccupiedTables.Text = "Occupied Tables List:";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTotalPrice.Location = new System.Drawing.Point(36, 530);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(92, 23);
            this.lblTotalPrice.TabIndex = 9;
            this.lblTotalPrice.Text = "Total Price:";
            this.lblTotalPrice.Click += new System.EventHandler(this.lblTotalPrice_Click);
            // 
            // totalPriceText
            // 
            this.totalPriceText.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.totalPriceText.Location = new System.Drawing.Point(134, 523);
            this.totalPriceText.Name = "totalPriceText";
            this.totalPriceText.ReadOnly = true;
            this.totalPriceText.Size = new System.Drawing.Size(114, 30);
            this.totalPriceText.TabIndex = 10;
            // 
            // btnPrintBill
            // 
            this.btnPrintBill.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnPrintBill.Location = new System.Drawing.Point(37, 580);
            this.btnPrintBill.Name = "btnPrintBill";
            this.btnPrintBill.Size = new System.Drawing.Size(100, 35);
            this.btnPrintBill.TabIndex = 11;
            this.btnPrintBill.Text = "Print Bill";
            this.btnPrintBill.UseVisualStyleBackColor = true;
            this.btnPrintBill.Click += new System.EventHandler(this.btnPrintBill_Click);
            // 
            // btnPaid
            // 
            this.btnPaid.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnPaid.Location = new System.Drawing.Point(157, 580);
            this.btnPaid.Name = "btnPaid";
            this.btnPaid.Size = new System.Drawing.Size(100, 35);
            this.btnPaid.TabIndex = 12;
            this.btnPaid.Text = "Paid";
            this.btnPaid.UseVisualStyleBackColor = true;
            this.btnPaid.Click += new System.EventHandler(this.btnPaid_Click);
            // 
            // DashboardForm
            // 
            this.ClientSize = new System.Drawing.Size(1238, 687);
            this.Controls.Add(this.btnPaid);
            this.Controls.Add(this.btnPrintBill);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.totalPriceText);
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
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
