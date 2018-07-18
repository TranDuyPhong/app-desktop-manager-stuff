using DevExpress.XtraEditors;
using ManagerStuffs.Bll.Users;
using ManagerStuffs.Constants;
using ManagerStuffs.Constants.Languages;
using ManagerStuffs.Constants.Roles;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerStuffs
{
    public partial class frmLogin : MetroForm
    {
        private bool isExit;

        public frmLogin()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
        }

        // Method Exit Application
        void ExitApp(FormClosingEventArgs e = null)
        {
            if(!isExit)
            {
                DialogResult exit = MetroMessageBox.Show(this, "Bạn có chắc chắn muốn thoát ?", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, GlobalConstants.Config.HeightAlert);

                if(e != null)
                {
                    e.Cancel = exit != DialogResult.Yes;
                }

                if(exit == DialogResult.Yes)
                {
                    isExit = true;

                    Application.Exit();
                }
            }
        }

        // Event Click Button Login
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim().ToLower();
            string password = txtPassword.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(username))
            {
                MetroMessageBox.Show(this, "Bạn chưa nhập Tên tài khoản !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                txtUsername.Focus();

                return;
            }

            if(string.IsNullOrEmpty(password))
            {
                MetroMessageBox.Show(this, "Bạn chưa nhập Mật khẩu !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                txtPassword.Focus();

                return;
            }

            GlobalConstants.ResponseResult res = UsersBll.Instance.Login(username, password);

            switch(res.TypeResponse)
            {
                case GlobalConstants.EnumResponse.LoginSuccess:
                    dynamic dys = res.Result.HashObjectToDic();

                    if(GlobalConstants.RoleName != ManipulationRoles.Admin)
                    {
                        List<ManipulationRoleModel> roles = ManipulationRoles.GetRolesByRole(dys["ROLENAME"].ToString());

                        if (roles.Count == 0)
                        {
                            MetroMessageBox.Show(this, "Bạn không được phép sử dụng hệ thống vì hiện tại bạn không có quyền !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error, GlobalConstants.Config.HeightAlert);

                            return;
                        }
                    }

                    MetroMessageBox.Show(this, $"Xin chào '{dys["NAME"].ToString()}', chúc một ngày thành công !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Information, GlobalConstants.Config.HeightAlert);

                    txtPassword.ResetText();

                    frmSystem sys = new frmSystem();

                    sys.NameOfUser = dys["NAME"].ToString();

                    this.Hide();

                    try
                    {
                        sys.ShowDialog();
                    }
                    catch { }

                    cbRememberMe.Checked = GlobalConstants.Config.RememberMe;

                    sys = null;

                    this.Show();

                    txtPassword.Focus();

                    break;
                case GlobalConstants.EnumResponse.BlockUser:
                    MetroMessageBox.Show(this, "Tài khoản của bạn đang bị khóa, xin vui lòng thử lại sau !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);
                    break;
                case GlobalConstants.EnumResponse.LoginFail:
                    MetroMessageBox.Show(this, "Sai Tên tài khoản hoặc mật khẩu !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error, GlobalConstants.Config.HeightAlert);
                    break;
            }
        }
        
        // Event Click Button Exit
        private void btnExit_Click(object sender, EventArgs e)
        {
            ExitApp();
        }

        // Event FormClosing
        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExitApp(e);
        }

        // Select All Text When Tab, Focus TextBox
        private void txt_Enter(object sender, EventArgs e)
        {
            TextEdit tb = sender as TextEdit;

            if(tb != null)
            {
                tb.SelectAll();
            }
        }
   
        // Event Load Form
        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (GlobalConstants.Config.RememberMe)
            {
                txtUsername.Text = GlobalConstants.Config.UsernameRemember;
                cbRememberMe.Checked = GlobalConstants.Config.RememberMe;

                txtPassword.TabIndex = 0;
            }

            LanguageManipulation.ListLanguages(cbbLanguages);
        }

        // Open Web Url From Winform When Click Picture
        private void pbStuffs_Click(object sender, EventArgs e)
        {
            ProcessStartInfo urlWeb = new ProcessStartInfo("https://www.facebook.com/tran.duyphong.12");

            Process.Start(urlWeb);
        }

        // Event Select ComboBox Language
        private void cbbLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            LanguageManipulation.GetStranlatesByStandFor(cbbLanguages.SelectedValue.ToString());

            tableLayoutPanel1.SetStranlatesForTableLayout();
        }
    }
}
