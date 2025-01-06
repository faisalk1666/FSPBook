using FSPBook.Data;
using FSPBook.MVCPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FSPBook.MVCPortal.Controllers;

public class ProfileController : Controller
{
    private readonly Context _context;

    public ProfileController(Context context)
    {
        _context = context;
    }

    public async Task<IActionResult> Details(int profileId)
    {
        var profile = await _context.Profile
            .Include(p => p.Posts)
            .FirstOrDefaultAsync(p => p.Id == profileId);

        if (profile == null)
        {
            return NotFound();
        }

        var model = new ProfileViewModel
        {
            Name = profile.FullName,
            JobTitle = profile.JobTitle,
            Posts = profile.Posts.OrderByDescending(p => p.DateTimePosted).ToList()
        };

        return View(model);
    }
}
