using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player_Tracker
{
    class Character
    {
        private string name;
        private int attack;
        private int defense;

        public Character(string n, int atk, int def)
        {
            name = n;
            attack = atk;
            defense = def;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"{name} has {attack} attack and {defense} defense");
        }

        // Hey there!
        //   /
        //  O           
        // /|\
        // / \
    }
}
