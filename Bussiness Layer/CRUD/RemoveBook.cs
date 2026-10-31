using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness_Layer.CRUD;

static public class RemoveBook
{
    static public bool Execute(string input, SearchBy searchBy)
    {
        Book book = new Book();

        bool isFound = false;

        switch (searchBy)
        {
            case SearchBy.ById:
                isFound = Library.IsBookExistByID(input, out book);
                break;
            case SearchBy.ByTitle:
                isFound = Library.IsBookExistByTitle(input, out book);
                break;
        }

        if (!isFound || !Library.Remove (book))
        {
            return false;
        }

        Infrastructure.File.SaveBooksDataToFile(Library.Books);

        return true;
    }
}
