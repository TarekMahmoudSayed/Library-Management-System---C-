namespace Persentation;

internal class InputValidate
{

    public static int ReadIntFromUser(string message)
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

    public static int ReadIntFromUserBetween(string message, int from, int to)
    {

        int number;
        do
        {
            number = ReadIntFromUser(message);

        } while (number < from || number > to);

        return number;

    }

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
}
