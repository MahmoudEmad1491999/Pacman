using System;
using System.IO;
using System.Collections.Generic;
namespace Pacman
{
    public class Maze
    {
        public int MazeCols { get; private set; }
        public int MazeRows { get; private set; }
        public string MazeString { get; private set; }
        public List<List<Tile>> MazeBoard { get; private set; }

        public Maze(Problem problem)
        {
            this.MazeRows = problem.MazeRows;
            this.MazeCols = problem.MazeCols;
            this.MazeString = problem.MazeString;
            initMazeStructure();
        }

        public void initMazeStructure()
        {
            this.MazeBoard = new List<List<Tile>>();
            for (int count = 1; count <= this.MazeRows; count++)
            {
                MazeBoard.Add(new List<Tile>());
            }
            for (int index = 0; index < MazeString.Length; index++)
            {
                int row = index / (MazeCols + 1);
                int col = index % (MazeCols + 1);
                if (MazeString[index] == '%')
                {
                    MazeBoard[row].Insert(
                        col,
                        new Tile(row, col, TileType.WALL)
                        );

                }
                else if (MazeString[index] == 'p')
                {
                    MazeBoard[row].Insert(
                        col,
                        new Tile(row, col, TileType.START_POINT)
                        );
                }
                else if (MazeString[index] == '.')
                {
                    MazeBoard[row].Insert(
                        col,
                        new Tile(row, col, TileType.FOOD)
                        );

                }
                else if (MazeString[index] == ' ')
                {
                    MazeBoard[row].Insert(
                        col,
                        new Tile(row, col, TileType.OPEN_PATH)
                        );
                }
                else if (MazeString[index] == '\n') { }
                else
                {
                    throw new Exception("Undefined Character at:" + index);
                }
            }
        }

        public override string ToString()
        {
            return $"MazeHeight: {this.MazeCols}, MazeWidth: {this.MazeRows}, MazeString: \n{this.MazeString}";
        }
        public List<Tile> getAllTargets()
        {
            List<Tile> result = new List<Tile>();
            foreach (List<Tile> row in MazeBoard)
            {
                foreach (Tile tile in row)
                {
                    if (tile.type == TileType.FOOD)
                    {
                        result.Add(tile);
                    }
                }
            }
            return result;
        }
        public List<Tile> getAllNeighbours(Tile node)
        {
            List<Tile> neighbours = new List<Tile>();

            int row = node.row;
            int col = node.col;


            neighbours.Add(MazeBoard[row][(col == MazeCols - 1) ? (col) : (col + 1)]);
            neighbours.Add(MazeBoard[row][(col == 0) ? (col) : (col - 1)]);
            neighbours.Add(MazeBoard[(row == MazeRows - 1) ? (row) : (row + 1)][col]);
            neighbours.Add(MazeBoard[(row == 0) ? (row) : (row - 1)][col]);
            neighbours.Remove(MazeBoard[row][col]);
            return neighbours;
        }
        public List<Tile> getAllReachable(Tile node)
        {
            List<Tile> neighbours = getAllNeighbours(node);
            List<Tile> result = new List<Tile>();
            foreach (Tile neighbour in neighbours)
            {
                if (isReachable(node, neighbour))
                {
                    result.Add(neighbour);
                }
            }

            return result;
        }

        public bool isReachable(Tile from, Tile to)
        {
            List<Tile> neighbours = getAllNeighbours(from);
            if (
                neighbours.Contains(to) &&
                (
                (to.type == TileType.FOOD) ||
                (to.type == TileType.OPEN_PATH) ||
                (to.type == TileType.START_POINT)
                )
            )
            {
                return true;
            }
            return false;
        }

    }
}