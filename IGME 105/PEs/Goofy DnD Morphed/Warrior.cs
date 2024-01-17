//Conor Race
//Oct. 20th, 2021
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
            : base(name, str, dex, intel)
        {
            daysSinceShower = days;
        }

        /// <summary>
        /// Property for getting and setting a warrior's days since last shower.
        /// </summary>
        public int Days { get { return daysSinceShower; } set { daysSinceShower = value; } }

        /// <summary>
        /// Overridden method which adds on to the returned string from the 
        /// Character class, thus creating a unique, longer string for the
        /// Warrior class.
        /// </summary>
        /// <returns> Returns a warrior's basic stats and unique stat. </returns>
        public override string ToString()
        {
            return base.ToString() + $"\n{name} (A Warrior) has not bathed in {daysSinceShower} days\n";
        }

        /// <summary>
        /// Warrior's special move. Result varies depending on daysSinceShower variable.
        /// Overrides the Character class' SpecialMove() method.
        /// </summary>
        public override void SpecialMove()
        {
            base.SpecialMove();
            Random rng = new Random();
            if (daysSinceShower < 2)
            {
                Console.Write($"\"make friends.\" {name} successfully made {rng.Next(3, 6)} friends\n\n");
            }
            else if (daysSinceShower > 1 && daysSinceShower < 5)
            {
                Console.Write($"\"make friends.\" Despite their slight oder, {name} successfully made {rng.Next(1, 3)} friends\n\n");
            }
            else
            {
                Console.Write($"\"make friends.\" Because of their unbearable stench, no friends were made\n\n");
            }
        }

        /// <summary>
        /// Unique method to Warrior class. Tracks how many days warrior has gone without
        /// shower. Will reset counter if daysSinceShower is greater than 4.
        /// </summary>
        public void Cleanse()
        {
            if  (daysSinceShower < 2)
            {
                Console.WriteLine($"{name} feels proud for his recent cleaniness!\n");
                daysSinceShower++;
            }
            else if (daysSinceShower > 1 && daysSinceShower < 5)
            {
                Console.WriteLine($"Although {name} has a slight oder, they decide a shower is not needed at this time\n");
                daysSinceShower++;
            }
            else
            {
                Console.WriteLine($"{name}'s stench is so unbearable! {name} takes this time to finally take a shower\n");
                daysSinceShower = 0;
            }
        }
    }
}