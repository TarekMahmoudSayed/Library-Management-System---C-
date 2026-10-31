using Bussiness_Layer;
using Bussiness_Layer.Books;
using Bussiness_Layer.Borrowing;
using Data_Access.Entities;
using Persentation;

namespace Presentation.Screens
{
    internal class ReturnBookScreen : Screen
    {

        static private SearchBy _readFindByUserChoice()
        {
            int input = InputValidate.ReadIntFromUserBetween("\nWhat Do You Want To Find By [1] ID [2] Title ? ", 1, 2);

            return ((input == 1) ? SearchBy.ById : SearchBy.ByTitle);

        }

        static private bool _confirmReturnBookOperation()
        {
            char c;

            Console.Write("\nAre You Sure You Want To Return This Book [y/n] ? ");

            bool isOkey = char.TryParse(Console.ReadLine(), out c);


            if (isOkey && char.ToLower(c) == 'y')
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        static public void ShowReturnBookScreen ()
        {
            Screen.DrawScreenHeader("Return Book Screen");

            SearchBy searchBy = _readFindByUserChoice();

            string input = "";

            bool isSuccessed = false;

            Book book = new Book();

            switch (searchBy)
            {
                case SearchBy.ById:

                    Console.Write("\nPlease Enter Book ID To Search ? ");
                    input = Console.ReadLine();

                    break;

                case SearchBy.ByTitle:

                    Console.Write("\nPlease Enter Book Title To Search ? ");
                    input = Console.ReadLine();

                    break;
            }

            if (FindBook.Execute(out book, input, searchBy))
            {
                Console.WriteLine("\n\nBook Found :-) \n");
                DisplayBookDetails(book);
            }
            else
            {
                Console.WriteLine("\n\nBook Not Found :-( \n");
                return;
            }

            bool isOkey = false;

            if (!book.IsAvailable())
            {
                isOkey = _confirmReturnBookOperation();
            }

            if (isOkey)
            {
                isSuccessed = ReturnBook.Execute(book);

                if (isSuccessed)
                {
                    Console.WriteLine("\n\nReturn Book Approved ! ");
                }
            }
            else
            {
                Console.WriteLine("\n\nError Occurred , Please Try Again ");
            }
        }
    }
}
