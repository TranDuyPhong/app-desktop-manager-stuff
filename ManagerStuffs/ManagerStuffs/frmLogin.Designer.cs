namespace ManagerStuffs
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbLanguage = new MetroFramework.Drawing.Html.HtmlLabel();
            this.btnExit = new MetroFramework.Controls.MetroButton();
            this.btnLogin = new MetroFramework.Controls.MetroButton();
            this.txtPassword = new MetroFramework.Controls.MetroTextBox();
            this.txtUsername = new MetroFramework.Controls.MetroTextBox();
            this.lbPassword = new MetroFramework.Drawing.Html.HtmlLabel();
            this.lbUsername = new MetroFramework.Drawing.Html.HtmlLabel();
            this.cbRememberMe = new MetroFramework.Controls.MetroCheckBox();
            this.cbbLanguages = new MetroFramework.Controls.MetroComboBox();
            this.pbStuffs = new System.Windows.Forms.PictureBox();
            this.ttUsername = new MetroFramework.Components.MetroToolTip();
            this.ttPassword = new MetroFramework.Components.MetroToolTip();
            this.ttImageStuffs = new MetroFramework.Components.MetroToolTip();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStuffs)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lbLanguage, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnExit, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.btnLogin, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtPassword, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtUsername, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbPassword, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbUsername, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbRememberMe, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.cbbLanguages, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(11, 186);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(270, 291);
            this.tableLayoutPanel1.TabIndex = 100;
            // 
            // lbLanguage
            // 
            this.lbLanguage.AutoScrollMinSize = new System.Drawing.Size(64, 23);
            this.lbLanguage.AutoSize = false;
            this.lbLanguage.BackColor = System.Drawing.Color.White;
            this.lbLanguage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLanguage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(65)))), ((int)(((byte)(114)))));
            this.lbLanguage.Location = new System.Drawing.Point(3, 3);
            this.lbLanguage.Name = "lbLanguage";
            this.lbLanguage.Size = new System.Drawing.Size(264, 24);
            this.lbLanguage.TabIndex = 105;
            this.lbLanguage.TabStop = false;
            this.lbLanguage.Text = "<b>Ngôn ngữ</b>";
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExit.Location = new System.Drawing.Point(3, 253);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(264, 29);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseSelectable = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogin.Location = new System.Drawing.Point(3, 218);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(264, 29);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseSelectable = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtPassword.CustomButton.Image = null;
            this.txtPassword.CustomButton.Location = new System.Drawing.Point(242, 2);
            this.txtPassword.CustomButton.Name = "";
            this.txtPassword.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.txtPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPassword.CustomButton.TabIndex = 1;
            this.txtPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPassword.CustomButton.UseSelectable = true;
            this.txtPassword.CustomButton.Visible = false;
            this.txtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPassword.Lines = new string[0];
            this.txtPassword.Location = new System.Drawing.Point(3, 158);
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.ShortcutsEnabled = true;
            this.txtPassword.Size = new System.Drawing.Size(264, 24);
            this.txtPassword.TabIndex = 1;
            this.ttPassword.SetToolTip(this.txtPassword, resources.GetString("txtPassword.ToolTip"));
            this.txtPassword.UseSelectable = true;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtUsername.CustomButton.Image = null;
            this.txtUsername.CustomButton.Location = new System.Drawing.Point(242, 2);
            this.txtUsername.CustomButton.Name = "";
            this.txtUsername.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.txtUsername.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtUsername.CustomButton.TabIndex = 1;
            this.txtUsername.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtUsername.CustomButton.UseSelectable = true;
            this.txtUsername.CustomButton.Visible = false;
            this.txtUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUsername.Lines = new string[0];
            this.txtUsername.Location = new System.Drawing.Point(3, 98);
            this.txtUsername.MaxLength = 32767;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PasswordChar = '\0';
            this.txtUsername.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUsername.SelectedText = "";
            this.txtUsername.SelectionLength = 0;
            this.txtUsername.SelectionStart = 0;
            this.txtUsername.ShortcutsEnabled = true;
            this.txtUsername.Size = new System.Drawing.Size(264, 24);
            this.txtUsername.TabIndex = 0;
            this.ttUsername.SetToolTip(this.txtUsername, resources.GetString("txtUsername.ToolTip"));
            this.txtUsername.UseSelectable = true;
            this.txtUsername.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtUsername.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lbPassword
            // 
            this.lbPassword.AutoScrollMinSize = new System.Drawing.Size(62, 23);
            this.lbPassword.AutoSize = false;
            this.lbPassword.BackColor = System.Drawing.Color.White;
            this.lbPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(65)))), ((int)(((byte)(114)))));
            this.lbPassword.Location = new System.Drawing.Point(3, 128);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(264, 24);
            this.lbPassword.TabIndex = 103;
            this.lbPassword.TabStop = false;
            this.lbPassword.Text = "<b>Mật khẩu</b>";
            // 
            // lbUsername
            // 
            this.lbUsername.AutoScrollMinSize = new System.Drawing.Size(86, 23);
            this.lbUsername.AutoSize = false;
            this.lbUsername.BackColor = System.Drawing.Color.White;
            this.lbUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(65)))), ((int)(((byte)(114)))));
            this.lbUsername.Location = new System.Drawing.Point(3, 68);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(264, 24);
            this.lbUsername.TabIndex = 102;
            this.lbUsername.TabStop = false;
            this.lbUsername.Text = "<b>Tên tài khoản</b>";
            // 
            // cbRememberMe
            // 
            this.cbRememberMe.AutoSize = true;
            this.cbRememberMe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbRememberMe.Location = new System.Drawing.Point(3, 188);
            this.cbRememberMe.Name = "cbRememberMe";
            this.cbRememberMe.Size = new System.Drawing.Size(264, 24);
            this.cbRememberMe.TabIndex = 104;
            this.cbRememberMe.Text = "Ghi nhớ tài khoản ?";
            this.cbRememberMe.UseSelectable = true;
            // 
            // cbbLanguages
            // 
            this.cbbLanguages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbbLanguages.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(65)))), ((int)(((byte)(114)))));
            this.cbbLanguages.FormattingEnabled = true;
            this.cbbLanguages.ItemHeight = 23;
            this.cbbLanguages.Location = new System.Drawing.Point(3, 33);
            this.cbbLanguages.Name = "cbbLanguages";
            this.cbbLanguages.Size = new System.Drawing.Size(264, 29);
            this.cbbLanguages.TabIndex = 106;
            this.cbbLanguages.UseSelectable = true;
            this.cbbLanguages.SelectedIndexChanged += new System.EventHandler(this.cbbLanguages_SelectedIndexChanged);
            // 
            // pbStuffs
            // 
            this.pbStuffs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbStuffs.Image = ((System.Drawing.Image)(resources.GetObject("pbStuffs.Image")));
            this.pbStuffs.Location = new System.Drawing.Point(76, 12);
            this.pbStuffs.Name = "pbStuffs";
            this.pbStuffs.Size = new System.Drawing.Size(128, 128);
            this.pbStuffs.TabIndex = 101;
            this.pbStuffs.TabStop = false;
            this.ttImageStuffs.SetToolTip(this.pbStuffs, "Phần mềm quản lí vật tự Stuffs\r\nClick vào để truy cập website stuffs.com.vn để bi" +
        "ết thêm thông tin\r\n");
            this.pbStuffs.Click += new System.EventHandler(this.pbStuffs_Click);
            // 
            // ttUsername
            // 
            this.ttUsername.Style = MetroFramework.MetroColorStyle.Default;
            this.ttUsername.StyleManager = null;
            this.ttUsername.Theme = MetroFramework.MetroThemeStyle.Default;
            // 
            // ttPassword
            // 
            this.ttPassword.Style = MetroFramework.MetroColorStyle.Default;
            this.ttPassword.StyleManager = null;
            this.ttPassword.Theme = MetroFramework.MetroThemeStyle.Default;
            // 
            // ttImageStuffs
            // 
            this.ttImageStuffs.Style = MetroFramework.MetroColorStyle.Default;
            this.ttImageStuffs.StyleManager = null;
            this.ttImageStuffs.Theme = MetroFramework.MetroThemeStyle.Default;
            // 
            // frmLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(292, 490);
            this.Controls.Add(this.pbStuffs);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DisplayHeader = false;
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(65)))), ((int)(((byte)(114)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "Đăng nhập";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLogin_FormClosing);
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStuffs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pbStuffs;
        private MetroFramework.Drawing.Html.HtmlLabel lbUsername;
        private MetroFramework.Drawing.Html.HtmlLabel lbPassword;
        private MetroFramework.Controls.MetroTextBox txtUsername;
        private MetroFramework.Controls.MetroTextBox txtPassword;
        private MetroFramework.Controls.MetroButton btnLogin;
        private MetroFramework.Controls.MetroButton btnExit;
        private MetroFramework.Controls.MetroCheckBox cbRememberMe;
        private MetroFramework.Components.MetroToolTip ttUsername;
        private MetroFramework.Components.MetroToolTip ttPassword;
        private MetroFramework.Components.MetroToolTip ttImageStuffs;
        private MetroFramework.Drawing.Html.HtmlLabel lbLanguage;
        private MetroFramework.Controls.MetroComboBox cbbLanguages;
    }
}

