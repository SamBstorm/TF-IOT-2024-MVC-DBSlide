using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_DBSlide.Entities
{
    public class User
    {
        public Guid User_Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
    }
}
