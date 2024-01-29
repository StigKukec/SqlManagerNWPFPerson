namespace SqlViewer.View
{
    partial class LoginForm
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
            tbServer = new TextBox();
            lblServer = new Label();
            btnLogin = new Button();
            lblUsername = new Label();
            tbUsername = new TextBox();
            lblPassword = new Label();
            tbPassword = new TextBox();
            lblWrongCredentials = new Label();
            SuspendLayout();
            // 
            // tbServer
            // 
            tbServer.Location = new Point(130, 26);
            tbServer.Name = "tbServer";
            tbServer.Size = new Size(501, 23);
            tbServer.TabIndex = 0;
            // 
            // lblServer
            // 
            lblServer.AutoSize = true;
            lblServer.Location = new Point(40, 29);
            lblServer.Name = "lblServer";
            lblServer.Size = new Size(42, 15);
            lblServer.TabIndex = 1;
            lblServer.Text = "Server:";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(40, 190);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(591, 34);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Log in";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += BtnLogin_Click;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(40, 83);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(63, 15);
            lblUsername.TabIndex = 4;
            lblUsername.Text = "Username:";
            // 
            // tbUsername
            // 
            tbUsername.Location = new Point(130, 80);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(501, 23);
            tbUsername.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(40, 136);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(60, 15);
            lblPassword.TabIndex = 6;
            lblPassword.Text = "Password:";
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(130, 133);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(501, 23);
            tbPassword.TabIndex = 5;
            tbPassword.UseSystemPasswordChar = true;
            // 
            // lblWrongCredentials
            // 
            lblWrongCredentials.AutoSize = true;
            lblWrongCredentials.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblWrongCredentials.ForeColor = Color.Red;
            lblWrongCredentials.Location = new Point(275, 248);
            lblWrongCredentials.Name = "lblWrongCredentials";
            lblWrongCredentials.Size = new Size(108, 15);
            lblWrongCredentials.TabIndex = 7;
            lblWrongCredentials.Text = "Wrong credentials!";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(688, 293);
            Controls.Add(lblWrongCredentials);
            Controls.Add(lblPassword);
            Controls.Add(tbPassword);
            Controls.Add(lblUsername);
            Controls.Add(tbUsername);
            Controls.Add(btnLogin);
            Controls.Add(lblServer);
            Controls.Add(tbServer);
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbServer;
        private Label lblServer;
        private Button btnLogin;
        private Label lblUsername;
        private TextBox tbUsername;
        private Label lblPassword;
        private TextBox tbPassword;
        private Label lblWrongCredentials;
    }
}