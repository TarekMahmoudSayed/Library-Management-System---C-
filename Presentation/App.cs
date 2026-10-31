namespace Presentation;

using Bussiness_Layer;
using Presentation.Screens;

static internal class App
{

    static private void _run (UserRole permission, bool isSuccessed)
    {
        if (!isSuccessed)
        {
            return;
        }

        switch (permission) 
        {
            case UserRole.Librarian:
                LibrarianForm.Login();
                break;
            case UserRole.Member:
                LibraryUserForm.Login();
                break;
            default:
                break;

        }
      

    }

    static internal void Login ()
    {
        UserRole permission;
        bool isSuccessed;

        LoginScreen.ShowLoginScreen(out permission, out isSuccessed);

        Console.ReadKey();
        Console.Clear();

        _run(permission, isSuccessed);

    }

}
