using System.Windows.Forms;

namespace BarManagementSystem
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButtonMaster = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItemCategoryMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTableMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemItemMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonLogout = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewOrderItems = new System.Windows.Forms.DataGridView();
            this.SelectedType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderItems)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(200)))));
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButtonMaster,
            this.toolStripSeparator1,
            this.toolStripButtonLogout});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.toolStripMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripMenu.Size = new System.Drawing.Size(1163, 60);
            this.toolStripMenu.Stretch = true;
            this.toolStripMenu.TabIndex = 0;
            // 
            // toolStripDropDownButtonMaster
            // 
            this.toolStripDropDownButtonMaster.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.toolStripDropDownButtonMaster.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemCategoryMaster,
            this.toolStripMenuItemTableMaster,
            this.toolStripMenuItemItemMaster});
            this.toolStripDropDownButtonMaster.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.toolStripDropDownButtonMaster.ForeColor = System.Drawing.SystemColors.Window;
            this.toolStripDropDownButtonMaster.Name = "toolStripDropDownButtonMaster";
            this.toolStripDropDownButtonMaster.Padding = new System.Windows.Forms.Padding(7);
            this.toolStripDropDownButtonMaster.Size = new System.Drawing.Size(90, 37);
            this.toolStripDropDownButtonMaster.Text = "Master";
            this.toolStripDropDownButtonMaster.Click += new System.EventHandler(this.toolStripDropDownButtonMaster_Click);
            // 
            // toolStripMenuItemCategoryMaster
            // 
            this.toolStripMenuItemCategoryMaster.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.toolStripMenuItemCategoryMaster.Font = new System.Drawing.Font("Arial", 10F);
            this.toolStripMenuItemCategoryMaster.ForeColor = System.Drawing.Color.Black;
            this.toolStripMenuItemCategoryMaster.Name = "toolStripMenuItemCategoryMaster";
            this.toolStripMenuItemCategoryMaster.Size = new System.Drawing.Size(213, 26);
            this.toolStripMenuItemCategoryMaster.Text = "Category Master";
            this.toolStripMenuItemCategoryMaster.Click += new System.EventHandler(this.toolStripMenuItemCategoryMaster_Click);
            // 
            // toolStripMenuItemTableMaster
            // 
            this.toolStripMenuItemTableMaster.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.toolStripMenuItemTableMaster.Font = new System.Drawing.Font("Arial", 10F);
            this.toolStripMenuItemTableMaster.ForeColor = System.Drawing.Color.Black;
            this.toolStripMenuItemTableMaster.Name = "toolStripMenuItemTableMaster";
            this.toolStripMenuItemTableMaster.Size = new System.Drawing.Size(213, 26);
            this.toolStripMenuItemTableMaster.Text = "Table Master";
            this.toolStripMenuItemTableMaster.Click += new System.EventHandler(this.toolStripMenuItemTableMaster_Click);
            // 
            // toolStripMenuItemItemMaster
            // 
            this.toolStripMenuItemItemMaster.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.toolStripMenuItemItemMaster.Font = new System.Drawing.Font("Arial", 10F);
            this.toolStripMenuItemItemMaster.ForeColor = System.Drawing.Color.Black;
            this.toolStripMenuItemItemMaster.Name = "toolStripMenuItemItemMaster";
            this.toolStripMenuItemItemMaster.Size = new System.Drawing.Size(213, 26);
            this.toolStripMenuItemItemMaster.Text = "Item Master";
            this.toolStripMenuItemItemMaster.Click += new System.EventHandler(this.toolStripMenuItemItemMaster_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // toolStripButtonLogout
            // 
            this.toolStripButtonLogout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.toolStripButtonLogout.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.toolStripButtonLogout.ForeColor = System.Drawing.Color.White;
            this.toolStripButtonLogout.Name = "toolStripButtonLogout";
            this.toolStripButtonLogout.Padding = new System.Windows.Forms.Padding(3);
            this.toolStripButtonLogout.Size = new System.Drawing.Size(75, 37);
            this.toolStripButtonLogout.Text = "Logout";
            this.toolStripButtonLogout.Click += new System.EventHandler(this.toolStripButtonLogout_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Table No : ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(134, 80);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "1";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(935, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Date : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1005, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Today\'s Date";
            // 
            // dataGridViewOrderItems
            // 
            this.dataGridViewOrderItems.AllowUserToAddRows = false;
            this.dataGridViewOrderItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOrderItems.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewOrderItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewOrderItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewOrderItems.ColumnHeadersHeight = 29;
            this.dataGridViewOrderItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.SelectedType,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dataGridViewOrderItems.Location = new System.Drawing.Point(29, 120);
            this.dataGridViewOrderItems.Name = "dataGridViewOrderItems";
            this.dataGridViewOrderItems.RowHeadersWidth = 51;
            this.dataGridViewOrderItems.Size = new System.Drawing.Size(900, 400);
            this.dataGridViewOrderItems.TabIndex = 0;
            this.dataGridViewOrderItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOrderItems_CellContentClick);
            this.dataGridViewOrderItems.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOrderItems_CellEndEdit);
            // 
            // SelectedType
            // 
            this.SelectedType.HeaderText = "SelectedType";
            this.SelectedType.MinimumWidth = 6;
            this.SelectedType.Name = "SelectedType";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDelete.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(940, 120);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.btnEdit.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(940, 160);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 30);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 636);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dataGridViewOrderItems);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStripMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DashboardForm";
            this.Text = "Bar Management System";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonMaster;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCategoryMaster;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTableMaster;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemItemMaster;
        private System.Windows.Forms.ToolStripButton toolStripButtonLogout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewOrderItems;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewComboBoxColumn SelectedType;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}