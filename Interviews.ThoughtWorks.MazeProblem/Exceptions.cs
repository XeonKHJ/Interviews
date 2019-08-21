using System;
using System.Collections.Generic;
using System.Text;

namespace Interviews.ThoughtWorks.MazeProblem
{
    class CellNotConnectedException : Exception
    {
        public override string Message => "目标单元没有和该单元相连。";
    }

    class CellConnectivityConflictException : Exception
    {
        public override string Message => "单元连接冲突！";
    }
}
