using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using static ConsoleLinq.PlayingCards;

//使用LINQ查询将数据聚合成有意义的序列
//编写扩展方法以将我们自己的自定义功能添加到 LINQ 查询
//在我们的代码中定位我们的 LINQ 查询可能遇到性能问题的区域，例如速度下降
//关于LINQ查询的懒惰和急切的评估及其对查询性能的影响
//https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/working-with-linq
namespace ConsoleLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            //var startingDeck = Suits().LogQuery("产生花色").SelectMany(s => Ranks().LogQuery("产生点数"), (s, r) => new {Suit = s, Rank = r}).LogQuery("起始牌组");

            var startingDeck = (from s in Suits().LogQuery("Suit Generation")
                                from r in Ranks().LogQuery("Value Generation")
                                select new { Suit = s, Rank = r }).LogQuery("Starting Deck").ToList();

            foreach (var c in startingDeck)
            {
                Console.WriteLine(c);
            }

            Console.WriteLine("==========================");

            var times = 0;
            var shuffle = startingDeck;

            do
            {
                // Out shuffle 每次运行时顶牌和底牌都保持不变

                shuffle = shuffle.Take(26)
                         .LogQuery("Top Half")
                         .InterleaveSequenceWith(shuffle.Skip(26)
                         .LogQuery("Bottom Half"))
                         .LogQuery("Shuffle").ToList();


                // In shuffle 对于 in shuffle，您可以将牌组交错，使下半部分的第一张牌成为牌组中的第一张牌。这意味着上半部分的最后一张牌成为底牌
                /*shuffle = shuffle.Skip(26).LogQuery("Bottom Half")
                    .InterleaveSequenceWith(shuffle.Take(26).LogQuery("Top Half"))
                    .LogQuery("Shuffle").ToList();*/

                //此处使用ToList()或ToArray()构建一副纸牌的原始 LINQ 查询的结果
                //否则每次 do-while 循环进行迭代时，您都会一次又一次地执行查询，每次都重新构建一副牌并重新洗牌
                //LINQ 查询是惰性求值的语句。仅在请求元素时生成序列。通常，这是 LINQ 的主要优点。然而，在像这个程序这样的使用中，这会导致执行时间呈指数增长。
                foreach (var c in shuffle)
                {
                    Console.WriteLine(c);
                }

                times++;
                Console.WriteLine(times);
            } while (!startingDeck.SequenceEquals(shuffle));

            Console.WriteLine(times);
        }

    }
}
