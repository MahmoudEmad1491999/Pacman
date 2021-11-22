using System;
using System.Collections.Generic;

namespace Pacman
{
    public class SearchResult
    {
        public List<Tile> visitedList;
        public IEnumerable<Tile> unvisitedList;
        public SearchResult(List<Tile> visitedList, IEnumerable<Tile> unvisitedList)
        {
            this.visitedList = visitedList;
            this.unvisitedList = unvisitedList;
        }
    }
}