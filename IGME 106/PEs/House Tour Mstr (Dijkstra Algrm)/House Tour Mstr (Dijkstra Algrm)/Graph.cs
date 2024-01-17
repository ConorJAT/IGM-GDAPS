using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House_Tour_Mstr__Dijkstra_Algrm_
{
    class Graph
    {
        // Fields:
        private List<Vertex> rooms;
        private Dictionary<string, List<Vertex>> connections;
        private int[,] adjMatrix;

        // Properties:
        public List<Vertex> Rooms { get { return rooms; } }

        // Constructor:
        public Graph()
        {
            rooms = new List<Vertex>();
            connections = new Dictionary<string, List<Vertex>>();

            AddAllRooms();
            AddAllAdjacent();
            CreateMatrix();
        }

        // Core Methods:

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
        /// Sets all vertex rooms as "unvisited" for the next search.
        /// </summary>
        public void Reset()
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                rooms[i].Visited = false;

                rooms[i].Distance = int.MaxValue;
                rooms[i].Permenant = false;
            }
        }


        /// <summary>
        /// Returns the first adjacent and unvisited room according to the room parameter.
        /// </summary>
        /// <param name="roomName"> Room to be checked for any adjacent and unvisited neighbors. </param>
        /// <returns> A vertex room if the room is unvisted and adjacent. Null, if there are no rooms
        ///           that fit the description. </returns>
        public Vertex GetAdjacentUnvisited(string roomName)
        {
            for (int i = 0; i < 12; i++)
            {
                // Finds the corresponding room Vertex via name parameter:
                if (rooms[i].Room == roomName)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        // Checks for adjacency (= 1) and if room is unvisited:
                        if (adjMatrix[i, j] == 1 && !rooms[j].Visited)
                        {
                            return rooms[j];
                        }
                    }

                    // Returns null if room is not found:
                    return null;
                }
            }

            return null;
        }


        /// <summary>
        /// Searchs throught graph and prints all rooms, starting with a base vertex, then
        /// printing all of its unvisted neighbors, then each of their unvisted neighbors, until
        /// all verticies are printed.
        /// </summary>
        /// <param name="roomName"> Room vertex being used as a base room. </param>
        public void BreadthFirst(string roomName)
        {
            // Checks if room is in the house:
            if (!connections.ContainsKey(roomName))
            {
                Console.WriteLine("Error! Room does not exist in this layout!");
                return;
            }

            // Resets all rooms to unvisited:
            Reset();

            // Creates new Queue to hold adjacent rooms:
            Queue<Vertex> roomQueue = new Queue<Vertex>();

            // Searches for the base room in the rooms list:
            for (int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].Room.ToLower() == roomName)
                {
                    Console.WriteLine("  - " + rooms[i].Room);
                    roomQueue.Enqueue(rooms[i]);
                    rooms[i].Visited = true;
                    break;
                }
            }

            // Once the base is queued, being looking for all unvisted adjacencies and
            // print them out. Sets each visted room to "visited" after it is printed:
            while (roomQueue.Count > 0)
            {
                if (GetAdjacentUnvisited(roomQueue.Peek().Room) != null)
                {
                    Vertex roomToAdd = GetAdjacentUnvisited(roomQueue.Peek().Room);
                    Console.WriteLine("  - " + roomToAdd.Room);
                    roomQueue.Enqueue(roomToAdd);

                    for (int i = 0; i < 12; i++)
                    {
                        if (rooms[i] == roomToAdd)
                        {
                            rooms[i].Visited = true;
                        }
                    }
                }

                // If there are no more unvisited adjacencies, dequeue the room:
                else
                {
                    roomQueue.Dequeue();
                }
            }
        }


        /// <summary>
        /// Sorts the house map via the shortest pathways originating from a base room.
        /// </summary>
        /// <param name="roomName"> Room from which the sort is centered from. </param>
        public void ShortestPath(string roomName)
        {
            // Resets all verticies:
            Reset();

            for (int i = 0; i < rooms.Count; i++)
            {
                // Searches list for the base room:
                if (rooms[i].Room.ToLower() == roomName)
                {
                    rooms[i].Distance = 0;
                    rooms[i].Permenant = true;

                    // Checks if there are still non-permanents in the list:
                    while (ArePermanents())
                    {
                        for (int j = 0; j < 12; j++)
                        {
                            // Checks all adjacent, non-perm verticies to the current room:
                            if (!rooms[j].Permenant && adjMatrix[i,j] > 0)
                            {
                                // If the new distance is less than the current one, replace the distance and set a new neighbor:
                                if (rooms[i].Distance + 1 < rooms[j].Distance)
                                {
                                    rooms[j].Distance = rooms[i].Distance + 1;
                                    rooms[j].Neighbor = rooms[i];
                                }
                            }
                        }

                        // Find the index of the room with the smallest index and set as new current:
                        i = FindSmallestDistance();

                        if (i > -1)
                        {
                            rooms[i].Permenant = true;
                        }  
                    }
                }
            }
        }


        /// <summary>
        /// Once the house map has been sorted to shortest pathways, allows for the search of the quickest route.
        /// </summary>
        /// <param name="targetRoom"> Target room the user wishes to go to. </param>
        public void GetPath(string targetRoom)
        {
            // Checks if target room exists:
            if (!connections.ContainsKey(targetRoom))
            {
                Console.WriteLine("Error! Room does not exist!");
                return;
            }

            for (int i = 0; i < rooms.Count; i++)
            {
                // Finds the target room in the list:
                if (rooms[i].Room.ToLower() == targetRoom)
                {
                    Vertex current = rooms[i];
                    
                    // If the room has a nieghbor, recursively call the method again:
                    if (current.Neighbor != null)
                    {
                        GetPath(current.Neighbor.Room.ToLower());
                    }

                    // If there is no neighbor, we have reached the base room and can now print all rooms:
                    Console.WriteLine(" - " + current.Room);
                    return;
                    
                }
            }
        }


        // Helper Methods:

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

        /// <summary>
        /// Generates an adjacency matrix based off of how all rooms are
        /// connected with another.
        /// </summary>
        private void CreateMatrix()
        {
            adjMatrix = new int[12, 12]
            {
                {0, 1, 0, 0, 0, 1, 0, 1, 1, 1, 1, 0},
                {1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                {0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0},
                {0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0},
                {1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0},
                {1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0},
                {1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0},
                {1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0},
                {1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
            };
        }

        /// <summary>
        /// Checks whether or not if there are still non-permanent verticies in the list.
        /// </summary>
        /// <returns> True, if there are. False, if not. </returns>
        private bool ArePermanents()
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (!rooms[i].Permenant)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Finds the vertex with the smallest distance of entire graph.
        /// </summary>
        /// <returns> An index int value of the room in the rooms list. </returns>
        private int FindSmallestDistance()
        {
            int index = -1;
            int currentLow = int.MaxValue;

            for (int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].Distance < currentLow && !rooms[i].Permenant)
                {
                    currentLow = rooms[i].Distance;
                    index = i;
                }
            }

            return index;
        }
    }
}
