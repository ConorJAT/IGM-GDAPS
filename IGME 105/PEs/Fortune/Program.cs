//Conor Race
//IGME.105.01 - Sep. 29, 2021
//Purpose: Acts as an 8-Ball simulator, accepting a user's name, allowing the
//user to ask questions and print out a random response. Also allows reports
//to be given based on total shake times.

using System;

namespace Fortune
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to this Magic 8-Ball Simulator!");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Who's fortunes will we be telling today: ");
            Console.ForegroundColor = ConsoleColor.White;
            string user = Console.ReadLine();
            MagicEightBall my8Ball = new MagicEightBall(user); //New 'MagicEightBall' object creation.

            string response = null;

            while (response != "quit") //Loops for as long as reponse doesn't equal "quit"
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n\nWhat would you like to do?");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\'Shake\' - Recieve a Fortune | \'Report\' - Get a Report | \'Quit\' - Leave the 8-Ball");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\nYour choice, my friend: ");
                Console.ForegroundColor = ConsoleColor.White;
                response = Console.ReadLine().ToLower();

                switch (response)
                {
                    case "shake":
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("  >>What is it you desire to ask: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine($"  >>The Magic 8-Ball says: \"{my8Ball.ShakeBall()}\""); //Call to the .ShakeBall() method for the 8-ball object.
                        break;

                    case "report":
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine($"  >>{my8Ball.Report()}"); //Call to the .Report() method for the 8-ball object.
                        break;

                    case "quit":
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("  >>Safe travels, my friend!");
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("  >>I'm sorry, but I do not understand that choice. Please try again.");
                        break;
                }
            }

        }
    }
}
