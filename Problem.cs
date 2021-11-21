using System;
using System.IO;

namespace Pacman
{
    public class Problem
    {
        public int MazeRows{get; set;}
        public int MazeCols{get; set;}

        public string MazeString {get; set;}
        
        public Problem(string mazeFilePath, int MazeRows, int MazeCols)
        {
            this.MazeCols = MazeCols;
            this.MazeRows = MazeRows;

            MazeString = File.ReadAllText(mazeFilePath);
        }

        public override string ToString()
        {
            
            return this.MazeString;
        }
    }

}