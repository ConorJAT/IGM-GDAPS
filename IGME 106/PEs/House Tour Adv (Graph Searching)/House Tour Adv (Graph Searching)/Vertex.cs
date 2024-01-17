using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House_Tour_Adv__Graph_Searching_
{
    class Vertex
    {
        // Fields:
        private string room;
        private string desc;
        private bool visited;

        // Properties:
        public string Room { get { return room; } }

        public string Descrip { get { return desc; } }

        public bool Visited { get { return visited; } set { visited = value; } }

        // Constructor:
        public Vertex(string roomName, string description)
        {
            room = roomName;
            desc = description;
            visited = false;
        }

        // Methods:
        public override string ToString()
        {
            return $"{room} - {desc}";
        }
    }
}

