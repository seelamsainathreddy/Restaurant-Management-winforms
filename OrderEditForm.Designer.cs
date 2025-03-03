namespace restaurantManagement
{
    partial class OrderEditForm
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
            dataGridViewOrderItems = new DataGridView();
            comboBoxMenuItems = new ComboBox();
            numericUpDownQuantity = new NumericUpDown();
            btnAddMenuItem = new Button();
            comboBoxWaiters = new ComboBox();
            comboBoxTables = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrderItems).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantity).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewOrderItems
            // 
            dataGridViewOrderItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewOrderItems.Location = new Point(12, 12);
            dataGridViewOrderItems.Name = "dataGridViewOrderItems";
            dataGridViewOrderItems.RowHeadersWidth = 51;
            dataGridViewOrderItems.Size = new Size(380, 259);
            dataGridViewOrderItems.TabIndex = 0;
            // 
            // comboBoxMenuItems
            // 
            comboBoxMenuItems.FormattingEnabled = true;
            comboBoxMenuItems.Location = new Point(179, 336);
            comboBoxMenuItems.Name = "comboBoxMenuItems";
            comboBoxMenuItems.Size = new Size(151, 28);
            comboBoxMenuItems.TabIndex = 1;
            comboBoxMenuItems.Text = "Select Menu";
            // 
            // numericUpDownQuantity
            // 
            numericUpDownQuantity.Location = new Point(13, 336);
            numericUpDownQuantity.Name = "numericUpDownQuantity";
            numericUpDownQuantity.Size = new Size(150, 27);
            numericUpDownQuantity.TabIndex = 2;
            // 
            // btnAddMenuItem
            // 
            btnAddMenuItem.Location = new Point(12, 379);
            btnAddMenuItem.Name = "btnAddMenuItem";
            btnAddMenuItem.Size = new Size(94, 29);
            btnAddMenuItem.TabIndex = 3;
            btnAddMenuItem.Text = "Add Item";
            btnAddMenuItem.UseVisualStyleBackColor = true;
            btnAddMenuItem.Click += btnAddMenuItem_Click;
            // 
            // comboBoxWaiters
            // 
            comboBoxWaiters.FormattingEnabled = true;
            comboBoxWaiters.Location = new Point(12, 291);
            comboBoxWaiters.Name = "comboBoxWaiters";
            comboBoxWaiters.Size = new Size(151, 28);
            comboBoxWaiters.TabIndex = 5;
            comboBoxWaiters.Text = "Select Waiter";
            // 
            // comboBoxTables
            // 
            comboBoxTables.FormattingEnabled = true;
            comboBoxTables.Location = new Point(179, 291);
            comboBoxTables.Name = "comboBoxTables";
            comboBoxTables.Size = new Size(151, 28);
            comboBoxTables.TabIndex = 6;
            comboBoxTables.Text = "Select Table";
            // 
            // OrderEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(comboBoxTables);
            Controls.Add(comboBoxWaiters);
            Controls.Add(btnAddMenuItem);
            Controls.Add(numericUpDownQuantity);
            Controls.Add(comboBoxMenuItems);
            Controls.Add(dataGridViewOrderItems);
            Name = "OrderEditForm";
            Text = "OrderEditForm";
            Load += OrderEditForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrderItems).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantity).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewOrderItems;
        private ComboBox comboBoxMenuItems;
        private NumericUpDown numericUpDownQuantity;
        private Button btnAddMenuItem;
        private Label label1;
        private ComboBox comboBoxWaiters;
        private ComboBox comboBoxTables;
    }
}