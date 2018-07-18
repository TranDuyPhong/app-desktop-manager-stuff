using ManagerStuffs.Constants;
using ManagerStuffs.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStuffs.Bll.StuffsPlaceStuffsBll
{
    public class StuffsPlaceStuffsBll
    {
        private static volatile StuffsPlaceStuffsBll instance;

        private static object key = new object();

        public static StuffsPlaceStuffsBll Instance
        {
            get
            {
                lock (key)
                {
                    if (instance == null)
                    {
                        instance = new StuffsPlaceStuffsBll();
                    }

                    return instance;
                }
            }
        }

        private StuffsPlaceStuffsBll() { }

        // Method Insert
        public GlobalConstants.ResponseResult Insert(int idPlaceStuff, int[] stuffs)
        {
            GlobalConstants.ResponseResult res = new GlobalConstants.ResponseResult();

            int excute = StuffsPlaceStuffsDao.Instance.Insert(idPlaceStuff, stuffs);

            if(excute == stuffs.Length)
            {
                res.TypeResponse = GlobalConstants.EnumResponse.InsertSuccess;
            }
            else
            {
                res.TypeResponse = GlobalConstants.EnumResponse.InsertFail;
            }

            return res;
        }

        // Method Delete
        public GlobalConstants.ResponseResult Delete(int idPlaceStuff, int[] stuffs)
        {
            GlobalConstants.ResponseResult res = new GlobalConstants.ResponseResult();

            int excute = StuffsPlaceStuffsDao.Instance.Delete(idPlaceStuff, stuffs);

            if (excute == stuffs.Length)
            {
                res.TypeResponse = GlobalConstants.EnumResponse.DeleteSuccess;
            }
            else
            {
                res.TypeResponse = GlobalConstants.EnumResponse.DeleteFail;
            }

            return res;
        }
    }
}
