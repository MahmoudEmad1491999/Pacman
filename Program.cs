using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
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
                List<List<Tile>> gbf = Search.gbf(mazeGraph);
                List<List<Tile>> dfs = Search.dfs(mazeGraph);
                List<List<Tile>> bfs = Search.bfs(mazeGraph);
                List<Tile> path = new List<Tile>();
                int size = 0;
                int pathLength = 0;
                for (int index = 0; index < gbf.Count; index++)
                {
                    path.Clear();
                    path = getPath(gbf[index], maze);
                    size += gbf[index].Count;
                    pathLength += path.Count;
                }
                Console.WriteLine(Maze.Key + "Gready Best First Visited List Length: " + size);
                Console.WriteLine(Maze.Key + "Gready Best First Path Length: " + pathLength);
                size = 0;
                pathLength = 0;
                for (int index = 0; index < bfs.Count; index++)
                {
                    path.Clear();
                    path = getPath(bfs[index], maze);
                    size += bfs[index].Count;
                    pathLength += path.Count;
                }
                Console.WriteLine(Maze.Key + " Breadth First Visited List Length: " + size);
                Console.WriteLine(Maze.Key + " Breadth First Path Length: " + pathLength);
                size = 0;
                pathLength = 0;
                for (int index = 0; index < dfs.Count; index++)
                {
                    path.Clear();
                    path = getPath(dfs[index], maze);
                    size += dfs[index].Count;
                    pathLength += path.Count;
                }

                Console.WriteLine(Maze.Key + " Depth First Visited List Length: " + size);
                Console.WriteLine(Maze.Key + " Depth First Path Length: " + pathLength);

            }
        }
        public static List<Tile> getPath(List<Tile> visitedList, Maze maze)
        {
            List<Tile> path = new List<Tile>(visitedList);
            path.Reverse();
            for (int index = 0; index < path.Count - 1; index++)
            {
                while (!maze.isReachable(path[index], path[index + 1]))
                {
                    path.RemoveAt(index + 1);
                }
            }
            return path;
        }
        public static string getMazeString(Maze maze, List<Tile> path)
        {
            // Console.WriteLine(maze.MazeString);
            StringBuilder result = new StringBuilder(maze.MazeString);
            foreach (var tile in path)
            {
                result[tile.col + (tile.row) * maze.MazeCols + tile.row] = 'x';
            }
            return result.ToString();
        }
    }
}
