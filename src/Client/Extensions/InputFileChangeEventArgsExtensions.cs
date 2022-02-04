using Microsoft.AspNetCore.Components.Forms;

namespace Tellurian.WagonCardApp.Client.Extensions;

public static class InputFileChangeEventArgsExtensions
{
    public static async Task<ImageFile> GetImageFile(this InputFileChangeEventArgs e)
    {
        var resizedFile = await e.File.RequestImageFileAsync(e.File.ContentType, 1280, 960);
        var fileBytes = new byte[resizedFile.Size];
        using var stream = resizedFile.OpenReadStream();
        await stream.ReadAsync(fileBytes);
        return new ImageFile { Base64data = Convert.ToBase64String(fileBytes), ContentType = e.File.ContentType, FileName = e.File.Name };
    }
}
