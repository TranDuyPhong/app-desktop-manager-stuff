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
    public partial class frmChangeProfile : MetroForm
    {
        public frmChangeProfile(frmSystem frmSystem)
        {
            InitializeComponent();

            this.frmSystem = frmSystem;
        }

        private frmSystem frmSystem;

        // Method ChangeProfile
        void ChangeProfile()
        {
            string name = txtName.Text.Trim();
            bool sex = cbSex.Checked;
            DateTime birthOfDate = dtBirthOfDate.Value;
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MetroMessageBox.Show(this, "Bạn chưa nhập Tên !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                txtName.Focus();

                return;
            }

            if (string.IsNullOrEmpty(email))
            {
                MetroMessageBox.Show(this, "Bạn chưa nhập địa chỉ Email !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                txtEmail.Focus();

                return;
            }

            if (string.IsNullOrEmpty(phone))
            {
                MetroMessageBox.Show(this, "Bạn chưa nhập Số điện thoại !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                txtPhone.Focus();

                return;
            }

            GlobalConstants.ResponseResult res = UsersBll.Instance.ChangeProfile(GlobalConstants.Username, name, sex, birthOfDate, email, phone);

            switch(res.TypeResponse)
            {
                case GlobalConstants.EnumResponse.EditSuccess:
                    MetroMessageBox.Show(this, "Thay đổi thông tin thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, GlobalConstants.Config.HeightAlert);

                    frmSystem.lbUser.Text = name;

                    this.Close();
                    break;
                case GlobalConstants.EnumResponse.EditFail:
                    MetroMessageBox.Show(this, "Có lỗi trong quá trình thay đổi dữ liệu, xin vui lòng thử lại sau !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, GlobalConstants.Config.HeightAlert);
                    break;
                case GlobalConstants.EnumResponse.NotExsist:
                    MetroMessageBox.Show(this, "Tài khoản hiện tại không tìm thấy hoặc không tồn tại !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, GlobalConstants.Config.HeightAlert);
                    break;
            }
        }

        // Event Click Button ChangeProfile
        private void btnChangeProfile_Click(object sender, EventArgs e)
        {
            ChangeProfile();
        }

        // Event Load Form 
        private void frmChangeProfile_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.SetStranlatesForTableLayout();

            this.SetStranlatesTitleForm();
        }
    }
}
