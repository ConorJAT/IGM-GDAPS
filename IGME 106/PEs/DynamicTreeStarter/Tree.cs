using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DynamicTreeStarter
{
	/// <summary>
	/// Represents a tree-centric data structure
	/// that can have data dynamically inserted, 
	/// and can be drawn as a literal "tree" on the screen
	/// </summary>
	class Tree : DrawableTree
	{
		// Already has an inherited root node field called "root"

		/// <summary>
		/// Creates a tree that can be drawn
		/// </summary>
		/// <param name="sb">The sprite batch used to draw</param>
		/// <param name="treeColor">The color of this tree</param>
		public Tree(SpriteBatch sb, Color treeColor)
			: base(sb, treeColor)
		{ }

		/// <summary>
		/// Public facing Add method
		/// </summary>
		/// <param name="data">The data to add</param>
		public void Add(int data)
		{
			if (root == null)
            {
				root = new TreeNode(data);
            }

            else
            {
				Add(data, root);
            }


		}

		/// <summary>
		/// Private recursive Add method
		/// </summary>
		/// <param name="data">The data to add</param>
		/// <param name="node">The node to attempt to add into</param>
		private void Add(int data, TreeNode node)
		{
			if (data < node.Data)
            {
				if (node.Left != null)
                {
					Add(data, node.Left);
					return;
                }
                else
                {
					node.Left = new TreeNode(data);
                }
            }

			else if (data >= node.Data)
            {
				if (node.Right != null)
				{
					Add(data, node.Right);
					return;
				}
				else
				{
					node.Right = new TreeNode(data);
				}
			}

		}
	}
}
