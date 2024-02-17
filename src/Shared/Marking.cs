using System.Diagnostics.CodeAnalysis;

namespace Tellurian.WagonCardApp.Shared;

public class Marking
{
    public bool UseMarking { get; set; } = true;
    public bool UseColorMarking { get; set; } = false;
    public string Color1 { get; set; } = "#FFFFFF";
    public string Color2 { get; set; } = "#FFFFFF";
    public string Color3 { get; set; } = "#FFFFFF";
    public string Color4 { get; set; } = "#FFFFFF";
    public string InventoryNumber { get; set; } = string.Empty;
    public string? IconHref { get; set; }
    public string? TextLabel { get; set; }
    public ImageFile? Icon { get; set; }
}

public static class MarkingExtensions
{
    public static bool ShowColourMarkings(this Marking? it) => it.HasColourMarking();
    public static bool ShowOwnerTextLabel(this Marking? it) => it.HasTextLabel() && !it.HasColourMarking();
    public static bool ShowOwnerIcon(this Marking? it) => (it.HasOwnerIcon()|| it.HasOwnerIconHref()) && !it.HasTextLabel() && !it.HasColourMarking();
    public static bool ShowInventoryNumber(this Marking? it) => it.HasInventoryNumber();

    public static bool EditMarking(this Marking? it) => it is not null;

    private static bool HasColourMarking(this Marking? it) => it?.UseColorMarking == true;
    private static bool HasInventoryNumber(this Marking? it) => !string.IsNullOrWhiteSpace(it?.InventoryNumber);
    private static bool HasTextLabel(this Marking? it) => it?.TextLabel.HasValue() == true;

    public static bool HasOwnerIcon([NotNullWhen(true)] this Marking? it) => it?.Icon is not null ;
    public static bool HasOwnerIconHref([NotNullWhen(true)] this Marking? it) => it?.IconHref?.StartsWith("http") == true;
    public static string BackgroundColor(this Marking? it) => it.ShowColourMarkings() || it.ShowOwnerIcon() || it.ShowOwnerTextLabel() || it?.Color4.IsOtherThanWhite()==true ? "white" : it?.Color1 ?? "white";

    public static bool IsOtherThanWhite(this string? color) => color is not null && !color.Equals("#FFFFFF", StringComparison.OrdinalIgnoreCase);
}
