// Conor Race
// Nov. 1st, 2021
// Purpose: Implemented class; Allows for the creation of point objects, along with
// the manipulation of said objects, largely in part from methods from an interface.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points_and_Shapes__Interfaces_
{
    class Point : IPosition
    {
        private double xPos;
        private double yPos;

        /// <summary>
        /// Constructor for the Point class. Simply creates a Point object via an x
        /// and y position passed in as parameters.
        /// </summary>
        /// <param name="x"> X coordinate of the point. </param>
        /// <param name="y"> Y coordinate of the point. </param>
        public Point(double x, double y)
        {
            xPos = x;
            yPos = y;
        }

        /// <summary>
        /// Property; Allows for the retrieval and editing of the x coordinate of a
        /// point object. Mandatory placement via IPosition interface.
        /// </summary>
        public double X { get { return xPos; } set { xPos = value; } }

        /// <summary>
        /// Property; Allows for the retrieval and editing of the y coordinate of a
        /// point object. Mandatory placement via IPosition interface.
        /// </summary>
        public double Y { get { return yPos; } set { yPos = value; } }

        /// <summary>
        /// Calculates the distance between a point object and the position of another
        /// object (whether point, circle center, etc) and returns the result. Mandatory
        /// placement via IPosition interface.
        /// </summary>
        /// <param name="position"> The second object from which distance is calculated. </param>
        /// <returns> The calculated distance between the two objects. </returns>
        public double DistanceTo(IPosition position)
        {
            return Math.Sqrt(Math.Pow((position.X - xPos), 2) + Math.Pow((position.Y - yPos), 2));
        }

        /// <summary>
        /// Changes the x and y positions to a new position via values passed in as parameters.
        /// Mandatory via IPosition interface.
        /// </summary>
        /// <param name="x"> New x coordinate to be changed to. </param>
        /// <param name="y"> New y coordinate to be changes to. </param>
        public void MoveTo(double x, double y)
        {
            xPos = x;
            yPos = y;
        }

        /// <summary>
        /// Shifts the x and y positions by a certain amount via values passed in as parameters.
        /// Mandatory via IPosition interface.
        /// </summary>
        /// <param name="xOff"> How much the x coordinate is shifted by. </param>
        /// <param name="yOff"> How much the y coordinate is shifted by. </param>
        public void MoveBy(double xOff, double yOff)
        {
            xPos += xOff;
            yPos += yOff;
        }

        /// <summary>
        /// Overridden ToString() method which returns the object's current x and y positions via string.
        /// </summary>
        /// <returns> A string of an object's current x and y positions. </returns>
        public override string ToString()
        {
            return $"Point: ({xPos},{yPos})";
        }
    }
}
