// Conor Race
// Nov. 1st, 2021
// Purpose: Creates several point and circle objects and runs them through
// a series of tests from methods dictated by interfaces.

using System;

namespace Points_and_Shapes__Interfaces_
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Creation of Point and Circle objects

            IPosition point1 = new Point(5, 7);
            IPosition point2 = new Point(10, 10);
            Circle circle1 = new Circle(10, 10, 3);
            Circle circle2 = new Circle(0, 0, 5);


            // Outputting all stats of all objects

            Console.WriteLine(point1);
            Console.WriteLine(point2);
            Console.WriteLine(circle1);
            Console.WriteLine(circle2);


            // Using 'MoveTo()' and 'MoveBy()' methods

            Console.WriteLine("\nMoving Point #2 to (2,2)");
            point2.MoveTo(2, 2);
            Console.WriteLine("Moving Circle #2 by (-1,-1)\n");
            circle2.MoveBy(-1, -1);


            // Outputting all stats of all objects (again)

            Console.WriteLine(point1);
            Console.WriteLine(point2);
            Console.WriteLine(circle1);
            Console.WriteLine(circle2);


            // Calculatiung distances between points via 'DistanceTo()' method

            Console.WriteLine($"\nDistance between Point #1 and Point #2: {point1.DistanceTo(point2):#.#####}");
            Console.WriteLine($"Distance between Point #1 and Circle #1: {point1.DistanceTo(circle1):#.#####}");
            Console.WriteLine($"Distance between Point #1 and Circle #2: {point1.DistanceTo(circle2):#.#####}");
            Console.WriteLine($"Distance between Point #2 and Circle #1: {point2.DistanceTo(circle1):#.#####}");
            Console.WriteLine($"Distance between Point #2 and Circle #2: {point2.DistanceTo(circle2):#.#####}\n");


            // Using 'IsLargerThan()' method to compare circle sizes

            if (circle1.IsLargerThan(circle2))
            {
                Console.WriteLine($"Circle #1's area ({circle1.Area:#.##}) is larger than Circle #2's area ({circle2.Area:#.##})");
            }
            else
            {
                Console.WriteLine($"Circle #2's area ({circle2.Area:#.##}) is larger than Circle #1's area ({circle1.Area:#.##})\n");
            }


            // Using 'ContainsPosition()' method to see whether various points are in the area of a circle

            if (circle1.ContainsPosition(point1))
            {
                Console.WriteLine("Circle #1 contains Point #1");
            }
            else
            {
                Console.WriteLine("Circle #1 does NOT contain Point #1");
            }

            if (circle1.ContainsPosition(point2))
            {
                Console.WriteLine("Circle #1 contains Point #2");
            }
            else
            {
                Console.WriteLine("Circle #1 does NOT contain Point #2");
            }

            if (circle2.ContainsPosition(point1))
            {
                Console.WriteLine("Circle #2 contains Point #1");
            }
            else
            {
                Console.WriteLine("Circle #2 does NOT contain Point #1");
            }

            if (circle2.ContainsPosition(point2))
            {
                Console.WriteLine("Circle #2 contains Point #2");
            }
            else
            {
                Console.WriteLine("Circle #2 does NOT contain Point #2");
            }
        }
    }
}
