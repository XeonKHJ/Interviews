using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Interviews.ThoughtWorks.MazeProblem
{
    public enum Direction { Up, Down, Left, Right};
    public class Cell
    {
        /// <summary>
        /// 该单元格的中心点
        /// </summary>
        public Point CentralPoint { set; get; }
        public Cell(Point centralPoint)
        {
            CentralPoint = centralPoint;
            ConnectedCells = new Dictionary<Direction, Point>();
        }

        public static Cell Create(Point cellPos)
        {
            return new Cell(new Point(cellPos.X * 3 - cellPos.X + 1, cellPos.Y * 3 - cellPos.Y + 1));
        }

        public Direction GetDirection(Cell connectedCell)
        {
            if(connectedCell.CentralPoint == new Point(CentralPoint.X, CentralPoint.Y + 2))
            {
                return Direction.Up;
            }
            else if(connectedCell.CentralPoint == new Point(CentralPoint.X, CentralPoint.Y - 2))
            {
                return Direction.Down;
            }
            else if(connectedCell.CentralPoint == new Point(CentralPoint.X - 2, CentralPoint.Y))
            {
                return Direction.Left;
            }
            else if(connectedCell.CentralPoint == new Point(CentralPoint.X + 2, CentralPoint.Y))
            {
                return Direction.Right;
            }
            else
            {
                throw new CellNotConnectedException();
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Cell cell &&
                   EqualityComparer<Point>.Default.Equals(CentralPoint, cell.CentralPoint);
        }

        public override int GetHashCode()
        {
            return -2088542676 + EqualityComparer<Point>.Default.GetHashCode(CentralPoint);
        }

        public Dictionary<Direction, Point> ConnectedCells { set; get; }


        public static bool operator ==(Cell lhs, Cell rhs)
        {
            return lhs.CentralPoint == rhs.CentralPoint;
        }

        public static bool operator !=(Cell lhs, Cell rhs)
        {
            return lhs.CentralPoint != rhs.CentralPoint;
        }

    }
}
