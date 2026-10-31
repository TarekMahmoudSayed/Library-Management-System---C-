using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.Screens;

using Bussiness_Layer;
internal class Screen
{

    static private void  _addCurrentUserAndCurrentDate ()
    {

        Console.WriteLine($"\n\n\t\t\t\t\tUser: {Login.GetCurrentUserName()}");
        Console.WriteLine($"\t\t\t\t\tPermssion: {Login.GetCurrentPermssion()}");
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
}
