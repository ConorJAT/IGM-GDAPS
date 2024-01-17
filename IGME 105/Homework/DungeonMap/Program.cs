//Conor Race
//IGME.105.01 - Oct 1st, 2021
//Purpose: Creates a pre-made video game dungeon map
//using only ASCII characters.

using System;

namespace DungeonMap
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creates a Dungeon object, which contains the code to draw
            // a map in the console.  This map is 50 columns by 20 rows.
            Dungeon dungeon = new Dungeon("Sample Dungeon", 20, 50);
            
            // ACTIVITY 1: Building the first room ------------------------------------
            // Top left room:
            dungeon.DrawWallHorizontal(-1, 0, 12);  // Draw the top wall
            dungeon.DrawWallVertical(0, -5, 12);    // Draw left wall
            dungeon.DrawWallHorizontal(1, 7, 10);   // Draw the bottom wall
            dungeon.DrawWallVertical(11, 1, 1);     // Draw top right wall
            dungeon.DrawWallVertical(11, 5, 2);     // Draw bottom right wall
            
            // Wall corners:
            dungeon.DrawObject(0, 0, '╔'); 
            dungeon.DrawObject(11, 0, '╗'); 
            dungeon.DrawObject(0, 7, '╚'); 
            dungeon.DrawObject(11, 7, '╝'); 
            dungeon.DrawObject(11, 2, '╚'); // The entrance to the hallway
            dungeon.DrawObject(11, 4, '╔'); // The entrance to the hallway
            
            // Objects in the room:
            dungeon.DrawObject(3, 4, '@'); // The explorer character
            dungeon.DrawObject(7, 6, '['); // Trap door - left half
            dungeon.DrawObject(8, 6, ']'); // Trap door - right half
            
            // Attempting to draw off the screen (none of these should appear):
            dungeon.DrawObject(-5,  -12, 'X');
            dungeon.DrawObject(-7, 6, 'X');
            dungeon.DrawObject(55, 92, 'X');
            
            // Attempting to use a negative length (neither of these should appear):
            dungeon.DrawWallHorizontal(10, 10, -5); 
            dungeon.DrawWallVertical(10, 10, -200);


            // ACTIVITY 2: Adding more to the dungeon --------------------------------- 
            // Horizontal hallway:
            dungeon.DrawWallHorizontal(12, 2, 24, ConsoleColor.Cyan, '~');
            dungeon.DrawWallHorizontal(12, 4, 20, ConsoleColor.DarkCyan, '~');
            
            // Vertical hallway:
            dungeon.DrawWallVertical(36, 3, 11, ConsoleColor.Cyan, '|');
            dungeon.DrawWallVertical(32, 5, 9, ConsoleColor.DarkCyan, '|');
            
            // Corners:
            dungeon.DrawObject(36, 2, '.', ConsoleColor.Magenta);
            dungeon.DrawObject(32, 4, '.', ConsoleColor.DarkMagenta);
            
            // Second room walls:
            dungeon.DrawWallHorizontal(25, 14, 7, ConsoleColor.DarkGray, '_');
            dungeon.DrawWallHorizontal(37, 14, 12, ConsoleColor.DarkGray, '_'); 
            dungeon.DrawWallHorizontal(25, 19, 50, ConsoleColor.Red, '-'); 
            dungeon.DrawWallVertical(24, 15, 1000, ConsoleColor.Gray, '[');
            dungeon.DrawWallVertical(49, 15, 9000, ConsoleColor.Gray, ']');
            
            // Corners:
            dungeon.DrawObject(32, 14, '/', ConsoleColor.Gray);
            dungeon.DrawObject(36, 14, '\\', ConsoleColor.Gray);
            dungeon.DrawObject(24, 19, '}', ConsoleColor.Yellow);
            dungeon.DrawObject(49, 19, '{', ConsoleColor.Yellow);
            
            // Objects:
            dungeon.DrawObject(40, 18, '$', ConsoleColor.Green);
            dungeon.DrawObject(36, 16, '$', ConsoleColor.Green);
            dungeon.DrawObject(28, 17, '$', ConsoleColor.Green);


            // WRAP UP ----------------------------------------------------------------
            // The following lines ensure the cursor ends up near the bottom
            // of the console window when the program ends.
            Console.CursorTop = Console.WindowHeight - 1; 
            Console.CursorLeft = 0; 
            
            // Keep the window open
            Console.ReadKey();
        }
    }
}
