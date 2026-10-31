using Bussiness_Layer.CRUD;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
        string subTitle = $"{Library.Books.Count()} Book(s)";
        Screen.DrawScreenHeader("List All Books Screen", subTitle);

        _printTableOfBooksHeader () ;

        List<Book> books = new List<Book>(1000);

        ListAllBooks.Execute(out books);

        foreach (var i in books)
        {
            _printBookRecord(i);
        }

        Console.WriteLine("\t\t-------------------------------------------------------------------------------------------------");

    }
}
