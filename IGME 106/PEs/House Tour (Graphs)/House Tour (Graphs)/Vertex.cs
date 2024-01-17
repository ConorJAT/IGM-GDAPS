using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House_Tour__Graphs_
{
    class Vertex
    {
        // Fields:
        private string room;
        private string desc;

        // Properties:
        public string Room { get { return room; } }

        public string Descrip { get { return desc; } }

        // Constructor:
        public Vertex(string roomName, string description)
        {
            room = roomName;
            desc = description;
        }

        // Methods:
        public override string ToString()
        {
            return $"{room} - {desc}";
        }
    }
}
