namespace BarManagementSystem
{
    partial class LoginForm
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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblWelcome
            this.lblWelcome.Location = new System.Drawing.Point(50, 30);
            this.lblWelcome.Size = new System.Drawing.Size(300, 40);
            this.lblWelcome.Text = "Welcome to Bar Management System";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWelcome.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.DarkBlue;

            // lblPassword
            this.lblPassword.Location = new System.Drawing.Point(50, 100);
            this.lblPassword.Size = new System.Drawing.Size(100, 23);
            this.lblPassword.Text = "Password:";
            this.lblPassword.Font = new System.Drawing.Font("Arial", 10F);

            // txtPassword
            this.txtPassword.Location = new System.Drawing.Point(150, 100);
            this.txtPassword.Size = new System.Drawing.Size(150, 23);
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Font = new System.Drawing.Font("Arial", 10F);

            // btnLogin
            this.btnLogin.Location = new System.Drawing.Point(150, 150);
            this.btnLogin.Size = new System.Drawing.Size(100, 30);
            this.btnLogin.Text = "Login";
            this.btnLogin.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogin.BackColor = System.Drawing.Color.DarkGreen;
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // LoginForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Text = "Login";
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLogin);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
    }
}