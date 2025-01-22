using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ShortLink.Shared.Extensions
{
    public static class EnumExtension
    {
        /// <summary>
        /// The GetDescription method allows fetching a custom description for an enum value
        /// using the DescriptionAttribute provided by System.ComponentModel.
        /// This is useful when displaying more user-friendly or readable names for enum values
        /// in a UI or logs.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            FieldInfo? fieldInfo = value.GetType().GetField(value.ToString());
            DescriptionAttribute? descriptionAttribute = fieldInfo?.GetCustomAttribute<DescriptionAttribute>();
            return descriptionAttribute?.Description ?? value.ToString();
        }
    }
}
