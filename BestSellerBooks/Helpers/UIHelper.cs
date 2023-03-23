using BestSellerBooks.Models.BookClasses;
using System.Globalization;
using System.Web;

namespace BestSellerBooks.Helpers
{
    public class UIHelper
    {
        public bool IsValidUserInput(string userPreference)
        {
            int userSelection;
            if (string.IsNullOrEmpty(userPreference)
                || !int.TryParse(userPreference,out userSelection)
                || !Constants.UserInputs.Contains(userSelection))
            {
                return false;
            }
            return true;
        }

        public  bool IsValidBookNumber(string bookNumber)
        {
            if ((string.IsNullOrEmpty(bookNumber) || !int.TryParse(bookNumber, out int bookNumberOption)))
            {
                return false;
            }
            return true;
        }

        public  bool IsValidInputDate(string datestring)
        {
            if (DateTime.TryParseExact(datestring, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                int inputYear = date.Year;
                int currentYear = DateTime.Now.Year;

                if(inputYear < currentYear && inputYear > Constants.MinimumYear)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ShouldExit(string input)
        {
            if (int.TryParse(input, out int result))
            {
                if (result == Constants.ExitCode) 
                {
                    return true;
                }
            }
            return false;
        }

        public string TakeUserInput(Func<string, bool> ValidateInput)
        {
            string userPreference = "";
            while (true)
            {
                userPreference = Console.ReadLine();
                if (ShouldExit(userPreference))
                {
                    return "0";
                }
                if (!ValidateInput(userPreference))
                {
                    Console.WriteLine("Please select a valid input!");
                }
                else
                {
                    break;
                }
            }
            return userPreference;
        }

        public void ShowUserInstructions() 
        {
            Console.WriteLine("+--------------------------------------------------------------+");
            Console.WriteLine("|Please select an option!                                      |");
            Console.WriteLine("|Press 1 to see the latest best seller book.                   |");
            Console.WriteLine("|Press 2 to see the list of specific date.                     |");
            Console.WriteLine("|Press 3 to books in local storage.                            |");
            Console.WriteLine("|(Press 0 to exit the app)                                     |");
            Console.WriteLine("+--------------------------------------------------------------+");
        }

        public void PrintInstructionForDateInput()
        {
            Console.WriteLine("+--------------------------------------------------------------+");
            Console.WriteLine("|Please enter a date to see the best selling books(yyyy-mm-dd) |");
            Console.WriteLine("+--------------------------------------------------------------+");
        }

        public void PrintInstructionForSelectingBook()
        {
            Console.WriteLine("+--------------------------------------------------------------+");
            Console.WriteLine("|Please select a valid book number.                            |");
            Console.WriteLine("+--------------------------------------------------------------+");
        }

        public void ShowBooks(List<Book> books)
        {
            int cnt = 1;
            foreach (Book book in books)
            {
                Console.WriteLine("****************************************************************");
                Console.WriteLine($"{cnt++}.Book Name: " + book.title);
                Console.WriteLine(book.author);
                Console.WriteLine("Description");
                Console.WriteLine("-----------");
                PrintDescription(book.description);
            }
            Console.WriteLine("****************************************************************");
        }

        private void PrintDescription(string description)
        {
            string[] words = description.Split(" ");
            string currentLine = "";
            foreach (string word in words)
            {
                if (currentLine.Length + word.Length + 1 > Constants.MaxCharactersPerLine)
                {
                    Console.WriteLine(currentLine);
                    currentLine = word + " ";
                }
                else
                {
                    currentLine += (word + " ");
                }
            }
            Console.WriteLine(currentLine);
        }

        public void PrintInstructionForBookQueries()
        {
            Console.WriteLine("+--------------------------------------------------------------+");
            Console.WriteLine("|Please select an option!                                      |");
            Console.WriteLine("|Press 1 to see the review of a book.                          |");
            Console.WriteLine("|Press 2 to see the review of a author.                        |");
            Console.WriteLine("|(Press 0 to exit the app)                                     |");
            Console.WriteLine("+--------------------------------------------------------------+");
        }

        public void PrintReview(string name, string review)
        {
            if (review.Length == 0)
            {
                Console.WriteLine("No review found!");
                return;
            }

            Console.WriteLine("****************************************************************");
            Console.WriteLine(name);
            Console.WriteLine("Review");
            Console.WriteLine("------");
            review = HttpUtility.HtmlDecode(review);
            PrintDescription(review);
        }
    }
}
