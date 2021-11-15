using E.S.Common.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace E.S.Common.Helpers.Extensions
{
    public static class StringExtensions
    {
        public static string ToCamelCase(this string str)
        {
            return char.ToUpper(str[0]) + str.Substring(1);
        }

        public static string ToPascalCase(this string str)
        {
            return char.ToLower(str[0]) + str.Substring(1);
        }

        public static string ToCaseStyle(this string str, CaseStyleType caseStyleType)
        {
            switch (caseStyleType)
            {
                case CaseStyleType.None:
                    return str;
                case CaseStyleType.PascalCase:
                    return str.ToPascalCase();
                case CaseStyleType.CamelCase:
                    return str.ToCamelCase();
            }

            return str;
        }
    }
}
