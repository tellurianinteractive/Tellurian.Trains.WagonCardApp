namespace Tellurian.WagonCardApp.Client.Extensions;

public static class VehicleExtensions
{
    public static string Css(this Vehicle? vehicle, string? css) => $"{css} {vehicle?.Scale}";

}
