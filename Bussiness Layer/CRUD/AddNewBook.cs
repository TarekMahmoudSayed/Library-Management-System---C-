using Entities;
using Infrastructure;



namespace Bussiness_Layer.CRUD; 

static public class AddNewBook
{
    static public bool Execute (Book book)
    {

        if (!Library.Add (book))
        {
            return false;
        }

        string line = Infrastructure.File.ConvertBookRecordToLine(book);

        Infrastructure.File.AddDataBookLineToFile(line);

        return true;
    }
}
