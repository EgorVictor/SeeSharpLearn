using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            //PatternMatchingTest patternMatchingTest = new PatternMatchingTest();

            Discards.TestDiscards();
            Discards.PersonTest();
            //等待异步结果
            Task.WaitAny(Discards.ExecuteAsyncMethod());
            //丢弃返回结果
            //_ = Discards.ExecuteAsyncMethod();
        }
    }
}
