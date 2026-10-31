using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness_Layer
{
    public class ReturnBook
    {
        static public bool Execute(Book book)
        {
            if (!book.isAvilable())
            {
                book.isBorrowed = false;
                Infrastructure.File.SaveBooksDataToFile(Library.Books);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
