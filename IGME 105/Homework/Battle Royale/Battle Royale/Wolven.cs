//Conor Race
//Oct. 26th, 2021
//Purpose: Sub-class for CommonCharacter class. Allows for the 
//creation and usage of Wolven character objects.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Royale
{
    class Wolven : CommonCharacter
    {
        private bool timeForHunt;
        private int packSize;
        private int resistance;
        Random rng = new Random();

        /// <summary>
        /// Constructor for Wolven class. Extends off of base class constructor, while
        /// also setting defaults for two additional fields, unique to this class.
        /// </summary>
        /// <param name="name"> The name of the Wolven. </param>
        /// <param name="pwr"> The Wolven's power. </param>
        /// <param name="hp"> The Wolven's health points. </param>
        public Wolven (string name, int pwr, int hp)
            : base (name, pwr, hp)
        {
            packSize = 0;
            resistance = 0;
        }

        /// <summary>
        /// Property; Allows for the retrieval of the Wolven's pack size.
        /// </summary>
        public int ThePack { get { return packSize; } }

        /// <summary>
        /// Property; Allows for the retrieval and edit of the Wolven's resistance/defense.
        /// </summary>
        public int Resistance { get { return resistance; } set { resistance = value; } }

        /// <summary>
        /// Generates and returns a random attack value based on the Wolven's power AND
        /// pack size. Also tests for special attack. If a special attack is active,
        /// damage is dramatically increeased.
        /// </summary>
        /// <returns> A random int which serves as a damage value. </returns>
        public override int Attack()
        {
            int damage = 0;
            if (timeForHunt)
            {
                // Special Formula: damage = randomValue(1, Wolven's Power) + (10 * Size of Pack)
                // When a special attack is triggered, the pack size mutiple goes from 2x to 10x,
                // sharply boosting damage. In return, the pack size dissolves after the attack.
                damage = base.Attack() + (10 * packSize);
                packSize = 0;
            }
            else
            {   // Normal Formula: damage = randomValue(1, Wolven's Power) + (2 * Size of Pack)
                // Damage generally increases as the pack size goes up. The pack size
                // increases after every attack (except after special attacks).
                damage = base.Attack() + (2 * packSize);
                packSize++;
            }
            return damage;
        }

        /// <summary>
        /// Takes an int value as a parameter and subtracts it from the character's
        /// total health. In the Wolven class, the damage parameter is subtracted by the
        /// Wolven's resistance stat. If resistance > damage recieved, the character
        /// takes no damage whatsoever.
        /// </summary>
        /// <param name="damage"> How much damage the Wolven is possibly taking. </param>
        public override void TakeDamage(int damage)
        {
            // Does not call the base method if reesistance is >= damage parameter.
            if (resistance >= damage)
            {
                return;
            }
            // Damage reduced otherwise.
            else { 
                base.TakeDamage(damage - resistance);
            }
        }

        /// <summary>
        /// Tests whether a character is ready to flee battle via a particular condition.
        /// Wolven particularly never flee, so false is always returned.
        /// </summary>
        /// <returns> False is always returned (No fleeing allowed). </returns>
        public override bool ReadyToFlee()
        {
            return false;
        }

        /// <summary>
        /// Wolven's special attack switch. During each round, every Wolven has a chance to
        /// unleash a special attack. This attack will not be triggered if pack size = 0
        /// (no two special attacks in a row).
        /// </summary>
        public void HuntIsOn()
        {
            // Will not trigger if there is not pack to hunt with.
            if (packSize == 0)
            {
                timeForHunt = false;
            }
            // Wolven have a 20% chance of activating their special attacks.
            else if (rng.Next(1, 101) <= 20)
            {
                Console.ForegroundColor = ConsoleColor.White;
                // Message indicates when special attack is activated.
                Console.WriteLine($"{name} calls for a pack wide hunt!");
                Console.ForegroundColor = ConsoleColor.Gray;
                timeForHunt = true;
            }
            else
            {
                timeForHunt = false;
            }
        }

        /// <summary>
        /// Returns a complex string highlighting all of the Wolven's unique abilities, in
        /// addition to its base stats from the base ToString method.
        /// </summary>
        /// <returns> Returns a constructed string of Wolven's complete stats. </returns>
        public override string ToString()
        {
            return base.ToString() + "Race: Wolven\nList of Abilities:\n" +
                                     "   Pack : \t\tWolven folk grow stronger when fighting side by side. Wolven get +2 attack\n" +
                                     "          \t\tper stack of \'Pack\'. They also +1 stack of \'Pack\' after every attack.\n\n" +
                                     "   Just a Scratch : \tWolven folk are pretty resilient. Every time a wolven folk is attacked,\n" +
                                     "                  \tthey gain +1 defense. This stacks up to 5 times.\n\n" +
                                     "   To Death! : \t\tWolven folk do not flee and will fight to the death.\n\n" +
                                     "   \"The Hunt is On!\" : \tUnleashes a special attack based on how many stacks of 'Pack'\n" +
                                     "                       \tthe fighter has. The greater the stack, the greater the damage.\n" +
                                     "                       \tThe pack disbands once the hunt is finished.";                       
        }
    }
}
