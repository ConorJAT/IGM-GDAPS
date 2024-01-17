//Conor Race
//IGME.105.01 - Oct 1st, 2021
//Purpose: Object class for the main class "DungeonMap." Responsible
//for drawing out the premade game map, including walls, corners, and
//in-map items and player.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMap
{

    class Dungeon
    {
        private int roomLength;
        private int roomHeight;
        private string dungeonName;

        public Dungeon(string name, int height, int length)
        {
            dungeonName = name;
            if (height > Console.LargestWindowHeight) // Can't go over max window height.
            {
                roomHeight = Console.LargestWindowHeight;
            }
            else if (height <= 10) // Can't be less than 10 units.
            {
                roomHeight = 11;
            }
            else
            {
                roomHeight = height - 1;
            }

            if (length > Console.LargestWindowWidth) // Can't go over max window width.
            {
                roomLength = Console.LargestWindowWidth;
            }
            else if (length <= 10) // Can't be less than 10 units.
            {
                roomLength = 11;
            }
            else
            {
                roomLength = length - 1;
            }
        }

        /// <summary>
        /// Responsible for drawing out vertical walls of the dungeon. Acts as an
        /// overload method for when the user provides limited input. If that's the case, the
        /// default color used is Gray and the default character used is '║'.
        /// </summary>
        /// <param name="x"> Starting x position for drawing. </param>
        /// <param name="y"> Starting y position for drawing. </param>
        /// <param name="length"> How long the vertical wall will be. </param>
        public void DrawWallVertical(int x, int y, int length)
        {
            DrawWallVertical(x, y, length, ConsoleColor.Gray, '║'); // Passes input to larger DrawWallVertical method, along w/ default color and character.
        }

        /// <summary>
        /// Responsible for drawing out vertical walls of the dungeon. Acts as the
        /// main method for when the user provides maximum input.
        /// </summary>
        /// <param name="x"> Starting x position for drawing. </param>
        /// <param name="y"> Starting y position for drawing. </param>
        /// <param name="length"> How long the vertical wall will be. </param>
        /// <param name="color"> The color of the wall segment. </param>
        /// <param name="symbol"> The chosen character the wall will consist of. </param>
        public void DrawWallVertical(int x, int y, int length, ConsoleColor color, char symbol)
        {
            Console.ForegroundColor = color;

            if (length <= 0) // Tests for zero and negative lengths.
            {
                return;
            }
            else if (x < 0 || x > roomLength) // Tests for negative and out of bounds width positions.
            {
                return;
            }
            else if (y > roomHeight) // Checks for out of bounds height positions.
            {
                return;
            }

            if (y < 0) // Offsets how much is printed if starting height is negative.
            {
                length = length + y;
                y = 0;
            }

            Console.CursorLeft = x;
            Console.CursorTop = y;

            for (int i = 0; i < length; i++)
            {
                if (Console.CursorTop > roomHeight) // Stops method if the wall reaches the vertical bound.
                {
                    return;
                }
                Console.WriteLine(symbol);
                Console.CursorLeft = x;
            }
        }

        /// <summary>
        /// Responsible for drawing out horizontal walls of the dungeon. Acts as an
        /// overload method for when the user provides limited input. If that's the case, the
        /// default color used is Gray and the default character used is '═'.
        /// </summary>
        /// <param name="x"> Starting x position for drawing. </param>
        /// <param name="y"> Starting y position for drawing. </param>
        /// <param name="length"> How long the horizontal wall will be. </param>
        public void DrawWallHorizontal(int x, int y, int length)
        {
            DrawWallHorizontal(x, y, length, ConsoleColor.Gray, '═'); // Passes input to larger DrawWallHorizontal method, along w/ default color and character.
        }

        /// <summary>
        /// Responsible for drawing out horizontal walls of the dungeon. Acts as the
        /// main method for when the user provides maximum input.
        /// </summary>
        /// <param name="x"> Starting x position for drawing. </param>
        /// <param name="y"> Starting y position for drawing. </param>
        /// <param name="length"> How long the horizontal wall will be. </param>
        /// <param name="color"> The color of the wall segment. </param>
        /// <param name="symbol"> The chosen character the wall will consist of. </param>
        public void DrawWallHorizontal(int x, int y, int length, ConsoleColor color, char symbol)
        {
            Console.ForegroundColor = color;

            if (length <= 0) // Tests for zero and negative lengths.
            {
                return;
            }
            else if (y < 0 || y > roomHeight) // Tests for negative and out of bounds height positions.
            {
                return;
            }
            else if (x > roomLength) // Checks for out of bounds width positions.
            {
                return;
            }

            if (x < 0) // Offsets how much is printed if starting width is negative.
            {
                length = length + x;
                x = 0;
            }

            Console.CursorLeft = x;
            Console.CursorTop = y;

            for (int i = 0; i < length; i++)
            {
                if (Console.CursorLeft > roomLength) // Stops method if the wall reaches the vertical bound.
                {
                    return;
                }
                Console.Write(symbol);
                Console.CursorTop = y;
            }
        }

        /// <summary>
        /// Responsible for drawing any potential in-map items and players. Acts as an
        /// overload method for when the user provides limited input. If that's the case, the
        /// default color used is Gray.
        /// </summary>
        /// <param name="x"> The x coordinate for the inserted object. </param>
        /// <param name="y"> The y coordinate for the inserted object. </param>
        /// <param name="symbol"> The selected character the user would like to enter. </param>
        public void DrawObject(int x, int y, char symbol)
        {
            DrawObject(x, y, symbol, ConsoleColor.Gray); // Passes input to larger DrawObject method, along w/ default color. 
        }

        /// <summary>
        /// Responsible for drawing any potential in-map items and players. Acts as the
        /// main method for when the user provides maximum input.
        /// </summary>
        /// <param name="x"> The x coordinate for the inserted object. </param>
        /// <param name="y"> The y coordinate for the inserted object. </param>
        /// <param name="symbol"> The selected character the user would like to enter. </param>
        /// <param name="color"> The color of the inserted character. </param>
        public void DrawObject(int x, int y, char symbol, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            
            if (x < 0 || y < 0) // Tests for negative coordinates.
            {
                return;
            }
            else if (x > roomLength || y > roomHeight) // Tests for if coordinates are out of bounds of dungeon.
            {
                return;
            }

            Console.CursorLeft = x;
            Console.CursorTop = y;

            Console.Write(symbol);
        }
    }
}
