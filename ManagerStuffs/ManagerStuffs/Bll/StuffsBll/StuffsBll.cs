using ManagerStuffs.Constants;
using ManagerStuffs.Dao.StuffsDao;
using ManagerStuffs.Model;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStuffs.Bll.StuffsBll
{
    public class StuffsBll
    {
        private static List<StuffsModel> Stuffs = new List<StuffsModel>();
        private static List<StuffsModel> StuffsSearch = new List<StuffsModel>();
        private static List<StuffsModel> StuffsSearchForPlaceStuff = new List<StuffsModel>();
        private static List<StuffsModel> StuffsSearchForStuffsPlaceStuffs = new List<StuffsModel>();

        private static int PageSizes = 0;
        private static int TotalCountNumber = 0;
        private static int CountStuffs = 0;
        private static int Pages = 0;
        private static bool IsSearch;
        private static MetroGrid Grid;
        private static MetroTextBox Txt;
        private static MetroLabel LbTotal;
        private static MetroLabel LbCount;

        private static volatile StuffsBll instance;

        private static object key = new object();

        public static StuffsBll Instance
        {
            get
            {
                lock (key)
                {
                    if (instance == null)
                    {
                        instance = new StuffsBll();
                    }

                    return instance;
                }
            }
        }

        private StuffsBll() { }

        // Method ListPaging
        public void ListPaging(MetroGrid grid, int pageSizes, out int totalCountNumber, out int countStuffs, MetroTextBox txt, bool click = true, int pages = 1, int IdCategory = 0, MetroLabel lbTotal = null, MetroLabel lbCount = null, bool? status = null) 
       {
            if (StuffsBll.Grid == null)
                StuffsBll.Grid = grid;

            if (StuffsBll.Txt == null)
                StuffsBll.Txt = txt;

            if (StuffsBll.LbTotal == null)
                StuffsBll.LbTotal = lbTotal;

            if (StuffsBll.LbCount == null)
                StuffsBll.LbCount = lbCount;

            List<StuffsModel> stuffs = new List<StuffsModel>();

            if(IsSearch)
            {
                stuffs.AddRange(StuffsSearch);
            }
            else
            {
                stuffs = StuffsDao.Instance.List(status);

                Stuffs.Clear();

                Stuffs.AddRange(stuffs);
            }

            if(IdCategory > 0 && IsSearch == false)
            {
                stuffs = stuffs.Where(p => p.IdCategories == IdCategory).ToList();
            }

            countStuffs = stuffs.Count;

            CountStuffs = stuffs.Count;

            PageSizes = pageSizes;

            if (countStuffs == pageSizes && pageSizes > 0)
            {
                TotalCountNumber = 1;
            }
            else
            {
                TotalCountNumber = countStuffs % pageSizes > 0 ? (countStuffs / pageSizes) + 1 : countStuffs / pageSizes;
            }

            totalCountNumber = TotalCountNumber;

            if (pages <= 0)
            {
                txt.Text = 1.ToString();

                pages = 1;

                Pages = 1;
            }  
            else if(pages > totalCountNumber)
            {
                txt.Text = totalCountNumber == 0 ? 1.ToString() : totalCountNumber.ToString();

                pages = totalCountNumber;

                Pages = totalCountNumber;
            }
            else
            {
                txt.Text = pages.ToString();

                Pages = pages;
            }

            lbTotal.Text = totalCountNumber.ToString();
            lbCount.Text = countStuffs.ToString();

            stuffs = stuffs.Skip((pages - 1) * pageSizes).Take(pageSizes).ToList();

            if (click == false)
            {
                grid.DataSource = null;

                grid.DataSource = CustomRenderUI(stuffs);
            }
        }

        // Method CustomRenderUI
        private List<StuffsModelCustomUI> CustomRenderUI(List<StuffsModel> stuffs)
        {
            return (from p in stuffs
                    select new StuffsModelCustomUI
                    {
                        Id = p.Id,
                        BQCode = p.BQCode,
                        Name = p.Name,
                        Producer = p.Producer,
                        Release = p.YearRelease,
                        State = p.State,
                        DateBuy = p.DateBuy,
                        DateUse = p.DateUse,
                        ColorStuffs = p.ColorStuffs,
                        PriceBuy = p.PriceBuy.ToString("N0"),
                        Warranty = p.Warranty,
                        Category = p.Category,
                        PlaceStuff = p.PlaceStuff
                    }).ToList();
        }

        // Method Search
        public void Search(MetroGrid grid, string keyword, int pageSizes, out int totalCountNumber, out int countStuffs, MetroTextBox txt, int pages = 1, string idCategory = null)
        {
            keyword = keyword.Trim().ToLower();

            if(string.IsNullOrEmpty(keyword))
            {
                IsSearch = false;

                StuffsSearch.Clear();

                ListPaging(grid, pageSizes, out totalCountNumber, out countStuffs, txt, false, Pages, Convert.ToInt32(idCategory), LbTotal, LbCount, true);

                totalCountNumber = TotalCountNumber;

                countStuffs = CountStuffs;
            }
            else
            {
                IsSearch = true;

                List<StuffsModel> stuffsSearch = (from p in Stuffs
                                                  let name = p.Name.Trim().ToLower()
                                                  let bqcode = p.BQCode.Trim().ToLower()
                                                  where name.Contains(keyword)
                                                  || name.Equals(keyword, StringComparison.OrdinalIgnoreCase)
                                                  || name.EndsWith(keyword)
                                                  || name.StartsWith(keyword)
                                                  || bqcode.Equals(keyword)
                                                  || bqcode.EndsWith(keyword)
                                                  || bqcode.StartsWith(keyword)
                                                  || bqcode.Contains(keyword)
                                                  select p).ToList();

                List<StuffsModelCustomUI> stuffsSearchCustomUI = CustomRenderUI(stuffsSearch);

                StuffsSearch.Clear();

                StuffsSearch.AddRange(stuffsSearch);

                grid.DataSource = null;

                grid.DataSource = stuffsSearchCustomUI.Skip((pages - 1) * pageSizes).Take(pageSizes).ToList();

                txt.Text = 1.ToString();

                countStuffs = stuffsSearch.Count;

                if (countStuffs == pageSizes && pageSizes > 0)
                {
                    totalCountNumber = 1;
                }
                else
                {
                    totalCountNumber = countStuffs % pageSizes > 0 ? (countStuffs % pageSizes) + 1 : countStuffs / pageSizes;
                }
            }
        }

        // Method Insert
        public GlobalConstants.ResponseResult Insert(string bqCode, string stuffName, string producer, DateTime dateBuy, DateTime dateUse, DateTime yearRelease, string color, string state, decimal price, string warranty, bool status, int idCategory, string createdBy)
        {
            GlobalConstants.ResponseResult res = new GlobalConstants.ResponseResult();

            int count = StuffsDao.Instance.CheckExist(new StuffsModel
            {
                BQCode = bqCode
            }, new string[] { "@BQCODE" });

            if(count > 0)
            {
                res.TypeResponse = GlobalConstants.EnumResponse.Unique;

                return res;
            }

            int execute = StuffsDao.Instance.Insert(new StuffsModel
            {
                BQCode = bqCode,
                Name = stuffName,
                Producer = producer,
                DateBuy = dateBuy,
                DateUse = dateUse,
                YearRelease = yearRelease,
                ColorStuffs = color,
                State = state,
                PriceBuy = price,
                Warranty = warranty,
                Status = status,
                CreatedDate = DateTime.Now,
                CreatedBy = createdBy,
                IdCategories = idCategory
            }, new string[] {
                "@BQCODE",
                "@NAME",
                "@PRODUCER",
                "@DATEBUY",
                "@DATEUSE",
                "@YEARRELEASE",
                "@COLORSTUFFS",
                "@STATE",
                "@PRICEBUY",
                "@WARRANTY",
                "@STATUS",
                "@CREATEDDATE",
                "@CREATEBY",
                "@MODIFIEDDATE:NULL",
                "@IDCATEGORIES"
            });

            if(execute == 1)
            {
                res.TypeResponse = GlobalConstants.EnumResponse.InsertSuccess;

                List<StuffsModel> listTemps = Stuffs.Where(p => p.IdCategories == idCategory).ToList();

                int pages = listTemps.Count % PageSizes > 0 ? (listTemps.Count / PageSizes) + 1 : listTemps.Count / PageSizes;

                ListPaging(Grid, PageSizes, out TotalCountNumber, out CountStuffs, Txt, false, pages + 1, idCategory, LbTotal, LbCount, true);
            }
            else
            {
                res.TypeResponse = GlobalConstants.EnumResponse.InsertFail;
            }

            return res;
        }

        // Method Delete
        public GlobalConstants.ResponseResult Deletes(int[] ids, int idCategory)
        {
            GlobalConstants.ResponseResult res = new GlobalConstants.ResponseResult();

            int execute = StuffsDao.Instance.DeleteStuffs(ids);

            if(execute == ids.Length)
            {
                res.TypeResponse = GlobalConstants.EnumResponse.DeleteSuccess;

                if(ids.Length == PageSizes)
                {
                    Pages = Pages - 1;
                }

                ListPaging(Grid, PageSizes, out TotalCountNumber, out CountStuffs, Txt, false, 1, idCategory, LbTotal, LbCount, true);
            }
            else
            {
                res.TypeResponse = GlobalConstants.EnumResponse.DeleteFail;
            }

            return res;
        }

        // Method Edit
        public GlobalConstants.ResponseResult Edit(int id, string bqCode, string stuffName, string producer, DateTime dateBuy, DateTime dateUse, DateTime yearRelease, string color, string state, decimal price, string warranty, bool status, int idCategory, string createdBy)
        {
            GlobalConstants.ResponseResult res = new GlobalConstants.ResponseResult();

            int count = StuffsDao.Instance.CheckExist(new StuffsModel
            {
                Id = id,
                BQCode = bqCode
            }, new string[] { "@BQCODE" });

            if (count > 0)
            {
                res.TypeResponse = GlobalConstants.EnumResponse.Unique;

                return res;
            }

            int execute = StuffsDao.Instance.Edit(new StuffsModel
            {
                Id = id,
                BQCode = bqCode,
                Name = stuffName,
                Producer = producer,
                DateBuy = dateBuy,
                DateUse = dateUse,
                YearRelease = yearRelease,
                ColorStuffs = color,
                State = state,
                PriceBuy = price,
                Warranty = warranty,
                Status = status,
                IdCategories = idCategory,
                ModifiedDate = DateTime.Now,
                ModifiedBy = createdBy
            }, new string[] {
                "@BQCODE",
                "@NAME",
                "@PRODUCER",
                "@DATEBUY",
                "@DATEUSE",
                "@YEARRELEASE",
                "@COLORSTUFFS",
                "@STATE",
                "@PRICEBUY",
                "@WARRANTY",
                "@STATUS",
                "@MODIFIEDDATE",
                "@IDCATEGORIES",
                "@MODIFIEDBY"
            });

            if (execute == 1)
            {
                res.TypeResponse = GlobalConstants.EnumResponse.EditSuccess;

                ListPaging(Grid, PageSizes, out TotalCountNumber, out CountStuffs, Txt, false, Pages, idCategory, LbTotal, LbCount, true);
            }
            else
            {
                res.TypeResponse = GlobalConstants.EnumResponse.EditFail;
            }

            return res;
        }

        // Method ListForExcel
        public void ListForExcel(MetroGrid grid, string keyword, string sortColumn, string sortBy, string columnFilter, object filterValue)
        {
            grid.Rows.Clear();

            grid.Columns.Clear();

            List<StuffsModel> stuffs = StuffsDao.Instance.ListForExcel(keyword, !string.IsNullOrEmpty(sortColumn) ? HelperBll.GetColumnNameInSQLByPropertyName<StuffsModel>(sortColumn) : "", sortBy, !string.IsNullOrEmpty(columnFilter) ? HelperBll.GetColumnNameInSQLByPropertyName<StuffsModel>(columnFilter) : "", filterValue);

            StuffsModel nameOf = new StuffsModel();

            grid.Columns.Add(nameof(nameOf.BQCode), nameof(nameOf.BQCode));
            grid.Columns.Add(nameof(nameOf.Name), nameof(nameOf.Name));
            grid.Columns.Add(nameof(nameOf.Category), nameof(nameOf.Category));
            grid.Columns.Add(nameof(nameOf.PlaceStuff), nameof(nameOf.PlaceStuff));
            grid.Columns.Add(nameof(nameOf.DateBuy), nameof(nameOf.DateBuy));
            grid.Columns.Add(nameof(nameOf.DateUse), nameof(nameOf.DateUse));
            grid.Columns.Add(nameof(nameOf.YearRelease), nameof(nameOf.YearRelease));
            grid.Columns.Add(nameof(nameOf.ColorStuffs), nameof(nameOf.ColorStuffs));
            grid.Columns.Add(nameof(nameOf.State), nameof(nameOf.State));
            grid.Columns.Add(nameof(nameOf.PriceBuy), nameof(nameOf.PriceBuy));
            grid.Columns.Add(nameof(nameOf.Warranty), nameof(nameOf.Warranty));
            grid.Columns.Add(nameof(nameOf.CreatedDate), nameof(nameOf.CreatedDate));
            grid.Columns.Add(nameof(nameOf.CreatedBy), nameof(nameOf.CreatedBy));
            grid.Columns.Add(nameof(nameOf.ModifiedDate), nameof(nameOf.ModifiedDate));
            grid.Columns.Add(nameof(nameOf.ModifiedBy), nameof(nameOf.ModifiedBy));

            for (int i = 0; i < stuffs.Count; i++)
            {
                grid.Rows.Add();

                grid[nameof(nameOf.BQCode), i].Value = stuffs[i].BQCode;
                grid[nameof(nameOf.Name), i].Value = stuffs[i].Name;
                grid[nameof(nameOf.Category), i].Value = stuffs[i].Category;
                grid[nameof(nameOf.PlaceStuff), i].Value = stuffs[i].PlaceStuff;
                grid[nameof(nameOf.DateBuy), i].Value = stuffs[i].DateBuy;
                grid[nameof(nameOf.DateUse), i].Value = stuffs[i].DateUse;
                grid[nameof(nameOf.YearRelease), i].Value = stuffs[i].YearRelease;
                grid[nameof(nameOf.ColorStuffs), i].Value = stuffs[i].ColorStuffs;
                grid[nameof(nameOf.State), i].Value = stuffs[i].State;
                grid[nameof(nameOf.PriceBuy), i].Value = stuffs[i].PriceBuy;
                grid[nameof(nameOf.Warranty), i].Value = stuffs[i].Warranty;
                grid[nameof(nameOf.CreatedDate), i].Value = stuffs[i].CreatedDate;
                grid[nameof(nameOf.CreatedBy), i].Value = stuffs[i].CreatedBy;
                grid[nameof(nameOf.ModifiedDate), i].Value = stuffs[i].ModifiedDate.ToString() == "01-Jan-01 12:00:00 AM" ? "" : stuffs[i].ModifiedDate.ToString();
                grid[nameof(nameOf.ModifiedBy), i].Value = stuffs[i].ModifiedBy;
            }
        }

        // Method ListDataByCoumn
        public Dictionary<string, object> ListDataByCoumn(string column)
        {
            List<string> data = StuffsDao.Instance.ListDataByColumn(HelperBll.GetColumnNameInSQLByPropertyName<StuffsModel>(column));

            Dictionary<string, object> dics = new Dictionary<string, object>();

            foreach(string item in data)
            {
                dics.Add(item, item);
            }

            return dics;
        }

        // Method ListStuffsNotHavePlacePaging
        public void ListStuffsNotHavePlace(MetroGrid grid, bool click = true)
        {
            List<StuffsModel> stuffs = StuffsDao.Instance.ListStuffsNotHavePlace();

            if (!click)
            {
                grid.DataSource = null;

                grid.DataSource = CustomRenderUI(stuffs);
            }

            StuffsSearchForPlaceStuff.Clear();

            StuffsSearchForPlaceStuff.AddRange(stuffs);
        }

        // Method SearchStuffsForPlaceStuff
        public void SearchStuffsForPlaceStuff(MetroGrid grid, string keyword)
        {
            keyword = keyword.Trim().ToLower();

            grid.DataSource = null;

            if (string.IsNullOrEmpty(keyword))
            { 
                grid.DataSource = CustomRenderUI(StuffsSearchForPlaceStuff);
            }
            else
            {
                List<StuffsModel> stuffs = (from p in StuffsSearchForPlaceStuff
                                            let name = p.Name.Trim().ToLower()
                                            let bqcode = p.BQCode.Trim().ToLower()
                                            where name.Contains(keyword)
                                            || name.Equals(keyword, StringComparison.OrdinalIgnoreCase)
                                            || name.StartsWith(keyword)
                                            || name.EndsWith(keyword)
                                            || bqcode.Contains(keyword)
                                            || bqcode.Equals(keyword, StringComparison.OrdinalIgnoreCase)
                                            || bqcode.StartsWith(keyword)
                                            || bqcode.EndsWith(keyword)
                                            select p).ToList();

                grid.DataSource = CustomRenderUI(stuffs);
            }
        }

        // Method ListStuffsByPlaceStuff
        public void ListStuffsByPlaceStuff(MetroGrid grid, int idPlaceStuff)
        {
            grid.DataSource = null;

            List<StuffsModel> stuffs = StuffsDao.Instance.ListStuffsByPlaceStuff(idPlaceStuff);

            grid.DataSource = CustomRenderUI(stuffs);

            StuffsSearchForStuffsPlaceStuffs.Clear();

            StuffsSearchForStuffsPlaceStuffs.AddRange(stuffs);
        }

        // Method SearchStuffsForStuffsPlaceStuffs
        public void SearchStuffsForStuffsPlaceStuffs(MetroGrid grid, string keyword)
        {
            keyword = keyword.Trim().ToLower();

            grid.DataSource = null;

            if (string.IsNullOrEmpty(keyword))
            {
                grid.DataSource = CustomRenderUI(StuffsSearchForStuffsPlaceStuffs);
            }
            else
            {
                List<StuffsModel> stuffs = (from p in StuffsSearchForStuffsPlaceStuffs
                                            let name = p.Name.Trim().ToLower()
                                            let bqcode = p.BQCode.Trim().ToLower()
                                            where name.Contains(keyword)
                                            || name.Equals(keyword, StringComparison.OrdinalIgnoreCase)
                                            || name.StartsWith(keyword)
                                            || name.EndsWith(keyword)
                                            || bqcode.Contains(keyword)
                                            || bqcode.Equals(keyword, StringComparison.OrdinalIgnoreCase)
                                            || bqcode.StartsWith(keyword)
                                            || bqcode.EndsWith(keyword)
                                            select p).ToList();

                grid.DataSource = CustomRenderUI(stuffs);
            }
        }
    }
}
