namespace Tellurian.WagonCardApp.Shared;

public class Loco : Vehicle
{
    public string DrivelineType { get; set; } = string.Empty;
    public int? EnginePower { get; set; }
    public EnginePowerUnit EnginePowerUnit { get; set; }
    public int? YearOfManufacturing { get; set; }
    public string Manufacturer { get; set; } = string.Empty;
    public int? Weight { get; set; }
    public string MainColor { get; set; } = "white";
    public string SecondColor { get; set; } = "black";
    public IEnumerable<LocoFunction> Functions { get; set; } = Array.Empty<LocoFunction>();

    public override string ForeColor => MainColor;
    public override string BackColor => SecondColor;

    public static Loco Default => new() { Functions = Enumerable.Range(0, 15).Select(i => new LocoFunction(i, string.Empty)).ToArray() };

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
        Functions = new[]
        {
                new LocoFunction(0, "Lys"),
                new LocoFunction(1, "Toplys"),
                new LocoFunction(2, "Horn"),
                new LocoFunction(3, "Rangering"),
                new LocoFunction(4, "Udrul fra"),
                new LocoFunction(5, "Motor"),
                new LocoFunction(6, "Horn, kort"),
                new LocoFunction(7, "Kobling"),
                new LocoFunction(8, ""),
                new LocoFunction(9, ""),
                new LocoFunction(10, ""),
                new LocoFunction(11, "Lys, fast A"),
                new LocoFunction(12, "Lys, fast B"),
                new LocoFunction(13, ""),
                new LocoFunction(14, ""),
                new LocoFunction(15, ""),
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
    public LocoFunction(int key, string text) { Key = key; Text = text; }
    public int Key { get; set; }
    public string Text { get; set; }
}


public enum EnginePowerUnit
{
    Kilowatts,
    Horsepowers
}
