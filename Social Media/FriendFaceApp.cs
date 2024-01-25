using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FriendFaceNamespace
{
    internal class FriendFaceApp
    {
        public Dictionary<string, UserProfile> Users = new Dictionary<string, UserProfile>();
        public List<string> FriendList = new List<string>();
        public string LoggedInUser;

        public void CreateUser(string username, string email, string occupation, int age)
        {
            UserProfile userProfile = new UserProfile(username, email, occupation, age);
            Users.Add(username, userProfile);
        }

        public void Login(string username)
        {
            if (Users.ContainsKey(username))
            {
                LoggedInUser = username;
                Console.WriteLine($"{username} er nå innlogget.");
            }
            else
            {
                Console.WriteLine($"{username} eksisterer ikke. Vennligst opprett en bruker først.");
            }
        }

        public void AddFriend(string friendUsername)
        {
            if (IsValidFriendToAdd(friendUsername))
            {
                FriendList.Add(friendUsername);
                Console.WriteLine($"{friendUsername} er lagt til som venn.");
            }
            else
            {
                Console.WriteLine("Feil: Kan ikke legge til venn. Sjekk at brukeren eksisterer og ikke allerede er en venn.");
            }
        }

        private bool IsValidFriendToAdd(string friendUsername)
        {
            return IsExistingUser(friendUsername) && IsNotLoggedInUser(friendUsername) && IsNotAlreadyFriend(friendUsername);
        }

        private bool IsExistingUser(string username)
        {
            return Users.ContainsKey(username);
        }

        private bool IsNotLoggedInUser(string username)
        {
            return username != LoggedInUser;
        }

        private bool IsNotAlreadyFriend(string username)
        {
            return !FriendList.Contains(username);
        }

        public void RemoveFriend(string friendUsername)
        {
            if (FriendList.Contains(friendUsername))
            {
                FriendList.Remove(friendUsername);
                Console.WriteLine($"{friendUsername} er fjernet som venn.");
            }
            else
            {
                Console.WriteLine($"{friendUsername} er ikke en venn.");
            }
        }

        public void PrintFriendList()
        {
            Console.WriteLine("Venneliste:");
            foreach (var friend in FriendList)
            {
                Console.WriteLine(friend);
            }
        }

        public void ViewFriendProfile(string friendUsername)
        {
            if (FriendList.Contains(friendUsername))
            {
                UserProfile friendProfile = Users[friendUsername];
                friendProfile.PrintProfile();
            }
            else
            {
                Console.WriteLine($"{friendUsername} er ikke en venn. Du kan ikke se profilen.");
            }
        }
    }

    internal class UserProfile
    {
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Occupation { get; private set; }
        public int Age { get; private set; }

        public UserProfile(string username, string email, string occupation, int age)
        {
            Username = username;
            Email = email;
            Occupation = occupation;
            Age = age;
        }

        public void PrintProfile()
        {
            Console.WriteLine($"Profil for {Username}:");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Occupation: {Occupation}");
            Console.WriteLine($"Age: {Age} år");
        }
    }
}
