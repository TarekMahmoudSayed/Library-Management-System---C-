namespace Entities;

static public class Library
{
    public static List<Book> Books = new List <Book> (1000);
    static public bool Add (Book book)
    {
        if (Books.Contains(book) || book == null)
        {
            return false;
        }

        Books.Add(book);

        return true;
    }
    static public bool Remove (Book book)
    {
        if (!Books.Contains(book) || book == null)
        {
            return false;
        }

        Books.Remove(book);

        return true;
    }
    static public List<Book> GetAllBooks ()
    {
        if (Books.Count == 0)
        {
            return null;
        }
            
        return Books;
        
    }
    static public bool IsBookExistByID (string bookID, out Book book) 
    {
        foreach (var i in Books)
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
        foreach (var i in Books)
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
