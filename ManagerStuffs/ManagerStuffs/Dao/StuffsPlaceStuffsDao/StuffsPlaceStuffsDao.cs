using ManagerStuffs.Querys.StuffsPlaceStuffsQuerys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStuffs.Dao
{
    public class StuffsPlaceStuffsDao
    {
        private static volatile StuffsPlaceStuffsDao instance;

        private static object key = new object();

        public static StuffsPlaceStuffsDao Instance
        {
            get
            {
                lock (key)
                {
                    if (instance == null)
                    {
                        instance = new StuffsPlaceStuffsDao();
                    }

                    return instance;
                }
            }
        }

        private StuffsPlaceStuffsDao() { }

        // Method Insert
        public int Insert(int placeStuff, int[] stuffs)
        {
            int execute = 0;

            foreach(int i in stuffs)
            {
                execute += DataProvider.Instance.Execute(StuffsPlaceStuffsQuerys.Insert(placeStuff, i));
            }

            return execute;
        }

        // Method Delete
        public int Delete(int placeStuff, int[] stuffs)
        {
            int execute = 0;

            foreach (int i in stuffs)
            {
                execute += DataProvider.Instance.Execute(StuffsPlaceStuffsQuerys.Delete(placeStuff, i));
            }

            return execute;
        }
    }
}
