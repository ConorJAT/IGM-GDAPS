// Conor Race
// Nov. 10th, 2021
// Purpose: Creates a custom stack and queue and
// tests their abilities.

using System;

namespace Custom_Stacks_and_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            GameStack<string> spells = new GameStack<string>();
            GameQueue<string> players = new GameQueue<string>();


            // Playing around w/ custom stack:

            spells.Push("Utter Devestation");
            spells.Push("Resurrection");
            spells.Push("Pierce Defenses");
            spells.Push("Ritualistic Strength");
            spells.Push("Mind Burn");

            Console.WriteLine("Placing the following spells into a stack:\n");
            Console.WriteLine("  > Utter Devestation");
            Console.WriteLine("  > Resurrection");
            Console.WriteLine("  > Pierce Defenses");
            Console.WriteLine("  > Ritualistic Strength");
            Console.WriteLine("  > Mind Burn\n\n");

            Console.WriteLine("Resolving all spells (reversed order):\n");
            Console.WriteLine("  > " + spells.Pop());
            Console.WriteLine("  > " + spells.Pop());
            Console.WriteLine("  > " + spells.Pop());
            Console.WriteLine("  > " + spells.Pop());
            Console.WriteLine("  > " + spells.Pop());


            // Playing around w/ custom queue:

            players.Enqueue("Gideon Jura");
            players.Enqueue("Jace Beleran");
            players.Enqueue("Nissa Revane");
            players.Enqueue("Chandra Nalaar");
            players.Enqueue("Liliana Vess");

            Console.WriteLine("\n\nThe following players are joining the match:\n");
            Console.WriteLine("  > Gideon Jura");
            Console.WriteLine("  > Jace Beleran");
            Console.WriteLine("  > Nissa Revane");
            Console.WriteLine("  > Chandra Nalaar");
            Console.WriteLine("  > Liliana Vess\n\n");

            Console.WriteLine($"\"{players.Dequeue()}\" has joined the server\t- {players.Count} player(s) left in queue");
            Console.WriteLine($"\"{players.Dequeue()}\" has joined the server\t- {players.Count} player(s) left in queue");
            Console.WriteLine($"\"{players.Dequeue()}\" has joined the server\t- {players.Count} player(s) left in queue");
            Console.WriteLine($"\"{players.Dequeue()}\" has joined the server\t- {players.Count} player(s) left in queue");
            Console.WriteLine($"\"{players.Dequeue()}\" has joined the server\t- {players.Count} player(s) left in queue");
        }
    }
}
