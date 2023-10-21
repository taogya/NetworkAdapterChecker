using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkAdapterChecker.Settings
{
    public static class GlobalSettings
    {
        public static string DefaultCultureCode { get; } = "ja";

        public static string GetLanguagePath() => GetLanguagePath(DefaultCultureCode);
        public static string GetLanguagePath(string cultureCode) => @$"Resources/language/Dictionary.{cultureCode}.xaml";
    }
}
