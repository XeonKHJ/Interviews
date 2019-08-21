using System;
using Interviews.ThoughtWorks.MazeProblem;

namespace Interviews
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MazzFactory.Create("1 23 \n 3,4 0,2;0,0 1,0;0,1 1,1");
        }
    }
}
