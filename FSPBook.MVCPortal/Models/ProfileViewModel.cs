using FSPBook.Data.Entities;

namespace FSPBook.MVCPortal.Models;

public class ProfileViewModel
{
    public string Name { get; set; }
    public string JobTitle { get; set; }
    public List<Post> Posts { get; set; }
}
