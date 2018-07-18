using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStuffs.Constants.Excels
{
    public class ManipulationTable
    {
        private static List<TableModel> tables = new List<TableModel>
        {
            new TableModel { Schema = "USERS", DisplayName = "Danh sách tài khoản" },
            new TableModel { Schema = "ROLES", DisplayName = "Danh sách quyền" },
            new TableModel { Schema = "STUFFS", DisplayName = "Danh sách vật tư" },
            new TableModel { Schema = "CATEGORIES", DisplayName = "Danh sách danh mục" },
            new TableModel { Schema = "PLACESTUFFS", DisplayName = "Danh sách nơi" },
            new TableModel { Schema = "STUFFSPLACESTUFFS", DisplayName = "Danh sách nơi để vật tư" }
        };

        public static List<TableModel> Tables
        {
            get
            {
                return tables;
            }
        }
    }
}
