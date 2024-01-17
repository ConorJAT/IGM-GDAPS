// Conor Race
// IGME.106.07
// Homework #5 - Quadtrees
// April 1st, 2022

using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

namespace QuadTreeStarter
{
	class QuadTreeNode
	{
		// The maximum number of objects in a quad
		// before a subdivision occurs
		private const int MaxObjectsBeforeSubdivide = 3;

		// The game objects held at this level of the tree
		private List<GameObject> objects;

		// This quad's rectangle area
		private Rectangle rectArea;

		// This quad's divisions
		private QuadTreeNode[] divisions;


		/// <summary>
		/// The divisions of this quad
		/// </summary>
		public QuadTreeNode[] Divisions { get { return divisions; } }

		/// <summary>
		/// This quad's rectangle area
		/// </summary>
		public Rectangle RectangleArea { get { return rectArea; } }

		/// <summary>
		/// The game objects inside this quad
		/// </summary>
		public List<GameObject> GameObjects { get { return objects; } }


		/// <summary>
		/// Creates a new Quad Tree
		/// </summary>
		/// <param name="x">This quad's x position</param>
		/// <param name="y">This quad's y position</param>
		/// <param name="width">This quad's width</param>
		/// <param name="height">This quad's height</param>
		public QuadTreeNode(int x, int y, int width, int height)
		{
			// Save the rectangle
			rectArea = new Rectangle(x, y, width, height);

			// Create the object list
			objects = new List<GameObject>();

			// No divisions yet
			divisions = null;
		}


		/// <summary>
		/// Adds a game object to the quad.  If the quad has too many
		/// objects in it, and hasn't been divided already, it should
		/// be divided
		/// </summary>
		/// <param name="gameObj">The object to add</param>
		public void AddObject(GameObject gameObj)
		{
			// Checks to see the object fits within this quad:
			if (rectArea.Contains(gameObj.Rectangle))
			{
				// If there are still divisions accessible, and the object MIGHT fit,
				// check everyone of those smaller spaces via recursion:
				if (divisions != null)
				{
					// Case - Should the object border between two quads, a boolean
					// is used to keep track of this occurance:
					bool doesFit = false;

					for (int i = 0; i < divisions.Length; i++)
					{
						// Recursive Steps - Goes into deeper layers of quadtrees
						if (divisions[i].RectangleArea.Contains(gameObj.Rectangle))
						{
							divisions[i].AddObject(gameObj);
							doesFit = true;
							break;
						}
					}

					// If the case is never fulfilled in the loop, the object is stored
					// the previous, cumulitive quad:
					if (!doesFit)
                    {
						objects.Add(gameObj);
					}
				}

				else
                {
					// Once a space is found, apply the object there:
					objects.Add(gameObj);
                }
				

				// Checks if the the current space needs to be divided:
				if (divisions == null && objects.Count > MaxObjectsBeforeSubdivide)
				{
					Divide();
				}
			}
		}

		/// <summary>
		/// Divides this quad into 4 smaller quads.  Moves any game objects
		/// that are completely contained within the new smaller quads into
		/// those quads and removes them from this one.
		/// </summary>
		public void Divide()
		{
			divisions = new QuadTreeNode[4];

			// Creates four new QuadTreeNodes, relying on rectangular data from the original:
			divisions[0] = new QuadTreeNode(rectArea.X, rectArea.Y, rectArea.Width / 2, rectArea.Height / 2);
			divisions[1] = new QuadTreeNode(rectArea.X + rectArea.Width / 2, rectArea.Y, rectArea.Width / 2, rectArea.Height / 2);
			divisions[2] = new QuadTreeNode(rectArea.X, rectArea.Y + rectArea.Height / 2, rectArea.Width / 2, rectArea.Height / 2);
			divisions[3] = new QuadTreeNode(rectArea.X + rectArea.Width / 2, rectArea.Y + rectArea.Height / 2, 
											rectArea.Width / 2, rectArea.Height / 2);

			// Moves any objects in current object list to possible lists of divided subsections:
			for (int i = objects.Count - 1; i > -1; i--)
            {
				if (divisions[0].RectangleArea.Contains(objects[i].Rectangle))
                {
					divisions[0].GameObjects.Add(objects[i]);
					objects.RemoveAt(i);
                }

				else if (divisions[1].RectangleArea.Contains(objects[i].Rectangle))
				{
					divisions[1].GameObjects.Add(objects[i]);
					objects.RemoveAt(i);
				}

				else if (divisions[2].RectangleArea.Contains(objects[i].Rectangle))
				{
					divisions[2].GameObjects.Add(objects[i]);
					objects.RemoveAt(i);
				}

				else if (divisions[3].RectangleArea.Contains(objects[i].Rectangle))
				{
					divisions[3].GameObjects.Add(objects[i]);
					objects.RemoveAt(i);
				}
			}
        }

		/// <summary>
		/// Recursively populates a list with all of the rectangles in this
		/// quad and any subdivision quads.  Use the "AddRange" method of
		/// the list class to add the elements from one list to another.
		/// </summary>
		/// <returns>A list of rectangles</returns>
		public List<Rectangle> GetAllRectangles()
		{
			List<Rectangle> rects = new List<Rectangle>();

			// Add this current rectangle area to list:
			rects.Add(rectArea);

			// If there are divisions present, keep going:
			if (divisions != null)
            {
				for (int i = 0; i < divisions.Length; i++)
                {
					// Continuously add rectangular areas to the list
					// until you reach a point of no divions:
					rects.AddRange(divisions[i].GetAllRectangles());
                }
            }

			// Return completed list of rectangles:
			return rects;
		}

		/// <summary>
		/// A possibly recursive method that returns the
		/// smallest quad that contains the specified rectangle
		/// </summary>
		/// <param name="rect">The rectangle to check</param>
		/// <returns>The smallest quad that contains the rectangle</returns>
		public QuadTreeNode GetContainingQuad(Rectangle rect)
		{
			// If this area holds the rectangle...
			if (rectArea.Contains(rect))
            {
				// Check to see if any subdivisions can hold the rectangle (if any):
				if (divisions != null)
                {
					for (int i = 0; i < divisions.Length; i++)
                    {
						QuadTreeNode test = divisions[i].GetContainingQuad(rect);

						// If the rectangle doesn't fit, continue to the next subdivion:
						if (test == null)
                        {
							continue;
                        }

						// Else, if it does, return that same subdivision:
                        else
                        {
							return test;
                        }
                    }

					// If the rectangle doesn't fit into any subdivisions,
					// return this current rectangle:
					return this;
                }

                else
                {
					return this;
                }
            }

			// Return null if this quad doesn't completely contain
			// the rectangle that was passed in
			return null;
		}
	}
}
