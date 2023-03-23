using BestSellerBooks.Models.ReviewClasses;

namespace BestSellerBooks.Models.Review
{
    public class ReviewRoot
    {
        public string status { get; set; }
        public string copyright { get; set; }
        public int num_results { get; set; }
        public List<ReviewResult> results { get; set; }
    }
}
