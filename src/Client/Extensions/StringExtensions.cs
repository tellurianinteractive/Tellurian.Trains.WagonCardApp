using static System.Net.Mime.MediaTypeNames;
using System.Drawing;

namespace Tellurian.WagonCardApp.Client.Extensions;

public static class StringExtensions
{
    public static string LongHeadingStyle(this string? text) => text is null || text.Length < 25 ? "font-size: 24pt" : "fontfont-size: 20pt; font-family: Arial Narrow";
    public static string ShortHeadingStyle(this string? text) => text is null || text.Length < 12 ? "font-size: 24pt" : $"font-size: {(int)(24 - text.Length / 3.9)}pt; font-family: Arial Narrow";
    public static string WagonNumberFontSize(this string? text) => text is null || text.Length < 12 ? "20pt" : $"{18 - text.Length / 5}pt";

    public static string FredStickerOperatorFontSize(this string? text) => text is null || text.Length < 6 ? "16pt" : $"{18 - text.Length * 1}pt";
    public static string FredStickerLocoNumberFontSize(this string? text) => text is null || text.Length < 6 ? "16pt" : $"{20 - text.Length * 1}pt";
    public static string FredStickerLocoClassFontSize(this string? text) => text is null || text.Length < 6 ? "16pt" : $"{24 - text.Length * 2}pt";
    public static string HomeStationLabel(this string? language) => language switch
    {
        "DE" => "Banhof/Home station",
        "SE" => "Hemstation/Home station",
        "NO" => "Hjemstasjon/Home station",
        "DK" => "Hjemstation/Home station",
        _ => "Home station"
    };
}
