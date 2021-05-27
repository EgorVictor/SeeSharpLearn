using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fundamentals.Back.Test;
using Fundamentals.Registration;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            //PatternMatchingTest patternMatchingTest = new PatternMatchingTest();

            //Discards.TestDiscards();
            //Discards.PersonTest();
            ////等待异步结果
            //Task.WaitAny(Discards.ExecuteAsyncMethod());
            ////丢弃返回结果
            ////_ = Discards.ExecuteAsyncMethod();

            ////解构元组
            ////C# 9.0 对象实例化简洁方式
            //DeconstructingTuplesAndOtherTypes deconstructingTuplesAndOtherTypes = new();
            //deconstructingTuplesAndOtherTypes.Test();

            //BankTest.MainTest();

            TollCalculatorTest.Test();
        }
    }
}
