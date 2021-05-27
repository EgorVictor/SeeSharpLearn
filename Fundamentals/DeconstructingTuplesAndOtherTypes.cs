using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 解构元组和其它类型
namespace Fundamentals
{
    internal class DeconstructingTuplesAndOtherTypes
    {
        private static (string, int, double) QueryCityDate()
        {
            return ("Beijing", 8175133, 468.48);
        }

        internal void TuplesTest()
        {
            var result = QueryCityDate();
            var city = result.Item1;
            var pop = result.Item2;
            var size = result.Item3;
            Console.WriteLine($"city:{city};,pop:{pop};size:{size};");
        }
        //元组解构的三种方法

        internal void DeconstructingTuples1()
        {
            (string city, int pop, double size) = QueryCityDate();
            Console.WriteLine($"DeconstructingTuples1-> city:{city};,pop:{pop};size:{size};");
        }

        internal void DeconstructingTuples2()
        {
            var (city, pop, size) = QueryCityDate();
            Console.WriteLine($"DeconstructingTuples2-> city:{city};,pop:{pop};size:{size};");
        }

        internal void DeconstructingTuples3()
        {
            (string city, var pop, var size) = QueryCityDate();
            Console.WriteLine($"DeconstructingTuples3-> city:{city};,pop:{pop};size:{size};");
        }

        internal void Test()
        {
            TuplesTest();
            DeconstructingTuples1();
            DeconstructingTuples2();
            DeconstructingTuples3();
        }
    }
}
