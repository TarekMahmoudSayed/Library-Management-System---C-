using Data_Access.Entities;

namespace Bussiness_Layer.Borrowing; 

public class RequestBorrowBook
{
    static public bool Execute(Book book)
    {
        if (book.IsAvailable ())
        {
            book.IsBorrowed = true;
            TextFileStorage.SaveBooksToFile(Library.Books);
            return true;
        }else
        {
            return false;
        }
    }

}
