namespace Tellurian.WagonCardApp.Shared;

public abstract class Vehicle
{
    public string OperatorSignature { get; set; } = string.Empty;
    public string VehicleClass { get; set; } = string.Empty;
    public string VehicleNumber { get; set; } = string.Empty;
    public string Epoch { get; set; } = string.Empty;
    public int? OperatingFromYear { get; set; }
    public int? OperatingUptoYear { get; set; }
    public int? MaxSpeed { get; set; }
    public SpeedUnit SpeedUnit { get; set; }

    public float? Length { get; set; }
    public string? OriginalImageUrl { get; set; }
    public string? ModelImageUrl { get; set; }
    public string ModelManufacturer { get; set; } = string.Empty;
    public string ModelNumber { get; set; } = string.Empty;

    public virtual string ForeColor => "#000000";
    public virtual string BackColor => "#FFFFFF";

    public Marking Marking { get; set; } = new();
}

public enum SpeedUnit
{
    KmPerHour,
    MilesPerHour
}

public static class VehicleExtensions
{
    public static string Identification(this Vehicle? me) => me is null ? string.Empty : $"{me.OperatorSignature} {me.VehicleClass} {me.VehicleNumber}".Trim();

}
