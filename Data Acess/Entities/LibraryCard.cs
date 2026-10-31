namespace Data_Access.Entities;

public class LibraryCard
{
    public string UserName { set; get; }
    public string CardID { set; get; }
    public DateTime IssueDate { set; get; }
    public bool IsActive { set; get; }

    public string Password { set; get; }
    public int Permission { set; get; }

    public bool IsValidate ()
    {
        return IsActive;
    }

}
