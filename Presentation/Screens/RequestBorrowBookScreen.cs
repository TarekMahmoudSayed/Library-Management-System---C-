using Bussiness_Layer;
using Bussiness_Layer.CRUD;
using Entities;
using Infrastructure;
using Presentation.Screens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Acess; 

internal class RequestBorrowBookScreen : Screen
{

    static private SearchBy _readFindByUserChoice()
    {
        int input = InputValidate.ReadIntFromUserBetween("\nWhat Do You Want To Find By [1] ID [2] Title ? ", 1, 2);

        return ((input == 1) ? SearchBy.ById : SearchBy.ByTitle);

    }

    static private bool _confirmBorrowBookOperation()
    {
        char c;

        Console.Write("\nAre You Sure You Want To Borrow This Book [y/n] ? ");

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
    static public void ShowRequestBorrowBookScreen ()
    {
        Screen.DrawScreenHeader("Request Borrow Book Screen");

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
            book.DisplayDetails();
        }
        else
        {
            Console.WriteLine("\n\nBook Not Found :-( \n");
            return;
        }

        bool isOkey = false;

        if (book.isAvilable())
        {
            isOkey = _confirmBorrowBookOperation();
        }

        if (isOkey)
        {
            isSuccessed = RequestBorrowBook.Execute(book);

            if (isSuccessed)
            {
                Console.WriteLine("\n\nRequest Borrow Book Approved ! ");
            }
        }
        else
        {
            Console.WriteLine("\n\nSorry, You Can't Borrow this Book, Please Try Again Later");
        }


    }
}
