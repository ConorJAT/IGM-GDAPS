//Conor Race
//Oct. 18th, 2021
//Purpose: Sub-class for Character. Responsible for creating
//Warrior objects.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goofy_DnD
{
    class Warrior : Character
    {
        private int daysSinceShower;

        /// <summary>
        /// Warrior constructor. All warriors have a name, and values for strength,
        /// dexterity, and intellegence, in addition to a unique value for how many
        /// days they have not showered.
        /// </summary>
        /// <param name="Name"> The name of the warrior. </param>
        /// <param name="str"> The warrior's strength. </param>
        /// <param name="dex"> The warrior's dexterity. </param>
        /// <param name="intel"> The warrior's intellegence. </param>
        /// <param name="days"> How many days it's beens since the warrior's last shower. </param>
        public Warrior(string name, int str, int dex, int intel, int days)
            : base (name, str, dex, intel)
        {
            daysSinceShower = days;
        }

        /// <summary>
        /// Property for getting and setting a warrior's days since last shower.
        /// </summary>
        public int Days { get { return daysSinceShower; } set { daysSinceShower = value; } }

        /// <summary>
        /// Prints the warrior's common stats, in addition to its uniqe stat.
        /// </summary>
        public void PrintWarrior()
        {
            Print();
            Console.WriteLine($"{name} (A Warrior) has not bathed in {daysSinceShower} days\n");
        }

        /// <summary>
        /// Warrior's special move. Result varies depending on daysSinceShower variable.
        /// </summary>
        public void SpecialMove()
        {
            Random rng = new Random();
            if (daysSinceShower < 2)
            {
                Console.WriteLine($"{name} attempted to make some friends. {name} successfully made {rng.Next(3,6)} friends\n");
            }
            else if (daysSinceShower > 1 && daysSinceShower < 5)
            {
                Console.WriteLine($"{name} attempted to make some friends. Despite their slight oder, {name} successfully made {rng.Next(1, 3)} friends\n");
            }
            else
            {
                Console.WriteLine($"{name} attempted to make some friends. Because of their unbearable stench, no friends were made\n");
            }
        }
    }
}
