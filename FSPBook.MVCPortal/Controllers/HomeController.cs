using FSPBook.Data;
using FSPBook.MVCPortal.Models;
using FSPBook.MVCPortal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FSPBook.MVCPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context _context;

        public HomeController(ILogger<HomeController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index(int skip = 0, int take = 6)
        {
            try
            {
                var postsQuery = _context.Post.Include(p => p.Author).OrderByDescending(p => p.DateTimePosted);
                var totalPosts = await postsQuery.CountAsync();
                var posts = await postsQuery.Skip(skip).Take(take).ToListAsync();

                var model = new HomeViewModel
                {
                    Posts = posts,
                    Skip = skip + take,
                    Take = take,
                    TotalPosts = totalPosts
                };

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching posts for Index page.");
                return View("Error");
            }
        }
        public async Task<IActionResult> LoadMorePosts(int skip, int take)
        {
            try
            {
                var postsQuery = _context.Post.Include(p => p.Author).OrderByDescending(p => p.DateTimePosted);
                var totalPosts = await postsQuery.CountAsync();
                var posts = await postsQuery.Skip(skip).Take(take).ToListAsync();

                var model = new HomeViewModel
                {
                    Posts = posts,
                    Skip = skip + take,
                    Take = take,
                    TotalPosts = totalPosts
                };

                return PartialView("_PostCards", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching posts for Index page.");
                return View("Error");
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            _logger.LogError($"Error occurred. RequestId: {requestId}");
            return View(new ErrorViewModel { RequestId = requestId });
        }
    }
}
