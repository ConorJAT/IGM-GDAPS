using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player_Inventory__Final_
{
	abstract class Item
	{
		protected String name;
		protected double weight;

		public String Name { get { return name; } }
		public double Weight { get { return weight; } }


		/// <summary>
		/// Consructs an Item object
		/// </summary>
		/// <param name="name">Name of this Item</param>
		/// <param name="weight">Weight of this Item</param>
		public Item(String name, double weight)
		{
			this.name = name;
			this.weight = weight;
		}


		/// <summary>
		/// Uses an object of a subclass type
		/// </summary>
		/// <returns>Whether the subclass item was usable</returns>
		public abstract bool Use();


		/// <summary>
		/// String representation of this object
		/// </summary>
		/// <returns>A string representation of this object containing 
		/// the name and weight</returns>
		public override string ToString()
		{
			return "This is an item named '" + name + "' and weighs " + weight + " pounds";
		}
	}
}
