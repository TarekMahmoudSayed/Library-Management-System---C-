using Data_Access.Entities;
using Infrastructure;


namespace Bussiness_Layer.Users;

public  class Login
{
    static private User CurrentUser = new User ();
    
    static public bool HasCard(string username) 
    {
        List<User> users = TextFileStorage.LoadUsers();

        CurrentUser.Card = new LibraryCard();
        users = TextFileStorage.LoadUsers();
        
        foreach (var i in users)
        {
            if (i.Card.UserName == username)
            {
                CurrentUser = i;
                return true;
            }
        }

        return false;
    }

    static public bool Authenticate (string password)
    {
        return EncryptionUtility.Verify(password, CurrentUser.Card.Password);
    }

    static public bool Authorize (out UserRole permission)
    {

        switch (CurrentUser.Card.Permission)
        {
            case 1:
                permission = UserRole.Member;
                break;
            case -1:
                permission = UserRole.Librarian;
                break;
            default:
                permission = UserRole.None;
                break;

        }

        return CurrentUser.Card.IsValidate();


    }

    static public string GetCurrentUserName ()
    {
        if (string.IsNullOrEmpty(CurrentUser.Name))
        {
            return "";
        }else
        {
            return CurrentUser.Name;
        }
    }
    static public string GetCurrentRoleName ()
    {

        if (string.IsNullOrEmpty(CurrentUser.Name))
        {
            return "";
        }

        if (CurrentUser.Card.Permission == -1) return "Admin";
        if (CurrentUser.Card.Permission == 1) return "Member";

        return "";
        
    }

    static public void Clear ()
    {
        CurrentUser = new User ();
        CurrentUser.Card = new LibraryCard ();
    }



}
