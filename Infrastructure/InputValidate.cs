using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure; 

public class InputValidate
{

    public static int ReadIntFromUser (string message)
    {

        bool isFaild = false;
        int input = 0;
        do
        {
            Console.Write($"\n\t\t\t\t\t{message}");
            isFaild = int.TryParse(Console.ReadLine(), out input);

        } while (!isFaild);

        return input;
    }

    public static int ReadIntFromUserBetween (string message, int from, int to)
    {

        int number;
        do
        {
            number = ReadIntFromUser(message);

        } while (number < from || number > to);

        return number;

    }

}
