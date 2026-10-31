using Bussiness_Layer.Books;

using Presentation.Screens;

namespace Presentation
{
    static internal class LibrarianForm
    {
        static internal void Login ()
        {

            LoadBooks.Execute();

            LibrarianMenuScreen.ShowMenuScreen();
        }
    }
}
