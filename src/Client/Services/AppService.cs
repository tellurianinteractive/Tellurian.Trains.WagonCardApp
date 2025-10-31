namespace Tellurian.WagonCardApp.Client.Services;

public static class AppService
{
    private static Version? AssemblyVersion => typeof(AppService).Assembly.GetName().Version;

    public static string? Version
    {
        get
        {
            var version = AssemblyVersion;
            if (version == null) return string.Empty;
            return $"{version.Major}.{version.Minor}.{version.Build}";
        }
    }

    public const int MaxUploadFileSize = 2097152 * 2;
}
