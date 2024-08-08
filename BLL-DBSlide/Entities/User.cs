using System;
using System.Collections.Generic;
using System.Text;

namespace BLL_DBSlide.Entities
{
    public class User
    {

        public Guid User_Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }

        public User() { }

        public User(string email, string password, string first_Name, string last_Name)
        {
            Email = email;
            Password = password;
            First_Name = first_Name;
            Last_Name = last_Name;
        }
        public User(Guid user_Id, string email, string password, string first_Name, string last_Name)
        {
            User_Id = user_Id;
            Email = email;
            Password = password;
            First_Name = first_Name;
            Last_Name = last_Name;
        }

    }
}
