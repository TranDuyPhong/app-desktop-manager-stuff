using ManagerStuffs.Constants;
using ManagerStuffs.Dao;
using ManagerStuffs.Model.CategoriesModel;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStuffs.Bll.CategoriesBll
{
    public class CategoriesBll
    {
        private static List<CategoriesModel> Categories = new List<CategoriesModel>();

        private static volatile CategoriesBll instance;

        private static object key = new object();

        public static CategoriesBll Instance
        {
            get
            {
                lock (key)
                {
                    if (instance == null)
                    {
                        instance = new CategoriesBll();
                    }

                    return instance;
                }
            }
        }

        private CategoriesBll() { }

        // Method List
        public void List(MetroGrid grid, bool click = true, bool? status = null)
        {
            List<CategoriesModel> categories = CategoriesDao.Instance.List(status);

            if(click == false)
            {
                grid.DataSource = categories;
            }

            Categories.Clear();

            Categories.AddRange(categories);
        }

        // Method ListForUIStuffs
        public void ListForUIStuffs(MetroGrid grid, bool click = true, bool? status = null)
        {
            List<CategoriesModel> categories = CategoriesDao.Instance.List(status);

            var customCategories = (from p in categories
                                    select new
                                    {
                                        Id = p.Id,
                                        Name = p.Name,
                                        CountStuffs = p.CountStuffs
                                    }).ToList();

            if (click == false)
            {
                grid.DataSource = customCategories;
            }

            Categories.Clear();

            Categories.AddRange(categories);
        }

        // Method Search
        public void Search(MetroGrid grid, string keyword)
        {
            keyword = keyword.ToLower().Trim();

            grid.DataSource = Categories.Where(p => p.Name.ToLower().StartsWith(keyword)
            || p.Name.ToLower().EndsWith(keyword) || p.Name.Contains(keyword) || p.Name.Equals(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        // Method SearchForUIStuffs
        public void SearchForUIStuffs(MetroGrid grid, string keyword)
        {
            keyword = keyword.ToLower().Trim();

            var customCategories = (from p in Categories
                     let name = p.Name.Trim().ToLower()
                     where name.Equals(keyword)
                     || name.StartsWith(keyword)
                     || name.EndsWith(keyword)
                     || name.Contains(keyword)
                     select new
                     {
                         Id = p.Id,
                         Name = p.Name,
                         CountStuffs = p.CountStuffs
                     }).ToList();

            grid.DataSource = customCategories;
        }

        // Method Insert
        public GlobalConstants.ResponseResult Insert(string categoryName, bool status, string createdBy)
        {
            categoryName = categoryName.Trim();

            GlobalConstants.ResponseResult res = new GlobalConstants.ResponseResult();

            int count = CategoriesDao.Instance.CheckExist(new CategoriesModel
            {
                Name = categoryName
            }, new string[] { "@NAME" });

            if(count >= 1)
            {
                res.TypeResponse = GlobalConstants.EnumResponse.Unique;

                return res;
            }

            string[] parameters =
            {
                "@NAME",
                "@STATUS",
                "@CREATEBY",
                "@MODIFIEDDATE:NULL"
            };

            int execute = CategoriesDao.Instance.Insert(new CategoriesModel
            {
                Name = categoryName,
                Status = status,
                CreatedBy = createdBy,
                ModifiedDate = null
            }, parameters);

            if(execute == 1)
            {
                res.TypeResponse = GlobalConstants.EnumResponse.InsertSuccess;

                List<CategoriesModel> categories = CategoriesDao.Instance.List();

                res.Result = categories;

                Categories.Clear();

                Categories.AddRange(categories);
            }
            else
            {
                res.TypeResponse = GlobalConstants.EnumResponse.InsertFail;
            }

            return res;
        }

        // Method Delete
        public GlobalConstants.ResponseResult Delete(int id)
        {
            GlobalConstants.ResponseResult res = new GlobalConstants.ResponseResult();

            int count = CategoriesDao.Instance.CheckForeignKey(id);

            if(count > 0)
            {
                res.TypeResponse = GlobalConstants.EnumResponse.ForeignKey;

                return res;
            }

            int execute = CategoriesDao.Instance.Delete(new CategoriesModel
            {
                Id = id
            }, new string[] { "@ID" });

            if(execute == 1)
            {
                res.TypeResponse = GlobalConstants.EnumResponse.DeleteSuccess;

                res.Result = CategoriesDao.Instance.List();

                List<CategoriesModel> categories = CategoriesDao.Instance.List();

                res.Result = categories;

                Categories.Clear();

                Categories.AddRange(categories);
            }
            else
            {
                res.TypeResponse = GlobalConstants.EnumResponse.DeleteFail;
            }

            return res;
        }

        // Method Edit
        public GlobalConstants.ResponseResult Edit(int id, string categoryname, bool status, string modifiedBy)
        {
            categoryname = categoryname.Trim();

            GlobalConstants.ResponseResult res = new GlobalConstants.ResponseResult();

            int count = CategoriesDao.Instance.CheckExist(new CategoriesModel
            {
                Id = id,
                Name = categoryname
            }, new string[] { "@NAME" });

            if(count > 0)
            {
                res.TypeResponse = GlobalConstants.EnumResponse.Unique;

                return res;
            }

            DateTime now = DateTime.Now;

            string subDateTime = now.ToString("dd/MM/yyyy hh:mm:ss");

            subDateTime = subDateTime.Substring(0, subDateTime.LastIndexOf(":"));

            subDateTime = subDateTime + ":00";

            int execute = CategoriesDao.Instance.Edit(new CategoriesModel
            {
                Id = id,
                Name = categoryname,
                Status = status,
                ModifiedDate = Convert.ToDateTime(subDateTime),
                ModifiedBy = modifiedBy
            }, new string[] {
                "@NAME",
                "@STATUS",
                "@MODIFIEDDATE",
                "@MODIFIEDBY"
            });

            if(execute == 1)
            {
                res.TypeResponse = GlobalConstants.EnumResponse.EditSuccess;

                List<CategoriesModel> categories = CategoriesDao.Instance.List();

                res.Result = categories;

                Categories.Clear();

                Categories.AddRange(categories);
            }
            else
            {
                res.TypeResponse = GlobalConstants.EnumResponse.EditFail;
            }

            return res;
        }

        // Method ListForComboBox
        public void ListForComboBox(MetroComboBox cbb)
        {
            List<CategoriesModel> categories = CategoriesDao.Instance.List(true);

            cbb.DataSource = null;

            cbb.DataSource = categories;

            cbb.DisplayMember = "Name";

            cbb.ValueMember = "Id";
        }

        // Method ListForExcel
        public void ListForExcel(MetroGrid grid, string keyword, string sortColumn, string sortBy)
        {
            grid.Rows.Clear();

            grid.Columns.Clear();

            List<CategoriesModel> stuffs = CategoriesDao.Instance.ListForExcel(keyword, !string.IsNullOrEmpty(sortColumn) ? HelperBll.GetColumnNameInSQLByPropertyName<CategoriesModel>(sortColumn) : "", sortBy);

            CategoriesModel nameOf = new CategoriesModel();

            grid.Columns.Add(nameof(nameOf.Name), nameof(nameOf.Name));
            grid.Columns.Add(nameof(nameOf.CreatedDate), nameof(nameOf.CreatedDate));
            grid.Columns.Add(nameof(nameOf.CreatedBy), nameof(nameOf.CreatedBy));
            grid.Columns.Add(nameof(nameOf.ModifiedDate), nameof(nameOf.ModifiedDate));
            grid.Columns.Add(nameof(nameOf.ModifiedBy), nameof(nameOf.ModifiedBy));
            grid.Columns.Add(nameof(nameOf.CountStuffs), nameof(nameOf.CountStuffs));

            for (int i = 0; i < stuffs.Count; i++)
            {
                grid.Rows.Add();

                grid[nameof(nameOf.Name), i].Value = stuffs[i].Name;
                grid[nameof(nameOf.CreatedDate), i].Value = stuffs[i].CreatedDate;
                grid[nameof(nameOf.CreatedBy), i].Value = stuffs[i].CreatedBy;
                grid[nameof(nameOf.ModifiedDate), i].Value = stuffs[i].ModifiedDate.ToString() == "01-Jan-01 12:00:00 AM" ? "" : stuffs[i].ModifiedDate.ToString();
                grid[nameof(nameOf.ModifiedBy), i].Value = stuffs[i].ModifiedBy;
                grid[nameof(nameOf.CountStuffs), i].Value = stuffs[i].CountStuffs;
            }
        }
    }
}
