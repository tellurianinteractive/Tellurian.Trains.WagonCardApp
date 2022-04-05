namespace Tellurian.WagonCardApp.Shared;
public class ImageFile
{
	public string? Base64data { get; set; }
	public string? ContentType { get; set; }
	public string? FileName { get; set; }
	public bool IsImage => !string.IsNullOrEmpty(Base64data);
	public void Clear() => Base64data = null;
}
