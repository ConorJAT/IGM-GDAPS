using System;

namespace RepoSetupVerify
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Welcome to the Program! To verify entry, please enter your name: "); 

            string user;
            string response;

            user = Console.ReadLine();
            Console.Write($"\"{user},\" is this the correct name? (Type \"no\" to enter new name): ");
            response = Console.ReadLine().ToLower();

            while(response == "no")
            {
                Console.Write("\nPlease enter a new name: ");
                user = Console.ReadLine();
                Console.Write($"\"{user},\" is this the correct name? (Type \"no\" to enter new name): ");
                response = Console.ReadLine().ToLower();
            }

            Console.WriteLine($"\nWelcome, {user}, to the Spring Semester!");
        }
    }
}
