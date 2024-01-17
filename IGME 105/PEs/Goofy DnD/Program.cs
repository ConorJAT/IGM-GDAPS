//Conor Race
//Oct. 18th, 2021
//Purpose: Creates and uses various Character sub-class objects.

using System;

namespace Goofy_DnD
{
    class Program
    {
        static void Main(string[] args)
        {
            Warrior myWarrior = new Warrior("Knuckles", 20, 17, 11, 6);
            Wizard myWizard = new Wizard("Silver", 16, 13, 20, 80);
            Thief myThief = new Thief("Rouge", 17, 17, 17, 3);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Character Stats: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            myWarrior.PrintWarrior();
            myWizard.PrintWizard();
            myThief.PrintThief();
            Console.WriteLine("\n");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Special Moves: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            myWarrior.SpecialMove();
            myWizard.SpecialMove();
            myThief.SpecialMove();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("------------------------------------------------------------------------------------------------\n");

            myWarrior.Intelligence = 15;
            myWizard.Dexterity = 15;
            myThief.Strength = 19;

            myWarrior.Days = 0;
            myWizard.Chance = 15;
            myThief.Calls = 11;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Character Stats: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            myWarrior.PrintWarrior();
            myWizard.PrintWizard();
            myThief.PrintThief();
            Console.WriteLine("\n");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Special Moves: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            myWarrior.SpecialMove();
            myWizard.SpecialMove();
            myThief.SpecialMove();
        }
    }
}
