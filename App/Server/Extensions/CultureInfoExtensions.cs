using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using WagonCardApp.Contract;

namespace WagonCardApp.Server.Extensions
{
    internal static class CultureInfoExtensions
    {
        public async static Task<TextContent> GetMarkdownAsync(this CultureInfo culture, string path, string content)
        {
            var specificCultureFile = new FileInfo($"{path}/{content}.{culture.TwoLetterISOLanguageName}.md");
            if (specificCultureFile.Exists) return new TextContent(await File.ReadAllTextAsync(specificCultureFile.FullName), "MD", specificCultureFile.LastWriteTimeUtc);
            var defaultCultureFile = new FileInfo($"{path}/{content}.md");
            if (defaultCultureFile.Exists) return new TextContent(await File.ReadAllTextAsync(defaultCultureFile.FullName), "MD", defaultCultureFile.LastWriteTimeUtc);
            return new TextContent(string.Empty, "MD", DateTimeOffset.Now);
        }
    }
}
