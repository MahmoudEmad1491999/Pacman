using System;
using System.IO;
using System.Collections.Generic;
namespace Pacman
{
    class Program
    {
        static void Main(string[] args)
        {
            Problem problem = new Problem(args[0], 23, 61);
            Maze maze = new Maze(problem);
            // Console.WriteLine(maze.MazeString);
            MazeGraph mazeGraph = new MazeGraph(maze);
            // foreach (Tile node in mazeGraph.GetOpenTiles())
            // {
            //     System.Console.WriteLine(node);
            // }
            // foreach (Edge edge in mazeGraph.GetEdges())
            // {
            //     System.Console.WriteLine(edge);
            // }

            // Console.WriteLine(maze.getAllTargets()[0]);
            // Console.WriteLine(maze.getAllTargets()[1]);
            List<Tile> test1 = Search.BreadthFirstSearch(mazeGraph, maze.getAllTargets()[0]);
            List<Tile> test2 = Search.DepthFirstSearch(mazeGraph, maze.getAllTargets()[0]);
            List<Tile> test3 = Search.GreedyBestFirstSearch(mazeGraph, maze.getAllTargets()[0]);
            Console.WriteLine(test1.Count);
            Console.WriteLine(test2.Count);
            Console.WriteLine(test3.Count);
            foreach (Tile t in test3)
            {
                Console.Write(t + "--->");
            };

            foreach (Tile t in test1)
            {
                Console.Write(t + "--->");
            };
            foreach (Tile t in test2)
            {
                Console.Write(t + "--->");
            };

            Console.WriteLine();
        }
    }
}
