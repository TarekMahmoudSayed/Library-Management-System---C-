using Presentation.Screens;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace Presentation;

using Bussiness_Layer;

static internal class App
{

    static private void _run (Permissions permission, bool isSuccessed)
    {
        if (!isSuccessed)
        {
            return;
        }

        switch (permission) 
        {
            case Permissions.Librarian:
                LibrarianForm.Login();
                break;
            case Permissions.LibraryUser:
                LibraryUserForm.Login();
                break;
            default:
                break;

        }
      

    }

    static internal void Login ()
    {
        Permissions permission;
        bool isSuccessed;

        LoginScreen.ShowLoginScreen(out permission, out isSuccessed);

        Console.ReadKey();
        Console.Clear();

        _run(permission, isSuccessed);

    }

}
