// Conor Race
// Nov. 1st, 2021
// Purpose: Implemented class; Allows for the creation of circle objects, along with
// the manipulation of said objects, largely in part from methods from interfaces.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points_and_Shapes__Interfaces_
{
    class Circle : IPosition, IArea
    {
        private double xCenter;
        private double yCenter;
        private double radius;

        /// <summary>
        /// Constructor for the Circle class. Simply creates a Circle object via an x
        /// and y position, as well as a radius passed in as parameters.
        /// </summary>
        /// <param name="x"> X coordinate of the point. </param>
        /// <param name="y"> Y coordinate of the point. </param>
        /// <param name="r"> Radius of the circle. </param>
        public Circle(double x, double y, double r)
        {
            xCenter = x;
            yCenter = y;
            radius = r;
        }


        // IPosition Properties:

        /// <summary>
        /// Property; Allows for the retrieval and editing of the x coordinate of a
        /// circle object's center. Mandatory placement via IPosition interface.
        /// </summary>
        public double X { get { return xCenter; } set { xCenter = value; } }

        /// <summary>
        /// Property; Allows for the retrieval and editing of the y coordinate of a
        /// circle object's center. Mandatory placement via IPosition interface.
        /// </summary>
        public double Y { get { return yCenter; } set { yCenter = value; } }


        // IArea Properties:

        /// <summary>
        /// Property; Returns the area of the circle object.
        /// Mandatory via IArea interface.
        /// </summary>
        public double Area { get { return Math.PI * Math.Pow(radius, 2); } }

        /// <summary>
        /// Property; Returns the perimeter (circumfrence) of the circle object.
        /// Mandatory via IArea interface.
        /// </summary>
        public double Perimeter { get { return 2 * Math.PI * radius;  } }


        // IPosition Methods:

        /// <summary>
        /// Calculates the distance between a circle object's center and the position of another object
        /// (whether point, circle center, etc) and returns the result. Mandatory placement via IPosition interface.
        /// </summary>
        /// <param name="position"> The second object from which distance is calculated. </param>
        /// <returns> The calculated distance between the two objects. </returns>
        public double DistanceTo(IPosition position)
        {
            return Math.Sqrt(Math.Pow((position.X - xCenter), 2) + Math.Pow((position.Y - yCenter), 2));
        }

        /// <summary>
        /// Changes the x and y positions of the object's center to a new position via values passed in as parameters.
        /// Mandatory via IPosition interface.
        /// </summary>
        /// <param name="x"> New x coordinate to be changed to. </param>
        /// <param name="y"> New y coordinate to be changes to. </param>
        public void MoveTo(double x, double y)
        {
            xCenter = x;
            yCenter = y;
        }

        /// <summary>
        /// Shifts the x and y positions of the object's center by a certain amount via values passed in as parameters.
        /// Mandatory via IPosition interface.
        /// </summary>
        /// <param name="xOff"> How much the x coordinate is shifted by. </param>
        /// <param name="yOff"> How much the y coordinate is shifted by. </param>
        public void MoveBy(double xOff, double yOff)
        {
            xCenter += xOff;
            yCenter += yOff;
        }


        // IArea Methods:

        /// <summary>
        /// Checks to see whether a point's position is within the area of a circle object. Mandatory via IArea interface.
        /// </summary>
        /// <param name="position"> The point which its position is being checked. </param>
        /// <returns> True if the point lies within the area. False otherwise. </returns>
        public bool ContainsPosition(IPosition position)
        {
            if ((position.X >= (xCenter - radius) && position.X <= (xCenter + radius)) && (position.Y >= (yCenter - radius) && position.Y <= (yCenter + radius)))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Compares the area sizes of two circle objects. Mandatory via IArea interface.
        /// </summary>
        /// <param name="areaToCheck"> Another circle object for which its area is compared. </param>
        /// <returns> True if the first circle's area is larger than the second's. False otherwise. </returns>
        public bool IsLargerThan(IArea areaToCheck)
        {
            if (Area > areaToCheck.Area)
            {
                return true;
            }
            return false;
        }


        // ToString Method:

        /// <summary>
        /// Overridden ToString() method which returns the object's current x and y positions,
        /// as well as its radius, area, and perimeter via string.
        /// </summary>
        /// <returns> A string of an object's current stats. </returns>
        public override string ToString()
        {
            return $"Circle Center: ({xCenter},{yCenter}) | Radius: {radius} | Area: {Area:#.##} | Perimeter: {Perimeter:#.##}";
        }
    }
}
