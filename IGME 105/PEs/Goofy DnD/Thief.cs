//Conor Race
//Oct. 18th, 2021
//Purpose: Sub-class for Character. Responsible for creating
//Thief objects.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goofy_DnD
{
    class Thief : Character
    {
        private int spamCalls;

        /// <summary>
        /// Thief constructor. All thieves have a name, and values for strength,
        /// dexterity, and intellegence, in addition to a unique value for how many
        /// spam calls they recieve a day.
        /// </summary>
        /// <param name="Name"> The name of the thief. </param>
        /// <param name="str"> The thief's strength. </param>
        /// <param name="dex"> The thief's dexterity. </param>
        /// <param name="intel"> The thief's intellegence. </param>
        /// <param name="days"> How many spam calls the thief recieves daily. </param>
        public Thief(string name, int str, int dex, int intel, int calls)
            : base(name, str, dex, intel)
        {
            spamCalls = calls;
        }

        /// <summary>
        /// Property for getting and setting a thief's daily spam calls.
        /// </summary>
        public int Calls { get { return spamCalls; } set { spamCalls = value; } }

        /// <summary>
        /// Prints the thief's common stats, in addition to its uniqe stat.
        /// </summary>
        public void PrintThief()
        {
            Print();
            Console.WriteLine($"{name} (A Thief) recieves {spamCalls} spam calls a day, due to their provider\n");
        }

        /// <summary>
        /// Thief's special move. Result varies depending on spamCalls variable.
        /// </summary>
        public void SpecialMove()
        {
            if (spamCalls == 0)
            {
                Console.WriteLine($"{name} recieves no spam calls at all, and thus has no need to search for new cell plan\n");
            }
            else if (spamCalls > 0 && spamCalls < 3)
            {
                Console.WriteLine($"{name} has thought about changing their cell plan, but decides to stick with their current plan\n");
            }
            else if (spamCalls > 2 && spamCalls < 6)
            {
                Console.WriteLine($"{name} decides to browse for a new cell plan, but ultimately decides to stick with what they got\n");
            }
            else
            {
                Console.WriteLine("After a slew of unsuccessful thievery attempts due to mass amounts of spam calls,");
                Console.WriteLine($"{name} ultimately changes their cell phone provider, in hopes to recieve less spam calls\n");
            }
        }
    }
}
