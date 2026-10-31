using Data_Access.Entities;

namespace Bussiness_Layer.Borrowing; 

public class ReturnBook
{
    static public bool Execute(Book book)
    {
        if (!book.IsAvailable())
        {
            book.IsBorrowed = false;
            TextFileStorage.SaveBooksToFile(Library.Books);
            return true;
        }
        else
        {
            return false;
        }
    }
}
