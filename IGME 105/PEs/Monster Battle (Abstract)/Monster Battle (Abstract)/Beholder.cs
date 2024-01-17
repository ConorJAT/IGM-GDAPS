//Conor Race
//Oct. 28th, 2021
//Purpose: Allows for the creation of Beholder objects. Has
//abstract methods overridden from the base Monster class.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Battle__Abstract_
{
    class Beholder : Monster
    {
        Damage weakness;
        Random rng = new Random();

        /// <summary>
        /// Parameterized constructor for the Beholder class. Chains off of the base class's
        /// constructor while also using an additional parameter to represent a beholder's
        /// weakness to a specific type of damage.
        /// </summary>
        /// <param name="type"> What type of damage the Beholder performs. </param>
        /// <param name="name"> The name of the Beholder. </param>
        /// <param name="hp"> The starting health of the Beholder. </param>
        /// <param name="resistType"> What type of damage the Beholder is weak to. </param>
        public Beholder(Damage type, string name, int hp, Damage weakType)
            : base(type, name, hp)
        {
            weakness = weakType;
        }

        /// <summary>
        /// Overridden abstract class; For the Beholder class, the beholder deals damage between
        /// 5 - 25. After getting a random number, it sends its damage and damage type to
        /// the opponent.
        /// </summary>
        /// <param name="targetMonster"> A Monster object recieving the damage. </param>
        public override void Attack(Monster targetMonster)
        {
            int damage = rng.Next(5, 26);
            Console.Write($"\n{name} attacks for {damage} {type} damage. ");
            targetMonster.TakeDamage(damage, type);
        }

        /// <summary>
        /// Overridden abstract class; For the Beholder class, the beholder object takes damage
        /// normally unless the incoming damage type is equal to its weakness type. In that
        /// case, the incoming damage is then doubled. Health never falls below 0.
        /// </summary>
        /// <param name="damage"> Base amount of damage the Beholder is recieving. </param>
        /// <param name="damageType"> The type of damage the Beholder is recieving. </param>
        public override void TakeDamage(int damage, Damage damageType)
        {
            // If the incoming damage type is the same as its weakness type, the damage is doubled.
            if (damageType == weakness)
            {
                Console.WriteLine($"{name} takes {damage} {damageType} damage, \ndoubled to {damage * 2} due to weakness to {damageType} damage");
                if (damage * 2 >= health)
                {
                    health = 0;
                }
                else
                {
                    health -= (damage * 2);
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
        /// Uses a base string from the parent class to return a Beholder's core stats, in addition to
        /// providing information on what the Beholder is weak to.
        /// </summary>
        /// <returns> A complete string of all the Beholder's stats. </returns>
        public override string ToString()
        {
            return base.ToString() + $" | Vulnerability: {weakness} Damage";
        }
    }
}
