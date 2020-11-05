using Ganss.XSS;
using Gunetberg.Types.Post;
using Gunetberg.Web.Providers;
using Gunetberg.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Gunetberg.Web.CustomComponents
{
    public partial class SearchComponent : ComponentBase
    {
        [Inject]
        private NavigationManager _navigationManager { get; set; }

        [Inject]
        private IHtmlSanitizer _htmlSanitizer { get; set; }

        [Inject]
        private PostService _postService { get; set; }

        [Parameter]
        public string Placeholder { get; set; }

        public ICollection<AutocompletePostDto> AutocompletePosts { get; set; }

        private string _searchField;
        public string SearchField
        {
            get => _searchField;
            set
            {
                _searchField = value;
                LoadAutocompletePosts(value);
            }
        }


        private CancellationTokenSource _cancellationToken;
        private async void LoadAutocompletePosts(string title)
        {
            if (_cancellationToken != null)
            {
                _cancellationToken.Cancel();
            }

            using (_cancellationToken = new CancellationTokenSource())
            {
                try
                {
                    AutocompletePosts = await _postService.GetAutocompletePosts(title, _cancellationToken);
                    StateHasChanged();
                }
                catch { }
            }

            _cancellationToken = null;

        }

        private void ClearSearchField()
        {
            SearchField = string.Empty;
        }

        private MarkupString HighlightTitle(string title)
        {

            var stringIndex = title.IndexOf(SearchField, StringComparison.InvariantCultureIgnoreCase);
            if(stringIndex == -1)
            {
                return new MarkupString();
            }
            var searchFieldLength = SearchField.Length;
            var titleLength = title.Length;


            var stringBeforeContent = title.Substring(0, stringIndex);
            var stringContent = title.Substring(stringIndex, searchFieldLength);
            var stringAfterContent = title.Substring(stringIndex + searchFieldLength);

            var htmlTemplate = $"<span>{stringBeforeContent}</span><span class='text-bold'>{stringContent}</span><span>{stringAfterContent}</span>";
            var sanitizedHtml = _htmlSanitizer.Sanitize(htmlTemplate);

            return new MarkupString(sanitizedHtml);

        }

        public void LoadPost(long postId)
        {
            ClearSearchField();
            _navigationManager.NavigateTo($"post/{postId}");
        }

        public void GoToAdvancedSearch()
        {
            ClearSearchField();
            _navigationManager.NavigateTo($"search");
        }
    }
}
