using System;
using System.IO;
using System.Collections.Generic;

namespace Pacman
{
    public class Edge
    {
        public Tile tile1;
        public Tile tile2;

        public Edge(Tile tile1, Tile tile2)
        {
            this.tile1 = tile1;
            this.tile2 = tile2;
        }

        public override bool Equals(object obj)
        {
            Edge possible = (Edge)obj;
            if (
                (possible.tile1.Equals(tile1) && possible.tile2.Equals(tile2)) ||
                (possible.tile1.Equals(tile2) && possible.tile2.Equals(tile1))
                )
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "{" + tile1 + "<--->" + tile2 + "}";
        }

        public bool isVertex(Tile tile)
        {
            if (tile1.Equals(tile) || tile2.Equals(tile2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}