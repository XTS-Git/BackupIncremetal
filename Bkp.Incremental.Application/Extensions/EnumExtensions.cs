namespace Bkp.Incremental.Application.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription<T>(this T enumValue) where T : Enum
        {
            var type = enumValue.GetType();
            var memInfo = type.GetMember(enumValue.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                var attrs = memInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                {
                    return ((System.ComponentModel.DescriptionAttribute)attrs[0]).Description;
                }
            }
            return enumValue.ToString();
        }
    }
}
