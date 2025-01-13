using ArticleStream.Model;
using Microsoft.AspNetCore.Components;

namespace ArticleStream.Pages;

public partial class DisplayArticle : ComponentBase
{
    [Parameter]
    public int Id { get; set; }

    private ArticleModel? Article;

    protected override async Task OnInitializedAsync()
    {
        Article = await displayArticleService.GetArticleByIdAsync(Id);
    }
}
