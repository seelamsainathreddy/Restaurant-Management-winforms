namespace restaurantManagement
{
    partial class ManageTables
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelBottom, panelCenter;
        private DataGridView dataGridViewTables;
        private TextBox txtTableNumber;
        private NumericUpDown numCapacity;
        private Button btnAddTable, btnChangeStatus, btnDeleteTable;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dataGridViewTables = new DataGridView();
            panelBottom = new Panel();
            panelCenter = new Panel();
            txtTableNumber = new TextBox();
            numCapacity = new NumericUpDown();
            btnAddTable = new Button();
            btnChangeStatus = new Button();
            btnDeleteTable = new Button();

            ((System.ComponentModel.ISupportInitialize)dataGridViewTables).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCapacity).BeginInit();
            SuspendLayout();

            // 
            // dataGridViewTables
            // 
            dataGridViewTables.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTables.Dock = DockStyle.Fill;
            dataGridViewTables.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewTables.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewTables.BackgroundColor = Color.White;
            dataGridViewTables.BorderStyle = BorderStyle.None;
            dataGridViewTables.Location = new Point(0, 0);
            dataGridViewTables.Name = "dataGridViewTables";
            dataGridViewTables.RowHeadersWidth = 51;
            dataGridViewTables.AllowUserToAddRows = false;
            dataGridViewTables.AllowUserToResizeColumns = true;
            dataGridViewTables.AllowUserToResizeRows = false;
            dataGridViewTables.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewTables.MultiSelect = false;
            dataGridViewTables.Size = new Size(800, 420);
            dataGridViewTables.TabIndex = 0;

            // 
            // panelBottom
            // 
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Height = 80;
            panelBottom.Padding = new Padding(10);
            panelBottom.BackColor = Color.FromArgb(240, 240, 240);
            panelBottom.TabIndex = 1;

            // TableLayoutPanel for aligning items in panelBottom
            TableLayoutPanel layoutBottom = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 1
            };

            layoutBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20)); // Left (Change Status)
            layoutBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60)); // Center (Table Number + Capacity + Add)
            layoutBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20)); // Right (Delete Table)

            // 
            // panelCenter (Holds Table Number, Capacity, and Add Table)
            // 
            panelCenter.Dock = DockStyle.Fill;
            panelCenter.Padding = new Padding(5);
            panelCenter.BackColor = Color.Transparent;

            // TableLayoutPanel for flexible spacing inside panelCenter
            TableLayoutPanel layoutCenter = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 1
            };

            layoutCenter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33));
            layoutCenter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33));
            layoutCenter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34));

            // 
            // txtTableNumber
            // 
            txtTableNumber.Dock = DockStyle.Fill;
            txtTableNumber.Margin = new Padding(5);
            txtTableNumber.Name = "txtTableNumber";
            txtTableNumber.PlaceholderText = "Table No";

            // 
            // numCapacity
            // 
            numCapacity.Dock = DockStyle.Fill;
            numCapacity.Margin = new Padding(5);
            numCapacity.Name = "numCapacity";
            numCapacity.Minimum = 1;
            numCapacity.Maximum = 20;

            // 
            // btnAddTable
            // 
            btnAddTable.Dock = DockStyle.Fill;
            btnAddTable.Margin = new Padding(5);
            btnAddTable.Name = "btnAddTable";
            btnAddTable.Text = "Add Table";
            btnAddTable.Click += btnAddTable_Click;

            // Add elements to layoutCenter
            layoutCenter.Controls.Add(txtTableNumber, 0, 0);
            layoutCenter.Controls.Add(numCapacity, 1, 0);
            layoutCenter.Controls.Add(btnAddTable, 2, 0);

            // Add layoutCenter to panelCenter
            panelCenter.Controls.Add(layoutCenter);

            // 
            // btnChangeStatus
            // 
            btnChangeStatus.Dock = DockStyle.Fill;
            btnChangeStatus.Margin = new Padding(5);
            btnChangeStatus.Name = "btnChangeStatus";
            btnChangeStatus.Text = "Change Status";
            btnChangeStatus.Click += btnChangeStatus_Click;

            // 
            // btnDeleteTable
            // 
            btnDeleteTable.Dock = DockStyle.Fill;
            btnDeleteTable.Margin = new Padding(5);
            btnDeleteTable.Name = "btnDeleteTable";
            btnDeleteTable.Text = "Delete Table";
            btnDeleteTable.Click += btnDeleteTable_Click;

            // Add elements to layoutBottom
            layoutBottom.Controls.Add(btnChangeStatus, 0, 0);
            layoutBottom.Controls.Add(panelCenter, 1, 0);
            layoutBottom.Controls.Add(btnDeleteTable, 2, 0);

            // Add layoutBottom to panelBottom
            panelBottom.Controls.Add(layoutBottom);

            // 
            // ManageTables
            // 
            ClientSize = new Size(800, 500);
            Controls.Add(dataGridViewTables);
            Controls.Add(panelBottom);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ManageTables";
            Text = "Manage Tables";

            ((System.ComponentModel.ISupportInitialize)dataGridViewTables).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCapacity).EndInit();
            ResumeLayout(false);
        }
    }
}
