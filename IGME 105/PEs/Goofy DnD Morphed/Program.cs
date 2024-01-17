//Conor Race
//Oct. 20th, 2021
//Purpose: Creates and uses various Character sub-class objects in a list.
//Utilizes polymorphism and downcasting to achieve this goal.

using System;
using System.Collections.Generic;

namespace Goofy_DnD
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Character> players = new List<Character>();
            Random rng = new Random();
            int whoIs;
            
            Character myWarrior = new Warrior("Knuckles", rng.Next(5,21), rng.Next(5, 21), rng.Next(5, 21), 6); //Character stats are randomized.
            Character myWizard = new Wizard("Silver", rng.Next(5, 21), rng.Next(5, 21), rng.Next(5, 21), 80);
            Character myThief = new Thief("Rouge", rng.Next(5, 21), rng.Next(5, 21), rng.Next(5, 21), 3);

            players.Add(myWarrior);
            players.Add(myWizard);
            players.Add(myThief);

            for (int i = 0; i < 10; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("----- Random Character Selection -----\n");
                Console.ForegroundColor = ConsoleColor.Gray;

                whoIs = rng.Next(0, players.Count);

                if (players[whoIs] is Warrior) //Keyword "is" used to test presence of each type of character.
                {
                    Warrior fighter = (Warrior)players[whoIs]; //If true, the list element is then downcasted to the appropriate sub class.
                    Console.WriteLine(fighter.ToString());
                    fighter.SpecialMove();
                    fighter.Cleanse(); //Unique sub class method.
                }
                else if (players[whoIs] is Wizard)
                {
                    Wizard caster = (Wizard)players[whoIs];
                    Console.WriteLine(caster.ToString());
                    caster.SpecialMove();
                    caster.Learn();
                }
                else if (players[whoIs] is Thief)
                {
                    Thief stealer = (Thief)players[whoIs];
                    Console.WriteLine(stealer.ToString());
                    stealer.SpecialMove();
                    stealer.Silence();
                }

                Console.WriteLine("");
            }

        }
    }
}