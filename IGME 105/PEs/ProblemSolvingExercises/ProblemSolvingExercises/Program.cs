using System;
using System.Collections.Generic;

namespace ProblemSolvingExercises
{
	class Program
	{
		// Used by several problems
		static Random rng = new Random();

		/// <summary>
		/// Test code for the 5 methods below.  Do not alter this.
		/// </summary>
		static void Main(string[] args)
		{
			// Output of the various problems
			Console.WriteLine("Problem 1 ------------------");
			Console.WriteLine(Problem1(rng.Next(-10, 11)));

			Console.WriteLine("\nProblem 2 ------------------");
			Problem2();

			Console.WriteLine("\nProblem 3 ------------------");
			Problem3();

			Console.WriteLine("\nProblem 4 ------------------");
			Problem4();

			Console.WriteLine("\nProblem 5 ------------------");
			Problem5();

			// Keep the window open
			Console.ReadLine();
		}



		/// <summary>
		/// GOAL: Determine the intended purpose of this code, then
		/// rewrite this code WITHOUT using a conditional statement.
		/// 
		/// RESTRICTIONS: 
		/// - No conditional statements (if, switch or ternary) allowed
		/// - Your solution should be functionally identical to the provided code
		/// 
		/// NOTE: A commented-out copy has been provided so
		/// you can compare your solution or start over.
		/// </summary>
		static bool Problem1(int a)
		{
			#region Copy of code
			//if (a < 0)
			//	return false;
			//else
			//	return true;
			#endregion

			return !(a < 0);
		}



		/// <summary>
		/// GOAL: Determine the intended purpose of this code
		/// and rewrite it to be as simple (and easy to
		/// understand) as possible.
		/// - The fewer clearly-written lines of code, the better
		/// - Ternary operator (a?b:c) is unnecessary, however
		/// 
		/// RESTRICTIONS: Your solution should be able to produce
		/// the exact same output with the same probability.
		/// 
		/// NOTE: A commented-out copy has been provided so
		/// you can compare your solution or start over.
		/// </summary>
		static void Problem2()
		{
			#region Copy of code
			//int temp = rng.Next(2);

			//bool temp2 = true;
			//if (temp == 0)
			//	temp2 = false;
			//else if (temp == 1)
			//	temp2 = true;

			//if (temp2.ToString().ToUpper()[0].ToString() == "T")
			//	Console.WriteLine("YES");
			//else if (temp2.ToString().ToUpper()[0].ToString() == "F")
			//	Console.WriteLine("NO");
			#endregion

			int temp = rng.Next(2);

			if (temp == 0)
				Console.WriteLine("YES");
			else if (temp == 1)
				Console.WriteLine("NO");
		}



		/// <summary>
		/// GOAL: Determine the intended purpose of this code, then 
		/// simplify it by reducing the number of statements. The goal
		/// here is simplicity with the fewest clearly-written code 
		/// statements, not necessarily cleverness.
		/// 
		/// RESTRICTIONS: Your solution should be able to only produce
		/// appropriate output based on the intended purpose of this code.
		/// 
		/// NOTE: A commented-out copy has been provided so
		/// you can compare your solution or start over.
		/// </summary>
		static void Problem3()
		{
			#region Copy of code
			//int a = rng.Next(100);

			//bool even = false;
			//bool odd = false;

			//if (a % 2 == 0)
			//{
			//	even = true;
			//	odd = false;
			//}
			//if (a % 2 == 1)
			//{
			//	even = false;
			//	odd = true;
			//}
			//else
			//{
			//	even = false;
			//	odd = false;
			//}

			//if (even == true && odd == false)
			//	Console.WriteLine(a + "is EVEN");
			//else if (even == false && odd == true)
			//	Console.WriteLine(a + "is ODD");
			//else if (even == true && odd == true)
			//	Console.WriteLine(a + " SHOULDN'T GET HERE");
			//else if (even == false && odd == false)
			//	Console.WriteLine(a + " SHOULDN'T GET HERE");
			//else
			//	Console.WriteLine(a + " SHOULDN'T GET HERE");
			#endregion

			int a = rng.Next(100);

			if (a % 2 == 0)
				Console.WriteLine(a + " is EVEN");
			else if (a % 2 == 1)
				Console.WriteLine(a + " is ODD");
		}



		/// <summary>
		/// GOAL: This code removes all three-letter names from a list
		/// of names.  However, it doesn't appear to always work.
		/// 
		/// 1. Identify why the code sometimes fails to 
		///    remove a three-letter name
		/// 2. Alter the code to fix the issue
		/// 
		/// RESTRICTIONS: None, other than following good coding
		/// practices and keeping the code as simple as possible.
		/// 
		/// NOTE: A commented-out copy has been provided so
		/// you can compare your solution or start over.
		/// </summary>
		static void Problem4()
		{
			#region Copy of Code
			//// Create a list and immediately fill
			//// it with several names
			//List<string> names = new List<string>() {
			//	"Steve",
			//	"Bob",
			//	"Jim",
			//	"Pam",
			//	"Jan",
			//	"Larry",
			//	"Sue",
			//	"Tom",
			//	"Tina",
			//	"Simon" };

			//// Loop through the list and remove
			//// all 3-letter names
			//for (int i = 0; i < names.Count; i++)
			//{
			//	if (names[i].Length == 3)
			//	{
			//		names.RemoveAt(i);
			//	}
			//}

			//// Print the list
			//foreach (string name in names)
			//{
			//	Console.WriteLine(name);
			//}
			#endregion

			// Answer to #1: This code fails to remove all 3 letter names b/c when a few
			// 3 letter names appear subsequent to each other, the RemoveAt() method pushes
			// the name to the location where a name was just removed.

			// Create a list and immediately fill
			// it with several names
			List<string> names = new List<string>() {
				"Steve",
				"Bob",
				"Jim",
				"Pam",
				"Jan",
				"Larry",
				"Sue",
				"Tom",
				"Tina",
				"Simon" };

			// Loop through the list and remove
			// all 3-letter names
			for (int i = names.Count - 1; i > 0; i--)
			{
				if (names[i].Length == 3)
				{
					names.RemoveAt(i);
				}
			}

			// Print the list
			foreach (string name in names)
			{
				Console.WriteLine(name);
			}
		}



		/// <summary>
		/// GOAL: Determine the intended purpose of this code by
		/// analyzing each line of the method, one at a time, rather
		/// than trying to figure it all out at once.  Do the following:
		/// 
		/// 1. One at a time, answer EACH of the questions posed in 
		///    the comments throughout the code below
		/// 2. Make a guess as to what the code is attempting to do
		/// 3. To verify, print out the array at the end of the method
		/// 
		/// RESTRICTIONS: Answer each question in terms of the code that
		/// immediately follows it, rather than looking at the method as a
		/// whole - the idea is to figure out each line in isolation first.
		/// 
		/// NOTE: You do not need to alter any of the code itself.
		/// Simply add comments answering each question.
		/// </summary>
		static void Problem5()
		{
			// Declares an array of names
			string[] names = new string[] {
				"Steve",
				"Bob",
				"Jim",
				"Pam",
				"Jan",
				"Larry",
				"Sue",
				"Tom",
				"Tina",
				"Simon" };

			// Given just this line, what does this loop appear to do?
			// Answer: Goes through the entire length of the "names" array.
			for (int i = 0; i < names.Length; i++)
			{
				// Given just this line, what does this loop appear to do?
				// Answer: Goes through a particular length of the "names" array from the
				//         end of the array up to i's current position.
				for (int j = names.Length - 1; j > i; j--)
				{
					// What would be better names for these variables?
					// Note: This might be easier to determine after
					//       answering some of the other comments below
					// Answer: Change 'check' to 'swapOrder' and 'k' to 'charCheck'.
					bool check = false;
					int k = 0;

					// Given just this line, what is the condition checking?
					// Answer: Loops code inside so long as int k is less than the string's length
					//         at index j and (j-1).
					while (k < names[j - 1].Length && k < names[j].Length)
					{
						// What is this condition checking?
						// Answer: Checks if the character position at index k is equal in both strings
						//         referenced (string at index j and (j-1)).
						if (names[j - 1][k] == names[j][k])
						{
							// What is the effect of the following
							// lines once the if condition is met?
							// Answer: k is increased, thus moving to the next character in both strings,
							//         or if the end of string is met, the loop is broken.
							k++;
							continue;
						}

						// What does this expression represent?
						// Answer: If the characters do NOT match, this conditional checks whether the character
						//         of string (j-1) at index k comes later alphabetically compared to the character
						//         of string j at the same index. If so, check is set to true.
						check = (names[j - 1][k] > names[j][k]);
						break;
					}

					// When does this if statement execute?
					// Answer: This condition is met only if the strings j and (j-1) are not alphabetically aligned
					//         (i.e: Pot, Apple).
					if (check)
					{
						// What are these 3 lines effectively doing?
						// Answer: Swaps the position of the strings at j and (j-1).
						string temp = names[j - 1];
						names[j - 1] = names[j];
						names[j] = temp;
					}
				}
			}

			// Step 2: What is the code attempting to do?
			// Answer: From my analysis, this code is attempting to sort this list of strings in alphabetical order.

			// Step 3: Print out the array elements to verify your guess
			// (You will write code here!)
			foreach (string name in names)
			{
				Console.WriteLine(name);
			}
		}

	}
}
