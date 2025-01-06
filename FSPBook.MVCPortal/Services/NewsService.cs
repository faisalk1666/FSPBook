using FSPBook.MVCPortal.Models;
using Newtonsoft.Json;

namespace FSPBook.MVCPortal.Services;

public class NewsService : INewsService
{
    private readonly ILogger<NewsService> _logger;
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public NewsService(HttpClient httpClient, ILogger<NewsService> logger, IConfiguration config)
    {
        _httpClient = httpClient;
        _logger = logger;
        _apiKey = config["ApiKey"];
    }

    public async Task<NewsResponse> GetTechnologyNewsAsync(int count, List<string>? sources = null)
    {
        try
        {
            // Top endpoint has been used - Headlines is not supported on Free Plan
            var apiUrl = $"https://api.thenewsapi.com/v1/news/top?api_token={_apiKey}&locale=in&categories=tech&limit={count}";

            if (sources != null && sources.Any())
            {
                var sourcesParam = string.Join(",", sources);
                apiUrl += $"&domains={sourcesParam}";
            }

            var response = await _httpClient.GetStringAsync(apiUrl);
            var result = JsonConvert.DeserializeObject<NewsResponse>(response);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching news from newsapi.");
            return new NewsResponse { Data = new List<NewsArticle>() };
        }
    }
}
