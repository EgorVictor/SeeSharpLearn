using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListInCSharp
{
    internal class ListTutorial
    {
       public void WorkWithString()
        {
            var names = new List<string> { "<name>", "Ana", "Felipe" };
            foreach (var name in names)
            {
                Console.WriteLine($"Hello {name.ToUpper()}!");
            }

            Console.WriteLine();
            names.Add("Maria");
            names.Add("Bill");
            names.Remove("Ana");
            foreach (var name in names)
            {
                Console.WriteLine($"Hello {name.ToUpper()}!");
            }

            Console.WriteLine($"My name is {names[0]}");
            Console.WriteLine($"I've added {names[2]} and {names[3]} to the list");

            Console.WriteLine($"The list has {names.Count} people in it");

            var index = names.IndexOf("Felipe");
            Console.WriteLine(index == -1
                ? $"When an item is not found, IndexOf returns {index}"
                : $"The name {names[index]} is at index {index}");


            index = names.IndexOf("Not Found");
            Console.WriteLine(index == -1
                ? $"When an item is not found, IndexOf returns {index}"
                : $"The name {names[index]} is at index {index}");


            names.Sort();
            foreach (var name in names)
            {
                Console.WriteLine($"Hello {name.ToUpper()}!");
            }




            //int[] someArray = new int[5] { 1, 2, 3, 4, 5 };
            //int lastElement = someArray[^1];

            //斐波那契数列
            var fibonacciNumbers = new List<int> { 1, 1 };
            while (fibonacciNumbers.Count < 20)
            {
                var previous = fibonacciNumbers[^1];
                var previous2 = fibonacciNumbers[^2];
                fibonacciNumbers.Add(previous + previous2);

            }
            foreach (var item in fibonacciNumbers)
                Console.WriteLine(item);
        }
    }
}
