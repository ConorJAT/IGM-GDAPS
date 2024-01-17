using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player_Inventory__Final_
{
	class Weapon : Item
	{
		private int durabilityCurrent;
		private int durabilityOriginal;
		private int damage;


		/// <summary>
		/// Constructs a Weapon object
		/// </summary>
		/// <param name="name">Name of this Weapon</param>
		/// <param name="durability">Measure of durability</param>
		/// <param name="damage">Amount of dealt damage when attacked with</param>
		/// <param name="weight">Weight of this weapon</param>
		public Weapon(String name, int durability, int damage, double weight)
			: base(name, weight)
		{
			this.durabilityCurrent = durability;
			this.durabilityOriginal = durability;
			this.damage = damage;
		}


		/// <summary>
		/// Uses this weapon by reducing its durability and printing confirmation messages
		/// </summary>
		/// <returns>Whether this item was usable</returns>
		public override bool Use()
		{
			// Is the weapon usable?
			if (durabilityCurrent <= 0)
			{
				Console.WriteLine(
					"You attempt to use the " + name +
					", but it is broken");
				return false;
			}

			// It's usable.  Reduce and print
			durabilityCurrent--;
			Console.WriteLine("You attack with " + name);
			Console.WriteLine("Its durability is now " + durabilityCurrent);
			return true;
		}


		/// <summary>
		/// Repairs a weapon by resetting its current durability to the max durability
		/// </summary>
		public void Repair()
		{
			Console.WriteLine("Weapon {0} is repaired.", name);
			durabilityCurrent = durabilityOriginal;
		}


		/// <summary>
		/// String representation of this object
		/// </summary>
		/// <returns>A string representation of this object containing 
		/// the name, weight, durability, and damage.</returns>
		public override string ToString()
		{
			return
				base.ToString() +
				", which is a weapon with " +
				durabilityCurrent + "/" + durabilityOriginal + " uses left. " +
				"It deals " + damage + " damage.";
		}
	}
}
