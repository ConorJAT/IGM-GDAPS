using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House_Tour_Mstr__Dijkstra_Algrm_
{
    class Vertex
    {
        // Fields:
        private string room;
        private string desc;
        private bool visited;

        private int distance;
        private bool perm;
        private Vertex neighbor;

        // Properties:
        public string Room { get { return room; } }

        public string Descrip { get { return desc; } }

        public bool Visited { get { return visited; } set { visited = value; } }

        public int Distance { get { return distance; } set { distance = value; } }

        public bool Permenant { get { return perm; } set { perm = value; } }

        public Vertex Neighbor { get { return neighbor; } set { neighbor = value; } }

        // Constructor:
        public Vertex(string roomName, string description)
        {
            room = roomName;
            desc = description;
            visited = false;

            distance = int.MaxValue;
            perm = false;
            neighbor = null;
        }

        // Methods:
        public override string ToString()
        {
            return $"{room} - {desc}";
        }
    }
}
