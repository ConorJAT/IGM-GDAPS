//Conor Race
//Oct. 20th, 2021
//Purpose: Serves as the parent class from which all 3
//sub-classes branch from for character creation.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goofy_DnD
{
    class Character
    {
        protected string name;
        protected int strength;
        protected int dexterity;
        protected int intelligence;

        /// <summary>
        /// Character constructor. All characters have a name, and values for strength,
        /// dexterity, and intellegence, despite any differences in the sub-classes.
        /// </summary>
        /// <param name="Name"> The name of the character. </param>
        /// <param name="str"> The character's strength. </param>
        /// <param name="dex"> The character's dexterity. </param>
        /// <param name="intel"> The character's intellegence. </param>
        public Character(string Name, int str, int dex, int intel)
        {
            name = Name;
            strength = str;
            dexterity = dex;
            intelligence = intel;
        }

        /// <summary>
        /// Property for returning the character's name. Only a getter.
        /// </summary>
        public string Name { get { return name; } }

        /// <summary>
        /// Property for getting and setting a character's strength.
        /// </summary>
        public int Strength { get { return strength; } set { strength = value; } }

        /// <summary>
        /// Property for getting and setting a character's dexterity.
        /// </summary>
        public int Dexterity { get { return dexterity; } set { dexterity = value; } }

        /// <summary>
        /// Property for getting and settinug a character's intelligence.
        /// </summary>
        public int Intelligence { get { return intelligence; } set { intelligence = value; } }

        /// <summary>
        /// Virtual method which RETURNS a string of a character's stats. Is later
        /// chained off of in the various sub classes.
        /// </summary>
        /// <returns> Returns a string of a character's basic stats. </returns>
        public override string ToString()
        {
            return $"{name}'s Stats: {strength} Strength, {dexterity} Dexterity, and {intelligence} Intellegence"; //Does NOT print.
        }

        /// <summary>
        /// Virtual method which starts off a string of character using their
        /// special ability.
        /// </summary>
        public virtual void SpecialMove()
        {
            Console.Write($"{name} performs "); //String is continued depending on the respective sub class
        }


    }
}