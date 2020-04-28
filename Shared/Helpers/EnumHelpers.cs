using System;
using System.ComponentModel;
using System.Linq;

namespace Shared.Helpers
{
    public class EnumHelpers
    {
        public static string GetDescription(Enum value)
        {
            var fields = value.GetType().GetField(value.ToString());
            var attributes = fields.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
    }
}
