//Conor Race
//Oct. 20th, 2021
//Purpose: Sub-class for Character. Responsible for creating
//Wizard objects.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goofy_DnD
{
    class Wizard : Character
    {
        private int failChance;

        /// <summary>
        /// Wizard constructor. All wizards have a name, and values for strength,
        /// dexterity, and intellegence, in addition to a unique value for their Hot 
        /// Pocket fizzle percentage.
        /// </summary>
        /// <param name="Name"> The name of the wizard. </param>
        /// <param name="str"> The wizard's strength. </param>
        /// <param name="dex"> The wizard's dexterity. </param>
        /// <param name="intel"> The wizard's intellegence. </param>
        /// <param name="days"> The wizard's Hot Pocket fizzle rate. </param>
        public Wizard(string name, int str, int dex, int intel, int chance)
            : base(name, str, dex, intel)
        {
            failChance = chance;
        }

        /// <summary>
        /// Property for getting and setting a wizard's spell fail chance.
        /// </summary>
        public int Chance { get { return failChance; } set { failChance = value; } }

        /// <summary>
        /// Overridden method which adds on to the returned string from the 
        /// Character class, thus creating a unique, longer string for the
        /// Wizard class.
        /// </summary>
        /// <returns> Returns a wizard's basic stats and unique stat. </returns>
        public override string ToString()
        {
            return base.ToString() + $"\n{name} (A Wizard) accidentally creates Hot Pockets (TM) {failChance}% of the time\n";
        }

        /// <summary>
        /// Wizard's special move. Result MAY vary depending on failChance variable.
        /// Overrides the Character class' SpecialMove() method.
        /// </summary>
        public override void SpecialMove()
        {
            base.SpecialMove();
            Random rng = new Random();
            if (rng.Next(1, 101) > failChance)
            {
                Console.Write($"\"cast a spell.\" The spell was successfully casted (this time...)\n\n");
            }
            else
            {
                Console.Write($"\"cast a spell.\" Unfortunately, a Hot Pocket (TM) falls to the ground with a thud...\n\n");
            }
        }

        /// <summary>
        /// Unique method to Wizard class. Decreases a Wizard's failChance by decrements of 5.
        /// </summary>
        public void Learn()
        {
            Console.WriteLine($"{name} decides to attend the Hogwarts School of Wizardry and improves his magical accuracy");
            Console.WriteLine("Hot Pocket (TM) fizzle chance reduced!\n");
            if (failChance < 5)
            {
                failChance = 0;
            }
            else
            {
                failChance -= 5;
            }
        }
    }
}