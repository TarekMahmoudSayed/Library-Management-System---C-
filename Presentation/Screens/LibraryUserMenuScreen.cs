using Persentation;
using Bussiness_Layer.Users;
using Data_Access.Entities;

namespace Presentation.Screens;

internal class LibraryUserMenuScreen : Screen
 {
    enum menueOptions
    {
        none = 0,
        ShowAllBooks = 1,
        ShowBookDetalis = 2,
        RequestBorrowBook = 3,
        ReturnBook = 4,
        Logout = 5
    };
    private static void _showMenueOption()
    {
        Console.WriteLine("\n\n\t\t\t\t\t    [1] List All Books. ");
        Console.WriteLine("\t\t\t\t\t    [2] Show Book Details. ");
        Console.WriteLine("\t\t\t\t\t    [3] Request Borrow Book. ");
        Console.WriteLine("\t\t\t\t\t    [4] Return Book. ");
        Console.WriteLine("\t\t\t\t\t    [5] Logout. ");
        Console.WriteLine("\t\t\t\t\t_______________________________________");
    }
    static private int _readMenueOption()
    {
        int choice = InputValidate.ReadIntFromUserBetween("Please Enter Your Choice [1 - 5] ? ", 1, 5);

        return choice;

    }
    static private void _ListAllBooks()
    {
        //Console.WriteLine("Show All Books Screen Will Be Here Soon");
        ListAllBooksScreen.ShowListAllBooksScreen();
    }
    static private void _showBookDetails()
    {
        //Console.WriteLine("Show Book Details Screen Will Be Here Soon");
        ListBookDetails.ShowBookDetials();
    }
    static private void _goingBackToMenue()
    {
        Console.Write("\n\n\t\t\t\t\tPress Any Key To Go Back Member Menue.");
        Console.ReadKey();
        Console.Clear();
        ShowMenueScreen();
    }
    static void _performMenueOption(int choice)
    {

        switch ((menueOptions)choice)
        {
            
            case menueOptions.ShowAllBooks:
                Console.Clear();
                _ListAllBooks();
                _goingBackToMenue();
                break;
            case menueOptions.RequestBorrowBook:
                Console.Clear();
                _requestBorrowBook();
                _goingBackToMenue();
                break;
            case menueOptions.ReturnBook:
                Console.Clear();
                _returnBook();
                _goingBackToMenue();
                break;
            case menueOptions.ShowBookDetalis:
                Console.Clear();
                _showBookDetails();
                _goingBackToMenue();
                break;
            case menueOptions.Logout:
                Login.Clear();
                break;
            default:
                _goingBackToMenue();
                break;
        }

    }

    private static void _returnBook()
    {
        //Console.WriteLine("return Books Screen Will Be Here Soon");
        ReturnBookScreen.ShowReturnBookScreen();
    }

    private static void _requestBorrowBook()
    {
        //Console.WriteLine("Borrow Books Screen Will Be Here Soon");
        RequestBorrowBookScreen.ShowRequestBorrowBookScreen();
        

    }

    internal static void ShowMenueScreen()
    {
        Screen.DrawScreenHeader("Memeber Menue Screen");
        _showMenueOption();

        _performMenueOption(_readMenueOption());

    }
}
