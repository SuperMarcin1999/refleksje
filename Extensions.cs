#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refleksje
{
    public static class Extensions
    {
        public static void SetValue(this object obj, string propertyName, string? propertyValue)
        {
            var objType = obj.GetType();
            var property = objType.GetProperty(propertyName);

            if (property != null && property.CanWrite)
                property.SetValue(obj, propertyValue);
        }

        public static void SetValue<T>(this T obj, string propertyName, string? propertyValue)
        {
            var objType = typeof(T);
            var property = objType.GetProperty(propertyName);

            if (property != null && property.CanWrite)
                property.SetValue(obj, propertyValue);
        }
    }
}
