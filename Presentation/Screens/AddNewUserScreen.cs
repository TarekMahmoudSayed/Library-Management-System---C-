using Bussiness_Layer.Users;
using Data_Access.Entities;
using Persentation;

namespace Presentation.Screens;

internal class AddNewUserScreen : Screen
{

    public static string ReadPassword()
    {
        string password = "";
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(true);

            // لو المستخدم داس Backspace وحذف حرف
            if (key.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                password = password.Substring(0, password.Length - 1);
                Console.Write("\b \b"); // بتمسح النجمة من على الشاشة
            }
            // لو الحرف مش زرار تحكم (زي Enter أو Backspace)، ضيفه واطبع *
            else if (!char.IsControl(key.KeyChar))
            {
                password += key.KeyChar;
                Console.Write("*");
            }
        }
        while (key.Key != ConsoleKey.Enter); // بتفضل شغال لحد ما تدوس Enter

        Console.WriteLine(); // ننزل سطر جديد بعد ما نخلص
        return password;
    }

    static private User  _readNewUserInfo()
    {

        User user = new User();

        Console.Write("\nPlease Enter Name : ");
        user.Name = Console.ReadLine();
        Console.Write("\nPlease Enter Phone Number : ");
        user.PhoneNumber = Console.ReadLine();

        user.Card = new LibraryCard();


        Console.Write("\nPlease Enter UserName : ");
        user.Card.UserName = Console.ReadLine();
        Console.Write("\nPlease Enter Card ID : ");
        user.Card.CardID = Console.ReadLine();
        Console.Write("\nPlease Enter PassWord : ");
        user.Card.Password = InputValidate.ReadPassword();
        user.Card.IssueDate = DateTime.Now;

        Console.Write("\nPlease Enter Permssions : ");
        try
        {
            user.Card.Permission = int.Parse(Console.ReadLine());

        }catch
        {
            user.Card.Permission = 1;
        }

        Console.Write("\nDo You Want To Activate Card [y/n] : ");
        char input;
        try
        {
             input = char.Parse(Console.ReadLine());

        }
        catch
        {
             input = 'n';
        }

        if (char.ToLower (input) == 'y')
        {
            user.Card.IsActive = true;
        }else
        {
            user.Card.IsActive = false;
        }


        return user;

    }
    static public void ShowAddNewUserScreen ()
    {
        Screen.DrawScreenHeader("Add New User Screen ");

        User user = _readNewUserInfo();

        if (!AddNewUser.isValidUser(user))
        {
            Console.WriteLine("\n\nInvalid User, You must Choice Unique UserName And ID Card !");
            return;
        }

        if (AddNewUser.Execute (user))
        {
            Console.WriteLine("\n\nUser Added Successfully :-) ");
        }else
        {
            
            Console.WriteLine("\n\nError Occurred, Please Try Again");
        }

    }
}
