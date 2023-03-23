using BestSellerBooks.Models.BookClasses;
using BestSellerBooks.Models.Review;
using BestSellerBooks.Models.ReviewClasses;
using Newtonsoft.Json;
using System.Net;

namespace BestSellerBooks.Services
{
    public class BookDataRetrieveServices
    {
        public string GetJSONString(string apiURL)
        {
            string str = "";
            try
            {
                WebClient client = new WebClient();
                str = client.DownloadString(apiURL);
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't get book details. Check your input and internet connection.");
            }
            return str;
        }

        public List<Book> GetBooks(string apiURL)
        {
            List<Book> books = new List<Book>();
            try
            {
                string str = GetJSONString(apiURL);
                Root root = JsonConvert.DeserializeObject<Root>(str);
                books = root.results.books;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while retrieving book details!");
            }
            return books;
        }

        public string GetReview(string apiURL)
        {
            string review = "";
            try
            {
                review = GetJSONString(apiURL);
                ReviewRoot root = JsonConvert.DeserializeObject<ReviewRoot>(review);

                if(root.results.Count == 0)
                {
                    return "";
                }
                ReviewResult results = root.results[0];
                review = results.summary;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return review;
        }

        public string GetBookDataApiUrl(string date)
        {
            return Constants.BookDataAPIFirstPart + date + Constants.BookDataAPILastPart;
        }

        public string GetBookReviewApiUrl(string isbn)
        {
            return Constants.BookReviewAPIFirstPart + isbn + Constants.BookReviewAPILastPart;
        }

        public string GetAuthorReviewApiUrl(string authorName)
        {
            string[] nameParts = authorName.Split(" ");
            string name = "";
            foreach(string part in nameParts)
            {
                if (string.IsNullOrEmpty(name))
                {
                    name = part;
                }
                else
                {
                    name += "+" + part;
                }
            }
            return Constants.AuthorReviewAPIFirstPart + name + Constants.AuthorReviewAPILastPart;
        }
    }
}
