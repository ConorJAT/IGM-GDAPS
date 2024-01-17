//Conor Race
//Oct. 28th, 2021
//Purpose: Creates two different Monster objects (One dragon and
//One beholder) and puts them head-to-head in battle with each other.

using System;

namespace Monster_Battle__Abstract_
{
    class Program
    {
        static void Main(string[] args)
        {
            Dragon myDragon = new Dragon(Damage.Acidic, "Acidrux", 115, Damage.Physical);
            Beholder myBehold = new Beholder(Damage.Physical, "Gronkus", 90, Damage.Electric);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Monster Mash 2021");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nMonster #1: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("    " + myDragon);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nMonster #2: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("    " + myBehold);

            bool areFighting = true;
            int round = 1;
            while (areFighting)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"\n\n------ Round {round} ------");
                Console.ForegroundColor = ConsoleColor.Gray;
                myDragon.Attack(myBehold);
                myBehold.Attack(myDragon);

                // Remaining health is always printed and tracked after a series of attacks.
                Console.WriteLine($"\n\n{myDragon.Name}'s Remaining Health: {myDragon.Health} HP");
                Console.WriteLine($"\n{myBehold.Name}'s Remaining Health: {myBehold.Health} HP");

                // Battle goes on indefinitely until one or both monsters reach 0 heath.
                if (myBehold.Health == 0 || myDragon.Health == 0)
                {
                    areFighting = false;
                }
                round++;
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n--- End of Battle ---");
            Console.ForegroundColor = ConsoleColor.Red;
            if (myDragon.Health == 0 && myBehold.Health != 0)
            {
                Console.WriteLine($"\n{myBehold.Name}, the Beholder, emerged victorious!");
            }
            else if (myDragon.Health != 0 && myBehold.Health == 0)
            {
                Console.WriteLine($"\n{myDragon.Name}, the Dragon, emerged victorious!");
            }
            // Considers a scenario where both monsters may kill each other on the same turn.
            else
            {
                Console.WriteLine("\nBoth monsters died, so no one won!");
            }
            Console.ForegroundColor = ConsoleColor.Gray;

        }
    }
}
