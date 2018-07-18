using ManagerStuffs.Model.CategoriesModel;
using ManagerStuffs.Querys.CategoriesQuerys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStuffs.Dao
{
    public class CategoriesDao
    {
        private static volatile CategoriesDao instance;

        private static object key = new object();

        public static CategoriesDao Instance
        {
            get
            {
                lock (key)
                {
                    if (instance == null)
                    {
                        instance = new CategoriesDao();
                    }

                    return instance;
                }
            }
        }

        private CategoriesDao() { }

        // Method List
        public List<CategoriesModel> List(bool? status = null)
        {
            DataTable dt = DataProvider.Instance.Query(CategoriesQuerys.List(status));

            return HelperDao.GenerateList<CategoriesModel>(dt);
        }

        // Method Insert
        public int Insert(CategoriesModel category, string[] parameters)
        {
            Dictionary<string, object> dicParamters = HelperDao.GenerateParameter<CategoriesModel>(category, parameters);

            return DataProvider.Instance.Execute(CategoriesQuerys.Insert(parameters), dicParamters);
        }

        // Method CheckExist
        public int CheckExist(CategoriesModel category, string[] parameters)
        {
            Dictionary<string, object> dicParameters = HelperDao.GenerateParameter<CategoriesModel>(category, parameters);

            return DataProvider.Instance.Count(CategoriesQuerys.CheckExsist(parameters, category.Id), dicParameters);
        }

        // Method Delete
        public int Delete(CategoriesModel category, string[] parameters)
        {
            Dictionary<string, object> dicParameters = HelperDao.GenerateParameter<CategoriesModel>(category, parameters);

            return DataProvider.Instance.Execute(CategoriesQuerys.Delete(parameters), dicParameters);
        }

        // Method CheckForeignKey
        public int CheckForeignKey(int id)
        {
            return DataProvider.Instance.Count(CategoriesQuerys.CheckForeignKey(id));
        }

        // Method Edit
        public int Edit(CategoriesModel category, string[] paramters)
        {
            Dictionary<string, object> dicParameters = HelperDao.GenerateParameter<CategoriesModel>(category, paramters);

            return DataProvider.Instance.Execute(CategoriesQuerys.Edit(paramters, category.Id), dicParameters);
        }

        // Method ListForExcel
        public List<CategoriesModel> ListForExcel(string keyword, string sortColumn, string sortBy)
        {
            DataTable dt = DataProvider.Instance.Query(CategoriesQuerys.ListForExcel(keyword, sortColumn, sortBy));

            return HelperDao.GenerateList<CategoriesModel>(dt);
        }
    }
}
