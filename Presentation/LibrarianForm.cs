using Entities;
using Presentation.Screens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation
{
    static internal class LibrarianForm
    {
        static internal void Login ()
        {
            Library.Books = Infrastructure.File.LoadBooksDataFormFile();
           
            LibrarianMenueScreen.ShowMenueScreen();
        }
    }
}
