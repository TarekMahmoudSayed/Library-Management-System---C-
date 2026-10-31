using Bussiness_Layer;
using Bussiness_Layer.Users;
using Persentation;

namespace Presentation.Screens;



internal class LoginScreen : Screen
{
    static internal void ShowLoginScreen (out UserRole Permission, out bool isSuccessed)
    {
        Screen.DrawScreenHeader("     Login Screen");

        Console.WriteLine("\n\nVerify Your Card : ");
        Console.WriteLine("_______________________");
        Console.Write("\nPlease Enter UserName : ");
        string userName = Console.ReadLine();

        if (!Login.HasCard (userName))
        {
            Console.WriteLine("\n\nSorry, You Don't Have A Card Please Contact Library Admin To Add Your Card ! ");
            Permission = UserRole.None;
            isSuccessed = false;
            return ;
        }

        Console.Write("\nPlease Enter password : ");
        string password = InputValidate.ReadPassword();

        if (!Login.Authenticate (password))
        {
            Console.WriteLine("\n\nInvalid Password, Please Try Again Later");
            Permission = UserRole.None;
            isSuccessed = false;
            return;
        }else
        {
            Console.Write("\n\nValid Card, Please Enter Any Key To Authorize");
            Console.ReadKey();

            if (Login.Authorize(out Permission))
            {
                Console.Write("\n\n\nAuthorization Confirmed, Please Enter Any Key To Continue");
                isSuccessed = true;
                
            }else
            {
                Console.Write("\n\n\nAuthorization not Confirmed, Please Contact Library Admin");
                Permission = UserRole.None;
                isSuccessed = false;
            }
        }

        


    }
}
