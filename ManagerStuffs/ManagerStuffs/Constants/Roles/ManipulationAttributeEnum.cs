using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStuffs.Constants
{
    public static class ManipulationAttributeEnum
    {
        // Method GetDescription
        public static string GetDescription(this Enum value)
        {
            DescriptionAttribute[] desAttrs = (DescriptionAttribute[])(value.GetType().GetField(value.ToString())).GetCustomAttributes(typeof(DescriptionAttribute), false);

            return desAttrs[0].Description;
        }

        // Method GetControlName
        public static string GetControlName(this Enum value)
        {
            RoleControlNameAttribute[] roleAttrs = (RoleControlNameAttribute[])(value.GetType().GetField(value.ToString())).GetCustomAttributes(typeof(RoleControlNameAttribute), false);

            return roleAttrs[0].Name;
        }
    }
}
