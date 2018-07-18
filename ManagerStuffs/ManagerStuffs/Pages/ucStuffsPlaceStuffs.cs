using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagerStuffs.Bll.PlaceStuffsBll;
using ManagerStuffs.Constants.Roles;
using ManagerStuffs.Bll.StuffsBll;
using ManagerStuffs.Constants;
using MetroFramework;
using ManagerStuffs.Bll.StuffsPlaceStuffsBll;
using ManagerStuffs.Constants.Languages;

namespace ManagerStuffs.Pages
{
    public partial class ucStuffsPlaceStuffs : UserControl
    {
        public ucStuffsPlaceStuffs()
        {
            InitializeComponent();
        }

        // Method LoadAll
        void LoadAll()
        {

            PlaceStuffsBll.Instance.List(gvPlaceStuffs, false);

            PlaceStuffsBll.Instance.ListForComboBox(cbbIdPlaceStuffs);

            StuffsBll.Instance.ListStuffsNotHavePlace(gvStuffs, false);

            LoadStuffByPlaceStuff();
        }

        // Method InsertStuffsPlaceStuffs
        void InsertStuffsPlaceStuffs()
        {
            if(gvStuffs.SelectedRows.Count > 0)
            {
                if(cbbIdPlaceStuffs.SelectedValue != null)
                {
                    int idPlaceStuff = Convert.ToInt32(cbbIdPlaceStuffs.SelectedValue.ToString());
                    string namePlace = cbbIdPlaceStuffs.Text;

                    int[] stuffs = gvStuffs.SelectedRows.Cast<DataGridViewRow>().Select(p => Convert.ToInt32(p.Cells["Id"].Value.ToString())).ToArray();

                    string[] nameStuffs = gvStuffs.SelectedRows.Cast<DataGridViewRow>().Select(p => p.Cells["Name"].Value.ToString()).ToArray();

                    GlobalConstants.ResponseResult res = StuffsPlaceStuffsBll.Instance.Insert(idPlaceStuff, stuffs);

                    switch(res.TypeResponse)
                    {
                        case GlobalConstants.EnumResponse.InsertSuccess:
                            foreach(string item in nameStuffs)
                            {
                                LogEvent.Log = LogEvent.Log = $"[{ DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")}] - [{ GlobalConstants.Username}] - thêm vật tư [{item}] vào nơi [{namePlace}]";
                            }

                            if(gvPlaceStuffs.SelectedRows.Count > 0)
                            {
                                DataGridViewRow row = gvPlaceStuffs.SelectedRows.Cast<DataGridViewRow>().Where(p => Convert.ToInt32(p.Cells["Id"].Value.ToString()) == idPlaceStuff).FirstOrDefault();

                                int rowIndex = row.Index;

                                if(row != null)
                                {
                                    PlaceStuffsBll.Instance.List(gvPlaceStuffs, false);

                                    gvPlaceStuffs.CurrentCell = gvPlaceStuffs.Rows[rowIndex].Cells["Id"];

                                    gvPlaceStuffs.Rows[rowIndex].Selected = true;

                                    LoadStuffByPlaceStuff();
                                }
                            }

                            StuffsBll.Instance.ListStuffsNotHavePlace(gvStuffs, false);

                            MetroMessageBox.Show(this, $"Bạn thêm '{stuffs.Length.ToString()}' vật tư vào nơi '{namePlace}' thành công !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);
                            break;
                        case GlobalConstants.EnumResponse.InsertFail:
                            MetroMessageBox.Show(this, "Có lỗi trong quá trình thêm dữ liệu, xin vui lòng thử lại sau !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, GlobalConstants.Config.HeightAlert);
                            break;
                    }
                }
                else
                {
                    MetroMessageBox.Show(this, "Bạn chưa chọn nơi để thêm vật tư !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);
                }
            }
            else
            {
                MetroMessageBox.Show(this, "Bạn chưa chọn vật tư !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);
            }
        }

        // Method LoadStuffByPlaceStuff
        void LoadStuffByPlaceStuff()
        {
            if(gvPlaceStuffs.SelectedRows.Count > 0)
            {
                int idPlaceStuff = Convert.ToInt32(gvPlaceStuffs["Id", gvPlaceStuffs.SelectedRows[0].Index].Value.ToString());

                StuffsBll.Instance.ListStuffsByPlaceStuff(gvStuffsPlaceStuffs, idPlaceStuff);
            }
        }

        // Method DeleteStuffsPlaceStuffs
        void DeleteStuffsPlaceStuffs()
        {
            if(gvStuffsPlaceStuffs.SelectedRows.Count > 0)
            {
                DialogResult dialog = MetroMessageBox.Show(this, "Bạn có chắc chắn xóa những vật tư đã chọn không ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, GlobalConstants.Config.HeightAlert);

                if(dialog == DialogResult.Yes)
                {
                    DataGridViewRow row = gvPlaceStuffs.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();

                    int idPlaceStuff = Convert.ToInt32(row.Cells["Id"].Value.ToString());
                    string namePlace = row.Cells["Name"].Value.ToString();

                    int[] stuffs = gvStuffsPlaceStuffs.SelectedRows.Cast<DataGridViewRow>().Select(p => Convert.ToInt32(p.Cells["Id"].Value.ToString())).ToArray();

                    string[] nameStuffs = gvStuffsPlaceStuffs.SelectedRows.Cast<DataGridViewRow>().Select(p => p.Cells["Name"].Value.ToString()).ToArray();

                    GlobalConstants.ResponseResult res = StuffsPlaceStuffsBll.Instance.Delete(idPlaceStuff, stuffs);

                    switch (res.TypeResponse)
                    {
                        case GlobalConstants.EnumResponse.DeleteSuccess:
                            foreach (string item in nameStuffs)
                            {
                                LogEvent.Log = LogEvent.Log = $"[{ DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")}] - [{ GlobalConstants.Username}] - xóa vật tư [{item}] ra khỏi nơi [{namePlace}]";
                            }

                            DataGridViewRow rowChose = gvPlaceStuffs.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();

                            int rowIndex = rowChose.Index;

                            if (rowChose != null)
                            {
                                PlaceStuffsBll.Instance.List(gvPlaceStuffs, false);

                                gvPlaceStuffs.CurrentCell = gvPlaceStuffs.Rows[rowIndex].Cells["Id"];

                                gvPlaceStuffs.Rows[rowIndex].Selected = true;

                                LoadStuffByPlaceStuff();
                            }

                            StuffsBll.Instance.ListStuffsNotHavePlace(gvStuffs, false);

                            MetroMessageBox.Show(this, $"Bạn đã xóa '{stuffs.Length.ToString()}' vật tư  ra khỏi nơi '{namePlace}' thành công !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);
                            break;
                        case GlobalConstants.EnumResponse.DeleteFail:
                            MetroMessageBox.Show(this, "Có lỗi trong quá trình xóa dữ liệu, xin vui lòng thử lại sau !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, GlobalConstants.Config.HeightAlert);
                            break;
                    }
                }
            }
            else
            {
                MetroMessageBox.Show(this, "Bạn chưa chọn vật tư để xóa !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, GlobalConstants.Config.HeightAlert);
            }
        }

        // Event Load UserControl
        private void ucStuffsPlaceStuffs_Load(object sender, EventArgs e)
        {
            tableLayoutPanel5.SetRoleForTableLayout();

            lbFilter.SetStranlateForControlSingle();
            lbFilter1.SetStranlateForControlSingle();
            lbFilter2.SetStranlateForControlSingle();
            lbNamePlaceStuff.SetStranlateForControlSingle();

            tableLayoutPanel5.SetStranlatesForTableLayout();

            LoadAll();
        }

        // Event Click TextBox Search PlaceStuffs
        private void txtSearchPlaceStuffs_Click(object sender, EventArgs e)
        {
            PlaceStuffsBll.Instance.List(gvPlaceStuffs, true);
        }

        // Event Type Word TextBox PlaceStuffs
        private void txtSearchPlaceStuffs_TextChanged(object sender, EventArgs e)
        {
            PlaceStuffsBll.Instance.Search(gvPlaceStuffs, txtSearchPlaceStuffs.Text);
        }

        // Event Click Button Insert
        private void btnInsertStuffsPlaceStuffs_Click(object sender, EventArgs e)
        {
            InsertStuffsPlaceStuffs();
        }
        
        // Event Click TextBox SearchStuffs
        private void txtSearchStuffs_Click(object sender, EventArgs e)
        {
            StuffsBll.Instance.ListStuffsNotHavePlace(gvStuffs, true);
        }

        // Event Type Word TextBox Stuffs
        private void txtSearchStuffs_TextChanged(object sender, EventArgs e)
        {
            StuffsBll.Instance.SearchStuffsForPlaceStuff(gvStuffs, txtSearchStuffs.Text);
        }

        // Event Click Row PlaceStuffs
        private void gvPlaceStuffs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadStuffByPlaceStuff();
        }

        // Event Type Word TextBox StuffsPlaceStuffs
        private void txtSearchStuffsPlaceStuffs_TextChanged(object sender, EventArgs e)
        {
            StuffsBll.Instance.SearchStuffsForStuffsPlaceStuffs(gvStuffsPlaceStuffs, txtSearchStuffsPlaceStuffs.Text);
        }

        // Event Click Button Delete
        private void btnDeleteStuffsPlaceStuffs_Click(object sender, EventArgs e)
        {
            DeleteStuffsPlaceStuffs();
        }
    }
}
