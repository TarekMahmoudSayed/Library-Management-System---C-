using Bussiness_Layer;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace Presentation.Screens;

using Bussiness_Layer;
using System.Net;

internal class LoginScreen : Screen
{
    static internal void ShowLoginScreen (out Permissions Permission, out bool isSuccessed)
    {
        Screen.DrawScreenHeader("Login Screen");

        Console.WriteLine("\n\nVerify Your Card : ");
        Console.WriteLine("======================");
        Console.Write("\nPlease Enter UserName : ");
        string userName = Console.ReadLine();

        if (!Login.HasCard (userName))
        {
            Console.WriteLine("\n\nSorry, You Don't Have A Card Please Contact Library Admin To Add Your Card ! ");
            Permission = Permissions.none;
            isSuccessed = false;
            return ;
        }

        Console.Write("\nPlease Enter password : ");
        string password = Console.ReadLine();

        if (!Login.Authentication (password))
        {
            Console.WriteLine("\n\nInvalid Password, Please Try Again Later");
            Permission = Permissions.none;
            isSuccessed = false;
            return;
        }else
        {
            Console.WriteLine("\n\nValid Card, Please Enter Any Key To Authorization");
            Console.ReadKey();

            if (Login.Authorization(out Permission))
            {
                Console.WriteLine("\n\nAuthorization Confirmed, Please Enter Any Key To Continue");
                isSuccessed = true;
                
            }else
            {
                Console.WriteLine("\n\nAuthorization not Confirmed, Please Contact Library Admin");
                Permission = Permissions.none;
                isSuccessed = false;
            }
        }

        


    }
}
