namespace BestSellerBooks.Models.ReviewClasses
{
    public class ReviewResult
    {
        public string url { get; set; }
        public string publication_dt { get; set; }
        public string byline { get; set; }
        public string book_title { get; set; }
        public string book_author { get; set; }
        public string summary { get; set; }
        public string uuid { get; set; }
        public string uri { get; set; }
        public List<string> isbn13 { get; set; }
    }
}
