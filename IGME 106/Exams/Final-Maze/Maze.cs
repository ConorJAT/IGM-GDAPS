using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Final_Maze
{
	/// <summary>
	/// Possible maze tile types
	/// </summary>
	enum MazeTile
	{
		Empty,
		Wall,
		Start,
		End
	}

	class Maze
	{
		// Constants ============================

		// Drawing-related constants
		const int MazeUnitSize = 10;

		// Fields ===========================

		// Maze colors
		private Color MazeColorEmpty = Color.White;
		private Color MazeColorWall = Color.Black;
		private Color MazeColorStart = Color.Lime;
		private Color MazeColorEnd = Color.Red;
		private Color MazeColorPath = Color.CornflowerBlue;
		private Color[] MazeColors;

		// The maze sizes
		private int mazeSizeX;
		private int mazeSizeY;

		// The maze offsets (using for centering the maze)
		int xOffset;
		int yOffset;

		// The maze Vertices
		private Vertex[,] vertices;
		private Vertex startVertex;
		private Vertex endVertex;

		// A 1x1 white texture (basically a single pixel) for drawing
		private Texture2D pixel;

		// Constructor ==========================

		/// <summary>
		/// Creates a new maze object
		/// </summary>
		/// <param name="device">The graphics device for the game</param>
		public Maze(GraphicsDevice device)
		{
			// Create the 1x1 white pixel texture
			pixel = new Texture2D(device, 1, 1);
			pixel.SetData<Color>(new Color[] { Color.White });

			// Set up the color array
			MazeColors = new Color[4];
			MazeColors[(int)MazeTile.Empty] = MazeColorEmpty;
			MazeColors[(int)MazeTile.Wall] = MazeColorWall;
			MazeColors[(int)MazeTile.Start] = MazeColorStart;
			MazeColors[(int)MazeTile.End] = MazeColorEnd;
		}

		// Setup Methods ========================

		/// <summary>
		/// Sets up the maze data
		/// </summary>
		/// <param name="mazeTexture">The texture to get the maze from</param>
		public void SetMaze(Texture2D mazeTexture, int screenWidth, int screenHeight)
		{
			// Get the maze sizes
			mazeSizeX = mazeTexture.Width;
			mazeSizeY = mazeTexture.Height;

			// Offsets (for centering)
			xOffset = (screenWidth - MazeUnitSize * mazeSizeX) / 2;
			yOffset = (screenHeight - MazeUnitSize * mazeSizeY) / 2;

			// Get the data from the maze texture
			Color[] textureData = new Color[mazeTexture.Width * mazeTexture.Height];
			mazeTexture.GetData<Color>(textureData);

			// Set up the Vertices
			vertices = new Vertex[mazeSizeX, mazeSizeY];
			for (int y = 0; y < mazeSizeY; y++)
			{
				for (int x = 0; x < mazeSizeX; x++)
				{
					// Set up the data to represent an empty space
					MazeTile currentData = MazeTile.Empty;

					// Get the current color
					Color currentColor = textureData[y * mazeSizeX + x];

					// Check for various colors
					if (currentColor == MazeColorWall) currentData = MazeTile.Wall;
					else if (currentColor == MazeColorStart) currentData = MazeTile.Start;
					else if (currentColor == MazeColorEnd)
						currentData = MazeTile.End;

					// Set up this Vertex and check for start/end
					vertices[x, y] = new Vertex(x, y, currentData);
					if (currentColor == MazeColorStart) startVertex = vertices[x, y];
					else if (currentColor == MazeColorEnd)
						endVertex = vertices[x, y];

				}
			}
		}

		// Draw =================================

		/// <summary>
		/// Draws the maze on the screen
		/// </summary>
		public void Draw(SpriteBatch spriteBatch)
		{
			// Draw the maze itself
			DrawMaze(spriteBatch);

			// Set all of the vertices as not yet visited
			ResetAllVertices();

			// Solve the maze and draw the solution
			DrawSolution(spriteBatch, SolveMaze());
		}

		/// <summary>
		/// Draws the walls, start and end locations of the map
		/// </summary>
		/// <param name="spriteBatch"></param>
		public void DrawMaze(SpriteBatch spriteBatch)
		{
			// The current color to draw
			Color currentColor = Color.White;

			// The rectangle to use for drawing
			Rectangle rect = new Rectangle();
			rect.Width = MazeUnitSize;
			rect.Height = MazeUnitSize;

			// Loop and draw
			for (int x = 0; x < mazeSizeX; x++)
			{
				for (int y = 0; y < mazeSizeY; y++)
				{
					// Set up the rectangle
					rect.X = x * MazeUnitSize + xOffset;
					rect.Y = y * MazeUnitSize + yOffset;

					// Draw
					spriteBatch.Draw(pixel, rect, MazeColors[(int)vertices[x, y].Data]);
				}
			}
		}

		/// <summary>
		/// Draw the solution path
		/// </summary>
		/// <param name="spriteBatch">Used for drawing</param>
		/// <param name="solution">The list that represents the solution</param>
		public void DrawSolution(SpriteBatch spriteBatch, List<Vertex> solution)
		{
			// Set up the rectangle
			Rectangle rect = new Rectangle();
			rect.Width = MazeUnitSize;
			rect.Height = MazeUnitSize;

			// Loop until we're out of Vertices
			foreach (Vertex currentVertex in solution)
			{
				// Check the data
				if (currentVertex.Data == MazeTile.Empty)
				{
					// Set up this rectangle
					rect.X = currentVertex.X * MazeUnitSize + xOffset;
					rect.Y = currentVertex.Y * MazeUnitSize + yOffset;

					// Draw
					spriteBatch.Draw(pixel, rect, MazeColorPath);
				}
			}
		}

		/// <summary>
		/// Sets all Vertices to "not visited"
		/// </summary>
		public void ResetAllVertices()
		{
			for (int x = 0; x < mazeSizeX; x++)
				for (int y = 0; y < mazeSizeY; y++)
				{
					// Reset the Vertex
					vertices[x, y].Visited = false;
				}
		}


		// Student Methods *****************************************************

		/// <summary>
		/// Determines if the vertex at [x,y] is valid and explorable
		/// </summary>
		/// <param name="x">The x value of the vertex to check</param>
		/// <param name="y">The y value of the vertex to check</param>
		/// <returns>True if the vertex is valid, false otherwise</returns>
		public Boolean IsTileValid(int x, int y)
		{

			if ((x > 33 || x < 0) || (y > 33 || y < 0) ||
				vertices[x,y].Data == MazeTile.Wall ||
                vertices[x,y].Visited)
            {
				return false;
            }
			
			return true;
		}

		/// <summary>
		/// Complete the SolveMaze method below:
		/// It must return a list of vertices on the path to the exit.
		/// This is NOT Dijkstra's algorithm - Just a normal graph search.
		/// 
		/// Some useful information/tips:
		/// 
		/// * Feel free to write any helper methods you may need
		/// 
		/// * The vertices are stored in a 2D array: vertices[x, y]
		///    - This is NOT an adjacency matrix.
		///    - In fact, there is no adjacency matrix.
		///    - But determining adjacency on a grid should be quite simple.
		///    
		/// * Assume you can NOT move diagonally
		/// 
		/// * The maze already knows about the start and end vertices, 
		///   which are stored in the following fields:
		///    - startVertex
		///    - endVertex
		///    
		/// * The end condition is finding the "endVertex" during the search.
		///   Once you come across it, end the search and use the vertices
		///    currently in your data structure as the path.
		/// 
		/// </summary>
		public List<Vertex> SolveMaze()
		{
			// 1. Use either Depth-First Search or Breadth-First Search
			//    - One of them is more appropriate for this task.
			//    - Which one are you using?  
			// LEAVE A COMMENT with either DFS or BFS *************************

			// Strategy - Using Depth First Search


			// 2. COMPLETE THE GRAPH SEARCH HERE ******************************
			Stack<Vertex> path = new Stack<Vertex>();
			
			Vertex currentTile = startVertex;

			while (currentTile != endVertex)
            {

				for (int i = 0; i < 33; i++)
                {
					for (int j = 0; j < 33; j++)
                    {

						if (vertices[i,j] == currentTile)
                        {

							if (IsTileValid(i + 1, j))
							{
								vertices[i, j].Visited = true;
								currentTile = new Vertex(currentTile.X + 1, currentTile.Y, currentTile.Data);
								path.Push(currentTile);
							}


							else if (IsTileValid(i - 1, j))
							{
								vertices[i, j].Visited = true;
								currentTile = new Vertex(currentTile.X - 1, currentTile.Y, currentTile.Data);
								path.Push(currentTile);
							}


							else if (IsTileValid(i, j + 1))
							{
								vertices[i, j].Visited = true;
								currentTile = new Vertex(currentTile.X, currentTile.Y + 1, currentTile.Data);
								path.Push(currentTile);
							}


							else if (IsTileValid(i, j - 1))
							{
								vertices[i, j].Visited = true;
								currentTile = new Vertex(currentTile.X, currentTile.Y - 1, currentTile.Data);
								path.Push(currentTile);
							}


							else
							{
								vertices[i, j].Visited = true;
								currentTile = path.Pop();
								currentTile.Visited = true;
							}

							break;
                        }
                    }

					break;
                }	
			}

			// 3. ADD PATH TO SOLUTION LIST ***********************************
			List<Vertex> rightWay = new List<Vertex>();
			//    - Add verts found during the search to the "path" List above
			//    - You can use the path list's AddRange() method to make this easier

			while(path.Count > 0)
            {
                rightWay.Add(path.Pop());
            }

            // All done! This should now be returning the full "path"
            return rightWay;
		}

	}
}
