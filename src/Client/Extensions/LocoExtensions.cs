namespace Tellurian.WagonCardApp.Client.Extensions;

public static class LocoExtensions
{
    public static IEnumerable<(string Key, string Text)> ActiveFunctions(this Loco? loco) => loco is null ? Array.Empty<(string, string)>() :
    loco.Functions.Where(f => !string.IsNullOrWhiteSpace(f.Text)).Select(f => ($"F{f.Key}", f.Text));

    public static string BorderStyle(this Loco? loco) => 
        loco?.PrintOptions.PrintCard == true ? $"border: 0.5cm solid {loco.FrameColor};  " : "border: 0.5cm solid white;";
}
