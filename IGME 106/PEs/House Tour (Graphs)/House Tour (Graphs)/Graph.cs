using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House_Tour__Graphs_
{
    class Graph
    {
        // Fields:
        private List<Vertex> rooms;
        private Dictionary<string, List<Vertex>> connections;

        // Properties:
        public List<Vertex> Rooms { get { return rooms; } }

        // Constructor:
        public Graph()
        {
            rooms = new List<Vertex>();
            connections = new Dictionary<string, List<Vertex>>();

            AddAllRooms();
            AddAllAdjacent();
        }

        // Methods:

        /// <summary>
        /// Gets a list of all adjacent rooms at a particular room. Returns null if the
        /// room does not exist in the dictionary.
        /// </summary>
        /// <param name="room"> Current room that the user (should be) is in. </param>
        /// <returns> List of all adjacent rooms. Null, if room doesn't exist. </returns>
        public List<Vertex> GetAdjacentList(string room)
        {
            if (connections.ContainsKey(room))
            {
                return connections[room];
            }

            return null;
        }


        /// <summary>
        /// Checks whether or not two or rooms are connected.
        /// </summary>
        /// <param name="room1"> Room that the user is currently in. </param>
        /// <param name="room2"> Room being tested for adjacency. </param>
        /// <returns> True if rooms connect. False, if not. </returns>
        public bool IsConnected(string room1, string room2)
        {
            if (connections.ContainsKey(room1))
            {
                for (int i = 0; i < connections[room1].Count; i++)
                {
                    if (connections[room1][i].Room.ToLower() == room2)
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        /// <summary>
        /// Lists all rooms in the house.
        /// </summary>
        public void ListAllVerticies()
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                Console.WriteLine(rooms[i]);
            }
        }


        /// <summary>
        /// Adds a set number of rooms in the house. All info is pre-set.
        /// </summary>
        private void AddAllRooms()
        {
            rooms.Add(new Vertex("Main Hall", "The main hall is central to the house."));
            rooms.Add(new Vertex("Library", "This library is packed with floor-to-ceiling bookshelves."));
            rooms.Add(new Vertex("Conservatory", "The glass wall allows sunlight to reach the plants here."));
            rooms.Add(new Vertex("Billiards Room", "We got a pool table!"));
            rooms.Add(new Vertex("Bathroom", "Adorned with the finest tilework."));
            rooms.Add(new Vertex("Study", "Two large chairs, a fireplace, and a bearskin rug."));
            rooms.Add(new Vertex("Kitchen", "Large enough to prepare a feast."));
            rooms.Add(new Vertex("Dining Room", "A huge table for sixteen has gold place settings."));
            rooms.Add(new Vertex("Ballroom", "A room full of balls."));
            rooms.Add(new Vertex("Gallery", "Exquisite artwork decorates the walls."));
            rooms.Add(new Vertex("Deck", "This covered deck looks over the landscaped grounds."));
            rooms.Add(new Vertex("Exit", "Cobblestone pathway leads you to the gardens."));
        }


        /// <summary>
        /// Adds all rooms and their adjacencies in the dictionary. All info is pre-set.
        /// </summary>
        private void AddAllAdjacent()
        {
            connections.Add("main hall", new List<Vertex>());
            connections["main hall"].Add(rooms[1]);
            connections["main hall"].Add(rooms[5]);
            connections["main hall"].Add(rooms[7]);
            connections["main hall"].Add(rooms[8]);
            connections["main hall"].Add(rooms[9]);
            connections["main hall"].Add(rooms[10]);

            connections.Add("library", new List<Vertex>());
            connections["library"].Add(rooms[0]);
            connections["library"].Add(rooms[2]);

            connections.Add("conservatory", new List<Vertex>());
            connections["conservatory"].Add(rooms[1]);
            connections["conservatory"].Add(rooms[10]);

            connections.Add("billiards room", new List<Vertex>());
            connections["billiards room"].Add(rooms[4]);
            connections["billiards room"].Add(rooms[9]);

            connections.Add("bathroom", new List<Vertex>());
            connections["bathroom"].Add(rooms[3]);
            connections["bathroom"].Add(rooms[5]);

            connections.Add("study", new List<Vertex>());
            connections["study"].Add(rooms[0]);
            connections["study"].Add(rooms[4]);
            connections["study"].Add(rooms[8]);

            connections.Add("kitchen", new List<Vertex>());
            connections["kitchen"].Add(rooms[7]);

            connections.Add("dining room", new List<Vertex>());
            connections["dining room"].Add(rooms[0]);
            connections["dining room"].Add(rooms[6]);

            connections.Add("ballroom", new List<Vertex>());
            connections["ballroom"].Add(rooms[0]);
            connections["ballroom"].Add(rooms[5]);
            connections["ballroom"].Add(rooms[9]);

            connections.Add("gallery", new List<Vertex>());
            connections["gallery"].Add(rooms[0]);
            connections["gallery"].Add(rooms[3]);
            connections["gallery"].Add(rooms[8]);

            connections.Add("deck", new List<Vertex>());
            connections["deck"].Add(rooms[0]);
            connections["deck"].Add(rooms[2]);
            connections["deck"].Add(rooms[11]);

            connections.Add("exit", new List<Vertex>());
            connections["exit"].Add(rooms[10]);
        }
    }
}
