// Conor Race
// Nov. 8, 2021 - Exam #2
// Purpose: Creates several minion/card objects, throws them into a list,
// allows the user to choose two cards, and they FIGHT!!!

using System;
using System.Collections.Generic;

namespace Hearthstone__Exam_2_
{
    class Program
    {
        static void Main(string[] args)
        {
            Card myCard1 = new Minion("Oasis Snapjaw", 4, 7, 2, "Beast");
            Card myCard2 = new Minion("Mana Wyrm", 1, 2, 1);
            Card myCard3 = new Minion("Monkey Assassin", 3, 3, 5);

            List<Card> myDeck = new List<Card>();
            myDeck.Add(myCard1);
            myDeck.Add(myCard2);
            myDeck.Add(myCard3);

            Minion fighter1 = new Minion("", 0, 0, 0);
            Minion fighter2 = new Minion("", 0, 0, 0);

            Console.Write("Choose your first minion for combat: ");
            string minionName = Console.ReadLine().ToLower();
            bool cardExists = false;
            while (!cardExists)
            {
                for (int i = 0; i < myDeck.Count; i++)
                {
                    if (myDeck[i].Name.ToLower() == minionName)
                    {
                        fighter1 = (Minion)myDeck[i];
                        cardExists = true;
                        break;
                    }
                }

                if (!cardExists)
                {
                    Console.Write("Minion does not exist, try another: ");
                    minionName = Console.ReadLine().ToLower();
                }
            }

            Console.Write("\nChoose your second minion for combat: ");
            minionName = Console.ReadLine().ToLower();
            cardExists = false;
            while (!cardExists)
            {
                for (int i = 0; i < myDeck.Count; i++)
                {
                    if (myDeck[i].Name.ToLower() == minionName)
                    {
                        fighter2 = (Minion)myDeck[i];
                        cardExists = true;
                        break;
                    }
                }

                if (!cardExists)
                {
                    Console.Write("Minion does not exist, try another: ");
                    minionName = Console.ReadLine().ToLower();
                }
            }


            Console.WriteLine("\n  === Casting ===");
            fighter1.Cast();
            fighter2.Cast();

            Console.WriteLine("\n  === Intital Card Status ===");
            Console.WriteLine(fighter1.ToString());
            Console.WriteLine(fighter2.ToString());

            Console.WriteLine("\n  === Combat Begins ===");
            Console.WriteLine($"    {fighter1.Name} attacks for {fighter1.Attack} damage!");
            fighter2.TakeDamage(fighter1.Attack);
            Console.WriteLine($"    {fighter2.Name} attacks for {fighter2.Attack} damage!");
            fighter1.TakeDamage(fighter2.Attack);

            Console.WriteLine("\n  === Post Battle Card Status ===");
            Console.WriteLine(fighter1.ToString());
            Console.WriteLine(fighter2.ToString());
        }
    }
}
