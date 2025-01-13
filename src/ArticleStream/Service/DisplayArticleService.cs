using ArticleStream.Model;
using System.Net.Http.Json;

namespace ArticleStream.Service
{
    public class DisplayArticleService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<DisplayArticleService> _logger;

        public DisplayArticleService(HttpClient httpClient, ILogger<DisplayArticleService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<List<ArticleModel>> FetchArticleAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<ArticleModel>>("https://ps-dev-1-partnergateway.patientsky.dev/assignment/articles");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching articles");
                return new List<ArticleModel>();
            }
        }
        public async Task<ArticleModel> GetArticleByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<ArticleModel>($"https://ps-dev-1-partnergateway.patientsky.dev/assignment/articles/{id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching article with ID {id}");
                throw new Exception("Failed to fetch the article details based on ID.", ex);
            }
        }
    }
}
