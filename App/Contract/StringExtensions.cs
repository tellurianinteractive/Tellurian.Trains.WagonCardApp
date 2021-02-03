using Markdig;

namespace WagonCardApp.Contract
{
    public static class StringExtensions
    {
        public static string FromMarkdown(this string? markdown)
        {
            if (string.IsNullOrWhiteSpace(markdown)) return string.Empty;
            return Markdown.ToHtml(markdown, Pipeline());

            static MarkdownPipeline Pipeline()
            {
                var builder = new MarkdownPipelineBuilder();
                builder.UseAdvancedExtensions();
                return builder.Build();
            }
        }
    }
}
