using System;
using System.Collections.Generic;
using System.Linq;

namespace WagonCardApp.Contract;

public class CargoWagon : Vehicle
{
    public string Description { get; set; } = string.Empty;
    public double LoadLimit { get; set; }
    public double LoadVolume { get; set; }

    public HomeStation HomeStation { get; set; } = new();

    public bool HasHomeStation => !string.IsNullOrWhiteSpace(HomeStation?.Name);

    public override string BackColor => FrameColor;
    public override string ForeColor => FrameColor.TextColor();

    private char MainClass => VehicleClass.Length > 0 ? VehicleClass.ToUpperInvariant()[0] : ' ';
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
        VehicleClass.StartsWith(value, System.StringComparison.OrdinalIgnoreCase);

    public static CargoWagon Default => new();

    public static CargoWagon Example =>
        new()
        {
            Description = "Fliscontainervagn FINSAM",
            Epoch = "V-VI",
            Length = 20.7f,
            LoadLimit = 23.5,
            LoadVolume = 0,
            MaxSpeed = 100,
            SpeedUnit = SpeedUnit.KmPerHour,
            OperatingFromYear = 1988,
            OperatingUptoYear = 2010,
            OperatorSignature = "NSB",
            VehicleClass = "Rps",
            VehicleNumber = "31 76 393 3 013-1",
            ModelImageUrl = "https://www.modellbahnshop-lippe.com/article_data/images/73/211190_e.jpg",
            OriginalImageUrl = "https://www.modellbahnshop-lippe.com/article_data/images/73/211190_e.jpg",
            ModelManufacturer = "NMJ",
            ModelNumber = "123-456",
            Marking = new()
            {
                Color1 = "#FF7700",
                Color2 = "#00FF77",
                Color3 = "#7700FF",
                InventoryNumber = ""
            },
            HomeStation = new()
            {
                Name = "Kongsvinger",
                Region = (int)Region.East,
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
    South = 1,
    East = 2,
    West = 3,
    North = 4,
    NorthWest = 5,
    NorthEast = 6,
    Middle = 7
}

public static class RegionExtensions
{
    public static string Color(this int it) => ((Region)it).Color();
    public static string Color(this Region me) => me switch
    {
        Region.South => "#ffff00",
        Region.East => "#ff0000",
        Region.West => "#009933",
        Region.NorthEast => "#000000",
        Region.North => "#0000ff",
        Region.NorthWest => "#993300",
        Region.Middle => "#ff9933",
        _ => "#ffffff"
    };

    public static IEnumerable<(int Id, string ResourceKey)> Regions => ((Region[])Enum.GetValues(typeof(Region))).Select(v => ((int)v, v.ToString()));
    public static IEnumerable<string> CountryCodes => new[] { "", "AT", "BE", "CH", "CZ", "DA", "DE", "ES", "FI", "FR", "HU", "IT", "NL", "NO", "PL", "SE", "UK" };
}
