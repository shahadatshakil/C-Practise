namespace BestSellerBooks.Models.BookClasses
{
    public class Root
    {
        public string status { get; set; }
        public string copyright { get; set; }
        public int num_results { get; set; }
        public DateTime last_modified { get; set; }
        public Results results { get; set; }
    }
}
