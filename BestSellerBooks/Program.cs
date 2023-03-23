using BestSellerBooks.Helpers;
using BestSellerBooks.Models.BookClasses;
using BestSellerBooks.Services;

namespace BestSellerBooks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UIHelper uIHelper = new UIHelper();
            FileServices fileServices = new FileServices();
            BookDataRetrieveServices bookDataRetrieveServices = new BookDataRetrieveServices();

            uIHelper.ShowUserInstructions();
            string userPreference;
            int userOption;

            userPreference = uIHelper.TakeUserInput(uIHelper.IsValidUserInput);
            int.TryParse(userPreference, out userOption);

            if(userOption == Constants.ExitCode)
            {
                return;
            }

            List<Book> books = new List<Book>();

            if(userOption == Constants.ShowLatestBook)
            {
                books = bookDataRetrieveServices.GetBooks(Constants.StartingAPIUrl);
            }
            else if(userOption == Constants.ShowBookOfSpecificDate)
            {
                uIHelper.PrintInstructionForDateInput();
                string inputDate = uIHelper.TakeUserInput(uIHelper.IsValidInputDate);
                if(inputDate.Length == 1 && inputDate[0] == '0')
                {
                    return;
                }
                books = bookDataRetrieveServices.GetBooks(bookDataRetrieveServices.GetBookDataApiUrl(inputDate));
            }
            else
            {
                books = fileServices.GetBooks();
            }

            uIHelper.ShowBooks(books);

            while (true)
            {
                uIHelper.PrintInstructionForBookQueries();

                userPreference = uIHelper.TakeUserInput(uIHelper.IsValidUserInput);
                int.TryParse(userPreference, out userOption);
                if(userOption == Constants.ExitCode)
                {
                    return;
                }

                uIHelper.PrintInstructionForSelectingBook();
                int selectedBookNumber;

                while (true)
                {
                    string selectBook = uIHelper.TakeUserInput(uIHelper.IsValidBookNumber);
                    int.TryParse(selectBook, out selectedBookNumber);

                    if(selectedBookNumber == Constants.ExitCode)
                    {
                        return;
                    }

                    if(selectedBookNumber < 0 || selectedBookNumber > books.Count)
                    {
                        Console.WriteLine("Please insert a valid book number!");
                    }
                    else
                    {
                        break;
                    }
                }
                if(userOption == 1)
                {
                    Isbn isbn = books[selectedBookNumber - 1].isbns[0];
                    string bookIsbn = isbn.isbn13;
                    string review = bookDataRetrieveServices.GetReview(bookDataRetrieveServices.GetBookReviewApiUrl(bookIsbn));
                    uIHelper.PrintReview(books[selectedBookNumber - 1].title, review);
                    int k = 0;
                }
                else
                {
                    string author = books[selectedBookNumber - 1].author;
                    string review = bookDataRetrieveServices.GetReview(bookDataRetrieveServices.GetAuthorReviewApiUrl(author));
                    uIHelper.PrintReview(books[selectedBookNumber - 1].title, review);
                }
            }
        }
    }
}