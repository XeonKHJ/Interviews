using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Interviews.ThoughtWorks.MazeProblem
{
    public struct MazeScale
    {
        public Size CellScale { set; get; }

        public Hashtable Connectivties { set; get; }
        public MazeScale(Size cellScale, Hashtable connectivities)
        {
            CellScale = cellScale;
            Connectivties = connectivities;
        }
    }
}
