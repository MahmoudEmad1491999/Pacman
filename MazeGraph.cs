using System;
using System.IO;
using System.Collections.Generic;

namespace Pacman
{
    public class MazeGraph
    {
        public Maze maze { get; set; }
        private List<Tile> OpenTiles = new List<Tile>();
        private List<Edge> Edges = new List<Edge>();
        private Tile StartTile;
        public MazeGraph(Maze maze)
        {
            this.maze = maze;
        }

        public List<Tile> GetOpenTiles()
        {
            if (OpenTiles.Count == 0)
            {
                initOpenTiles();
            }
            return OpenTiles;
        }

        public void initOpenTiles()
        {
            OpenTiles.Clear();
            foreach (List<Tile> row in maze.MazeBoard)
            {
                foreach (Tile tile in row)
                {
                    if (tile.type != TileType.WALL) OpenTiles.Add(tile);
                }
            }
            StartTile = OpenTiles.Find((Tile possible) => possible.type == TileType.START_POINT);
        }

        public Tile GetStartTile()
        {
            GetOpenTiles();
            if (StartTile == null)
            {
                StartTile = OpenTiles.Find((Tile possible) => possible.type == TileType.START_POINT);
            }
            return StartTile;
        }
        public List<Edge> GetEdges()
        {
            if (Edges.Count == 0)
            {
                initEdges();
            }
            return Edges;
        }

        private void initEdges()
        {
            Edges.Clear();
            foreach (Tile tile in OpenTiles)
            {
                List<Tile> reachableTilesFromThisTile = maze.getAllReachable(tile);
                foreach (Tile reachableTileFromThisTile in reachableTilesFromThisTile)
                {
                    Edges.Add(new Edge(tile, reachableTileFromThisTile));
                }
            }
            UniqufiyEdges();

        }
        private void UniqufiyEdges()
        {
            for (int index = 0; index < Edges.Count; index++)
            {
                for (int subIndex = index + 1; subIndex < Edges.Count; subIndex++)
                {
                    if (Edges[index].Equals(Edges[subIndex]))
                    {
                        Edges.Remove(Edges[subIndex]);
                    }
                }
            }
        }
    }


}
