namespace Infrastructure;

using Entities;
using DataModeling;

using System.IO;
using static System.Net.WebRequestMethods;
using System.Linq;
using System.Transactions;

public class File
{
    static private readonly string _seperator = "#//#" ;

    static private DateTime _currentDateTime = DateTime.Now.Date;

    static private readonly string _bookFilePath = "D:\\source\\repos\\CSharpFundamentals\\Library Management System\\Data Acess\\DataBase\\Books.txt";
    static private readonly string _userFilePath = "D:\\source\\repos\\CSharpFundamentals\\Library Management System\\Data Acess\\DataBase\\Users.txt";

    static public  string ConvertBookRecordToLine (Book book)
    {
        string line =  "";

        line += book.Title + _seperator;
        line += book.ID + _seperator;
        line += book.Author + _seperator;
        line += book.Year + _seperator;
        line += book.isBorrowed ;


        return line;
    }
    static public  string ConvertUserRecordToLine (User user)
    {
        string line =  "";

        line += user.Name + _seperator;
        line += user.PhoneNumber + _seperator;
        line += user.Card.UserName + _seperator;
        line += user.Card.CardID + _seperator;
        line += EncryptionUtility.Encrypt(user.Card.Password) + _seperator;
        line += user.Card.IssueDate + _seperator;
        line += user.Card.Permission + _seperator;
        line += user.Card.IsActive ;
        


        return line;
    }
    static public Book ConvertLineToBookRecord (string line)
    {
        Book book = new Book ();


        string[] records = line.Split(_seperator);

        if (records.Count() != 5)
        {
            return null;
        }

        book.Title = records[0];
        book.ID = records[1];
        book.Author = records[2];
        book.Year = records[3];

        try
        {
            book.isBorrowed = bool.Parse(records[4]);
        }catch
        {
            book.isBorrowed = false;
        }


        return book;
    }
    static public User ConvertLineToUserRecord (string line)
    {
        User user = new User ();


        string[] records = line.Split(_seperator);

        if (records.Count() != 8)
        {
            return null;
        }

        user.Name = records[0];
        user.PhoneNumber = records[1];
        user.Card = new Data_Modeling.LibraryCard();
        user.Card.UserName = records[2];
        user.Card.CardID = records[3];
        user.Card.Password = EncryptionUtility.Decrypt(records[4]);

        try
        {
            user.Card.IssueDate = DateTime.Parse(records[5]);
        }catch
        {
            user.Card.IssueDate = _currentDateTime;
        }

        try
        {
            user.Card.IsActive = bool.Parse(records[7]);
        }
        catch
        {
            user.Card.IsActive = false;
        }

        try
        {
            user.Card.Permission = int.Parse(records[6]);
        }
        catch
        {
            user.Card.Permission = 1;
        }


        return user;
    }
    static public void AddDataBookLineToFile (string line)
    {
        StreamWriter myFile = new StreamWriter (_bookFilePath, true);

        myFile.WriteLine(line);

        myFile.Close();

    }
    static public void AddDataUserLineToFile (string line)
    {
        StreamWriter myFile = new StreamWriter (_userFilePath, true);

        myFile.WriteLine(line);

        myFile.Close();

    }
    static public List<Book> LoadBooksDataFormFile ()
    {
        List<Book> books = new List<Book>(1000);

        StreamReader myFile = new StreamReader(_bookFilePath);

      if (!System.IO.File.Exists (_bookFilePath)) {
            Console.WriteLine("File Not Exsit");
            return null;
      }

        string line = "";
        while ((line = myFile.ReadLine()) != null)
        {
            books.Add(ConvertLineToBookRecord(line));
        }

        myFile.Close();

        return books;
    }
    static public List<User> LoadUsersDataFormFile ()
    {
        List<User> users = new List<User>(1000);

        StreamReader myFile = new StreamReader(_userFilePath);

        if (!System.IO.File.Exists(_bookFilePath))
        {
            Console.WriteLine("File Not Exsit");
            return null;
        }

        string line = "";
        while ((line = myFile.ReadLine()) != null)
        {
            users.Add(ConvertLineToUserRecord(line));
        }

        myFile.Close();

        return users;
    }
    static public void SaveBooksDataToFile(List<Book> books)
    {

        if (!System.IO.File.Exists(_bookFilePath))
        {
            Console.WriteLine("File Not Exsit");
            return;
        }

        StreamWriter myFile = new StreamWriter(_bookFilePath);

        foreach (var i in books)
        {
            myFile.WriteLine(ConvertBookRecordToLine(i));
        }

        myFile.Close();

    }
    static public void SaveUsersDataToFile(List<User> users)
    {

        if (!System.IO.File.Exists(_bookFilePath))
        {
            Console.WriteLine("File Not Exsit");
            return ;
        }

        StreamWriter myFile = new StreamWriter(_userFilePath);

        foreach (var i in users)
        {
            myFile.WriteLine(ConvertUserRecordToLine(i));
        }

        myFile.Close();

    }

}
