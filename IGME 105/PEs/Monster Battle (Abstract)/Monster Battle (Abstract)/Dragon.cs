//Conor Race
//Oct. 28th, 2021
//Purpose: Allows for the creation of Dragon objects. Has
//abstract methods overridden from the base Monster class.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Battle__Abstract_
{
    class Dragon : Monster
    {
        Damage resist;
        Random rng = new Random();

        /// <summary>
        /// Parameterized constructor for the Dragon class. Chains off of the base class's
        /// constructor while also using an additional parameter to represent a dragon's
        /// resistance to a specific type of damage.
        /// </summary>
        /// <param name="type"> What type of damage the Dragon performs. </param>
        /// <param name="name"> The name of the Dragon. </param>
        /// <param name="hp"> The starting health of the Dragon. </param>
        /// <param name="resistType"> What type of damage the Dragon is resistant to. </param>
        public Dragon (Damage type, string name, int hp, Damage resistType)
            : base(type, name, hp)
        {
            resist = resistType;
        }

        /// <summary>
        /// Overridden abstract class; For the Dragon class, the dragon deals damage between
        /// 10 - 20. After getting a random number, it sends its damage and damage type to
        /// the opponent.
        /// </summary>
        /// <param name="targetMonster"> A Monster object recieving the damage. </param>
        public override void Attack(Monster targetMonster)
        {
            int damage = rng.Next(10, 21);
            Console.Write($"\n{name} attacks for {damage} {type} damage. ");
            targetMonster.TakeDamage(damage, type);
        }

        /// <summary>
        /// Overridden abstract class; For the Dragon class, the dragon object takes damage
        /// normally unless the incoming damage type is equal to its resistant type. In that
        /// case, the incoming damage is then halved. Health never falls below 0.
        /// </summary>
        /// <param name="damage"> Base amount of damage the Dragon is recieving. </param>
        /// <param name="damageType"> The type of damage the Dragom is recieving. </param>
        public override void TakeDamage(int damage, Damage damageType)
        {
            // If the incoming damage type is the same as its resistant type, the damage is halved.
            if (damageType == resist)
            {
                Console.WriteLine($"{name} takes {damage} {damageType} damage, \nhalved to {damage / 2} due to resistance to {damageType} damage");
                if (damage / 2 >= health)
                {
                    health = 0;
                }
                else
                {
                    health -= (damage / 2);
                }
                
            }
            else
            {
                Console.WriteLine($"{name} takes {damage} {damageType} damage");
                if (damage >= health)
                {
                    health = 0;
                }
                else
                {
                    health -= damage;
                }
            }
        }

        /// <summary>
        /// Uses a base string from the parent class to return a Dragon's core stats, in addition to
        /// providing information on what the Dragon is resistant to.
        /// </summary>
        /// <returns> A complete string of all the Dragon's stats. </returns>
        public override string ToString()
        {
            return base.ToString() + $" | Resistance: {resist} Damage";
        }
    }
}
