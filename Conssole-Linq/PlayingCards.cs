using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLinq
{
    public class PlayingCards
    {
       public static IEnumerable<string> Suits()
        {
            yield return "梅花";
            yield return "黑桃";
            yield return "红桃";
            yield return "方块";
        }
       public static IEnumerable<string> Ranks()
        {
            yield return "A";
            yield return "2";
            yield return "3";
            yield return "4";
            yield return "5";
            yield return "6";
            yield return "7";
            yield return "8";
            yield return "9";
            yield return "10";
            yield return "J";
            yield return "Q";
            yield return "K";
        }
    }
}
