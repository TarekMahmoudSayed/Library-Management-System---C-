using Entities;
using Presentation.Screens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation
{
    internal class LibraryUserForm
    {
        static internal void Login()
        {
            Library.Books = Infrastructure.File.LoadBooksDataFormFile();
            
            LibraryUserMenueScreen.ShowMenueScreen();
            
        }
    }
}
