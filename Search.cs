using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Pacman
{
    public class Search
    {
        public static List<Tile> BreadthFirstSearch(MazeGraph mazeGraph, Tile Target)
        {
            List<Tile> Verticies = mazeGraph.GetOpenTiles();
            List<Edge> Edges = mazeGraph.GetEdges();

            Tile StartVertex = mazeGraph.GetStartTile();

            Queue<Tile> unvisited = new Queue<Tile>();
            List<Tile> visited = new List<Tile>();


            unvisited.Enqueue(StartVertex);

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
        public static List<Tile> DepthFirstSearch(MazeGraph mazeGraph, Tile Target)
        {
            List<Tile> Verticies = mazeGraph.GetOpenTiles();
            List<Edge> Edges = mazeGraph.GetEdges();

            Tile StartVertex = mazeGraph.GetStartTile();

            Stack<Tile> unvisited = new Stack<Tile>();
            List<Tile> visited = new List<Tile>();

            unvisited.Push(StartVertex);
            while ((unvisited.Count != 0) && (!visited.Contains(Target)))
            {
                Tile HeadofUnvisited = unvisited.Pop();
                visited.Add(HeadofUnvisited);
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

        public static List<Tile> GreedyBestFirstSearch(MazeGraph mazeGraph, Tile Target)
        {
            List<Tile> Verticies = mazeGraph.GetOpenTiles();
            List<Edge> Edges = mazeGraph.GetEdges();

            Tile StartVertex = mazeGraph.GetStartTile();

            List<Tile> visited = new List<Tile>();
            PriorityQueue<Tile, int> unvisited = new PriorityQueue<Tile, int>();

            unvisited.Enqueue(StartVertex, getManhatenDistance(StartVertex, Target));

            while ((unvisited.Count != 0) && (!visited.Contains(Target)))
            {
                Tile HeadofUnvisited = unvisited.Dequeue();
                visited.Add(HeadofUnvisited);
                if (HeadofUnvisited.Equals(Target))
                {
                    break;
                }
                else
                {
                    List<Tile> Neighbours = mazeGraph.maze.getAllReachable(HeadofUnvisited);

                    foreach (Tile neighbour in Neighbours)
                    {
                        if (!visited.Contains(neighbour))
                        {
                            unvisited.Enqueue(neighbour, getManhatenDistance(neighbour, Target));
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
    }
}