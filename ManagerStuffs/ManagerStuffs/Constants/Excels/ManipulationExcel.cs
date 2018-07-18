using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStuffs.Constants.Excels
{
    public class ManipulationExcel
    {
        public static void ListTablesForComboBox(MetroComboBox cbb)
        {
            cbb.DataSource = null;

            cbb.DataSource = ManipulationTable.Tables;

            cbb.DisplayMember = "DisplayName";
            cbb.ValueMember = "Schema";
        }
    }
}
