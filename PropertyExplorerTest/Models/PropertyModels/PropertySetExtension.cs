using PropertyExplorerTest.Defines.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyExplorerTest.Models.PropertyModels
{
    public static class PropertySetExtension
    {
        public static void Set<T>(this IPropertySet owner, T value)
        {
            try
            {
                var set = (IPropertySet<T>)owner;
                set.Value = value;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public static T Get<T>(this IPropertySet owner)
        {
            try
            {
                var set = (IPropertySet<T>)owner;
                return set.Value;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
    }
}
