using ArticleStream.Model;
using ArticleStream.Service;
using Microsoft.AspNetCore.Components;

namespace ArticleStream.Pages;

public partial class DisplayArticlesList : ComponentBase
{

    private ComponentState currentState = ComponentState.Loading;
    private string errorMessage = string.Empty;
    protected List<ArticleModel>? articles;

    [Inject]
    private DisplayArticleService displayArticleService { get; set; } = default!;

    [Inject]
    private NavigationManager NavigationManager { get; set; } = default!;

    [Inject]
    private IErrorLogger ErrorLogger { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            currentState = ComponentState.Loading;
            articles = await displayArticleService.FetchArticleAsync();

            if (articles != null && articles.Any())
            {
                currentState = ComponentState.Loaded;
            }
            else
            {
                currentState = ComponentState.Error;
                errorMessage = "No articles available.";
            }
        }
        catch (Exception ex)
        {
            currentState = ComponentState.Error;
            errorMessage = $"Error loading articles: {ex.Message}";
            ErrorLogger.LogError(ex);
        }
    }

    protected void SelectArticle(int id)
    {
        NavigationManager.NavigateTo($"/article/{id}");
    }

    private async Task ReloadArticles()
    {
        await OnInitializedAsync();
        StateHasChanged();
    }
}
