using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Interviews.ThoughtWorks.MazeProblem
{
    public struct Cell
    {
        /// <summary>
        /// 中心点
        /// </summary>
        //public Point CentralPoint
        //{
        //    get
        //    {
        //        return new Point(cellPoint.X * 3 - cellPoint.X + 1, cellPoint.Y * 3 - cellPoint.Y + 1);
        //    }
        //}

        public Point CentralPoint { set; get; }
        public Cell(Point centralPoint)
        {
            CentralPoint = centralPoint;
        }

        public static Cell Create(Point cellPos)
        {
            return new Cell(new Point(cellPos.X * 3 - cellPos.X + 1, cellPos.Y * 3 - cellPos.Y + 1));
        }
    }
}
