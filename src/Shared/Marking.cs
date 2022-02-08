namespace Tellurian.WagonCardApp.Shared;

public class Marking
{
    public bool UseMarking { get; set; } = true;
    public string Color1 { get; set; } = "#FFFFFF";
    public string Color2 { get; set; } = "#FFFFFF";
    public string Color3 { get; set; } = "#FFFFFF";
    public string InventoryNumber { get; set; } = string.Empty;
    public string? IconHref { get; set; }
    public string? TextLabel { get; set; }
    public ImageFile? Icon { get; set; }
}

public static class MarkingExtensions
{
    public static bool ShowOwnerTextLabel(this Marking? it) => !it.HasInventoryNumber() && !it.HasOwnerIcon();
    public static bool ShowInventoryNumber(this Marking? it) => !it.HasOwnerIcon() && !it.HasOwnerTextLabel();
    public static bool ShowOwnerIcon(this Marking? it) => !it.HasInventoryNumber() && !it.HasOwnerTextLabel();
    public static bool ShowColourMarkings(this Marking? it) => !it.HasInventoryNumber() && !it.HasOwnerIcon() && !it.HasOwnerTextLabel();
    private static bool HasInventoryNumber(this Marking? it) => !string.IsNullOrWhiteSpace(it?.InventoryNumber);
    private static bool HasOwnerIcon(this Marking? it) => it?.IconHref?.StartsWith("http") == true;
    private static bool HasOwnerTextLabel(this Marking? it) => it?.TextLabel.HasValue() == true;
}
