//Conor Race
//Oct. 26th, 2021
//Purpose: Serves as a base class from which characters
//are created from. Inherited by 2 sub-classes.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Royale
{
    class CommonCharacter
    {   
        protected string name;
        protected int power;
        protected int health;
        Random rng = new Random();
        
        /// <summary>
        /// Base constructor for all characters. All characters have a name, a power
        /// value and a health value. Is extended upon in the sub-classes.
        /// </summary>
        /// <param name="name"> The name of the character. </param>
        /// <param name="pwr"> The character's power. </param>
        /// <param name="hp"> The character's health points. </param>
        public CommonCharacter(string name, int pwr, int hp)
        {
            this.name = name;
            power = pwr;
            health = hp;
        }

        /// <summary>
        /// Property; Allows for the retrieval of the character's name.
        /// </summary>
        public string Name {  get { return name; } }

        /// <summary>
        /// Propety; Allows for the retrieval of the character's health.
        /// </summary>
        public int Health { get { return health; } }

        /// <summary>
        /// Generates and returns a random attack value based on the character's power.
        /// </summary>
        /// <returns> A random int which serves as a damage value. </returns>
        public virtual int Attack()
        {
            return rng.Next(1, power + 1);
        }

        /// <summary>
        /// Takes an int value as a parameter and subtracts it from the character's
        /// total health. Health is instead set to 0 if the param > the remaining
        /// health.
        /// </summary>
        /// <param name="damage"> How much damage the character is taking. </param>
        public virtual void TakeDamage(int damage)
        {
            if (damage > health)
            {
                health = 0;
            }
            else
            {
                health -= damage;
            }
        }

        /// <summary>
        /// Tests whether a character is ready to flee battle via a particular
        /// condition.
        /// </summary>
        /// <returns> True if the flee condition is met. False otherwise. </returns>
        public virtual bool ReadyToFlee()
        {
            // The base condition is whether or not the character's health below 50.
            if (health < 50) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Tests whether a character is dead (no health left).
        /// </summary>
        /// <returns> True if health = 0. False otherwise. </returns>
        public virtual bool IsDead()
        {
            if (health == 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Overridden ToString method; Returns a string consisting of a character's base
        /// stats (name, power, and health). Does not print.
        /// </summary>
        /// <returns> Returns a constructed string of character's stats. </returns>
        public override string ToString()
        {
            return $"Name: {name}\tPower: {power} Pwr\tHealth: {health} Total HP\t";
        }
    }
}
