using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace Interviews.ThoughtWorks.MazeProblem
{
    public class Maze
    {
        public MazeScale MazeScale { private set; get; }

        public Size MazeSize { private set; get; }
        internal Maze(MazeScale mazeScale)
        {
            //放入迷宫规模
            MazeScale = mazeScale;

            MazeSize = CaculateActualMazeSize();

            //加载每个迷宫单元
            for (int y = MazeSize.Height - 2; y >= 0; y -= 2)
            {
                for (int x = 1; x <= MazeSize.Width - 1; x += 2)
                {
                    cells.Add(new Cell(new Point(x, y)));
                }
            }

            //加载到哈希表
            foreach (var cell in cells)
            {
                PointToCellHash[cell.CentralPoint] = cell;
            }

            //凿穿迷宫
            CutThroughtWall();

            MazeSize = CaculateActualMazeSize();
        }

        private List<Cell> cells = new List<Cell>();

        public List<Cell> Cells { get { return cells; } }
        public Hashtable PointToCellHash { private set; get; } = new Hashtable();
        public string Render()
        {
            string mazeText = "";
            //2、遍历Cell
            for (int y = MazeSize.Height - 1; y >= 0; --y)
            {
                for (int x = 0; x < MazeSize.Width; ++x)
                {
                    //这些点是迷宫单元的中心。
                    if (x % 2 == 1 && y % 2 == 1)
                    {
                        mazeText += "[R]";
                    }
                    //这些点一定都是墙
                    else if ((x % 2 == 0 && y % 2 == 0) || x == 0 || x == MazeSize.Height - 1 || y == MazeSize.Width - 1 || y == 0)
                    {
                        mazeText += "[W]";
                    }

                             //当y在偶数行时，是上下连同才会打穿。
                    else if ((y % 2 == 0 && (((Cell)PointToCellHash[new Point(x, y - 1)]).ConnectedCells.ContainsKey(Direction.Up))) ||
                             //当y在奇数行时，要左右连同才会打穿。
                             (y % 2 == 1 && (((Cell)PointToCellHash[new Point(x + 1, y )]).ConnectedCells.ContainsKey(Direction.Left))))
                    {
                        mazeText += "[R]";
                    }
                    //其他情况都是墙
                    else
                    {
                        mazeText += "[W]";
                    }
                }
                mazeText += "\n";
            }
            return mazeText;
        }

        private void CutThroughtWall()
        {
            //根据连通性连同各个迷宫
            for (int i = 0; i < cells.Count; ++i)
            {
                var cell = cells[i];
                if (MazeScale.Connectivties.ContainsKey(cell.CentralPoint))
                {
                    List<Point> connectedCellsPoints = (List<Point>)MazeScale.Connectivties[cell.CentralPoint];
                    for (int j = 0; j < connectedCellsPoints.Count; ++j)
                    {
                        var connectedCell = (Cell)PointToCellHash[connectedCellsPoints[j]];
                        var direction = cell.GetDirection(connectedCell); //ConnectedCell相对Cell的方向
                        var oppoDirection = GetOppositeDirection(direction); //Cell相对ConnectedCell的方向

                        //如果改方向还没有载入单元，或者已经载入，且单元相同。
                        if ((!cell.ConnectedCells.ContainsKey(direction) || cell.ConnectedCells[direction] == connectedCell.CentralPoint)
                        && (!connectedCell.ConnectedCells.ContainsKey(oppoDirection) || connectedCell.ConnectedCells[oppoDirection] == cell.CentralPoint))
                        {
                            //往正确方向添加
                            cell.ConnectedCells[direction] = connectedCell.CentralPoint;
                            connectedCell.ConnectedCells[oppoDirection] = cell.CentralPoint;
                        }
                        else
                        {
                            throw new CellConnectivityConflictException();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 计算迷宫大小
        /// </summary>
        /// <returns></returns>
        private Size CaculateActualMazeSize()
        {
            return new Size(MazeScale.CellScale.Width * 3 - (MazeScale.CellScale.Width - 1),
                             MazeScale.CellScale.Height * 3 - (MazeScale.CellScale.Width - 1));
        }

        /// <summary>
        /// 获取相反方向
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        private Direction GetOppositeDirection(Direction direction)
        {
            if (direction == Direction.Down)
            {
                return Direction.Up;
            }
            else if (direction == Direction.Up)
            {
                return Direction.Down;
            }
            else if (direction == Direction.Left)
            {
                return Direction.Right;
            }
            else
            {
                return Direction.Left;
            }
        }

        struct CheckCell
        {
            public Cell Cell;
            public bool IsChecked;
        }
    }
}
