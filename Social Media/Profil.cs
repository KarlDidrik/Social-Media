using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_Media
{
    internal class UserProfile
    {
        public string Username{ get; set; }
        public string Email { get; set; }
        public string Occupation { get;  set; }
        public int Age { get;  set; }


        public UserProfile(string username, string email, string occupation, int age)
        {
            Username = username;
            Email = email;
            Occupation = occupation;
            Age = age;
        }

        public void PrintProfile()
        {
            Console.WriteLine($"Profil for {Username}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Occupation: {Occupation}");
            Console.WriteLine($"Age : {Age}");
        }
    }
}
