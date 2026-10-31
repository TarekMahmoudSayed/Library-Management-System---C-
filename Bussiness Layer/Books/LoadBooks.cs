using Data_Access.Entities;

namespace Bussiness_Layer.Books;

static public class LoadBooks
{
    static public void Execute()
    {
        Library.Load(TextFileStorage.LoadBooks());
    }
}