using FSPBook.MVCPortal.Models;

namespace FSPBook.MVCPortal.Services
{
    public interface INewsService
    {
        Task<NewsResponse> GetTechnologyNewsAsync(int count, List<string>? sources = null);
    }
}
