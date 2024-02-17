namespace Tellurian.WagonCardApp.Shared;

public abstract class Vehicle
{
    public string OperatorSignature { get; set; } = string.Empty;
    public ImageFile? OperatorLogo { get; set; }
    public string VehicleClass { get; set; } = string.Empty;
    public int InteroperatbilityNumber { get; set; }
    public int CountryRegistrationNumber { get; set; }

    public string VehicleNumber { get; set; } = string.Empty;
    public string Epoch { get; set; } = string.Empty;
    public string? UicMainClass { get; set; }

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
    public string? WheelType { get; set; }

    public virtual string ForeColor => "#000000";
    public virtual string BackColor => "#FFFFFF";

    public abstract string FrameColor { get; }

    public Marking Marking { get; set; } = new();
    public PrintOptions PrintOptions { get; set; } = new();
    public Owner Owner { get; set; } = new();

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
    public static string BulletVehicleClass(this Vehicle me) => $"• {me.VehicleClass}";

    public static string Country(this Vehicle me) => $"{me.CountryRegistrationNumber}";

    public static string MainClass(this Vehicle me) => me.MainClassLetter().ToString().ToUpperInvariant();
    private static char MainClassLetter(this Vehicle me) =>
        me.UicMainClass?.Length > 0 ? me.UicMainClass[0] : me.VehicleClass.Length > 0 ? me.VehicleClass[0] : ' ';

    public static string Identification(this Vehicle? me) => me is null ? string.Empty :
        $"{me.CountryCode()}{me.OperatorSignature} {me.VehicleClass} {me.VehicleNumber}{me.CheckDigit()}".Trim();

    public static string UicNumber(this Vehicle? me) => me is null || !me.HasUicNumber() ? string.Empty :
        $"{me.InteroperatbilityNumber} {me.CountryRegistrationNumber} {me.VehicleNumber}{me.CheckDigit()}";
    private static string CountryCode(this Vehicle? me) => me?.CountryRegistrationNumber > 0 ?
        $"{me.CountryCodeOfRegistration}-" : string.Empty;

    public static string VehicleNumberWithControlDigit(this Vehicle? me) =>
        me is null ? string.Empty :
        $"{me.VehicleNumber}{me.CheckDigit()}";

    public static string CheckDigit(this Vehicle me)
    {
        var digits = me.ElevenDigitNumber();
        if (digits is null || digits.Length!=11) return string.Empty;
        var checksum= digits.UicCheckSum();
        if (checksum.HasValue) return $"-{checksum}";
        return string.Empty;
      
    }

    public static string? ElevenDigitNumber(this Vehicle me)
    {
        var digits = me.VehicleNumberDigits();
        return me is null || digits.Length != 7 || me.InteroperatbilityNumber == 0 || me.CountryRegistrationNumber == 0 ? string.Empty :
        $"{me.InteroperatbilityNumber:00}{me.CountryRegistrationNumber:00}{digits}";
    }

    public static string VehicleNumberDigits(this Vehicle? me)
    {
        if (me is null) return string.Empty;
        var digits = me.VehicleNumber.Where(char.IsDigit).ToArray();
        return new string(digits);
    }
    


    public static int? UicCheckSum(this string? number)
    {
        if(number is null || number.Length != 11) return null;
        var digits = number.Select(c => c - '0').ToArray();
        return digits.UicCheckSum();
    }

    public static int? UicCheckSum(this int[] digits)
    {
        int[] multipliers = [2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2];
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

    public static bool HasUicNumber(this Vehicle it) => it.InteroperatbilityNumber > 0 && it.CountryRegistrationNumber > 0 && it.VehicleNumber.IsDigitsOrWhiteSpace() && it.VehicleNumber.NumberOfDigits() == 7;
}
