using Data_Access.Entities;

namespace Bussiness_Layer.Books;

public class ListAllBooks
{
    static public void Execute(out List <Book>books)
    {
        books = Library.GetAllBooks();
    }
}
