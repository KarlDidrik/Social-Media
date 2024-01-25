

using FriendFaceNamespace;
using Social_Media;

FriendFaceApp app = new FriendFaceApp();

app.CreateUser("Dodda", "karldodrik@gmail.com", "Utvikler", 24);
app.CreateUser("Radda", "dodrik@gmail.com", "Utvikler", 18);
app.CreateUser("Kal", "karl@gmail.com", "Utvikler", 22);

app.Login("Kal");

bool isRunning = true;

while (isRunning)
{
    Console.WriteLine("\nVelkommen til FriendFace!");
    Console.WriteLine("1. Legg til venn");
    Console.WriteLine("2. Fjern venn");
    Console.WriteLine("3. Vis venneliste");
    Console.WriteLine("4. Velg venn og vis profil");
    Console.WriteLine("5. Avslutt");

    Console.Write("Velg en handling (1-5): ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Write("Skriv inn brukernavnet til vennen du vil legge til: ");
            string friendToAdd = Console.ReadLine();
            app.AddFriend(friendToAdd);
            break;
        case "2":
            Console.Write("Skriv inn brukernavnet til vennen du vil fjerne: ");
            string friendToRemove = Console.ReadLine();
            app.RemoveFriend(friendToRemove);
            break;
        case "3":
            app.PrintFriendList();
            break;
        case "4":
            Console.Write("Skriv inn brukernavnet til vennen du vil se profilen til: ");
            string friendToView = Console.ReadLine();
            app.ViewFriendProfile(friendToView);
            break;
        case "5":
            isRunning = false;
            break;
        default:
            Console.WriteLine("Ugyldig valg. Prøv igjen.");
            break;
    }
}
