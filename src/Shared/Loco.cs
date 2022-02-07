namespace Tellurian.WagonCardApp.Shared;

public class Loco : Vehicle
{
    public const int MaxFunctions = 24;
    public string DrivelineType { get; set; } = string.Empty;
    public int? EnginePower { get; set; }
    public EnginePowerUnit EnginePowerUnit { get; set; }
    public int? YearOfManufacturing { get; set; }
    public string Manufacturer { get; set; } = string.Empty;
    public int? Weight { get; set; }
    public string MainColor { get; set; } = "white";
    public string SecondColor { get; set; } = "black";
    public LocoFunction[] Functions { get; set; } = Array.Empty<LocoFunction>();
    public int? Address { get; set; }

    public override string ForeColor => MainColor;
    public override string BackColor => SecondColor;

    public static Loco Default => new() { Functions = Enumerable.Range(0, MaxFunctions).Select(i => LocoFunction.Create(i, string.Empty, i < 8)).ToArray() };

    public static Loco Example => new()
    {
        OperatorSignature = "DSB",
        VehicleClass = "ME",
        VehicleNumber = "1508",
        Epoch = "IV",
        OperatingFromYear = 1971,
        OperatingUptoYear = 1989,
        DrivelineType = "Dieselelektrisk",
        EnginePower = 3300,
        EnginePowerUnit = EnginePowerUnit.Horsepowers,
        Manufacturer = "Henschel",
        YearOfManufacturing = 1981,
        MaxSpeed = 175,
        SpeedUnit = SpeedUnit.KmPerHour,
        Weight = 122,
        Length = 21.0f,
        Address=5432,
        Functions = new[]
        {
                LocoFunction.Create(0, "Lys", true),
                LocoFunction.Create(1, "Toplys", true),
                LocoFunction.Create(2, "Horn", true),
                LocoFunction.Create(3, "Rangering", true),
                LocoFunction.Create(4, "Udrul fra", true),
                LocoFunction.Create(5, "Motor", true),
                LocoFunction.Create(6, "Horn, kort", true),
                LocoFunction.Create(7, "Kobling", true),
                LocoFunction.Create(8, ""),
                LocoFunction.Create(9, ""),
                LocoFunction.Create(10, ""),
                LocoFunction.Create(11, "Lys, fast A"),
                LocoFunction.Create(12, "Lys, fast B"),
                LocoFunction.Create(13, ""),
                LocoFunction.Create(14, ""),
                LocoFunction.Create(15, ""),
                LocoFunction.Create(16, ""),
                LocoFunction.Create(17, ""),
                LocoFunction.Create(18, ""),
                LocoFunction.Create(19, ""),
                LocoFunction.Create(20, ""),
                LocoFunction.Create(21, ""),
                LocoFunction.Create(22, ""),
            },
        OriginalImageUrl = "https://www.jernbanen.dk/Fotos/Motor/DSB_ME1508_1982.jpg",
        ModelImageUrl = "http://mck-h0.dk/wp-content/uploads/2016/08/005_125.jpg",
        ModelManufacturer = "Hobbytrade",
        ModelNumber = "123-456",
        MainColor = "#000000",
        SecondColor = "#993333",
        Marking = new()
        {
            InventoryNumber = "",
            Color1 = "#FF0000",
            Color2 = "#00FF00",
            Color3 = "#0000FF"

        }
    };
}

public class LocoFunction
{
    public static LocoFunction Create(int key, string text) => new() { Key = key, Text = text, ShowOnFredSticker = false };
    public static LocoFunction Create(int key, string text, bool show) => new() { Key = key, Text = text, ShowOnFredSticker = show };
    public int Key { get; set; }
    public string Text { get; set; } = string.Empty;
    public bool ShowOnFredSticker { get; set; }
}


public enum EnginePowerUnit
{
    Kilowatts,
    Horsepowers
}
