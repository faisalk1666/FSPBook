using FSPBook.Data.Entities;

namespace FSPBook.MVCPortal.Models
{
    public class PostViewModel
    {
        public List<Post> Posts { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public int TotalPosts { get; set; }
    }
}
