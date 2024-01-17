using System;

namespace House_Tour_Adv__Graph_Searching_
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph myHouse = new Graph();

            Console.WriteLine("Printing All Rooms in House:");
            myHouse.ListAllVerticies();

            Console.Write("\n");
            Console.WriteLine("Breadth First Serarch w/ Main Hall as first room:");
            myHouse.BreadthFirst("main hall");

            Console.Write("\n");
            Console.WriteLine("Breadth First Serarch w/ Exit as first room:");
            myHouse.BreadthFirst("exit");
        }
    }
}
