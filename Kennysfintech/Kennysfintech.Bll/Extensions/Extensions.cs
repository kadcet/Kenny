using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kennysfintech.Bll.Extensions
{
    public static class Extensions
    {
        #region AttributeAcıklamaExtension
        public static string? EnumAciklamasiniGetir(this Enum deger)
        {
            if (deger == null) return "";

            var descriptionAttribute = deger.GetType()
                .GetMember(deger.ToString() ?? string.Empty)
                .FirstOrDefault()
                ?.GetCustomAttribute<DescriptionAttribute>();

            return descriptionAttribute?.Description;

        }

        public static string Tarih(this DateTime dt)
        {
            return (dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second).ToString();
        }
        #endregion

    }
}
