namespace Tellurian.WagonCardApp.Shared;

public class CargoWagon : Vehicle
{
    public string Description { get; set; } = string.Empty;
    public double LoadLimit { get; set; }
    public double LoadVolume { get; set; }

    public int InteroperatbilityNumber { get; set; }
    public bool IsRivConformant { get; set; }
    public bool IsTenConformant { get; set; }
    public int CountryRegistrationNumber { get; set; }
    public bool IsFlatWagon { get; set; }
    public string? WagonColor { get; set; }

    public override string UicCheckDigit => GetUicChecksum();

    public string FullVehicleNumber => $"{VehicleNumber}{UicCheckDigit}";

    static readonly int[] multipliers = { 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 };

    private string GetUicChecksum()
    {
        if (UseUicNumber && ! HasChecksum)
        {
            var checksum = CalculateUicCheckSum();
            if (checksum is null) return string.Empty;
            return $"-{checksum}";
        }
        else return string.Empty;

    }
    private int? CalculateUicCheckSum()
    {
        var digits = $"{InteroperatbilityNumber}{CountryRegistrationNumber}{VehicleNumber}".Where(c => char.IsDigit(c)).Select(c => c - '0').ToArray();
        if (digits.Length != multipliers.Length) return null;
        var sums = new int[11];
        for (int i = 0; i < digits.Length; i++)
        {
            sums[i] += digits[i] * multipliers[i];
            if (sums[i] > 9) sums[i] -= 9;
        }
        //var checkdigits = string.Join("", sums.ToString());
        var checksum = sums.Sum();
        return 10 - checksum % 10;
    }

    public bool UseUicNumber => InteroperatbilityNumber > 0 && CountryRegistrationNumber > 0 && VehicleNumber.Count(c => char.IsDigit(c)) >= 7;
    private bool HasChecksum => VehicleNumber.Length > 0 && VehicleNumber.Contains('-');


    public HomeStation HomeStation { get; set; } = new();

    public bool HasHomeStation => !string.IsNullOrWhiteSpace(HomeStation?.Name);

    public override string BackColor => FrameColor;
    public override string ForeColor => FrameColor.TextColor();

    public string Interoperability => $"{InteroperatbilityNumber} {RivAndOrTen} ";
    public string Country => $"{CountryRegistrationNumber}";

    private string RivAndOrTen =>
        IsRivConformant && IsTenConformant ? "TEN-RIV" :
        IsRivConformant ? "RIV" :
        IsTenConformant ? "TEN" :
        string.Empty;

    private char MainClass => VehicleClass.Length > 0 ? VehicleClass.ToUpperInvariant()[0] : ' ';

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

    public string FrameColor => MainClass switch
    {
        'D' => D,
        'E' => E,
        'F' => F,
        'G' => G,
        'H' => H,
        'I' => I,
        'K' => KL,
        'L' => L,
        'O' => KL,
        'Q' => QLZ,
        'R' => RS,
        'S' => RS,
        'T' => T,
        'U' => ULZ,
        'Z' => Z,
        _ => "#000000"
    };

    private const string D = "#4d4dff";
    private const string E = "#fd9bce";
    private const string F = "#ff60ff";
    private const string G = "#fefe9a";
    private const string H = "#fccca4";
    private const string I = "#fefefe";
    private const string K = "#cffed0";
    private const string L = "#b3d9ff";
    private const string RS = "#339967";
    private const string T = "#fccd03";
    private const string Z = "#c0c0c0";
    private string KL => ClassIs("Kö") ? L : K;
    private string QLZ => ClassIs("Q12") || ClassIs("Q14") ? Z : L;
    private string ULZ => ClassIs("Ua") || ClassIs("Ud") ? L : Z;

    private bool ClassIs(string value) =>
        VehicleClass.StartsWith(value, StringComparison.OrdinalIgnoreCase);

    public static CargoWagon Default => new();

    public static CargoWagon Example =>
        new()
        {
            Description = "Fliscontainervagn FINSAM",
            Epoch = "V-VI",
            Length = 20.7f,
            LoadLimit = 23.5,
            LoadVolume = 50.0,
            MaxSpeed = 100,
            SpeedUnit = SpeedUnit.KmPerHour,
            OperatingFromYear = 1988,
            OperatingUptoYear = 2010,
            CountryRegistrationNumber = 76,
            InteroperatbilityNumber = 31,
            IsRivConformant = true,
            OperatorSignature = "NSB",
            VehicleClass = "Rps",
            VehicleNumber = "393 3 013",
            WagonColor = "#570000",
            ModelImageUrl = "https://www.modellbahnshop-lippe.com/article_data/images/73/211190_e.jpg",
            OriginalImageUrl = "https://www.modellbahnshop-lippe.com/article_data/images/73/211190_e.jpg",
            ModelManufacturer = "NMJ",
            ModelNumber = "123-456",
            Marking = new()
            {
                Color1 = "#FF7700",
                Color2 = "#00FF77",
                Color3 = "#7700FF",
                InventoryNumber = "",
                IconHref = "http://cdn.onlinewebfonts.com/svg/img_2382.png"
            },
            HomeStation = new()
            {
                Name = "Kongsvinger",
                Region = (int)Region.Red,
                CountryCode = "NO"
            }
        };
}

public class HomeStation
{
    public string Name { get; set; } = string.Empty;
    public int Region { get; set; }
    public string? CountryCode { get; set; }
}

public enum Region
{
    NotSpecified = 0,
    Yellow = 1,
    Red = 2,
    Green = 3,
    Blue = 4,
    Brown = 5,
    Black = 6,
    Orange = 7
}

public static class RegionExtensions
{
    public static string Color(this int it) => ((Region)it).Color();
    public static string Color(this Region me) => me switch
    {
        Region.Yellow => "#ffff00",
        Region.Red => "#ff0000",
        Region.Green => "#009933",
        Region.Black => "#000000",
        Region.Blue => "#0000ff",
        Region.Brown => "#993300",
        Region.Orange => "#ff9933",
        _ => "#ffffff"
    };

    public static IEnumerable<(int Id, string ResourceKey)> Regions => ((Region[])Enum.GetValues(typeof(Region))).Select(v => ((int)v, v.ToString()));
    public static IEnumerable<string> CountryCodes => new[] { "", "AT", "BE", "CH", "CZ", "DA", "DE", "ES", "FI", "FR", "HU", "IT", "NL", "NO", "PL", "SE", "UK" };
}
