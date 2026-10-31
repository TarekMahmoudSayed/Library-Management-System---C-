using Bussiness_Layer.Books;
using Data_Access.Entities;

namespace Presentation.Screens; 

internal class ListAllBooksScreen : Screen
{

    static private void _printTableOfBooksHeader ()
    {

        Console.WriteLine("\n\n\t\t-------------------------------------------------------------------------------------------------");
        Console.WriteLine(string.Format("\t\t|{0, -40} | {1, -10} | {2, -30} | {3, -10}", "Book Name", "Book ID", "Book Author", "Year"));
        Console.WriteLine("\t\t-------------------------------------------------------------------------------------------------");

    }

    static private void _printBookRecord (Book book)
    {
        Console.WriteLine(string.Format("\t\t|{0, -40} | {1, -10} | {2, -30} | {3, -10}", book.Title, book.ID, book.Author, book.Year));

    }

    static public void ShowListAllBooksScreen ()
    {

        ListAllBooks.Execute(out List<Book> books);

        string subTitle = $"{Library.Books.Count()} Book(s)";
        Screen.DrawScreenHeader("List All Books Screen", subTitle);

        _printTableOfBooksHeader () ;


        ListAllBooks.Execute(out books);

        foreach (var i in books)
        {
            _printBookRecord(i);
        }

        Console.WriteLine("\t\t-------------------------------------------------------------------------------------------------");

    }
}
