#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;

//模式匹配
namespace Fundamentals
{
    internal class PatternMatching
    {
        //声明模式
        internal static void DeclarationPattern()
        {
            int? maybe = 12;
            if (maybe is int number)
                Console.WriteLine($"The nullable int 'maybe' has the value {number}");
            else
                Console.WriteLine("The nullable int 'maybe' doesn't hold a value");
        }

        //常量模式
        internal static void ConstantPattern()
        {
            var message = "This is not the null string";

            if (message is not null) Console.WriteLine(message);
        }

        //检测模式
        //检测sequence是否为非null实现,并且实现System.Collections.Generic.IList <T>接口
        internal static T MidPoint<T>(IEnumerable<T> sequence)
        {
            if (sequence is IList<T> list) return list[list.Count / 2];

            if (sequence is null) throw new ArgumentException(nameof(sequence), "sequence can't be null");

            var halfLength = sequence.Count() / 2 - 1;
            if (halfLength < 0) halfLength = 0;
            return sequence.Skip(halfLength).First();
        }

        //关系模式
        internal static string WaterState(int tempInFahrenheit)
        {
            return tempInFahrenheit switch
            {
                (> 32) and (< 212) => "liquid",
                < 32 => "solid",
                > 212 => "gas",
                32 => "solid/liquid transition",
                212 => "liquid / gas transition"
            };
        }

        //最后_一种情况是匹配所有值的丢弃模式
        internal static string WaterState2(int tempInFahrenheit)
        {
            return tempInFahrenheit switch
            {
                < 32 => "solid",
                32 => "solid/liquid transition",
                < 212 => "liquid",
                212 => "liquid / gas transition",
                _ => "gas"
            };
        }

        internal static decimal CalculateDiscount(Order order)
        {
            return order switch
            {
                ( > 10, > 1000.00m) => 0.10m,
                ( > 5, > 50.00m) => 0.05m,
                Order { Cost: > 250.00m } => 0.02m,
                null => throw new ArgumentNullException(nameof(order), "Can't calculate discount on null order"),
                var someObject => 0m
            };
        }


        internal record Order(int Items, decimal Cost);
    }

    internal class PatternMatchingTest
    {
        internal  PatternMatchingTest()
        {
            PatternMatching.DeclarationPattern();
            PatternMatching.ConstantPattern();

            IList<int> list = new List<int>() { 1, 2, 3, 4, 5 };
            var midPoint = PatternMatching.MidPoint(list);
            Console.WriteLine(midPoint);

            string waterState = PatternMatching.WaterState(50);
            Console.WriteLine(waterState);

            var waterState2 = PatternMatching.WaterState2(213);
            Console.WriteLine(waterState2);

            var order = new PatternMatching.Order(11, 9000m);
            decimal calculateDiscount = PatternMatching.CalculateDiscount(order);
            Console.WriteLine(calculateDiscount);
        }
    }
}