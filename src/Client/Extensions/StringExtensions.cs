namespace Tellurian.WagonCardApp.Client.Extensions;

public static class StringExtensions
{
    public static string LongHeadingFontSize(this string? text) => text is null || text.Length < 30 ? "24pt" : "20pt";
    public static string ShortHeadingFontSize(this string? text) => text is null || text.Length < 12 ? "24pt" : $"{(int)(24 - text.Length / 3)}pt";
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
