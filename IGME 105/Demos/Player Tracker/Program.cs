using System;
using System.Collections.Generic;

namespace Player_Tracker
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Character> myPlayers = new List<Character>(4);

            myPlayers.Add(new Character("Jim", 12, 7));
            myPlayers.Add(new Character("Mary", 5, 14));
            myPlayers.Add(new Character("Larry", 8, 8));

            for (int i = 0; i < myPlayers.Count; i++)
            {
                myPlayers[i].PrintInfo();
            }

            Character fighter = myPlayers[1];
            fighter.PrintInfo();
        }
    }
}
