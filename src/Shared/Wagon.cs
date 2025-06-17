using System.Runtime.InteropServices;
using System.Text;

namespace Tellurian.WagonCardApp.Shared;

public class Wagon : Vehicle
{
    public bool IsPassengerWagon { get; set; }
    public bool IsCargoWagon => !IsPassengerWagon;
    public string Description { get; set; } = string.Empty;
    public double LoadLimit { get; set; }
    public double LoadVolume { get; set; }
    public double LoadArea { get; set; }
    public string? LoadingInstructions { get; set; }
    public bool IsEuropConformant { get; set; }
    public bool IsInterfrigoConformant { get; set; }
    public bool IsMcConformant { get; set; }
    public bool IsOpwConformant { get; set; }
    public bool IsRivConformant { get; set; }
    public bool IsTenConformant { get; set; }
    public bool IsFlatWagon { get; set; }
    public string? WagonColor { get; set; }
    public int? ModelWeight { get; set; }
    public string? ModelWeightGrams => ModelWeight.HasValue ? $"{ModelWeight.Value}g" : null;

    public HomeStation HomeStation { get; set; } = new();
    public override string BackColor => FrameColor;
    public override string ForeColor => FrameColor.TextColor();
    public string Interoperability => InteroperatbilityNumber > 0 ? $"{InteroperatbilityNumber:00} {Conformance}" : Conformance;
    public override string FrameColor => IsPassengerWagon ? PassengerWagonFrameColor : CargoWagonFrameColor;

    private string Conformance => BuildConformance();


    private string BuildConformance()
    {
        var text = new StringBuilder(20);
        if (IsMcConformant) { text.Append("MC-"); }
        if (IsRivConformant) { text.Append("RIV-");  }
        if (IsTenConformant) { text.Append("TEN-"); }
        if (IsInterfrigoConformant) { text.Append("IF-");  }
        if (IsOpwConformant) { text.Append("OPW-"); }
        if (IsEuropConformant) { text.Append("EUROP-");  }
        return text.ToString()[0..(text.Length > 0 ? text.Length - 1 : 0)];
    }

    private string PassengerWagonFrameColor => this.MainClass()[0] switch
    {
        'P' => OperatorSignature.Is("OHJ") ? D : None,
        'B' => VehicleClass.StartsWith("BC") ? BCWLRS : ABC,
        'D' => D,
        'F' => D,
        'R' => BCWLRS,
        'S' => BCWLRS,
        'Q' => QLZ,
        'U' => ULZ,
        'W' => BCWLRS,
        _ => ABC,
    };

    private string CargoWagonFrameColor => this.MainClass()[0] switch
    {
        'E' => E,
        'F' => F,
        'G' => G,
        'H' => H,
        'I' => I,
        'K' => KL,
        'L' => L,
        'M' => ULZ,
        'O' => KL,
        'Q' => QLZ,
        'R' => RS,
        'S' => RS,
        'T' => T,
        'U' => ULZ,
        'Z' => Z,
        _ => "#000000"
    };

    private const string ABC = "#008000"; // Green
    private const string D = "#663300"; // Brown
    private const string E = "#fd9bce"; // Light pink
    private const string F = "#ff60ff"; // Pink
    private const string G = "#fefe9a"; // Yellow
    private const string H = "#fccca4"; // Gold
    private const string I = "#fefefe"; // White
    private const string K = "#cffed0"; // Light green
    private const string L = "#b3d9ff"; // Light blue
    private const string RS = "#339967"; // Green
    private const string T = "#fccd03"; // Yellow
    private const string U = "#ff0000"; // Red
    private const string BCWLRS = "#800080"; // Purple
    private const string Z = "#c0c0c0"; // Gray
    private const string None = "#FFFFFF";
    private string KL => ClassIs("Kö") ? L : K;
    private string QLZ => ClassIs("Q12") || ClassIs("Q14") ? Z :
        ClassIs("Q") ? D : L;
    private string ULZ =>
        ClassIs("Uag") || ClassIs("Uh") || ClassIs("Uc") || ClassIs("M") ? Z :
        ClassIs("Uf") || ClassIs("Ub") || ClassIs("Uab") || ClassIs("Uaf") || ClassIs("Udf") ? U :
        ClassIs("Ua") || ClassIs("Ud") || ClassIs("Ui") ? L :
        ClassIs("Ug") ? G : Z;

    private bool ClassIs(string value) =>
        VehicleClass.StartsWith(value, StringComparison.OrdinalIgnoreCase);

    public static Wagon CargoWagonDefault => new() { VehicleClass = "G" };
    public static Wagon PassengerWagonDefault => new() { IsPassengerWagon = true, VehicleClass = "AB" };

    public static Wagon Example =>
        new()
        {
            Description = "Fliscontainervagn FINSAM",
            Epoch = "V-VI",
            Length = 20.7f,
            LoadLimit = 23.5,
            LoadVolume = 50.0,
            LoadArea = 100,
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
            LoadingInstructions = "This is a loading instruction example.",
            ModelImageUrl = "https://www.modellbahnshop-lippe.com/article_data/images/73/211190_e.jpg",
            OriginalImageUrl = "https://www.modellbahnshop-lippe.com/article_data/images/73/211190_e.jpg",
            ModelManufacturer = "NMJ",
            ModelNumber = "123-456",
            ModelWeight = 120,
            Marking = new()
            {
                Color1 = "#FF7700",
                Color2 = "#00FF77",
                Color3 = "#7700FF",
                InventoryNumber = "",
                IconHref = "https://www.pngitem.com/pimgs/m/252-2524621_rail-transport-train-station-maglev-computer-icons-railway.png"
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
    public static IEnumerable<string> CountryCodes => ["", "AT", "BE", "CH", "CZ", "DA", "DE", "ES", "FI", "FR", "HU", "IT", "NL", "NO", "PL", "SE", "UK"];
}
