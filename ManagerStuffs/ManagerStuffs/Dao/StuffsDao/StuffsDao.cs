using ManagerStuffs.Model;
using ManagerStuffs.Querys;
using ManagerStuffs.Querys.Stuffs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStuffs.Dao.StuffsDao
{
    public class StuffsDao
    {
        private static volatile StuffsDao instance;

        private static object key = new object();

        public static StuffsDao Instance
        {
            get
            {
                lock (key)
                {
                    if (instance == null)
                    {
                        instance = new StuffsDao();
                    }

                    return instance;
                }
            }
        }

        private StuffsDao() { }

        // Method ListPaging
        public List<StuffsModel> ListPaging(int pageSizes, int pages = 1)
        {
            DataTable dt = DataProvider.Instance.Query(StuffsQuerys.ListPaging(pageSizes, pages));

            return HelperDao.GenerateList<StuffsModel>(dt);
        }

        // Method List
        public List<StuffsModel> List(bool? status = null)
        {
            DataTable dt = DataProvider.Instance.Query(StuffsQuerys.List(status));
            return HelperDao.GenerateList<StuffsModel>(dt);
        }

        // Method Insert
        public int Insert(StuffsModel stuff, string[] paramters)
        {
            Dictionary<string, object> dicParamters = HelperDao.GenerateParameter<StuffsModel>(stuff, paramters);

            return DataProvider.Instance.Execute(StuffsQuerys.Insert(paramters), dicParamters);
        }

        // Method CheckExist
        public int CheckExist(StuffsModel stuff, string[] parameters)
        {
            Dictionary<string, object> dicParameters = HelperDao.GenerateParameter<StuffsModel>(stuff, parameters);

            return DataProvider.Instance.Count(StuffsQuerys.CheckExsist(parameters, stuff.Id), dicParameters);
        }

        // Method DeleteStuffs
        public int DeleteStuffs(int[] ids)
        {
            int execute = 0;

            foreach(int id in ids)
            {
                DataProvider.Instance.Execute(StuffsQuerys.DeleteStuffsPlaceStuffs(id));

                execute += DataProvider.Instance.Execute(StuffsQuerys.Delete(id));
            }

            return execute;
        }

        // Method Insert
        public int Edit(StuffsModel stuff, string[] paramters)
        {
            Dictionary<string, object> dicParamters = HelperDao.GenerateParameter<StuffsModel>(stuff, paramters);

            return DataProvider.Instance.Execute(StuffsQuerys.Edit(paramters, stuff.Id), dicParamters);
        }

        // Method ListForExcel
        public List<StuffsModel> ListForExcel(string keyword, string sortColumn, string sortBy, string columnFilter, object filterValue)
        {
            DataTable dt = DataProvider.Instance.Query(StuffsQuerys.ListForExcel(keyword, sortColumn, sortBy, columnFilter, filterValue));

            return HelperDao.GenerateList<StuffsModel>(dt);
        }

        // Method ListDataByColumn
        public List<string> ListDataByColumn(string column)
        {
            DataTable dt = DataProvider.Instance.Query(StuffsQuerys.ListDataByColumn(column));

            List<string> data = new List<string>();

            foreach(DataRow row in dt.Rows)
            {
                data.Add(row[column].ToString());
            }

            return data;
        }

        // Method ListStuffsNotHavePlacePaging
        public List<StuffsModel> ListStuffsNotHavePlace()
        {
            DataTable dt = DataProvider.Instance.Query(StuffsQuerys.ListStuffsNotHavePlace());

            return HelperDao.GenerateList<StuffsModel>(dt);
        }

        // Method ListStuffsByPlaceStuff
        public List<StuffsModel> ListStuffsByPlaceStuff(int idPlaceStuff)
        {
            DataTable dt = DataProvider.Instance.Query(StuffsQuerys.ListStuffsByPlaceStuff(idPlaceStuff));

            return HelperDao.GenerateList<StuffsModel>(dt);
        }
    }
}
