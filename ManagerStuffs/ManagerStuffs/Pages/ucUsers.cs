using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagerStuffs.Constants.Roles;
using ManagerStuffs.Bll.Users;
using MetroFramework;
using ManagerStuffs.Constants;
using ManagerStuffs.Constants.Languages;

namespace ManagerStuffs.Pages
{
    public partial class ucUsers : UserControl
    {
        public ucUsers()
        {
            InitializeComponent();
        }
        
        // Method LoadAll
        void LoadAll()
        {
            ManipulationRoles.ListRoles(gvRoles);

            LoadUsers();

            ClickRowBindingText();

            ManipulationRoles.ListRolesForComboBox(cbbRoles);
        }

        // Method Insert
        void Insert()
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string name = txtName.Text;
            string rePassword = txtRePassword.Text;
            bool sex = cbSex.Checked;
            DateTime birthOfDate = dtBirthOfDay.Value;
            string email = txtEmail.Text;
            string phone = txtPhoneNumber.Text;
            bool status = cbStatus.Checked;
            string roleName = cbbRoles.SelectedValue.ToString();

            if(string.IsNullOrEmpty(username))
            {
                MetroMessageBox.Show(this, "Bạn chưa nhập Tên tài khoản !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                txtUsername.Focus();

                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MetroMessageBox.Show(this, "Bạn chưa nhập Mật khẩu !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                txtPassword.Focus();

                return;
            }

            if (password != rePassword)
            {
                MetroMessageBox.Show(this, "Mật khẩu nhập lại không chính xác !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                txtRePassword.Focus();

                return;
            }

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

                txtPhoneNumber.Focus();

                return;
            }

            GlobalConstants.ResponseResult res = UsersBll.Instance.Insert(username, password, name, sex, birthOfDate, email, phone, status, roleName, GlobalConstants.Username);

            switch(res.TypeResponse)
            {
                case GlobalConstants.EnumResponse.InsertSuccess:
                    LogEvent.Log = $"[{ DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")}] - [{ GlobalConstants.Username}] - thêm user [{username}]";

                    LoadUsers();

                    gvUsers.CurrentCell = gvUsers.Rows[gvUsers.RowCount - 1].Cells["Id"];

                    gvUsers.Rows[gvUsers.RowCount - 1].Selected = true;

                    ClickRowBindingText();

                    MetroMessageBox.Show(this, $"Thêm tài khoản '{username}' thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, GlobalConstants.Config.HeightAlert);
                    break;
                case GlobalConstants.EnumResponse.InsertFail:
                    MetroMessageBox.Show(this, "Có lỗi trong quá trình thêm dữ liệu, xin vui lòng thêm lại sau !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, GlobalConstants.Config.HeightAlert);
                    break;
                case GlobalConstants.EnumResponse.Unique:
                    MetroMessageBox.Show(this, "Tên tài khoản đã tồn tại. Xin vui lòng nhập tên tài khoản khác !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                    txtUsername.Focus();
                    break;
                case GlobalConstants.EnumResponse.NotExsist:
                    MetroMessageBox.Show(this, "Quyền này không tồn tại. Xin vui lòng chọn quyền khác !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                    cbbRoles.Focus();
                    break;
            }
        }

        // Method Delete
        void Delete()
        {
            if(gvUsers.SelectedRows.Count > 0)
            {
                string username = gvUsers["Username", gvUsers.SelectedRows[0].Index].Value.ToString();

                DialogResult dialog = MetroMessageBox.Show(this, $"Bạn chắc chắn muốn xóa tài khoản '{username}' !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, GlobalConstants.Config.HeightAlert);

                if (dialog == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(gvUsers["Id", gvUsers.SelectedRows[0].Index].Value.ToString());

                    GlobalConstants.ResponseResult res = UsersBll.Instance.Delete(id, username, GlobalConstants.Username);

                    switch(res.TypeResponse)
                    {
                        case GlobalConstants.EnumResponse.DeleteSuccess:
                            LogEvent.Log = $"[{ DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")}] - [{ GlobalConstants.Username}] - xóa user [{username}]";

                            LoadUsers();

                            if(gvUsers.RowCount > 0)
                            {
                                gvUsers.CurrentCell = gvUsers.Rows[gvUsers.RowCount - 1].Cells["Id"];

                                gvUsers.Rows[gvUsers.RowCount - 1].Selected = true;
                            }
                            
                            ClickRowBindingText();

                            MetroMessageBox.Show(this, $"Xóa tài khoản '{username}' thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, GlobalConstants.Config.HeightAlert);
                            break;
                        case GlobalConstants.EnumResponse.DeleteFail:
                            MetroMessageBox.Show(this, "Có lỗi trong quá trình xóa dữ liệu, xin vui lòng thêm lại sau !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, GlobalConstants.Config.HeightAlert);
                            break;
                    }
                }
            }
            else
            {
                MetroMessageBox.Show(this, "Bạn chưa chọn tài khoản cần xóa !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                gvUsers.Focus();
            }
        }

        // Method Edit
        void Edit()
        {
            if(gvUsers.SelectedRows.Count > 0)
            {
                string usernameNew = txtUsername.Text;
                string password = txtPassword.Text;
                string name = txtName.Text;
                string rePassword = txtRePassword.Text;
                bool sex = cbSex.Checked;
                DateTime birthOfDate = dtBirthOfDay.Value;
                string email = txtEmail.Text;
                string phone = txtPhoneNumber.Text;
                bool status = cbStatus.Checked;
                string roleName = cbbRoles.SelectedValue.ToString();

                int id = Convert.ToInt32(gvUsers["Id", gvUsers.SelectedRows[0].Index].Value.ToString());
                string usernameOld = gvUsers["Username", gvUsers.SelectedRows[0].Index].Value.ToString();

                if (string.IsNullOrEmpty(usernameNew))
                {
                    MetroMessageBox.Show(this, "Bạn chưa nhập Tên tài khoản !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                    txtUsername.Focus();

                    return;
                }

                if (string.IsNullOrEmpty(password))
                {
                    MetroMessageBox.Show(this, "Bạn chưa nhập Mật khẩu !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                    txtPassword.Focus();

                    return;
                }

                if (password != rePassword)
                {
                    MetroMessageBox.Show(this, "Mật khẩu nhập lại không chính xác !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                    txtRePassword.Focus();

                    return;
                }

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

                    txtPhoneNumber.Focus();

                    return;
                }

                GlobalConstants.ResponseResult res = UsersBll.Instance.Edit(id, usernameNew, password, name, sex, birthOfDate, email, phone, status, roleName, GlobalConstants.Username);

                switch (res.TypeResponse)
                {
                    case GlobalConstants.EnumResponse.EditSuccess:
                        LogEvent.Log = $"[{ DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")}] - [{ GlobalConstants.Username}] - sửa user [{usernameOld}] thành [{usernameNew}]";

                        int indexRow = gvUsers.SelectedRows[0].Index;

                        LoadUsers();

                        gvUsers.CurrentCell = gvUsers.Rows[indexRow].Cells["Id"];

                        gvUsers.Rows[indexRow].Selected = true;

                        ClickRowBindingText();

                        MetroMessageBox.Show(this, $"Sửa tài khoản '{usernameNew}' thành '{usernameOld}' thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, GlobalConstants.Config.HeightAlert);
                        break;
                    case GlobalConstants.EnumResponse.EditFail:
                        MetroMessageBox.Show(this, "Có lỗi trong quá trình sửa dữ liệu, xin vui lòng thêm lại sau !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, GlobalConstants.Config.HeightAlert);
                        break;
                    case GlobalConstants.EnumResponse.Unique:
                        MetroMessageBox.Show(this, "Tên tài khoản đã tồn tại. Xin vui lòng nhập tên tài khoản khác !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                        txtUsername.Focus();
                        break;
                    case GlobalConstants.EnumResponse.NotExsist:
                        MetroMessageBox.Show(this, "Quyền này không tồn tại. Xin vui lòng chọn quyền khác !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                        cbbRoles.Focus();
                        break;
                }
            }
            else
            {
                MetroMessageBox.Show(this, "Bạn chưa chọn tài khoản cần sửa !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                gvUsers.Focus();
            }
        }

        // Method ClickRowBindingText
        void ClickRowBindingText()
        {
            if(gvUsers.SelectedRows.Count > 0)
            {
                DataGridViewRow row = gvUsers.SelectedRows[0];

                txtUsername.Text = row.Cells["Username"].Value.ToString();
                txtName.Text = row.Cells["Name"].Value.ToString();
                cbSex.Checked = Convert.ToBoolean(row.Cells["Sex"].Value.ToString());
                dtBirthOfDay.Value = Convert.ToDateTime(row.Cells["BirthOfDate"].Value.ToString());
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtPhoneNumber.Text = row.Cells["PhoneNumber"].Value.ToString();
                cbStatus.Checked = Convert.ToBoolean(row.Cells["Status"].Value.ToString());

                cbbRoles.SelectedIndex = cbbRoles.Items.IndexOf(row.Cells["RoleName"].Value.ToString());
            }
        }

        // Method LoadUsers
        void LoadUsers()
        {
            if(gvRoles.SelectedRows.Count > 0)
            {
                string roleName = gvRoles["RoleName", gvRoles.SelectedRows[0].Index].Value.ToString();

                UsersBll.Instance.GetUsersByRoleName(gvUsers, roleName, GlobalConstants.Username);
            }
        }

        // Event Load Form
        private void ucUsers_Load(object sender, EventArgs e)
        {
            tableLayoutPanel4.SetStranlatesForTableLayout();
            tableLayoutPanel3.SetStranlatesForTableLayout();

            cbStatus.SetStranlateForControlSingle();
            cbSex.SetStranlateForControlSingle();

            LoadAll();

            txtUsername.Focus();
        }

        // Event Click Button Insert
        private void btnInsertUser_Click(object sender, EventArgs e)
        {
            Insert();
        }

        // Event Click Row GridView Users
        private void gvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClickRowBindingText();
        }

        // Event Click Button Delete
        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            Delete();
        }

        // Event Click Button Edit
        private void btnEditUser_Click(object sender, EventArgs e)
        {
            Edit();
        }
    }
}
