namespace Bussiness_Layer.Users;

using Data_Access.Entities;
using Infrastructure;

public class AddNewUser
{

    static public bool isValidUser (User user)
    {

        List<User> users = TextFileStorage.LoadUsers();


        foreach (var i in users)
        {
            if (i.Card.UserName == user.Card.UserName || i.Card.CardID == user.Card.CardID)
            {
                return false;
            }
        }

        return true;
    }
    static public bool Execute (User user)
    {

        if (user == null || !isValidUser (user))
        {
            return false;
        }

        user.Card.Password = EncryptionUtility.Hash(user.Card.Password);

        TextFileStorage.AppendUserLine(TextFileStorage.ConvertUserRecordToLine(user));

        return true;
    }
}
