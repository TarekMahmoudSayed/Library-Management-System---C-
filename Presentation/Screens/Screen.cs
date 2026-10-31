namespace Presentation.Screens;

using Bussiness_Layer.Users;
using Data_Access.Entities;

internal class Screen
{

    static private void  _addCurrentUserAndCurrentDate ()
    {

        Console.WriteLine($"\n\n\t\t\t\t\tUser: {Login.GetCurrentUserName()}");
        Console.WriteLine($"\t\t\t\t\tPermssion: {Login.GetCurrentRoleName()}");
        Console.WriteLine($"\t\t\t\t\tDateTime: {DateTime.Now}");

    }
    protected static void DrawScreenHeader (string title , string subTitle = "")
    {
        Console.Write("\t\t\t\t\t______________________________________");
        Console.Write($"\n\n\t\t\t\t\t\t{title}");

        if (!string.IsNullOrWhiteSpace(subTitle))
        {
            Console.Write($"\n\n\t\t\t\t\t\t     {subTitle}");


        }

        Console.Write("\n\t\t\t\t\t______________________________________");

        _addCurrentUserAndCurrentDate();

        Console.Write("\t\t\t\t\t______________________________________\n");


    }

    protected static void DisplayBookDetails(Book book)
    {
        string status = (!book.IsBorrowed) ? "Avilable" : "Not Avilable";

        Console.WriteLine("Book Card: ");
        Console.WriteLine("=======================");
        Console.WriteLine($"Title  : {book.Title}");
        Console.WriteLine($"ID     : {book.ID}");
        Console.WriteLine($"Author : {book.Author}");
        Console.WriteLine($"Year   : {book.Year}");
        Console.WriteLine($"Status   : {status}");
        Console.WriteLine("=======================");
    }
}
