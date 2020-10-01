using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TransactionsImporter.Common.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Select attributes for enum value
        /// </summary>
        /// <param name="enum">Enum value</param>
        /// <typeparam name="TAttr">Selected attribute type</typeparam>
        /// <returns>Attributes sequence</returns>
        public static IEnumerable<TAttr> SelectAttributes<TAttr>(this Enum @enum)
            where TAttr : Attribute =>
            @enum
                .GetType()
                .GetMember(@enum.ToString())
                .Where(mi => mi.MemberType == MemberTypes.Field)
                .SelectMany(mi => mi.GetCustomAttributes(typeof(TAttr), false).Cast<TAttr>());
    }
}