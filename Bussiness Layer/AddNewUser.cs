using DataModeling;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness_Layer;

using Infrastructure;

public class AddNewUser
{

    static public bool isValidUser (User user)
    {

        List<User> users = Login.users;

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

        Login.users.Add(user);
        Infrastructure.File.AddDataUserLineToFile(Infrastructure.File.ConvertUserRecordToLine(user));

        return true;
    }
}
