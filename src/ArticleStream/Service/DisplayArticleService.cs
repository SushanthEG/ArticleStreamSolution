using ArticleStream.Model;
using System.Net.Http.Json;

namespace ArticleStream.Service
{
    public class DisplayArticleService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<DisplayArticleService> _logger;
        private const string BaseUrl = "https://ps-dev-1-partnergateway.patientsky.dev/assignment/articles";

        public DisplayArticleService(HttpClient httpClient, ILogger<DisplayArticleService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<List<ArticleModel>> FetchArticleAsync()
        {
            return await FetchDataAsync<List<ArticleModel>>(BaseUrl, "Error fetching articles");
        }

        public async Task<ArticleModel> GetArticleByIdAsync(int id)
        {
            return await FetchDataAsync<ArticleModel>($"{BaseUrl}/{id}", $"Error fetching article with ID {id}");
        }

        private async Task<T> FetchDataAsync<T>(string url, string errorMessage)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<T>(url);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, errorMessage);
                if (typeof(T) == typeof(List<ArticleModel>))
                {
                    return (T)(object)new List<ArticleModel>();
                }
                throw new Exception("Failed to fetch the data.", ex);
            }
        }
    }
}
