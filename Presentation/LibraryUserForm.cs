using Bussiness_Layer.Books;
using Presentation.Screens;

namespace Presentation
{
    internal class LibraryUserForm
    {
        static internal void Login()
        {
            LoadBooks.Execute();
            
            LibraryUserMenuScreen.ShowMenueScreen();
            
        }
    }
}
