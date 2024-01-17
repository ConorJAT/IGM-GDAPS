//Conor Race
//Oct. 26th, 2021
//Purpose: Creates several CommonCharacter objects and places them
//in a list to be used a battle royale simulator.

using System;
using System.Collections.Generic;

namespace Battle_Royale
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Avalon Battle Royale";
            List<CommonCharacter> fighters = new List<CommonCharacter>();
            List<CommonCharacter> dead = new List<CommonCharacter>();
            List<CommonCharacter> fled = new List<CommonCharacter>();
            Random rng = new Random();
            int roundCount = 1;
            int atkDamage = 0;
            int victim;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to the Avalon Battle Royale!\n");
            
            fighters.Add(new Wolven("Ranok", 15, 150));
            fighters.Add(new Wolven("Vulgor", 15, 170));
            fighters.Add(new Feline("Puss in Boots", 12, 100));
            fighters.Add(new Feline("Alexios", 10, 115));

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------- Today's Contestants ----------------\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < fighters.Count; i++)
            {
                Console.WriteLine(fighters[i].ToString());
                Console.WriteLine("\n");   
            }

            // Fight will continue until one or no fighters remain
            while (fighters.Count > 1)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"--------------------- Round {roundCount} ---------------------\n");
                Console.ForegroundColor = ConsoleColor.Gray;
                for (int i = 0; i < fighters.Count; i++)
                {
                    // Getting a damage value:

                    if (fighters[i] is Wolven)
                    {
                        // Downcasting attacker to Wolven class
                        Wolven wolfAttacker = (Wolven)fighters[i];
                        // Chance to call special attack
                        wolfAttacker.HuntIsOn();
                        // Generates attack damage based on current conditions
                        atkDamage = wolfAttacker.Attack();
                    }
                    else if (fighters[i] is Feline)
                    {
                        // Downcasting attacker to Feline class
                        Feline catAttacker = (Feline)fighters[i];
                        // Prints message for if a riposte attack is triggered
                        if (catAttacker.Riposte)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Riposte Attack!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        // Chance to call special attack
                        catAttacker.ScratchEmUp();
                        // Generates attack damage based on current conditions
                        atkDamage = catAttacker.Attack();
                    }


                    // Getting a random target:
                    
                    // Gets a random index of a target character
                    victim = rng.Next(0, fighters.Count);
                    // Will loop until the target's index is different from the attacker's
                    while (victim == i)
                    {
                        victim = rng.Next(0, fighters.Count);
                    }


                    // Assigning the damage:

                    if (fighters[victim] is Wolven)
                    {
                        // Downcasting defender to Wolven class
                        Wolven wolfDefender = (Wolven)fighters[victim];
                        // Wolven takes damage. Resistance is taken into account in the method itself
                        wolfDefender.TakeDamage(atkDamage);
                        // Will notify if Wolven was able to tank the hit (resistance >= damage)
                        if (wolfDefender.Resistance >= atkDamage)
                        {
                            Console.WriteLine($"{fighters[i].Name} attacks, but {wolfDefender.Name} takes the hit without a scratch (0 damage dealt)");
                            
                        }
                        else
                        {
                            Console.WriteLine($"{fighters[i].Name} deals {atkDamage - wolfDefender.Resistance} damage to {wolfDefender.Name}");
                        }

                        // Resistance is increased up to 5. Will not exceed 5
                        if (wolfDefender.Resistance < 5)
                        {
                            wolfDefender.Resistance++;
                        }

                    }
                    else if (fighters[victim] is Feline)
                    {
                        // Downcasting defender to Feline class
                        Feline catDefender = (Feline)fighters[victim];
                        // Chance for Feline to dodge attack
                        catDefender.Dodge();
                        // Feline takes damage. Method covers whether or not the Feline dodges/takes no damage
                        catDefender.TakeDamage(atkDamage);
                        // Will notify if Feline sucessfully dodges an attack
                        if (catDefender.Dodges)
                        {
                            Console.WriteLine($"{fighters[i].Name} attacks, but {catDefender.Name} dodges it (0 damage dealt)");
                            catDefender.Dodges = false;
                        }
                        else
                        {
                            Console.WriteLine($"{fighters[i].Name} deals {atkDamage} damage to {catDefender.Name}");
                        }
                    }
                    Console.WriteLine("");
                }


                // Printing all fighter stats:

                Console.WriteLine("");
                for (int i = 0; i < fighters.Count; i++)
                {
                    if (fighters[i] is Wolven)
                    {
                        // Downcasting to Wolven class
                        Wolven wolf = (Wolven)fighters[i];
                        // Outputs base stats, in addition to all unique stats (i.e: Pack Size and Resistance)
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"{fighters[i].Name}'s Current Stats:");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine($"    Health: {fighters[i].Health} HP\tPack Size: {wolf.ThePack}\tDefense: {wolf.Resistance} DP");
                    }
                    else if (fighters[i] is Feline)
                    {
                        // Downcasting to Feline class
                        Feline cat = (Feline)fighters[i];
                        // Outputs base stats, in addition to all unique stats (i.e: Extra Life Count)
                        Console.ForegroundColor = ConsoleColor.White;
                        if (cat.ExtraLife)
                        {
                            Console.WriteLine($"{fighters[i].Name}'s Current Stats:");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine($"    Health: {fighters[i].Health} HP\tExtra Lives: 1");
                        }
                        else
                        {
                            Console.WriteLine($"{fighters[i].Name}'s Current Stats:");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine($"    Health: {fighters[i].Health} HP\tExtra Lives: 0");
                        }
                    }
                    
                    // Checks if any characters are dead first. Done in this order mainly to ensure that no
                    // Felines are able to run away when they have 0 health on their last lives
                    if (fighters[i].IsDead())
                    {
                        // Adds any dead fighters to a dead list
                        dead.Add(fighters[i]);
                    }
                    // Checks if any characters (Felines, b/c Wolven don't flee) are able to run away
                    else if (fighters[i].ReadyToFlee())
                    {
                        // Adds any fled fighters to a fled list
                        fled.Add(fighters[i]);
                    }
                    Console.WriteLine("");
                }


                // Printing runaways or deaths (if any):

                // Will never print if BOTH fled and dead lists are empty
                if (fled.Count > 0 || dead.Count > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n>>> Casualties <<<");
                    Console.ForegroundColor = ConsoleColor.White;
                    for (int i = 0; i < fled.Count; i++)
                    {
                        // Outputs all runaways
                        Console.WriteLine($"{fled[i].Name} has fled the battle!");
                        // Removes the matching fighter from the fighting list as they ran away and are no longer part of battle
                        fighters.Remove(fled[i]);
                    }
                    // Fled list is reset after outputting 
                    fled = new List<CommonCharacter>();

                    for (int i = 0; i < dead.Count; i++)
                    {
                        // Outputs all deaths
                        Console.WriteLine($"{dead[i].Name} has died in battle!");
                        // Removes the matching fighter from the fighting list as they are dead
                        fighters.Remove(dead[i]);
                    }
                    // Dead list is reset after outputting
                    dead = new List<CommonCharacter>();
                }

                // Will not proceed to the next round until user types a key.
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\n> Please press any continue to proceed into the next round <\n");
                Console.ReadKey();
                roundCount++;
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------- Battle Royale OVER ----------------\n");
            if (fighters.Count == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                // Outputs the one winner if there is one
                Console.WriteLine($"Winner: {fighters[0].Name}");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                // Outputs a closing statement if no one is remaining
                Console.WriteLine("No one wins! Everyone either died or ran away!");
            }
        }
    }
}
