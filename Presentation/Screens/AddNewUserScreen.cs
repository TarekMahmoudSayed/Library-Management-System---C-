using System;
using System.Collections.Generic;
using System.Text;

using DataModeling;
using Bussiness_Layer;

namespace Presentation.Screens
{
    internal class AddNewUserScreen : Screen
    {

        static private User  _readNewUserInfo()
        {

            User user = new User();

            Console.Write("\nPlease Enter Name : ");
            user.Name = Console.ReadLine();
            Console.Write("\nPlease Enter Phone Number : ");
            user.PhoneNumber = Console.ReadLine();

            user.Card = new Data_Modeling.LibraryCard();


            Console.Write("\nPlease Enter UserName : ");
            user.Card.UserName = Console.ReadLine();
            Console.Write("\nPlease Enter Card ID : ");
            user.Card.CardID = Console.ReadLine();
            Console.Write("\nPlease Enter PassWord : ");
            user.Card.Password = Console.ReadLine();
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
                Console.WriteLine("\n\nError Occured, Please Try Again");
            }

        }
    }
}
