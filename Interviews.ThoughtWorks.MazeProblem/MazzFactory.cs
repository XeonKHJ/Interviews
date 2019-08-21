using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;

namespace Interviews.ThoughtWorks.MazeProblem
{
    public static class MazzFactory
    {
        public static Maze Create(string command)
        {
            //先解析命令
            var scale = ParseCommandToMazeScale(command);

            return new Maze(scale);
        }

        /// <summary>
        /// 解析命令
        /// </summary>
        /// <param name="command">命令</param>
        static private MazeScale ParseCommandToMazeScale(string command)
        {
            var strings = command.Split('\n');

            var mazeSizeRegex = @"(\d)+(\s)*(\d)+";

            var mazeSizeMatch = Regex.Matches(strings[0], mazeSizeRegex)[0];

            var mazeSize = new Size(int.Parse(mazeSizeMatch.Captures[0].Value.Split(' ')[0]), int.Parse(mazeSizeMatch.Captures[0].Value.Split(' ')[1]));

            var connnectivityStrings = strings[1].Split(';');

            var connetivityRegex = @"(\d)+,(\d)+";

            Hashtable connectivities = new Hashtable();
            foreach (var connnectivityString in connnectivityStrings)
            {
                var connetivityMatches = Regex.Matches(connnectivityString, connetivityRegex);
                var maze1Cordinate = connetivityMatches[0].Value.Split(',');
                var maze2Cordinate = connetivityMatches[1].Value.Split(',');

                Cell cell1 = Cell.Create(new Point( int.Parse(maze1Cordinate[0]), int.Parse(maze1Cordinate[1])));
                Cell cell2 = Cell.Create(new Point(int.Parse(maze2Cordinate[0]), int.Parse(maze2Cordinate[1])));

                if(!connectivities.ContainsKey(cell1))
                {
                    connectivities[cell1] = new List<Cell>();
                }
                ((List<Cell>)connectivities[cell1]).Add(cell2);
            }

            
            return new MazeScale(mazeSize, connectivities);
        }
    }
}
