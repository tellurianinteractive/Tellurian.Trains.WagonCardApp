using System;
using System.Collections.Generic;

namespace WagonCardApp.Contract
{
    public record Loco
    {
        public string OperatorSignature { get; init; } = string.Empty;
        public string VehicleClass { get; init; } = string.Empty;
        public string VehicleNumber { get; init; } = string.Empty;
        public string Epoch { get; init; } = string.Empty;
        public IEnumerable<LocoFunction> Functions { get; init; } = Array.Empty<LocoFunction>();
        public (int? From, int? To) OperationPeriod { get; init; }
        public string DrivelineType { get; init; } = string.Empty;
        public string EnginePower { get; init; } = string.Empty;
        public int? YearOfManufacturing { get; init; }
        public string Manufacturer { get; init; } = string.Empty;
        public int? MaxSpeed { get; init; }
        public int? Weight { get; init; }
        public float? Length { get; init; }
        public string? OriginalImageUrl { get; init; }
        public string? ModelImageUrl { get; set; }
        public string? MainColor { get; init; }
        public string? SecondColor { get; init; }

        public static Loco Example => new()
        {
            OperatorSignature = "DSB",
            VehicleClass = "ME",
            VehicleNumber = "1508",
            Epoch = "IV",
            OperationPeriod = (1971, 1989),
            DrivelineType ="Dieseleketrisk",
            EnginePower = "3300 hk",
            Manufacturer = "Henschel",
            YearOfManufacturing = 1981,
            MaxSpeed = 175,
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
                new LocoFunction(11, "Lys, fast A"),
                new LocoFunction(12, "Lys, fast B")
            },
            OriginalImageUrl = "https://www.jernbanen.dk/Fotos/Motor/DSB_ME1508_1982.jpg",
            ModelImageUrl = "images/DSB_ME_1510.jpg",
            MainColor = "black",
            SecondColor = "red"
        };
    }

    public record LocoFunction(int Key, string Text);
    public record Owner(string Name, string Email, string Phone)
    {
        public static Owner Example => new("Stefan Fjällemark", "stefan@fjallemark.se", "+46704712241");
    }
}
