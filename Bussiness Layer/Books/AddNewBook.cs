using Data_Access.Entities;

namespace Bussiness_Layer.Books; 

static public class AddNewBook
{
    static public bool Execute (Book book)
    {
        if (Library.IsBookExistByID(book.ID, out _))
        {
            return false;
        }

        if (!Library.Add (book))
        {
            return false;
        }

        string line = TextFileStorage.ConvertBookRecordToLine(book);

        TextFileStorage.AppendBookLine(line);

        return true;
    }
}
