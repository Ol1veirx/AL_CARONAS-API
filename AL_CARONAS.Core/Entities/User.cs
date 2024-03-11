using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL_CARONAS.Core.Entities
{
    public class User
    {
        public User(int userId, string name, string email, string password, string phone)
        {
            UserId = userId;
            Name = name;
            Email = email;
            Password = password;
            Phone = phone;
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone {  get; set; }
    }
}
