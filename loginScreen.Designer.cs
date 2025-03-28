namespace ValScoresCore
{
    partial class loginScreen
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
            txtUsername = new TextBox();
            btnLogin = new Button();
            btnForgotPassword = new Button();
            txtPassword = new TextBox();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(197, 54, 65);
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.ForeColor = Color.White;
            txtUsername.Location = new Point(252, 254);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(131, 22);
            txtUsername.TabIndex = 0;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Transparent;
            btnLogin.BackgroundImageLayout = ImageLayout.None;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.ForeColor = Color.FromArgb(33, 16, 59);
            btnLogin.Location = new Point(170, 399);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(91, 56);
            btnLogin.TabIndex = 2;
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnForgotPassword
            // 
            btnForgotPassword.BackColor = Color.Transparent;
            btnForgotPassword.BackgroundImageLayout = ImageLayout.None;
            btnForgotPassword.FlatStyle = FlatStyle.Flat;
            btnForgotPassword.ForeColor = Color.FromArgb(33, 16, 59);
            btnForgotPassword.Location = new Point(128, 482);
            btnForgotPassword.Name = "btnForgotPassword";
            btnForgotPassword.Size = new Size(185, 31);
            btnForgotPassword.TabIndex = 3;
            btnForgotPassword.UseVisualStyleBackColor = false;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(197, 54, 65);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.ForeColor = Color.White;
            txtPassword.Location = new Point(252, 320);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(131, 22);
            txtPassword.TabIndex = 1;
            // 
            // loginScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.loginBackground;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(996, 629);
            Controls.Add(txtPassword);
            Controls.Add(btnForgotPassword);
            Controls.Add(btnLogin);
            Controls.Add(txtUsername);
            DoubleBuffered = true;
            Name = "loginScreen";
            Text = "Login";
            KeyDown += loginScreen_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUsername;
        private Button btnLogin;
        private Button btnForgotPassword;
        private TextBox txtPassword;
    }
}