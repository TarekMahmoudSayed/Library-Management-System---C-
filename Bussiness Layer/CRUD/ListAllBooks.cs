using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness_Layer.CRUD; 

public class ListAllBooks
{
    static public void Execute(out List <Book>books)
    {
        books = Library.GetAllBooks();
    }
}
