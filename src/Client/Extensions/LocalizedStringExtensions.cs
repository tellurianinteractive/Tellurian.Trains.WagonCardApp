using Microsoft.AspNetCore.Components;

namespace Tellurian.WagonCardApp.Client.Extensions;

public static class LocalizedStringExtensions
{
    public static MarkupString Label(this IStringLocalizer me, string label, string? english = null, bool twoRows = false)
    {
        var text = me[label].Value;
        english ??= label;
        if (twoRows) return new(text.Equals(english) ? text : $"{text}<br/>{english}");

        return new(text.Equals(english) ? text : $"{text}/{english}");
    }
}
