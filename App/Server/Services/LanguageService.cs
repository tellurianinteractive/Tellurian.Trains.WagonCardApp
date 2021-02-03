using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace WagonCardApp.Server.Services
{
    public static class LanguageService
    {
        public const string DefaultLanguage = "en";
        public static CultureInfo CurrentCulture => System.Threading.Thread.CurrentThread.CurrentCulture;
        public static CultureInfo DefaultCulture => new CultureInfo(DefaultLanguage);
        public static IList<CultureInfo> SupportedCultures => LanguageCultureMap.Values.ToArray();
        private static IDictionary<Language, CultureInfo> LanguageCultureMap =>
             new Dictionary<Language, CultureInfo>() {
                 { Language.English, new CultureInfo("en") },
                 { Language.Swedish, new CultureInfo("sv") },
                 { Language.Danish, new CultureInfo("da") }
                 //{ Language.Norwegian, new CultureInfo("no") },
                 //{ Language.German, new CultureInfo("de") },
                 //{ Language.Polish, new CultureInfo("pl") },
                 //{ Language.Dutch, new CultureInfo("nl") },
                 //{ Language.Czech, new CultureInfo("cs") },
             };

    }

    public enum Language
    {
        Default,
        English,
        Swedish,
        Danish,
        Norwegian,
        German,
        Polish,
        Dutch,
        Czech
    }

}
