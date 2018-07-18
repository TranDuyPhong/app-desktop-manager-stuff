using ManagerStuffs.Constants;
using ManagerStuffs.Dao.RolesDao;
using ManagerStuffs.Model.RolesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStuffs.Bll.RolesBll
{
    public class RolesBll
    {
        private static volatile RolesBll instance;

        private static object key = new object();

        public static RolesBll Instance
        {
            get
            {
                lock (key)
                {
                    if (instance == null)
                    {
                        instance = new RolesBll();
                    }

                    return instance;
                }
            }
        }

        private RolesBll() { }

        // Method Insert
        public GlobalConstants.ResponseResult Insert(string name)
        {
            GlobalConstants.ResponseResult res = new GlobalConstants.ResponseResult();

            name = name.Trim();

            int execute = RolesDao.Instance.Insert(new RolesModel
            {
                Name = name
            });

            if(execute == 1)
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
        public GlobalConstants.ResponseResult Delete(string name)
        {
            GlobalConstants.ResponseResult res = new GlobalConstants.ResponseResult();

            name = name.Trim();

            int count = RolesDao.Instance.CheckForeignKey(new RolesModel
            {
                Name = name
            });

            if(count > 0)
            {
                res.TypeResponse = GlobalConstants.EnumResponse.ForeignKey;

                return res;
            }

            int execute = RolesDao.Instance.Delete(new RolesModel
            {
                Name = name
            });

            if(execute > 0)
            {
                res.TypeResponse = GlobalConstants.EnumResponse.DeleteSuccess;
            }
            else
            {
                res.TypeResponse = GlobalConstants.EnumResponse.InsertFail;
            }

            return res;
        }
    }
}
