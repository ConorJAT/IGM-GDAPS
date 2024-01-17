// Conor Race
// Nov. 8, 2021 - Exam #2
// Purpose: Serves as a child class from the Card base
// class. Allows for the creation of Minion cards.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone__Exam_2_
{
    class Minion : Card
    {
        private int health;
        private int attack;
        private string subtype;

        /// <summary>
        /// Secondary constructor which returns null for its subtype if it doesn't have one.
        /// </summary>
        public Minion(string name, int cost, int hp, int atk) : this(name, cost, hp, atk, null) 
        { 
        }

        /// <summary>
        /// Main constructor for the Minion class. Contains all necessary attributes.
        /// </summary>
        /// <param name="name"> Minion's name. </param>
        /// <param name="cost"> Minion's casting cost. </param>
        /// <param name="hp"> Minion's starting health. </param>
        /// <param name="atk"> Minon's attack power. </param>
        /// <param name="subT"> Minion's subtype, if it has one. </param>
        public Minion(string name, int cost, int hp, int atk, string subT)
            : base(name, cost)
        {
            health = hp;
            attack = atk;
            subtype = subT;
        }

        /// <summary>
        /// Property; Only serves to retrieve a Minion's health.
        /// </summary>
        public int Health { get { return health; } }

        /// <summary>
        /// Property; Only serves to retrieve a Minion's attack.
        /// </summary>
        public int Attack { get { return attack; } }

        /// <summary>
        /// Property; Only serves to retrieve a Minion's subtype.
        /// </summary>
        public string SubType { get { return subtype; } }

        /// <summary>
        /// Property; Only serves to retrieve a Minion's alive status.
        /// </summary>
        public bool Alive
        {
            get
            {
                if (health > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Overridden method for Minion class. Prints a special message if a minion is casted.
        /// </summary>
        public override void Cast()
        {
            Console.WriteLine($"    {name} enters play!");
        }

        /// <summary>
        /// Builds upon the base ToString, adding all the unique stats of the minion.
        /// </summary>
        /// <returns> Returns a complex string of all the unique stats of the minion. </returns>
        public override string ToString()
        {
            string output = base.ToString() + $"It has {attack} attack and {health} health. ";
            if (subtype != null)
            {
                output += $"This minion's subtype is {subtype}. ";
            }

            if (Alive)
            {
                output += "This minion is alive.";
            }
            else
            {
                output += "This minion is dead.";
            }

            return output;


        }

        /// <summary>
        /// Appropriately reduces health of a minion using an int parameter.
        /// </summary>
        /// <param name="damage"> The damage the minion is taking. </param>
        public void TakeDamage(int damage)
        {
            if (damage > 0)
            {
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
    }
}
