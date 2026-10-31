namespace Data_Access.Entities; 
public class Book
{
    public string Title { set; get; }
    public string ID { set; get; }
    public string Author { set; get; }
    public string Year { set; get; }
    public bool IsBorrowed { set; get; }
    
    public bool IsAvailable()
    {
        return !IsBorrowed;
    }
    

}
