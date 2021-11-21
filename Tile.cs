using System;
using System.IO;
using System.Collections.Generic;
namespace Pacman
{
    public class Tile
    {
        public int row { get; private set; }
        public int col { get; set; }
        public TileType type { get; set; }
        public Tile(int row, int col, TileType type)
        {
            this.row = row;
            this.col = col;
            this.type = type;
        }
        public override string ToString()
        {
            return $"({row}, {col})";
        }


        public override bool Equals(object obj)
        {
            Tile pseduNode = (Tile)obj;
            return pseduNode.row == row && pseduNode.col == col && pseduNode.type == type;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(row, col, type);
        }
    }
}