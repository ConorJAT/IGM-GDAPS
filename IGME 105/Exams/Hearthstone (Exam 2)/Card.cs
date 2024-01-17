// Conor Race
// Nov. 8, 2021 - Exam #2
// Purpose: Serves as a base class from which (Hearthstone) card
// objects can be created.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone__Exam_2_
{
    abstract class Card
    {
        protected string name;
        protected int cost;

        /// <summary>
        /// Base constructor for class. All cards have a name
        /// and casting cost.
        /// </summary>
        /// <param name="name"> Name of card. </param>
        /// <param name="cost"> Casting cost of card. </param>
        public Card(string name, int cost)
        {
            this.name = name;
            this.cost = cost;
        }

        /// <summary>
        /// Property; Only serves to retrieve a card's name.
        /// </summary>
        public string Name { get { return name; } }

        /// <summary>
        /// Returns a string of the card's most basic stats.
        /// </summary>
        /// <returns> Returns a string of a card's basic stats. </returns>
        public override string ToString()
        {
            return $"  > {name} costs {cost} mana. ";
        }

        /// <summary>
        /// Abstract method to be overridden in any and all child classes.
        /// </summary>
        public abstract void Cast();
    }
}
