using Ganss.XSS;
using Markdig;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gunetberg.Web.CustomComponents
{
    public partial class PostTextSectionComponent: ComponentBase
    {
        [Inject]
        private IHtmlSanitizer _htmlSanitizer { get; set; }

        [Inject]
        private IJSRuntime _jSRuntime { get; set; }


        [Parameter]
        public string Content { 
            get=>_content;
            set
            {
                _content = value;
                HtmlContent = MarkdownToHtml(_content);
            }
        }

        private string _content;

        public MarkupString HtmlContent { get; set; }

        private MarkupString MarkdownToHtml(string markdown)
        {
            var htmlCode = Markdown.ToHtml(markdown);
            var sanitizedHtml = _htmlSanitizer.Sanitize(htmlCode);
            return new MarkupString(sanitizedHtml);
        }


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await _jSRuntime.InvokeVoidAsync("loadHighLight");
        }
    }
}
