namespace BestSellerBooks
{
    public static class Constants
    {
        public static int[] UserInputs = new int[] { 1, 2, 3 };

        public const int ShowLatestBook = 1;
        public const int ShowBookOfSpecificDate = 2;
        public const int ShowBookFromFile = 3;

        public const int MaxCharactersPerLine = 60;
        public const int ExitCode = 0;
        public const int MinimumYear = 2010;

        public const string FilePath = "C:\\Users\\shakil\\Desktop\\MetaGeek Assignments\\books.txt";

        public const string StartingAPIUrl = "https://api.nytimes.com/svc/books/v3/lists/current/hardcover-fiction.json?api-key=Wuc1leNpfOz8EoAsolaJFOMpCAtzxkM9";
        public const string BookDataAPIFirstPart = "https://api.nytimes.com/svc/books/v3/lists/";
        public const string BookDataAPILastPart = "/hardcover-fiction.json?api-key=Wuc1leNpfOz8EoAsolaJFOMpCAtzxkM9";

        public const string AuthorReviewAPIFirstPart = "https://api.nytimes.com/svc/books/v3/reviews.json?author=";
        public const string AuthorReviewAPILastPart = "&api-key=Wuc1leNpfOz8EoAsolaJFOMpCAtzxkM9";

        public const string BookReviewAPIFirstPart = "https://api.nytimes.com/svc/books/v3/reviews.json?isbn=";
        public const string BookReviewAPILastPart = "&api-key=Wuc1leNpfOz8EoAsolaJFOMpCAtzxkM9";
    }
}
