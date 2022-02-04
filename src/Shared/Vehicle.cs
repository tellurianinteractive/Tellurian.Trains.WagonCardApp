namespace Tellurian.WagonCardApp.Shared;

public abstract class Vehicle
{
    public string OperatorSignature { get; set; } = string.Empty;
    public string VehicleClass { get; set; } = string.Empty;
    public int InteroperatbilityNumber { get; set; }
    public int CountryRegistrationNumber { get; set; }

    public string VehicleNumber { get; set; } = string.Empty;
    public string Epoch { get; set; } = string.Empty;
    public int? OperatingFromYear { get; set; }
    public int? OperatingUptoYear { get; set; }
    public int? MaxSpeed { get; set; }
    public SpeedUnit SpeedUnit { get; set; }

    public float? Length { get; set; }
    public ImageFile? OriginalImage { get; set; }
    public string? OriginalImageUrl { get; set; }
    public ImageFile? ModelImage { get; set; }
    public string? ModelImageUrl { get; set; }
    public string ModelManufacturer { get; set; } = string.Empty;
    public string ModelNumber { get; set; } = string.Empty;

    public virtual string ForeColor => "#000000";
    public virtual string BackColor => "#FFFFFF";
    public virtual string UicCheckDigit => string.Empty;

    public Marking Marking { get; set; } = new();
    public string CountryCodeOfRegistration => CountryRegistrationNumber switch
    {
        70 => "UK",
        71 => "E",
        72 => "SRB",
        73 => "GR",
        74 => "S",
        75 => "TR",
        76 => "N",
        78 => "HR",
        79 => "SLO",
        80 => "D",
        81 => "A",
        82 => "L",
        83 => "I",
        84 => "NL",
        85 => "CH",
        86 => "DK",
        87 => "F",
        88 => "B",
        _ => string.Empty
    };

}

public enum SpeedUnit
{
    KmPerHour,
    MilesPerHour
}

public static class VehicleExtensions
{
    public static string Identification(this Vehicle? me) => me is null ? string.Empty : 
        $"{me.CountryCode()}{me.OperatorSignature} {me.VehicleClass} {me.VehicleNumber}{me.UicCheckDigit}".Trim();

    private static string CountryCode(this Vehicle? me) => me?.CountryRegistrationNumber > 0 ?
        $"{me.CountryCodeOfRegistration}-" : string.Empty;


}
