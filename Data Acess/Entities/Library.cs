namespace Data_Access.Entities;

static public class Library
{
    static private List<Book> _books = new List <Book> (1000);

    static public IReadOnlyList<Book> Books => _books;

    static public void Load (List <Book> books)
    {
        _books = books ?? new List<Book>(1000);
    }
    static public bool Add (Book book)
    {
        if ( book == null || _books.Contains(book) )
        {
            return false;
        }

        _books.Add(book);

        return true;
    }
    static public bool Remove (Book book)
    {
        if (book == null || !_books.Contains(book))
        {
            return false;
        }

        _books.Remove(book);

        return true;
    }
    static public List<Book> GetAllBooks ()
    {
        return new List<Book>(_books);
        
    }
    static public bool IsBookExistByID (string bookID, out Book book) 
    {
        foreach (var i in _books)
        {
            if (i.ID.Equals(bookID, StringComparison.OrdinalIgnoreCase) ){
                book = i;
                return true;
            }
        }

        book = null;
        return false;
    }
    static public bool IsBookExistByTitle (string title, out Book book) 
    {
        foreach (var i in _books)
        {
            if (i.Title.Equals(title, StringComparison.OrdinalIgnoreCase) ){
                book = i;
                return true;
            }
        }

        book = null;
        return false;
    }

}
