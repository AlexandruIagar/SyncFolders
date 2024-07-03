using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Sync.Helpers
{
    internal static class EnumHelpers
    {
        public static string GetDisplayName(this Enum @enum)
        {
            if (@enum == null)
                return null;

            var field = @enum.GetType().GetField(@enum.ToString());

            return GetDisplayName(field);
        }

        private static string GetDisplayName(FieldInfo field)
        {
            if (field == null)
                return null;

            var attrs = field.GetCustomAttributes(typeof(DisplayAttribute), false);

            return attrs != null && attrs.Any()
                ? ((DisplayAttribute)attrs.First()).GetName()
                : null;
        }
    }
}
