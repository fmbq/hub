using System.Threading.Tasks;
using Markdig;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace FMBQ.Hub
{
    public class MarkdownTagHelper : TagHelper
    {
        private MarkdownPipeline markdownPipeline;

        public MarkdownTagHelper(MarkdownPipeline markdownPipeline)
        {
            this.markdownPipeline = markdownPipeline;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";

            var childContent = await output.GetChildContentAsync();
            var renderedMarkdown = Markdown.ToHtml(childContent.GetContent(), markdownPipeline);
            output.Content.SetHtmlContent(renderedMarkdown);
        }
    }
}
