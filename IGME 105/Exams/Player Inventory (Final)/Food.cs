using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player_Inventory__Final_
{
	class Food : Item
	{
		private int servings;


		/// <summary>
		/// Constructs a Food object
		/// </summary>
		/// <param name="name">Name of the food</param>
		/// <param name="initialServings">Number of servings a full food starts with</param>
		/// <param name="weight">Weight of the food</param>
		public Food(String name, int initialServings, double weight)
			: base(name, weight)
		{
			this.servings = initialServings;
		}


		/// <summary>
		/// Uses this food by reducing its servings and printing confirmation messages
		/// </summary>
		/// <returns>Whether this item was usable</returns>
		public override bool Use()
		{
			// Are there any servings left?
			if (servings <= 0)
			{
				Console.WriteLine(
					"You attempt to eat the " + name +
					", but there are no servings left");
				return false;
			}

			// Yes, there are servings.  Reduce and print
			servings--;
			Console.WriteLine("You take a bite of the " + name);
			Console.WriteLine("There are now " + servings + " servings left.");
			return true;
		}


		/// <summary>
		/// String representation of this object
		/// </summary>
		/// <returns>A string representation of this object containing 
		/// the name, weight, and number of servings</returns>
		public override string ToString()
		{
			return
				base.ToString() +
				", which is food with " +
				servings + " servings left";
		}
	}

}
