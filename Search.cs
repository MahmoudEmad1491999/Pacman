using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Priority_Queue;
namespace Pacman
{
    public class Search
    {
        public static List<Tile> DepthFirstSearch(MazeGraph mazeGraph, Tile start, Tile target)
        {
            List<Tile> visited = new List<Tile>();
            Stack<Tile> unvisited = new Stack<Tile>();
            List<Tile> path = new List<Tile>();
            unvisited.Push(start);
            while ((unvisited.Count != 0) && (!visited.Contains(target)))
            {
                Tile HeadofUnvisited = unvisited.Pop();
                visited.Add(HeadofUnvisited);
                path.Add(HeadofUnvisited);
                List<Tile> Neighbours = mazeGraph.maze.getAllReachable(HeadofUnvisited);

                foreach (Tile neighbour in Neighbours)
                {
                    if (!unvisited.Contains(neighbour) && !visited.Contains(neighbour))
                    {
                        unvisited.Push(neighbour);
                    }
                }

            }
            return visited;
        }

        public static List<Tile> BreadthFirstSearch(MazeGraph mazeGraph, Tile start, Tile Target)
        {


            Queue<Tile> unvisited = new Queue<Tile>();
            List<Tile> visited = new List<Tile>();


            unvisited.Enqueue(start);

            while ((unvisited.Count != 0) && (!visited.Contains(Target)))
            {
                Tile HeadofUnvisited = unvisited.Dequeue();
                visited.Add(HeadofUnvisited);
                List<Tile> Neighbours = mazeGraph.maze.getAllReachable(HeadofUnvisited);

                foreach (Tile neighbour in Neighbours)
                {
                    if (!unvisited.Contains(neighbour) && !visited.Contains(neighbour))
                    {
                        unvisited.Enqueue(neighbour);
                    }
                }

            }


            return visited;
        }

        public static List<Tile> GreedyBestFirstSearch(MazeGraph mazeGraph, Tile start, Tile target)
        {

            List<Tile> visited = new List<Tile>();
            SimplePriorityQueue<Tile, int> unvisited = new Priority_Queue.SimplePriorityQueue<Tile, int>();

            unvisited.Enqueue(start, getManhatenDistance(start, target));

            while ((unvisited.Count != 0) && (!visited.Contains(target)))
            {
                Tile HeadofUnvisited = unvisited.Dequeue();
                visited.Add(HeadofUnvisited);
                if (HeadofUnvisited.Equals(target))
                {
                    break;
                }
                else
                {
                    List<Tile> Neighbours = mazeGraph.maze.getAllReachable(HeadofUnvisited);

                    foreach (Tile neighbour in Neighbours)
                    {
                        if (!unvisited.Contains(neighbour) && !visited.Contains(neighbour))
                        {

                            unvisited.Enqueue(neighbour, getManhatenDistance(neighbour, target));

                        }
                    }
                }

            }

            return visited;
        }
        public static int getManhatenDistance(Tile from, Tile to)
        {
            int dx = Math.Abs(from.col - to.col);
            int dy = Math.Abs(from.row - to.row);


            return dx + dy;
        }

        public static List<List<Tile>> bfs(MazeGraph mazeGraph)
        {
            List<Tile> targets = mazeGraph.getAllTargets();
            Tile StartVertex = mazeGraph.GetStartTile();

            List<List<Tile>> result = new List<List<Tile>>();
            for (int index = 0; index < targets.Count; index++)
            {
                if (index == 0)
                {
                    result.Add(BreadthFirstSearch(mazeGraph, StartVertex, targets[index]));
                }
                else
                {
                    result.Add(BreadthFirstSearch(mazeGraph, targets[index - 1], targets[index]));
                }
            }
            return result;
        }
        public static List<List<Tile>> dfs(MazeGraph mazeGraph)
        {
            List<Tile> targets = mazeGraph.getAllTargets();
            Tile StartVertex = mazeGraph.GetStartTile();
            List<List<Tile>> result = new List<List<Tile>>();

            for (int index = 0; index < targets.Count; index++)
            {
                if (index == 0)
                {
                    result.Add(DepthFirstSearch(mazeGraph, StartVertex, targets[index]));
                }
                else
                {
                    result.Add(DepthFirstSearch(mazeGraph, targets[index - 1], targets[index]));
                }
            }
            return result;
        }

        public static List<List<Tile>> gbf(MazeGraph mazeGraph)
        {
            List<Tile> targets = mazeGraph.getAllTargets();
            Tile StartVertex = mazeGraph.GetStartTile();
            List<List<Tile>> result = new List<List<Tile>>();

            for (int index = 0; index < targets.Count; index++)
            {
                if (index == 0)
                {
                    result.Add(GreedyBestFirstSearch(mazeGraph, StartVertex, targets[index]));
                }
                else
                {
                    result.Add(GreedyBestFirstSearch(mazeGraph, targets[index - 1], targets[index]));
                }
            }
            return result;
        }

    }
}
