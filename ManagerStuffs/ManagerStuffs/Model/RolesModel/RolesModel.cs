using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStuffs.Model.RolesModel
{
    public class RolesModel
    {
        [PropertyName(Name = "ID")]
        public int Id { get; set; }

        [PropertyName(Name = "NAME")]
        public string Name { get; set; }
    }
}
