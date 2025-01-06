using FSPBook.Data.Entities;
using FSPBook.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FSPBook.MVCPortal.Models;

namespace FSPBook.MVCPortal.Controllers;


public class PostController : Controller
{
    private readonly Context _context;

    public PostController(Context context)
    {
        _context = context;
    }

    public async Task<IActionResult> Create()
    {
        var viewModel = new CreatePostViewModel
        {
            Profiles = await _context.Profile.ToListAsync()
        };
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePostViewModel model)
    {
        if (model.ProfileId != -1)
        {
            var post = new Post
            {
                AuthorId = model.ProfileId,
                Content = model.ContentInput,
                DateTimePosted = DateTimeOffset.Now
            };

            _context.Post.Add(post);
            await _context.SaveChangesAsync();

            model.Success = true;
            return RedirectToAction("Index", "Home");
        }
        return View(model);
    }
}
