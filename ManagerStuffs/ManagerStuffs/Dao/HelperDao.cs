using ManagerStuffs.Model;
using ManagerStuffs.Model.CategoriesModel;
using ManagerStuffs.Model.PlaceStuffsModel;
using ManagerStuffs.Model.RolesModel;
using ManagerStuffs.Model.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStuffs.Dao
{
    public static class HelperDao
    {
        // Method GenerateList
        public static List<T> GenerateList<T>(DataTable dt)
        {
            if (dt == null)
                return null;

            List<T> list = new List<T>();

            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));

            int i = 0;

            foreach (DataRow row in dt.Rows)
            {
                T t = Activator.CreateInstance<T>();

                foreach (DataColumn column in dt.Columns)
                {
                    PropertyDescriptor prop = properties.Cast<PropertyDescriptor>().Where(p => (PropertyNameAttribute)p.Attributes[typeof(PropertyNameAttribute)] != null && ((PropertyNameAttribute)p.Attributes[typeof(PropertyNameAttribute)]).Name == column.ColumnName).FirstOrDefault();

                    if(prop != null)
                    {
                        if (string.IsNullOrEmpty(row[column.ColumnName].ToString()))
                        {
                            Type type = prop.PropertyType;

                            if (type == typeof(int))
                            {
                                prop.SetValue(t, 0);
                            }
                            else if (type == typeof(bool))
                            {
                                prop.SetValue(t, false);
                            }
                            else
                            {
                                prop.SetValue(t, null);
                            }
                        }
                        else
                        {
                            prop.SetValue(t, row[column.ColumnName]);
                        }
                    }
                }

                list.Add(t);

                i++;
            }

            return list;
        }
         
        // Method GenerateParameter
        public static Dictionary<string, object> GenerateParameter<T>(T t, string[] @parameters)
        {
            Dictionary<string, object> dicParameters = new Dictionary<string, object>();

            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));

            for (int i = 0; i < @parameters.Length; i++)
            {
                PropertyDescriptor prop = properties.Cast<PropertyDescriptor>().Where(p => (PropertyNameAttribute)p.Attributes[typeof(PropertyNameAttribute)] != null
                && $"@{((PropertyNameAttribute)p.Attributes[typeof(PropertyNameAttribute)]).Name}" == @parameters[i]).FirstOrDefault();

                if(prop != null)
                {
                    dicParameters.Add(@parameters[i], prop.GetValue(t));
                }
            }

            return dicParameters;
        }
    }
}
