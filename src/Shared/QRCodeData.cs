using QRCoder;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Tellurian.WagonCardApp.Shared;
public class VehicleQRCodeData
{
    public string? Address { get; init; }
    public string? Owner { get; init; } = string.Empty; 
    public string? UicNumber { get; init; }
    public string? UicClass { get; init; }
    public string? Label { get; init; }
}

public static class QRCodeExtensions
{
    private static readonly JsonSerializerOptions Options = new()
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        WriteIndented=true,
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
    };

    public static string QRCode(this Vehicle vehicle)
    {
        var png = vehicle.QrData().AsPng();
        return string.Format("data:image/pgn;base64,{0}", Convert.ToBase64String(png));
    }

    public static byte[] AsPng(this VehicleQRCodeData data)
    {
        var json = JsonSerializer.Serialize(data, Options);
        using var qrGenerator = new QRCodeGenerator();
        using var qrData = qrGenerator.CreateQrCode(json, QRCodeGenerator.ECCLevel.L);
        using var qrCode = new PngByteQRCode(qrData);
        return qrCode.GetGraphic(10);
    }

    private static VehicleQRCodeData QrData(this Vehicle vehicle) =>
        new()
        {
            Address = vehicle is Loco loco && loco.Address.HasValue ? loco.Address.Value.ToString() : null,
            Owner = vehicle.Owner.OwnerName,
            UicNumber = vehicle.UicNumber(),
            UicClass = vehicle is Wagon wagon ? wagon.MainClass() : null,
            Label = vehicle.Identification()
        };
}
