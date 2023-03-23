using BestSellerBooks.Models.BookClasses;
using Newtonsoft.Json;

namespace BestSellerBooks.Services
{
    public class FileServices
    {
        public List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();
            string str = File.ReadAllText(Constants.FilePath);
            try
            {
                books = JsonConvert.DeserializeObject<List<Book>>(str);
            }
            catch (Exception e)
            {
                Console.WriteLine("No file found with book data!");
            }
            return books;
        }
    }
}
