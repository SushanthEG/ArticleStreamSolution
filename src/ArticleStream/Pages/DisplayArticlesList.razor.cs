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
    private DisplayArticleService DisplayArticleService { get; set; } = default!;

    [Inject]
    private NavigationManager NavigationManager { get; set; } = default!;

    [Inject]
    private IErrorLogger ErrorLogger { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        await LoadArticlesAsync();
    }

    private async Task LoadArticlesAsync()
    {
        try
        {
            currentState = ComponentState.Loading;
            articles = await DisplayArticleService.FetchArticleAsync();

            if (articles != null && articles.Any())
            {
                currentState = ComponentState.Loaded;
            }
            else
            {
                SetErrorState("No articles available.");
            }
        }
        catch (Exception ex)
        {
            SetErrorState($"Error loading articles: {ex.Message}");
            ErrorLogger.LogError(ex);
        }
    }

    private void SetErrorState(string message)
    {
        currentState = ComponentState.Error;
        errorMessage = message;
    }

    protected void SelectArticle(int id)
    {
        NavigationManager.NavigateTo($"/article/{id}");
    }

    private async Task ReloadArticles()
    {
        await LoadArticlesAsync();
        StateHasChanged();
    }
}
