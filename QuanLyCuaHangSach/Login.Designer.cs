namespace QuanLyCuaHangSach
{
    partial class Login
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
            this.label1 = new System.Windows.Forms.Label();
            this.txbUser = new System.Windows.Forms.TextBox();
            this.tbnLogin = new System.Windows.Forms.Button();
            this.tbnExit = new System.Windows.Forms.Button();
            this.txbPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 95);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "User";
            // 
            // txbUser
            // 
            this.txbUser.Location = new System.Drawing.Point(251, 91);
            this.txbUser.Margin = new System.Windows.Forms.Padding(4);
            this.txbUser.Name = "txbUser";
            this.txbUser.Size = new System.Drawing.Size(244, 22);
            this.txbUser.TabIndex = 1;
            // 
            // tbnLogin
            // 
            this.tbnLogin.Location = new System.Drawing.Point(121, 234);
            this.tbnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.tbnLogin.Name = "tbnLogin";
            this.tbnLogin.Size = new System.Drawing.Size(100, 28);
            this.tbnLogin.TabIndex = 2;
            this.tbnLogin.Text = "Login";
            this.tbnLogin.UseVisualStyleBackColor = true;
            this.tbnLogin.Click += new System.EventHandler(this.tbnLogin_Click);
            // 
            // tbnExit
            // 
            this.tbnExit.Location = new System.Drawing.Point(396, 234);
            this.tbnExit.Margin = new System.Windows.Forms.Padding(4);
            this.tbnExit.Name = "tbnExit";
            this.tbnExit.Size = new System.Drawing.Size(100, 28);
            this.tbnExit.TabIndex = 3;
            this.tbnExit.Text = "Exit";
            this.tbnExit.UseVisualStyleBackColor = true;
            this.tbnExit.Click += new System.EventHandler(this.tbnExit_Click);
            // 
            // txbPass
            // 
            this.txbPass.Location = new System.Drawing.Point(251, 156);
            this.txbPass.Margin = new System.Windows.Forms.Padding(4);
            this.txbPass.Name = "txbPass";
            this.txbPass.PasswordChar = '*';
            this.txbPass.Size = new System.Drawing.Size(244, 22);
            this.txbPass.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(117, 160);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 319);
            this.Controls.Add(this.txbPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbnExit);
            this.Controls.Add(this.tbnLogin);
            this.Controls.Add(this.txbUser);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbUser;
        private System.Windows.Forms.Button tbnLogin;
        private System.Windows.Forms.Button tbnExit;
        private System.Windows.Forms.TextBox txbPass;
        private System.Windows.Forms.Label label2;
    }
}