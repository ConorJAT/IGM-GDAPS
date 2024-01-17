// Conor Race
// Nov. 22nd, 2021
// Purpose: Allows for the creation and use of Vector2 objects.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vectors__Op_Overload_
{
    class Vector2
    {
        /// <summary>
        /// Auto-Property; Allows for the retrieval and set of the vector's X value.
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// Auto-Property; Allows for the retrieval and set of the vector's Y value.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Default Constructor; Sets all vector values to 0.
        /// </summary>
        public Vector2() : this(0, 0)
        {
        }

        /// <summary>
        /// Parameterized Constructor; Sets all vector values accordingly via values
        /// passed in as parameters.
        /// </summary>
        /// <param name="x"> The vector's X value. </param>
        /// <param name="y"> The vector's Y value. </param>
        public Vector2(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Returns a string value of the vector's values.
        /// </summary>
        /// <returns> Returns all values associated with the vector. </returns>
        public override string ToString()
        {
            return $"<{X}, {Y}>";
        }

        /// <summary>
        /// Overloaded Operator; Allows for the addition of two like vectors.
        /// </summary>
        /// <param name="v1"> First vector operand being added. </param>
        /// <param name="v2"> Second vector operand being added. </param>
        /// <returns> Returns a new vector object as a result from addtion. </returns>
        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
        }

        /// <summary>
        /// Overloaded Operator; Allows for the subtraction of two like vectors.
        /// </summary>
        /// <param name="v1"> First vector operand being subtracted from. </param>
        /// <param name="v2"> Second vector operand doing the substraction. </param>
        /// <returns> Returns a new vector object as a result from subtraction. </returns>
        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X - v2.X, v1.Y - v2.Y);
        }

        /// <summary>
        /// Overloaded Operator; Allows vectors to be mutiplied by a scalar value.
        /// </summary>
        /// <param name="v1"> Vector operand being multiplied. </param>
        /// <param name="scale"> Scalar value multiplying the vector. </param>
        /// <returns> Returns a new vector object as a result from multiplication. </returns>
        public static Vector2 operator *(Vector2 v1, double scale)
        {
            return new Vector2(v1.X * scale, v1.Y * scale);
        }

        /// <summary>
        /// Overloaded Operator; Allows vectors to be divided by a scalar value.
        /// </summary>
        /// <param name="v1"> Vector operand being divided. </param>
        /// <param name="scale"> Scalar value dividing the vector. </param>
        /// <returns> Returns a new vector object as a result from division. </returns>
        public static Vector2 operator /(Vector2 v1, double scale)
        {
            return new Vector2(v1.X / scale, v1.Y / scale);
        }

        /// <summary>
        /// Overloaded Operator; Allows for Vector3 objects to be explicitly converted
        /// to Vector2 objects by simply dropping the Z-value.
        /// </summary>
        /// <param name="v"> Returns a new Vector2 object converted from the Vector3 parameter. </param>
        public static explicit operator Vector2(Vector3 v)
        {
            return new Vector2(v.X, v.Y);
        }
    }
}
