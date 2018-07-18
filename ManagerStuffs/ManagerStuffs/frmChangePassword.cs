using ManagerStuffs.Bll.Users;
using ManagerStuffs.Constants;
using ManagerStuffs.Constants.Languages;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerStuffs
{
    public partial class frmChangePassword : MetroForm
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }

        // Method ChangePassword
        void ChangePassword()
        {
            string passwordOld = txtPasswordOld.Text;
            string passwordNew = txtPasswordNew.Text;
            string rePasswordNew = txtRePasswordNew.Text;

            if(string.IsNullOrEmpty(passwordOld))
            {
                MetroMessageBox.Show(this, "Bạn chưa nhập Mật khẩu cũ !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                txtPasswordOld.Focus();

                return;
            }

            if (string.IsNullOrEmpty(passwordNew))
            {
                MetroMessageBox.Show(this, "Bạn chưa nhập Mật khẩu mới !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                txtPasswordNew.Focus();

                return;
            }

            if (passwordNew != rePasswordNew)
            {
                MetroMessageBox.Show(this, "Mật khẩu nhập lại không trùng mật khẩu mới !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                txtRePasswordNew.Focus();

                return;
            }

            GlobalConstants.ResponseResult res = UsersBll.Instance.ChangePassword(GlobalConstants.Username, passwordOld, passwordNew);

            switch(res.TypeResponse)
            {
                case GlobalConstants.EnumResponse.EditSuccess:
                    MetroMessageBox.Show(this, "Thay đổi mật khẩu thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, GlobalConstants.Config.HeightAlert);
                    this.Close();
                    break;
                case GlobalConstants.EnumResponse.EditFail:
                    MetroMessageBox.Show(this, "Có lỗi trong quá trình thay đổi dữ liệu, xin vui lòng thử lại sau !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, GlobalConstants.Config.HeightAlert);
                    break;
                case GlobalConstants.EnumResponse.NotMatch:
                    MetroMessageBox.Show(this, "Mật khẩu cũ không đúng !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                    txtPasswordOld.Focus();
                    break;
                case GlobalConstants.EnumResponse.NotExsist:
                    MetroMessageBox.Show(this, "Tài khoản hiện tại không tìm thấy hoặc không tồn tại !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, GlobalConstants.Config.HeightAlert);
                    break;
            }
        }

        // Event Click Button ChangePassword
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePassword();
        }

        // Event Load Form
        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.SetStranlatesForTableLayout();

            this.SetStranlatesTitleForm();

            lbDisplayUsername.Text = GlobalConstants.Username;

            txtPasswordOld.Focus();
        }
    }
}
