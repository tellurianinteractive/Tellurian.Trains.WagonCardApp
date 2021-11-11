namespace Tellurian.WagonCardApp.Shared;

public record TextContent(string? Text, string Type, DateTimeOffset LastModified)
{
    public string AsHtml => Text.FromMarkdown();

    public static TextContent Empty => new (string.Empty, string.Empty, DateTimeOffset.MinValue);
}
