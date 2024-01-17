//Conor Race
//Oct. 20th, 2021
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
        /// Overridden method which adds on to the returned string from the 
        /// Character class, thus creating a unique, longer string for the
        /// Thief class.
        /// </summary>
        /// <returns> Returns a thief's basic stats and unique stat. </returns>
        public override string ToString()
        {
            return base.ToString() + $"\n{name} (A Thief) recieves {spamCalls} spam calls a day, due to their provider\n";
        }

        /// <summary>
        /// Thief's special move. Result varies depending on spamCalls variable.
        /// Overrides the Character class' SpecialMove() method.
        /// </summary>
        public override void SpecialMove()
        {
            base.SpecialMove();
            if (spamCalls == 0)
            {
                Console.Write($"\"search for new cell providers.\" {name} recieves no spam calls at all, and thus has no need to\n");
                Console.WriteLine("search for new cell plan\n");
            }
            else if (spamCalls > 0 && spamCalls < 3)
            {
                Console.Write($"\"search for new cell providers.\" {name} has thought about changing their cell plan, but decides\n");
                Console.WriteLine("to stick with their current plan\n");
            }
            else if (spamCalls > 2 && spamCalls < 6)
            {
                Console.Write($"\"search for new cell providers.\" {name} decides to browse for a new cell plan, but\n");
                Console.WriteLine("ultimately decides to stick with what they got\n");
            }
            else
            {
                Console.Write("\"search for new cell providers.\" After a slew of unsuccessful thievery attempts due to mass amounts\n");
                Console.WriteLine($"of spam calls, {name} ultimately changes their cell phone provider, in hopes to recieve less spam calls\n");
            }
        }

        /// <summary>
        /// Unique method to Thief class. The thief silences their phone in hopes
        /// of bettering their odds in thievery, but gains an increase in daily
        /// spam calls.
        /// </summary>
        public void Silence()
        {
            if (spamCalls == 0)
            {
                Console.WriteLine($"With no recent spam calls, {name} continues their mischevious business with ease >:)\n");
                spamCalls++;
            }
            else if (spamCalls > 0 && spamCalls < 6)
            {
                Console.WriteLine($"Because of some recent spam calls, {name} silences their phone for one turn. They'll still recieve");
                Console.WriteLine("spam messages in the background however\n");
                spamCalls++;
            }
            else
            {
                Console.WriteLine($"{name} now has a new cell service. So far, it proves successful and they recieve no spam calls as of yet");
                Console.WriteLine("(No need to Silence)\n");
                spamCalls = 0;
            }
        }
    }
}