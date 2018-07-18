using ManagerStuffs.Constants;
using ManagerStuffs.Dao.PlaceStuffsDao;
using ManagerStuffs.Model.PlaceStuffsModel;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStuffs.Bll.PlaceStuffsBll
{
    public class PlaceStuffsBll
    {
        private static List<PlaceStuffsModel> PlaceStuffs = new List<PlaceStuffsModel>();

        private static volatile PlaceStuffsBll instance;

        private static object key = new object();

        public static PlaceStuffsBll Instance
        {
            get
            {
                lock (key)
                {
                    if (instance == null)
                    {
                        instance = new PlaceStuffsBll();
                    }

                    return instance;
                }
            }
        }

        private PlaceStuffsBll() { }

        // Method List
        public void List(MetroGrid grid, bool click = true)
        {
            List<PlaceStuffsModel> placeStuffs = PlaceStuffsDao.Instance.List();

            if (click == false)
            {
                grid.DataSource = placeStuffs;
            }

            PlaceStuffs.Clear();

            PlaceStuffs.AddRange(placeStuffs);
        }

        // Method Search
        public void Search(MetroGrid grid, string keyword)
        {
            keyword = keyword.ToLower().Trim();

            grid.DataSource = PlaceStuffs.Where(p => p.Name.ToLower().StartsWith(keyword)
            || p.Name.ToLower().EndsWith(keyword) || p.Name.Contains(keyword) || p.Name.Equals(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        // Method Insert
        public GlobalConstants.ResponseResult Insert(string placeStuffName)
        {
            placeStuffName = placeStuffName.Trim();

            GlobalConstants.ResponseResult res = new GlobalConstants.ResponseResult();

            int count = PlaceStuffsDao.Instance.CheckExist(new PlaceStuffsModel
            {

                Name = placeStuffName
            }, new string[] { "@NAME" });

            if (count >= 1)
            {
                res.TypeResponse = GlobalConstants.EnumResponse.Unique;

                return res;
            }

            string[] parameters =
            {
                "@NAME"
            };

            int execute = PlaceStuffsDao.Instance.Insert(new PlaceStuffsModel
            {
                Name = placeStuffName
            }, parameters);

            if (execute == 1)
            {
                res.TypeResponse = GlobalConstants.EnumResponse.InsertSuccess;

                List<PlaceStuffsModel> placeStuffs = PlaceStuffsDao.Instance.List();

                res.Result = placeStuffs;

                PlaceStuffs.Clear();

                PlaceStuffs.AddRange(placeStuffs);
            }
            else
            {
                res.TypeResponse = GlobalConstants.EnumResponse.InsertFail;
            }

            return res;
        }

        // Method Edit
        public GlobalConstants.ResponseResult Edit(int id, string placeStuffName)
        {
            placeStuffName = placeStuffName.Trim();

            GlobalConstants.ResponseResult res = new GlobalConstants.ResponseResult();

            int count = PlaceStuffsDao.Instance.CheckExist(new PlaceStuffsModel
            {
                Id = id,
                Name = placeStuffName
            }, new string[] { "@NAME" });

            if (count > 0)
            {
                res.TypeResponse = GlobalConstants.EnumResponse.Unique;

                return res;
            }

            DateTime now = DateTime.Now;

            string subDateTime = now.ToString("dd/MM/yyyy hh:mm:ss");

            subDateTime = subDateTime.Substring(0, subDateTime.LastIndexOf(":"));

            subDateTime = subDateTime + ":00";

            int execute = PlaceStuffsDao.Instance.Edit(new PlaceStuffsModel
            {
                Id = id,
                Name = placeStuffName,
            }, new string[] {
                "@NAME",
            });

            if (execute == 1)
            {
                res.TypeResponse = GlobalConstants.EnumResponse.EditSuccess;

                List<PlaceStuffsModel> placeStuffs = PlaceStuffsDao.Instance.List();

                res.Result = placeStuffs;

                PlaceStuffs.Clear();

                PlaceStuffs.AddRange(placeStuffs);
            }
            else
            {
                res.TypeResponse = GlobalConstants.EnumResponse.EditFail;
            }

            return res;
        }

        // Method Delete
        public GlobalConstants.ResponseResult Delete(int id)
        {
            GlobalConstants.ResponseResult res = new GlobalConstants.ResponseResult();

            int count = PlaceStuffsDao.Instance.CheckForeignKey(id);

            if (count > 0)
            {
                res.TypeResponse = GlobalConstants.EnumResponse.ForeignKey;

                return res;
            }

            int execute = PlaceStuffsDao.Instance.Delete(new PlaceStuffsModel
            {
                Id = id
            }, new string[] { "@ID" });

            if (execute == 1)
            {
                res.TypeResponse = GlobalConstants.EnumResponse.DeleteSuccess;

                res.Result = PlaceStuffsDao.Instance.List();

                List<PlaceStuffsModel> categories = PlaceStuffsDao.Instance.List();

                res.Result = categories;

                PlaceStuffs.Clear();

                PlaceStuffs.AddRange(categories);
            }
            else
            {
                res.TypeResponse = GlobalConstants.EnumResponse.DeleteFail;
            }

            return res;
        }

        // Method ListForComboBox
        public void ListForComboBox(MetroComboBox cbb)
        {
            List<PlaceStuffsModel> placeStuffs = PlaceStuffsDao.Instance.List();

            cbb.DataSource = null;

            cbb.DataSource = placeStuffs;

            cbb.DisplayMember = "Name";

            cbb.ValueMember = "Id";
        }

        // Method ListForExcel
        public void ListForExcel(MetroGrid grid, string keyword, string sortColumn, string sortBy)
        {
            grid.Rows.Clear();

            grid.Columns.Clear();

            List<PlaceStuffsModel> stuffs = PlaceStuffsDao.Instance.ListForExcel(keyword, !string.IsNullOrEmpty(sortColumn) ? HelperBll.GetColumnNameInSQLByPropertyName<PlaceStuffsModel>(sortColumn) : "", sortBy);

            PlaceStuffsModel nameOf = new PlaceStuffsModel();

            grid.Columns.Add(nameof(nameOf.Name), nameof(nameOf.Name));
            grid.Columns.Add(nameof(nameOf.CountStuffs), nameof(nameOf.CountStuffs));

            for (int i = 0; i < stuffs.Count; i++)
            {
                grid.Rows.Add();

                grid[nameof(nameOf.Name), i].Value = stuffs[i].Name;
                grid[nameof(nameOf.CountStuffs), i].Value = stuffs[i].CountStuffs;
            }
        }
    }
}
