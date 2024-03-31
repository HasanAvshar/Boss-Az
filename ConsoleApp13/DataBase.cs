using System;
using System.Collections.Generic;

namespace ConsoleApp13
{
    public class DataBase
    {
        static public List<User> Users = new List<User>();

        public static void AddUser(User user)
        {
            Users.Add(user);
        }
    }
}
