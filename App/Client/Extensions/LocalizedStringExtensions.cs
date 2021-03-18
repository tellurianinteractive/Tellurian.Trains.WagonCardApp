using Microsoft.Extensions.Localization;

namespace WagonCardApp.Client.Extensions
{
    public static class LocalizedStringExtensions
    {
        public static string Label(this IStringLocalizer me, string label, string? english=null)
        {
            var text = me[label].Value;
            if (english is null) english = label;
            return text.Equals(english) ? text : $"{text}/{english}";
        }
    }
}
