using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness_Layer
{
    public class RequestBorrowBook
    {
        static public bool Execute(Book book)
        {
            if (book.isAvilable ())
            {
                book.isBorrowed = true;
                Infrastructure.File.SaveBooksDataToFile(Library.Books);
                return true;
            }else
            {
                return false;
            }
        }

    }
}
