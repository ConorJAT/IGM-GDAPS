// Conor Race
// Dec. 1st, 2021
// Purpose: Allows for the creation of Player objects.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerBinaryIO
{
    class Player
    {
        /// <summary>
        /// Auto-Property; Allows for the getting/setting of the player's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Auto-Property; Allows for the getting/setting of the player's intelligence.
        /// </summary>
        public int Intel { get; set; }

        /// <summary>
        /// Auto-Property; Allows for the getting/setting of the player's strength.
        /// </summary>
        public int Strength { get; set; }

        /// <summary>
        /// Parameterized constructor; Initializes a player object by giving them a name,
        /// intelligence stat, and strength stat, all via passed in parameters.
        /// </summary>
        /// <param name="name"> The player's name. </param>
        /// <param name="intel"> The player's intelligence stat. </param>
        /// <param name="strength"> The player's strength stat. </param>
        public Player(string name, int intel, int strength)
        {
            Name = name;
            Intel = intel;
            Strength = strength;
        }

        /// <summary>
        /// Outputs all the the player's core information.
        /// </summary>
        /// <returns> Returns a string with all the player's information. </returns>
        public override string ToString()
        {
            return $"Player Name: {Name}  |  Intelligence: {Intel}  |  Strength: {Strength}";
        }
    }
}