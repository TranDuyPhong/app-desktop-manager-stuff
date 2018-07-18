using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagerStuffs.Bll.CategoriesBll;
using ManagerStuffs.Bll.StuffsBll;
using ManagerStuffs.Constants;
using MetroFramework;
using MetroFramework.Controls;
using static System.Windows.Forms.CheckedListBox;
using ManagerStuffs.Constants.Roles;
using ManagerStuffs.Constants.Languages;

namespace ManagerStuffs.Pages
{
    public partial class ucStuffs : UserControl
    {
        private int totalCountNumber;
        private int countStuffs;
        private string idCategory = "0";

        public ucStuffs()
        {
            InitializeComponent();
        }

        // void EditStuff
        void EditStuff()
        {
            if(gvStuffs.SelectedRows.Count > 0)
            {
                string stuffName = txtNameStuffs.Text.Trim();
                string bqCode = txtBQCode.Text.Trim();
                string producer = txtProducer.Text.Trim();
                string color = txtColor.Text.Trim();
                string state = txtState.Text.Trim();
                string price = txtPriceBuy.Text.Trim();
                string warranty = txtWarranty.Text.Trim();;
                string idCategory = cbbIdCategories.SelectedValue.ToString();
                bool status = cbStatus.Checked;
                DateTime dateBuy = dtDateBuy.Value;
                DateTime dateUse = dtDateUse.Value;
                DateTime yearRelease = dtYearRelease.Value;

                if (string.IsNullOrEmpty(stuffName))
                {
                    MetroMessageBox.Show(this, "Bạn chưa nhập Tên vật tư !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                    txtNameStuffs.Focus();

                    return;
                }

                if (string.IsNullOrEmpty(bqCode))
                {
                    MetroMessageBox.Show(this, "Bạn chưa nhập Code !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                    txtBQCode.Focus();

                    return;
                }

                if (string.IsNullOrEmpty(producer))
                {
                    MetroMessageBox.Show(this, "Bạn chưa nhập Tên nhà sản xuất !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                    txtProducer.Focus();

                    return;
                }

                if (string.IsNullOrEmpty(color))
                {
                    MetroMessageBox.Show(this, "Bạn chưa nhập Màu cho vật tư !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                    txtColor.Focus();

                    return;
                }

                if (string.IsNullOrEmpty(state))
                {
                    MetroMessageBox.Show(this, "Bạn chưa nhập Trạng thái vật tư !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                    txtState.Focus();

                    return;
                }

                if (string.IsNullOrEmpty(price))
                {
                    MetroMessageBox.Show(this, "Bạn chưa nhập Giá vật tư !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                    txtPriceBuy.Focus();

                    return;
                }

                if (string.IsNullOrEmpty(warranty))
                {
                    MetroMessageBox.Show(this, "Bạn chưa nhập Thời gian bảo hành !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                    txtWarranty.Focus();

                    return;
                }

                if (dateBuy > DateTime.Now)
                {
                    MetroMessageBox.Show(this, "Thời gian mua phải nhỏ hơn hoặc bằng thời gian hiện tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                    dtDateBuy.Focus();

                    return;
                }

                if (dateUse > DateTime.Now)
                {
                    MetroMessageBox.Show(this, "Thời gian sử dụng phải nhỏ hơn hoặc bằng thời gian hiện tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                    dtDateUse.Focus();

                    return;
                }

                if (yearRelease > DateTime.Now)
                {
                    MetroMessageBox.Show(this, "Thời gian bảo hành phải nhỏ hơn hoặc bằng thời gian hiện tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                    dtYearRelease.Focus();

                    return;
                }

                DataGridViewRow row = gvStuffs.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();

                int id = Convert.ToInt32(gvStuffs["Id", row.Index].Value.ToString());

                string nameStuffOld = gvStuffs["Name", row.Index].Value.ToString();

                string nameStuffNew = txtNameStuffs.Text.Trim();

                DialogResult dialog = MetroMessageBox.Show(this, $"Bạn có chắc chắn muốn sửa vật tự '{nameStuffOld}' thành '{nameStuffNew}' chứ ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, GlobalConstants.Config.HeightAlert);

                if(dialog == DialogResult.Yes)
                {
                    GlobalConstants.ResponseResult res = StuffsBll.Instance.Edit(
                        id,
                        bqCode,
                        stuffName,
                        producer,
                        dateBuy,
                        dateUse,
                        yearRelease,
                        color,
                        state,
                        Convert.ToDecimal(price),
                        warranty,
                        status,
                        Convert.ToInt32(idCategory),
                        GlobalConstants.Username
                    );

                    switch(res.TypeResponse)
                    {
                        case GlobalConstants.EnumResponse.EditSuccess:
                            LogEvent.Log = $"[{DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")}] - [{GlobalConstants.Username}] - sửa vật tư [{nameStuffOld}] thành [{nameStuffNew}]";

                            MetroMessageBox.Show(this, $"Sửa vật tư '{nameStuffOld}' thành '{nameStuffNew}' thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, GlobalConstants.Config.HeightAlert);

                            row = gvStuffs.Rows.Cast<DataGridViewRow>().Where(p => p.Cells["Id"].Value.ToString().Equals(id.ToString())).FirstOrDefault();

                            if (row != null)
                            {
                                gvStuffs.CurrentCell = row.Cells["Id"];

                                row.Selected = true;

                                txtPriceBuy.Text = row.Cells["PriceBuy"].Value.ToString();
                            }
                            break;
                        case GlobalConstants.EnumResponse.EditFail:
                            MetroMessageBox.Show(this, "Có lỗi trong quá trình sửa dữ liệu, xin vui lòng thử lại sau !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, GlobalConstants.Config.HeightAlert);
                            break;
                        case GlobalConstants.EnumResponse.Unique:
                            MetroMessageBox.Show(this, $"BQCode vật tư '{bqCode}' bị trùng, xin vui lòng nhập BQCode khác !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, GlobalConstants.Config.HeightAlert);
                            txtNameStuffs.Focus();
                            break;
                    }
                }
            }
            else
            {
                MetroMessageBox.Show(this, "Bạn chưa chọn vật tư cần sửa !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);
            }

            txtNameStuffs.Focus();
        }

        // void ClickRowBindingText
        void ClickRowBindingText()
        {
            if(gvStuffs.SelectedRows.Count > 0)
            {
                DataGridViewRow row = gvStuffs.SelectedRows.Cast<DataGridViewRow>()
                                        .FirstOrDefault();

                txtNameStuffs.Text = gvStuffs["Name", row.Index].Value.ToString();
                txtBQCode.Text = gvStuffs["BQCode", row.Index].Value.ToString();
                txtProducer.Text = gvStuffs["Producer", row.Index].Value.ToString();
                dtDateBuy.Value = Convert.ToDateTime(gvStuffs["DateBuy", row.Index].Value.ToString());
                dtDateUse.Value = Convert.ToDateTime(gvStuffs["DateUse", row.Index].Value.ToString());
                dtYearRelease.Value = Convert.ToDateTime(gvStuffs["Release", row.Index].Value.ToString());
                txtColor.Text = gvStuffs["ColorStuffs", row.Index].Value.ToString();
                txtState.Text = gvStuffs["State", row.Index].Value.ToString();
                txtPriceBuy.Text = gvStuffs["PriceBuy", row.Index].Value.ToString();
                txtWarranty.Text = gvStuffs["Warranty", row.Index].Value.ToString();
                cbStatus.Checked = true;

                string categoryName = gvStuffs["Category", row.Index].Value.ToString();

                for(int i = 0; i < cbbIdCategories.Items.Count; i++)
                {
                    if(cbbIdCategories.Items[i].ToString() == categoryName)
                    {
                        cbbIdCategories.SelectedIndex = i;

                        break;
                    }
                }
            }
        }

        // void DeleteStuffs
        void DeleteStuffs()
        {
            if(gvStuffs.SelectedRows.Count > 0)
            {
                DialogResult dialog = MetroMessageBox.Show(this, "Bạn có chắc chắn muốn xóa những vật tư vừa chọn ?. Nếu đồng ý những dòng liên quan đến vật tư bị xóa đều xóa theo.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, GlobalConstants.Config.HeightAlert);

                if(dialog == DialogResult.Yes)
                {
                    int[] ids = gvStuffs.SelectedRows.Cast<DataGridViewRow>().
                                Select(p => Convert.ToInt32(p.Cells["Id"].Value.ToString())).Cast<int>().ToArray();

                    string[] names = gvStuffs.SelectedRows.Cast<DataGridViewRow>().
                                Select(p => p.Cells["Name"].Value.ToString()).Cast<string>().ToArray();

                    GlobalConstants.ResponseResult res = StuffsBll.Instance.Deletes(ids, Convert.ToInt32(idCategory));

                    switch(res.TypeResponse)
                    {
                        case GlobalConstants.EnumResponse.DeleteSuccess:
                            StringBuilder logs = new StringBuilder();

                            foreach(string name in names)
                            {
                                LogEvent.Log = $"[{DateTime.Now}] - [{GlobalConstants.Username}] xóa vật tư[{name}]";
                            }

                            MetroMessageBox.Show(this, $"Bạn đã xóa thành công '{ids.Length.ToString()}' vật tư !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, GlobalConstants.Config.HeightAlert);

                            ClearTextControl();
                            break;
                        case GlobalConstants.EnumResponse.DeleteFail: 
                            MetroMessageBox.Show(this, "Có lỗi trong quá trình xóa vật tư, xin vui lòng thử lại sau !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, GlobalConstants.Config.HeightAlert);
                            break;
                    }
                }
            }
            else
            {
                MetroMessageBox.Show(this, "Bạn chưa những chọn vật tư cần xóa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);
            }

            gvStuffs.Focus();
        }

        // void AutoSelectRowCategories
        void AutoSelectRowCategories()
        {
           if(!string.IsNullOrEmpty(idCategory))
            {
                DataGridViewRow row = gvCategories.Rows.Cast<DataGridViewRow>().Where(p => p.Cells["Id"].Value.ToString().Equals(idCategory)).FirstOrDefault();

                if (row != null)
                {
                    row.Selected = true;
                }
            }
        }

        // void InsertStuffs
        void InsertStuffs()
        {
            string stuffName = txtNameStuffs.Text.Trim();
            string bqCode = txtBQCode.Text.Trim();
            string producer = txtProducer.Text.Trim();
            string color = txtColor.Text.Trim();
            string state = txtState.Text.Trim();
            string price = txtPriceBuy.Text.Trim();
            string warranty = txtWarranty.Text.Trim();
            string idCategory = cbbIdCategories.SelectedValue.ToString();
            bool status = cbStatus.Checked;
            DateTime dateBuy = dtDateBuy.Value;
            DateTime dateUse = dtDateUse.Value;
            DateTime yearRelease = dtYearRelease.Value;

            if (string.IsNullOrEmpty(stuffName))
            {
                MetroMessageBox.Show(this, "Bạn chưa nhập Tên vật tư !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                txtNameStuffs.Focus();

                return;
            }

            if (string.IsNullOrEmpty(bqCode))
            {
                MetroMessageBox.Show(this, "Bạn chưa nhập Code !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                txtBQCode.Focus();

                return;
            }

            if (string.IsNullOrEmpty(producer))
            {
                MetroMessageBox.Show(this, "Bạn chưa nhập Tên nhà sản xuất !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                txtProducer.Focus();

                return;
            }

            if (string.IsNullOrEmpty(color))
            {
                MetroMessageBox.Show(this, "Bạn chưa nhập Màu cho vật tư !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                txtColor.Focus();

                return;
            }

            if (string.IsNullOrEmpty(state))
            {
                MetroMessageBox.Show(this, "Bạn chưa nhập Trạng thái vật tư !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                txtState.Focus();

                return;
            }

            if (string.IsNullOrEmpty(price))
            {
                MetroMessageBox.Show(this, "Bạn chưa nhập Giá vật tư !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                txtPriceBuy.Focus();

                return;
            }

            if (string.IsNullOrEmpty(warranty))
            {
                MetroMessageBox.Show(this, "Bạn chưa nhập Thời gian bảo hành !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                txtWarranty.Focus();

                return;
            }

            if(dateBuy > DateTime.Now)
            {
                MetroMessageBox.Show(this, "Thời gian mua phải nhỏ hơn hoặc bằng thời gian hiện tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                dtDateBuy.Focus();

                return;
            }

            if (dateUse > DateTime.Now)
            {
                MetroMessageBox.Show(this, "Thời gian sử dụng phải nhỏ hơn hoặc bằng thời gian hiện tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                dtDateUse.Focus();

                return;
            }

            if (yearRelease > DateTime.Now)
            {
                MetroMessageBox.Show(this, "Thời gian bảo hành phải nhỏ hơn hoặc bằng thời gian hiện tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);

                dtYearRelease.Focus();

                return;
            }

            GlobalConstants.ResponseResult res = StuffsBll.Instance.Insert(
                bqCode,
                stuffName,
                producer,
                dateBuy,
                dateUse,
                yearRelease,
                color,
                state,
                Convert.ToDecimal(price),
                warranty,
                status,
                Convert.ToInt32(idCategory),
                GlobalConstants.Username
            );

            switch (res.TypeResponse)
            {
                case GlobalConstants.EnumResponse.InsertSuccess:
                    LogEvent.Log = $"[{ DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")}] - [{ GlobalConstants.Username}] - thêm một vật tư [{stuffName}]";

                    this.idCategory = idCategory;

                    AutoSelectRowCategories();

                    MetroMessageBox.Show(this, $"Thêm vật tư '{stuffName}' thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, GlobalConstants.Config.HeightAlert);
                    break;
                case GlobalConstants.EnumResponse.InsertFail:
                    MetroMessageBox.Show(this, "Có lỗi trong quá trình thêm dữ liệu, xin vui lòng thêm lại sau !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, GlobalConstants.Config.HeightAlert);
                    break;
                case GlobalConstants.EnumResponse.Unique:
                    MetroMessageBox.Show(this, "Mã BQCode bị trùng !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, GlobalConstants.Config.HeightAlert);

                    txtNameStuffs.Focus();
                    break;
            }

            txtNameStuffs.Focus();
        }

        // void LoadAll
        void LoadAll()
        {
            tableLayoutPanel5.SetRoleForTableLayout();

            CategoriesBll.Instance.ListForUIStuffs(gvCategories, false, true);

            CategoriesBll.Instance.ListForComboBox(cbbIdCategories);

            LoadStuffsPaging(Convert.ToInt32(txtPages.Text), txtSearchStuffs.Text);

            ClickRowBindingText();
        }

        // Method LooadCategoriesPaging
        void LoadStuffsPaging(int pages, string keyword)
        {
            int idCategory = Convert.ToInt32(this.idCategory);

            if(gvCategories.SelectedRows.Count > 0)
            {
                DataGridViewRow row = gvCategories.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();

                idCategory = Convert.ToInt32(gvCategories["Id", row.Index].Value);

                this.idCategory = idCategory.ToString();
            }

            StuffsBll.Instance.ListPaging(gvStuffs, GlobalConstants.Config.PageSizeForStuffs, out totalCountNumber, out countStuffs, txtPages, false, pages, idCategory, lbPages, lbRecords, true);

            lbPages.Text = totalCountNumber.ToString();
            lbRecords.Text = countStuffs.ToString();
        }

        // Method ClearTextControl
        void ClearTextControl()
        {
            foreach(Control c in tableLayoutPanel2.Controls)
            {
                if(c.GetType() == typeof(MetroTextBox))
                {
                    if(c.Tag != null && c.Tag.Equals("Focus"))
                    {
                        (c as MetroTextBox).Focus(); ;
                    }

                    c.ResetText();
                }
            }
        }

        // Method Override Refresh
        public override void Refresh()
        {
            LoadAll();

            base.Refresh();
        }

        // Event Load UserControl
        private void ucStuffs_Load(object sender, EventArgs e)
        {
            tableLayoutPanel5.SetStranlatesForTableLayout();
            tableLayoutPanel2.SetStranlatesForTableLayout();

            lbFilter.SetStranlateForControlSingle();
            lbFilter1.SetStranlateForControlSingle();
            lbPage.SetStranlateForControlSingle();
            lbRecord.SetStranlateForControlSingle();

            LoadAll();
        }

        // Event Click TextBox Search Categories
        private void txtSearchCategories_Click(object sender, EventArgs e)
        {
            CategoriesBll.Instance.ListForUIStuffs(gvCategories, true, true);

            AutoSelectRowCategories();
        }

        // Event Type TextBox Search Categories
        private void txtSearchCategories_TextChanged(object sender, EventArgs e)
        {
            CategoriesBll.Instance.SearchForUIStuffs(gvCategories, txtSearchCategories.Text);

            AutoSelectRowCategories();
        }

        // Event Click TextBox Search Stuffs
        private void txtSearchStuffs_Click(object sender, EventArgs e)
        {
            LoadStuffsPaging(Convert.ToInt32(txtPages.Text), txtSearchStuffs.Text);
        }

        // Event Type TextBox Search Stuffs
        private void txtSearchStuffs_TextChanged(object sender, EventArgs e)
        {
            StuffsBll.Instance.Search(gvStuffs, txtSearchStuffs.Text, GlobalConstants.Config.PageSizeForStuffs, out totalCountNumber, out countStuffs, txtPages, 1, idCategory);

            lbPages.Text = totalCountNumber.ToString();
            lbRecords.Text = countStuffs.ToString();
        }

        // Event Click Button Next
        private void btnNext_Click(object sender, EventArgs e)
        {
            LoadStuffsPaging(Convert.ToInt32(txtPages.Text) + 1, txtSearchStuffs.Text);
        }

        // Event Click Button Previous
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            LoadStuffsPaging(Convert.ToInt32(txtPages.Text) - 1, txtSearchStuffs.Text);
        }

        // Event Click GridView Categories
        private void gvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadStuffsPaging(Convert.ToInt32(txtPages.Text), txtSearchStuffs.Text);

            ClickRowBindingText();
        }

        // Event Click Button Insert Stuffs
        private void btnInsertStuffs_Click(object sender, EventArgs e)
        {
            InsertStuffs();
        }

        // Event Click Button Delete Stuffs
        private void btnDeleteStuffs_Click(object sender, EventArgs e)
        {
            DeleteStuffs();
        }

        // Event Click Row GridView Stuffs
        private void gvStuffs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClickRowBindingText();
        }

        // Event Click Button Edit
        private void btnEditStuffs_Click(object sender, EventArgs e)
        {
            EditStuff();
        }

        // Event Press Delete
        private void gvStuffs_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Delete)
            {
                DeleteStuffs();
            }
        }
    }
}
