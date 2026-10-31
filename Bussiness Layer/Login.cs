using DataModeling;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

using Data_Modeling;
using System.Net.Http.Headers;


namespace Bussiness_Layer;

public  class Login
{
    static internal List<User> users = new List<User> (1000);
    static private User CurrentUser = new User ();
    
    static public bool HasCard(string username) 
    {
        CurrentUser.Card = new LibraryCard();
        users = Infrastructure.File.LoadUsersDataFormFile();
        
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

    static public bool Authentication (string password)
    {
        return (CurrentUser.Card.Password == password);
    }

    static public bool Authorization (out Permissions permission)
    {

        switch (CurrentUser.Card.Permission)
        {
            case 1:
                permission = Permissions.LibraryUser;
                break;
            case -1:
                permission = Permissions.Librarian;
                break;
            default:
                permission = Permissions.none;
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
    static public string GetCurrentPermssion ()
    {

        if (string.IsNullOrEmpty(CurrentUser.Name))
        {
            return "";
        }

        if (CurrentUser.Card.Permission == -1) return "Admin";
        if (CurrentUser.Card.Permission == 1) return "Library User";

        return "";
        
    }

    static public void Clear ()
    {
        CurrentUser = new User ();
        CurrentUser.Card = new LibraryCard ();
    }

}
