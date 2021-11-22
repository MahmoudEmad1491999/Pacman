using System;
using System.IO;
using System.Collections.Generic;
namespace Pacman
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, KeyValuePair<int, int>> Mazes = new Dictionary<string, KeyValuePair<int, int>>();
            Mazes.Add("Mazes/big.txt", new KeyValuePair<int, int>(31, 81));
            Mazes.Add("Mazes/med.txt", new KeyValuePair<int, int>(23, 61));
            Mazes.Add("Mazes/meduim.txt", new KeyValuePair<int, int>(13, 49));
            Mazes.Add("Mazes/open.txt", new KeyValuePair<int, int>(20, 37));
            Mazes.Add("Mazes/small.txt", new KeyValuePair<int, int>(13, 30));
            Mazes.Add("Mazes/tiny.txt", new KeyValuePair<int, int>(9, 10));
            foreach (var Maze in Mazes)
            {
                Problem problem = new Problem(Maze.Key, Maze.Value.Key, Maze.Value.Value);
                Maze maze = new Maze(problem);
                MazeGraph mazeGraph = new MazeGraph(maze);
                int size = 0;
                List<List<Tile>> gbf = Search.gbf(mazeGraph);
                // List<List<Tile>> dfs = Search.dfs(mazeGraph);
                // List<List<Tile>> bfs = Search.bfs(mazeGraph);

                foreach (var sequence in gbf)
                {
                    size += sequence.Count;
                }
                Console.WriteLine("Gread Best First " + Maze.Key + ": " + size);
                size = 0;
                // foreach (var sequence in dfs)
                // {
                //     size += sequence.Count;
                // }
                // Console.WriteLine("Depth First " + Maze.Key + ": " + size);
                // size = 0;
                // foreach (var sequence in bfs)
                // {
                //     size += sequence.Count;
                // }
                // Console.WriteLine("Breadth First " + Maze.Key + ": " + size);


            }


        }
    }
}
