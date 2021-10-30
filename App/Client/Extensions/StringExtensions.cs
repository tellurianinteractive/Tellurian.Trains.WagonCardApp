namespace WagonCardApp.Client.Extensions
{
    public static class StringExtensions
    {
        public static string LongHeadingFontSize(this string? text) => text is null || text.Length < 30 ? "24pt" : "20pt";
        public static string ShortHeadingFontSize(this string? text) => text is null || text.Length < 17 ? "24pt" : $"{22-text.Length/5}pt";
        public static string WagonNumberFontSize(this string? text) => text is null || text.Length < 12 ? "24pt" : $"{20 - text.Length / 5}pt";
    }
}
