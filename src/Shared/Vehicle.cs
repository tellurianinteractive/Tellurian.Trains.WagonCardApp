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
    public virtual bool UseUicNumber => this.UseUicNumber();
    public virtual string UicCheckDigit => this.CheckDigit();

    public Marking Marking { get; set; } = new();
    public PrintOptions PrintOptions { get; set; } = new();
    public string CountryCodeOfRegistration => CountryRegistrationNumber switch
    {
        10 => "FI",
        51 => "PL",
        54 => "CZ",
        55 => "HU",
        56 => "SK",
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
        94 => "PT",
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

    public static string CheckDigit(this Vehicle me)
    {
        if (me.UseUicNumber() && ! me.HasChecksum())
        {
            var checksum = me.CalculateUicCheckSum();
            if (checksum is null) return string.Empty;
            return $"-{checksum}";
        }
        return String.Empty;

    }
    public static int? CalculateUicCheckSum(this Vehicle me)
    {
        int[] multipliers = { 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 };

        var digits = $"{me.InteroperatbilityNumber}{me.CountryRegistrationNumber}{me.VehicleNumber}".Where(c => char.IsDigit(c)).Select(c => c - '0').ToArray();
        if (digits.Length != multipliers.Length) return null;
        var sums = new int[11];
        for (int i = 0; i < digits.Length; i++)
        {
            sums[i] += digits[i] * multipliers[i];
            if (sums[i] > 9) sums[i] -= 9;
        }
        //var checkdigits = string.Join("", sums.ToString());
        var checksum = sums.Sum();
        var c = 10 - checksum % 10;
        return c > 9 ? 0 : c;
    }

    private static bool HasChecksum(this Vehicle it) => it.VehicleNumber.Length > 0 && it.VehicleNumber.Contains('-');
    public static bool UseUicNumber(this Vehicle it) => it.InteroperatbilityNumber > 0 && it.CountryRegistrationNumber > 0 && it.VehicleNumber.IsDigitsOrWhiteSpace() && it.VehicleNumber.NumberOfDigits() == 7;
}
