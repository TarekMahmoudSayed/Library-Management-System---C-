using Bussiness_Layer.CRUD;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.Screens; 

internal class AddNewBookScreen : Screen
{

    static private Book _readBookInfo ()
    {
        Book book = new Book();

        Console.Write("\n\nPlease Enter Book Title ? ");
        book.Title = Console.ReadLine();
        Console.Write("\nPlease Enter Book ID ? ");
        book.ID = Console.ReadLine();
        Console.Write("\nPlease Enter Book Author ? ");
        book.Author = Console.ReadLine();
        Console.Write("\nPlease Enter Book Year ? ");
        book.Year = Console.ReadLine();


        return book;

    }
    static internal void ShowAddNewBookScreen ()
    {
        Screen.DrawScreenHeader("Add New Book Screen");

        Book book = new Book ();
        book = _readBookInfo();

        if (AddNewBook.Execute(book))
        {
            Console.WriteLine("\n\nBook Added Successfully ");
        }else
        {
            Console.WriteLine("\n\nError Ouccered , Please Try Again ");
        }



    }

}
