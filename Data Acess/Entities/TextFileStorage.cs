using System.Globalization;

namespace Data_Access.Entities;
public class TextFileStorage
{
    static private readonly string _separator = "#//#" ;

    static private DateTime _currentDateTime = DateTime.Now.Date;


    // Handle FileHelper Paths To Be Daynamic 
    static private string FindDataFolder()
    {
        DirectoryInfo dir = new DirectoryInfo(AppContext.BaseDirectory);

        while (dir != null)
        {
            string candidate = Path.Combine(dir.FullName, "Data Access", "Data");

            if (Directory.Exists(candidate))
            {
                return candidate;
            }

            dir = dir.Parent;
        }

        return Path.Combine(AppContext.BaseDirectory, "Data");
    }
    static private readonly string _dataFolder = FindDataFolder();
    static private readonly string _bookFilePath = Path.Combine(_dataFolder, "Books.txt");
    static private readonly string _userFilePath = Path.Combine(_dataFolder, "Users.txt");


    // Convert To Line
    static public  string ConvertBookRecordToLine (Book book)
    {
        string line =  "";

        line += book.Title + _separator;
        line += book.ID + _separator;
        line += book.Author + _separator;
        line += book.Year + _separator;
        line += book.IsBorrowed ;


        return line;
    }
    static public  string ConvertUserRecordToLine (User user)
    {
        string line =  "";

        line += user.Name + _separator;
        line += user.PhoneNumber + _separator;
        line += user.Card.UserName + _separator;
        line += user.Card.CardID + _separator;
        line += (user.Card.Password) + _separator;
        line += user.Card.IssueDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + _separator;
        line += user.Card.Permission + _separator;
        line += user.Card.IsActive ;
        


        return line;
    }

    //Convert To Record
    static public Book ConvertLineToBookRecord (string line)
    {
        Book book = new Book ();


        string[] records = line.Split(_separator);

        if (records.Count() != 5)
        {
            return book;
        }

        book.Title = records[0];
        book.ID = records[1];
        book.Author = records[2];
        book.Year = records[3];

        try
        {
            book.IsBorrowed = bool.Parse(records[4]);
        }catch
        {
            book.IsBorrowed = false;
        }


        return book;
    }
    static public User ConvertLineToUserRecord (string line)
    {
        User user = new User ();


        string[] records = line.Split(_separator);

        if (records.Count() != 8)
        {
            return user;
        }

        user.Name = records[0];
        user.PhoneNumber = records[1];
        user.Card = new LibraryCard();
        user.Card.UserName = records[2];
        user.Card.CardID = records[3];
        user.Card.Password = (records[4]);

        if (DateTime.TryParse(records[5], CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime issueDate)
            || DateTime.TryParse(records[5], out issueDate))
        {
            user.Card.IssueDate = issueDate;
        }
        else
        {
            user.Card.IssueDate = _currentDateTime;
        }

        if (int.TryParse(records[6], out int permission))
        {
            user.Card.Permission = permission;
        }
        else
        {
            user.Card.Permission = 1;
        }

        if (bool.TryParse(records[7], out bool isActive))
        {
            user.Card.IsActive = isActive;
        }
        else
        {
            user.Card.IsActive = false;
        }


        return user;
    }

    //Add Data Line
    static public void AppendBookLine (string line)
    {

        if (!System.IO.File.Exists(_bookFilePath))
        {
            Console.WriteLine("File Not Exist");
            return ;
        }

        using StreamWriter myFile = new StreamWriter (_bookFilePath, true);

        myFile.WriteLine(line);

        myFile.Close();

    }
    static public void AppendUserLine (string line)
    {

        if (!System.IO.File.Exists(_userFilePath))
        {
            Console.WriteLine("File Not Exist");
            return;
        }

        using StreamWriter myFile = new StreamWriter (_userFilePath, true);

        myFile.WriteLine(line);

        myFile.Close();

    }

    // Load Data From FileHelper
    static public List<Book> LoadBooks ()
    {
        List<Book> books = new List<Book>(1000);

        if (!System.IO.File.Exists(_bookFilePath))
        {
            Console.WriteLine("File Not Exist");
            return books;
        }

        using StreamReader myFile = new StreamReader(_bookFilePath);

        string line = "";
        while ((line = myFile.ReadLine()) != null)
        {
            books.Add(ConvertLineToBookRecord(line));
        }

        myFile.Close();

        return books;
    }
    static public List<User> LoadUsers ()
    {
        List<User> users = new List<User>(1000);

        if (!System.IO.File.Exists(_bookFilePath))
        {
            Console.WriteLine("File Not Exist");
            return users;
        }

        using StreamReader myFile = new StreamReader(_userFilePath);

        string line = "";
        while ((line = myFile.ReadLine()) != null)
        {
            users.Add(ConvertLineToUserRecord(line));
        }

        myFile.Close();

        return users;
    }

    //Save Data To FileHelper
    static public void SaveBooksToFile(IEnumerable<Book> books)
    {

        if (!System.IO.File.Exists(_bookFilePath))
        {
            Console.WriteLine("File Not Exist");
            return;
        }

        using StreamWriter myFile = new StreamWriter(_bookFilePath);

        foreach (var i in books)
        {
            myFile.WriteLine(ConvertBookRecordToLine(i));
        }

        myFile.Close();

    }
    static public void SaveUsersToFile(List<User> users)
    {

        if (!System.IO.File.Exists(_bookFilePath))
        {
            Console.WriteLine("File Not Exist");
            return ;
        }

        using StreamWriter myFile = new StreamWriter(_userFilePath);

        foreach (var i in users)
        {
            myFile.WriteLine(ConvertUserRecordToLine(i));
        }

        myFile.Close();

    }

}
