using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStuffs.Constants.Roles
{
    public class RoleModel
    {
        public string RoleName { get; set; }

        public int CountManipulation { get; set; }

        public override string ToString()
        {
            return RoleName;
        }
    }
}
