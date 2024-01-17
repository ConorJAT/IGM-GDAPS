// Conor Race
// Nov. 22nd, 2021
// Purpose: Creates several vector objects and tests them using
// overloaded operators and conversions.

using System;
using System.Collections.Generic;

namespace Vectors__Op_Overload_
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector2 v1 = new Vector2(10, 10);
            Vector2 v2 = new Vector2(2 ,4);
            Vector3 v3 = new Vector3(1.5, 2, 3.14159);
            Vector3 v4 = new Vector3(5, 5, 5);


            // Print All Initial Vectors:

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Operation Overloading Test\n");
            Console.WriteLine("---- Initial Vectors ----");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(v1);
            Console.WriteLine(v2);
            Console.WriteLine(v3);
            Console.WriteLine(v4);


            // Using Overloaded Operators:

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n---- Vector Operations ----");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($"Adding {v1} and {new Vector2(4, -13)}: ");
            v1 = v1 + new Vector2(4, -13);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(v1);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($"Multiplying {v2} by 2: ");
            v2 = v2 * 2;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(v2);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($"Subtracting {new Vector3(1, 2, 3)} from {v3}: ");
            v3 = v3 - new Vector3(1, 2, 3);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(v3);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($"Dividing {v4} by 2.5: ");
            v4 = v4 / 2.5;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(v4);


            // Using Overloaded Implicit/Explicit Casting:

            List<Vector3> vectList = new List<Vector3>();
            Random rng = new Random();
            vectList.Add(v1);
            vectList.Add(v2);
            vectList.Add(v3);
            vectList.Add(v4);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n---- Vector Explicit Cast ----");
            int randInd = rng.Next(0, vectList.Count);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($"Element at index {randInd}: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine((Vector2)vectList[randInd]);


            // Calculating The Average:

            Vector3 avgVect = new Vector3();
            for (int i = 0; i < vectList.Count; i++)
            {
                avgVect += vectList[i];
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n---- Average Vector ----");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(avgVect / 4);
            Console.ForegroundColor = ConsoleColor.Gray;

        }
    }
}
