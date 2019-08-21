using System;
using Interviews.ThoughtWorks.MazeProblem;

namespace Interviews
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var maze = MazzFactory.Create("3 3 \n " +
                               "0,1 0,2;0,0 1,0;0,1 1,1;0,2 1,2;1,0 1,1;1,1 1,2;1,1 2,1;1,2 2,2;2,0 2,1");
            Console.WriteLine(maze.Render());
        }
    }
}
