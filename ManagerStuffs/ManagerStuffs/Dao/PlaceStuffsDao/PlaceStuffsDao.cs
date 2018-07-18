using ManagerStuffs.Model.PlaceStuffsModel;
using ManagerStuffs.Querys.PlaceStuffsQuerys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStuffs.Dao.PlaceStuffsDao
{
    public class PlaceStuffsDao
    {
        private static volatile PlaceStuffsDao instance;

        private static object key = new object();

        public static PlaceStuffsDao Instance
        {
            get
            {
                lock (key)
                {
                    if (instance == null)
                    {
                        instance = new PlaceStuffsDao();
                    }

                    return instance;
                }
            }
        }

        private PlaceStuffsDao() { }

        // Method List
        public List<PlaceStuffsModel> List()
        {
            DataTable dt = DataProvider.Instance.Query(PlaceStuffsQuerys.List());

            return HelperDao.GenerateList<PlaceStuffsModel>(dt);
        }

        // Method CheckExist
        public int CheckExist(PlaceStuffsModel placeStuff, string[] parameters)
        {
            Dictionary<string, object> dicParameters = HelperDao.GenerateParameter<PlaceStuffsModel>(placeStuff, parameters);

            return DataProvider.Instance.Count(PlaceStuffsQuerys.CheckExsist(parameters, placeStuff.Id), dicParameters);
        }

        // Method Insert
        public int Insert(PlaceStuffsModel placeStuff, string[] parameters)
        {
            Dictionary<string, object> dicParamters = HelperDao.GenerateParameter<PlaceStuffsModel>(placeStuff, parameters);

            return DataProvider.Instance.Execute(PlaceStuffsQuerys.Insert(parameters), dicParamters);
        }

        // Method Edit
        public int Edit(PlaceStuffsModel placeStuff, string[] paramters)
        {
            Dictionary<string, object> dicParameters = HelperDao.GenerateParameter<PlaceStuffsModel>(placeStuff, paramters);

            return DataProvider.Instance.Execute(PlaceStuffsQuerys.Edit(paramters, placeStuff.Id), dicParameters);
        }

        // Method CheckForeignKey
        public int CheckForeignKey(int id)
        {
            return DataProvider.Instance.Count(PlaceStuffsQuerys.CheckForeignKey(id));
        }

        // Method Delete
        public int Delete(PlaceStuffsModel placeStuff, string[] parameters)
        {
            Dictionary<string, object> dicParameters = HelperDao.GenerateParameter<PlaceStuffsModel>(placeStuff, parameters);

            return DataProvider.Instance.Execute(PlaceStuffsQuerys.Delete(parameters), dicParameters);
        }

        // Method ListForExcel
        public List<PlaceStuffsModel> ListForExcel(string keyword, string sortColumn, string sortBy)
        {
            DataTable dt = DataProvider.Instance.Query(PlaceStuffsQuerys.ListForExcel(keyword, sortColumn, sortBy));

            return HelperDao.GenerateList<PlaceStuffsModel>(dt);
        }
    }
}
