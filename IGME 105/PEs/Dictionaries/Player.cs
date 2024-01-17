// Conor Race
// Nov. 15th, 2021
// Purpose: Allows for the creation Player objects.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionaries
{
    class Player
    {
        /// <summary>
        /// Auto-Property; Serves to retrieve and privately set the player's name. 
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Auto-Property; Serves to retrieve and privately set the player's score. 
        /// </summary>
        public int Score { get; private set; }

        /// <summary>
        /// Parameterized constructor for Player class. Every player is constructed
        /// with a name and a score.
        /// </summary>
        /// <param name="name"> Name of player. </param>
        /// <param name="score"> Player's score. </param>
        public Player(string name,  int score) 
        {
            Name = name;
            Score = score;
        }

        /// <summary>
        /// Returns a string a player's name and score.
        /// </summary>
        /// <returns> Returns a string a player's name and score. </returns>
        public override string ToString()
        {
            return $"Player Name: {Name}\tScore: {Score}";
        }
    }
}
