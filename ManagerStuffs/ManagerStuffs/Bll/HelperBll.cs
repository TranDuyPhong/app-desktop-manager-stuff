using ManagerStuffs.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStuffs.Bll
{
    public static class HelperBll
    {
        // Method GetColumnNameInSQLByPropertyName
        public static string GetColumnNameInSQLByPropertyName<T>(string propertyName)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));

            PropertyNameAttribute propName = properties.Cast<PropertyDescriptor>().Where(p => (PropertyNameAttribute)p.Attributes[typeof(PropertyNameAttribute)] != null && p.DisplayName == propertyName).Select(p => ((PropertyNameAttribute)p.Attributes[typeof(PropertyNameAttribute)])).FirstOrDefault();

            if(propName != null)
            {
                return propName.Name;
            }

            return "";
        }

        // Method GetTypeOfProperty
        public static Type GetTypeOfProperty<T>(string propertyName)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));

            PropertyDescriptor prop = properties.Cast<PropertyDescriptor>().Where(p => p.DisplayName == propertyName).FirstOrDefault();

            if (prop != null)
            {
                return prop.PropertyType;
            }

            return null;
        }
    }
}
