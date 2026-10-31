using Infrastructure;
using Bussiness_Layer;
using Bussiness_Layer.CRUD;

namespace Presentation.Screens;

internal class RemoveBookScreen : Screen
{
    static private SearchBy _readRemoveByUserChoice()
    {
        int input = InputValidate.ReadIntFromUserBetween("\nWhat Do You Want To Reomve By [1] ID [2] Title ? ",1, 2);

        return ((input == 1) ? SearchBy.ById : SearchBy.ByTitle);

    }

    static private bool _confirmReomveOperation ()
    {
        char c ;

        Console.Write("\nAre You Sure You Want To Reomve This Book [y/n] ? ");

        bool isOkey = char.TryParse (Console.ReadLine(), out c);


       if (isOkey && char.ToLower(c) == 'y')
        {
            return true;
        }else
        {
            return false;
        }

    }

    public static void ShowRemoveBookScreen ()
    {
        Screen.DrawScreenHeader("Remove Book Screen");

        SearchBy searchBy = _readRemoveByUserChoice();

        string input = "";

        bool isSuccessed = false ;


        switch (searchBy)
        {
            case SearchBy.ById:

                Console.Write("\nPlease Enter Book ID To Remove ? ");
                input = Console.ReadLine();

                if (!_confirmReomveOperation())
                {
                    isSuccessed = false;
                    break;
                } 


                isSuccessed = RemoveBook.Execute(input, SearchBy.ById) ;

                break;

            case SearchBy.ByTitle:

                Console.Write("\nPlease Enter Book Title To Remove ? ");
                input = Console.ReadLine();

                if (!_confirmReomveOperation())
                {
                    isSuccessed = false;
                    break;
                }

                isSuccessed = RemoveBook.Execute(input, SearchBy.ByTitle);
           
                break;
        }

        if (isSuccessed)
        {
            Console.WriteLine("\n\nBook Removed Successfully ");
        }else
        {
            Console.WriteLine("\n\nError Ouccered , Please Try Again ");

        }

    }

}
