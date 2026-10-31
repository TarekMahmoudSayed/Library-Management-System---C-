using Bussiness_Layer;
using Bussiness_Layer.Books;
using Data_Access.Entities;
using Persentation;


namespace Presentation.Screens; 

internal class ListBookDetails : Screen
{

    static private SearchBy _readFindByUserChoice()
    {
        int input = InputValidate.ReadIntFromUserBetween("\nWhat Do You Want To Find By [1] ID [2] Title ? ", 1, 2);

        return ((input == 1) ? SearchBy.ById : SearchBy.ByTitle);

    }
    static public void ShowBookDetials ()
    {
        Screen.DrawScreenHeader("List Book Details ");

        SearchBy searchBy = _readFindByUserChoice();

        string input = "";

        bool isSuccessed = false;

        Book book = new Book();

        switch (searchBy)
        {
            case SearchBy.ById:

                Console.Write("\nPlease Enter Book ID To Search ? ");
                input = Console.ReadLine();

                isSuccessed = FindBook.Execute(out book, input, SearchBy.ById);

                break;

            case SearchBy.ByTitle:

                Console.Write("\nPlease Enter Book Title To Search ? ");
                input = Console.ReadLine();

                isSuccessed = FindBook.Execute(out book, input, SearchBy.ByTitle);

                break;
        }

        if (isSuccessed)
        {
            Console.WriteLine("\n\nBook Found Successfully :-) \n");
            DisplayBookDetails(book);
        }
        else
        {
            Console.WriteLine("\n\nError Occurred , Please Try Again ");

        }
    }
}
