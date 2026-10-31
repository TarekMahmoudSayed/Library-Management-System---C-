namespace Entities; 
public class Book
{
    public string Title { set; get; }
    public string ID { set; get; }
    public string Author { set; get; }
    public string Year { set; get; }
    public bool isBorrowed { set; get; }
    public void DisplayDetails ()
    {
        string status = (!isBorrowed) ? "Avilable" : "Not Avilable";
        Console.WriteLine("Book Card: ");
        Console.WriteLine("=======================");
        Console.WriteLine($"Title  : {Title}");
        Console.WriteLine($"ID     : {ID}");
        Console.WriteLine($"Author : {Author}");
        Console.WriteLine($"Year   : {Year}");
        Console.WriteLine($"Statue   : {status}");
        Console.WriteLine("=======================");

    }
    public bool isAvilable ()
    {
        return !isBorrowed;
    }
    

}
