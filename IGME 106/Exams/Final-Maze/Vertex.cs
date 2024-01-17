using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Maze
{
	class Vertex
	{
		// Fields
		private int x;
		private int y;
		private MazeTile data;
		private bool visited;

		// Properties
		public int X { get { return x; } set { x = value; } }
		public int Y { get { return y; } set { y = value; } }
		public MazeTile Data { get { return data; } set { data = value; } }
		public bool Visited { get { return visited; } set { visited = value; } }

		// Constructor
		public Vertex(int x, int y, MazeTile data)
		{
			this.x = x;
			this.y = y;
			this.data = data;
			this.visited = false;
		}
	}
}
