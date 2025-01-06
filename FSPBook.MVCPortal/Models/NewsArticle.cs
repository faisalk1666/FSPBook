using Newtonsoft.Json;

namespace FSPBook.MVCPortal.Models
{
    public class NewsArticle
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Source { get; set; }
        [JsonProperty("published_at")]
        public DateTime PublishedAt { get; set; }
    }
}
