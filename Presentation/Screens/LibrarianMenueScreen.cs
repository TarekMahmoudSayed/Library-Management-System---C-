using Bussiness_Layer;
using Entities;
using Infrastructure;

namespace Presentation.Screens
{
    internal class LibrarianMenueScreen : Screen
    {
        enum menueOptions
        {
            none = 0,
            AddBook = 1,
            ShowAllBooks = 2,
            RemoveBook = 3,
            ShowBookDetalis = 4,
            AddUserCard = 5, 
            Logout = 6
        };
        private static void _showMenueOption ()
        {
            Console.WriteLine("\n\n\t\t\t\t\t    [1] Add New Book. ");
            Console.WriteLine("\t\t\t\t\t    [2] List All Books. ");
            Console.WriteLine("\t\t\t\t\t    [3] Remove Book. ");
            Console.WriteLine("\t\t\t\t\t    [4] Show Book Details. ");
            Console.WriteLine("\t\t\t\t\t    [5] Add User Card. ");
            Console.WriteLine("\t\t\t\t\t    [6] Logout. ");
            Console.WriteLine("\t\t\t\t\t_______________________________________");
        }
        static private int _readMenueOption ()
        {
            int choice = InputValidate.ReadIntFromUserBetween("Please Enter Your Choice [1 - 6] ? ", 1, 6);

            return choice;

        }
        static private void _addBook ()
        {
            //Console.WriteLine("Add Book Screen Will Be Here Soon");
            AddNewBookScreen.ShowAddNewBookScreen();
        }
        static private void _addUserCard ()
        {
            //Console.WriteLine("Add User Card Screen Will Be Here Soon");
            AddNewUserScreen.ShowAddNewUserScreen();
        }
        static private void _removeBook ()
        {
            //Console.WriteLine("Reomve Book Screen Will Be Here Soon");
            RemoveBookScreen.ShowRemoveBookScreen();
        }
        static private void _ListAllBooks ()
        {
            //Console.WriteLine("Show All Books Screen Will Be Here Soon");
            ListAllBooksScreen.ShowListAllBooksScreen();
        }
        static private void _showBookDetails ()
        {
            //Console.WriteLine("Show Book Details Screen Will Be Here Soon");
            ListBookDetails.ShowBookDetials();
        }
        static private void _goingBackToMenue ()
        {
            Console.Write("\n\n\t\t\t\t\tPress Any Key To Go Back Librarian Menue.");
            Console.ReadKey();
            Console.Clear();
            ShowMenueScreen();
        }
        static void _performMenueOption (int choice)
        {

            switch ((menueOptions) choice)
            {
                case menueOptions.AddBook:
                    Console.Clear();
                    _addBook();
                    _goingBackToMenue();
                    break;
                case menueOptions.RemoveBook:
                    Console.Clear();
                    _removeBook();
                    _goingBackToMenue();
                    break;
                case menueOptions.ShowAllBooks:
                    Console.Clear();
                    _ListAllBooks();
                    _goingBackToMenue();
                    break;
                case menueOptions.ShowBookDetalis:
                    Console.Clear();
                    _showBookDetails();
                    _goingBackToMenue();
                    break;
                case menueOptions.AddUserCard:
                    Console.Clear();
                    _addUserCard();
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
        internal static void ShowMenueScreen()
        {
            Screen.DrawScreenHeader("Librarian Menue Screen");
            _showMenueOption();

            _performMenueOption(_readMenueOption());

        }
    }
}
