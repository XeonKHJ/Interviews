using System;
using System.Collections.Generic;
using System.Drawing;

namespace Interviews.ThoughtWorks.MazeProblem
{
    public class Maze
    {
        public MazeScale MazeScale { private set; get; }

        public Size MazeSize {private set; get; }
        internal Maze(MazeScale mazeScale)
        {
            MazeScale = mazeScale;

            MazeSize = CaculateActualMazeSize();
        }

        List<Cell> Cells
        {
            get
            {
                List<Cell> cells = new List<Cell>();

                for (int y = MazeSize.Height - 1; y >= 0; y -= 2)
                {
                    for(int x = MazeSize.Width - 1; x >= 0; x -= 2)
                    {
                        cells.Add(new Cell(new Point(x, y)));
                    }
                }

                return cells;
            }
        }
        public string Render()
        {
            //1、计算出迷宫的大小
            var size = CaculateActualMazeSize();

            //2、遍历Cell
            foreach(var cell in Cells)
            {
                //输出第一道墙
                for(int i = 0; i < MazeSize.Width; ++i) { Console.Write('*'); Console.WriteLine(); }
            }

        }

        /// <summary>
        /// 计算迷宫大小
        /// </summary>
        /// <returns></returns>
        private Size CaculateActualMazeSize()
        {
            return new Size(MazeScale.MazeSize.Width * 3 - MazeScale.MazeSize.Width - 1,
                             MazeScale.MazeSize.Height * 3 - MazeScale.MazeSize.Width - 1);
        }

        struct CheckCell
        {
            public Cell Cell;
            public bool IsChecked;
        }
    }
}
