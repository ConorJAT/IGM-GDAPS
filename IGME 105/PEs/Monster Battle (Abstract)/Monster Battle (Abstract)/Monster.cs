//Conor Race
//Oct. 28th, 2021
//Purpose: Abstract base class which provides the base instructions
//for what its sub-classes need to operate and compile.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Battle__Abstract_
{
    /// <summary>
    /// Damage type enumeration. Allows for the description of what damage
    /// type an object can possess without the use of strings.
    /// </summary>
    public enum Damage
    {
        Fire,
        Ice,
        Acidic,
        Electric,
        Physical
    }

    abstract class Monster
    {
        protected Damage type;
        protected string name;
        protected int health;

        /// <summary>
        /// Parameterized constructor for the base class. All monsters have their
        /// own damage type, name, and starting health.
        /// </summary>
        /// <param name="type"> What type of damage the monster performs. </param>
        /// <param name="name"> The name of the monster. </param>
        /// <param name="hp"> The starting health of the monster. </param>
        public Monster(Damage type, string name, int hp)
        {
            this.type = type;
            this.name = name;
            health = hp;
        }

        /// <summary>
        /// Property; Allows for the retrieval of the Monster's name ONLY.
        /// </summary>
        public string Name { get { return name; } }

        /// <summary>
        /// Property; Allows for the retrieval of the Monster's current health ONLY.
        /// </summary>
        public int Health { get { return health; } }

        /// <summary>
        /// Abstract emthod; Forces all inheriting sub-classes to have an "Attack()" method.
        /// How this is method implemented in the sub-classes varies, however.
        /// </summary>
        /// <param name="targetMonster"> A Monster object recieving the damage. All sub-classes 
        ///                              MUST have this parameter in their "Attack()" methods. </param>
        public abstract void Attack(Monster targetMonster);

        /// <summary>
        /// Abstract emthod; Forces all inheriting sub-classes to have a "TakeDamage()" method.
        /// How this is method implemented in the sub-classes varies, however.
        /// </summary>
        /// <param name="damage"> Amount of damage a monster is recieving. </param>
        /// <param name="damageType"> The type of damage th monster is recieving. </param>
        /// Note: All sub-classes MUST have these parameters in their "TakeDamage()" methods.
        public abstract void TakeDamage(int damage, Damage damageType);

        /// <summary>
        /// Constructs and returns a simple string describing all of a Monster's core stats,
        /// including its name, starting health, and damage type (via ability).
        /// </summary>
        /// <returns> Returns a simple string of a Monster's core stats. </returns>
        public override string ToString()
        {
            string start = $"Name: {name} | Health: {health} HP | Ability: ";
            switch (type)
            {
                case (Damage.Fire):
                    start += "Breathes Fire";
                    break;

                case (Damage.Ice):
                    start += "Icy Touch";
                    break;

                case (Damage.Acidic):
                    start += "Secretes Acid";
                    break;

                case (Damage.Electric):
                    start += "Conductive Body";
                    break;

                case (Damage.Physical):
                    start += "Reinforced Bones";
                    break;
            }
            return start;
        }
    }
}
