using Data_Modeling;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModeling; 

public class User
{
    public string Name { set; get; }

    public string PhoneNumber { set; get; }

    public LibraryCard Card { set; get; }

}
