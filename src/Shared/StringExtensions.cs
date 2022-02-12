using Markdig;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Tellurian.WagonCardApp.Shared;

public static class StringExtensions
{
    public static bool HasValue(this string? value) => !string.IsNullOrWhiteSpace(value);
    public static string FromMarkdown(this string? markdown)
    {
        if (string.IsNullOrWhiteSpace(markdown)) return string.Empty;
        return Markdown.ToHtml(markdown, Pipeline());

        static MarkdownPipeline Pipeline()
        {
            var builder = new MarkdownPipelineBuilder();
            builder.UseAdvancedExtensions();
            return builder.Build();
        }
    }
    public static string TextColor(this string? backColor)
    {
        if (backColor.IsHexColor())
        {
            var r = int.Parse(backColor.Substring(1, 2), System.Globalization.NumberStyles.HexNumber);
            var g = int.Parse(backColor.Substring(3, 2), System.Globalization.NumberStyles.HexNumber);
            var b = int.Parse(backColor.Substring(5, 2), System.Globalization.NumberStyles.HexNumber);
            var yiq = (r * 299 + g * 587 + b * 114) / 1000;
            return yiq >= 128 ? "#000000" : "#FFFFFF";
        }
        return "#000000";
    }

    public static string DarkTextColor(this string? textColor) =>
        textColor.IsHexColor() && "#FFFFFF".Equals(textColor.TextColor(), StringComparison.OrdinalIgnoreCase) ? textColor : "#000000";
    private static string HexColorRegEx => "^#([A-Fa-f0-9]{6})$";

    public static bool IsHexColor([NotNullWhen(true)] this string? maybeColor) =>
        !string.IsNullOrWhiteSpace(maybeColor) && Regex.IsMatch(maybeColor, HexColorRegEx);

    public static bool IsDigitsOrWhiteSpace(this string? value) =>
        !string.IsNullOrWhiteSpace(value) && value.All(c => char.IsDigit(c) || char.IsWhiteSpace(c));

    public static int NumberOfDigits(this string? value) =>
        string.IsNullOrWhiteSpace(value) ? 0 :
        value.Count(c => char.IsDigit(c));

}
