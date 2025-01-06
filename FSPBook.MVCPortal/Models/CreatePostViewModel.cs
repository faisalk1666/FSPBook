using FSPBook.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace FSPBook.MVCPortal.Models;

public class CreatePostViewModel
{
    [Required(ErrorMessage = "Choose a person to post on behalf of")]
    [Range(1, 10000, ErrorMessage = "Choose a person to post on behalf of")]
    public int ProfileId { get; set; }

    [Required(ErrorMessage = "Write a post")]
    [MinLength(1, ErrorMessage = "Post needs some content")]
    public string ContentInput { get; set; }

    public List<Profile> Profiles { get; set; }
    public bool Success { get; set; }
}
