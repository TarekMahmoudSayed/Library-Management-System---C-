using Data_Access.Entities;

namespace Bussiness_Layer.Books
{
    public class FindBook
    {
        static public bool Execute(out Book book, string input, SearchBy searchBy)
        {
            bool isFound = false;

            Book FoundBook = new Book();

            switch (searchBy)
            {
                case SearchBy.ById:
                    isFound = Library.IsBookExistByID(input, out FoundBook);
                    break;
                case SearchBy.ByTitle:
                    isFound = Library.IsBookExistByTitle(input, out FoundBook);
                    break;
            }

            if (!isFound )
            {
                book = FoundBook;
                return false;
            }

            book = FoundBook;
            return true;
        }
    }
}
