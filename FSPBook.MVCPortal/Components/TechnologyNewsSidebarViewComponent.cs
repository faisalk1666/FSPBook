using FSPBook.MVCPortal.Services;
using Microsoft.AspNetCore.Mvc;

namespace FSPBook.MVCPortal.Components;

public class TechnologyNewsSidebarViewComponent : ViewComponent
{
    private readonly INewsService _newsService;

    public TechnologyNewsSidebarViewComponent(INewsService newsService)
    {
        _newsService = newsService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        // News with specific sources

        //var filteredSources = new List<string> { "aitrends.com-1", "veracode.com-1" };
        //var news = await _newsService.GetTechnologyNewsAsync(5, filteredSources);

        // Free plan allows on maximum 3 limit value
        var news = await _newsService.GetTechnologyNewsAsync(3);
        return View(news);
    }
}
