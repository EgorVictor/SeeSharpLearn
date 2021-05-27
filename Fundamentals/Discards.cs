using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

//弃元 C#7.0开始支持,9.0使用弃元置顶Lambda表达式的未使用参数
namespace Fundamentals
{
    internal class Discards
    {
        internal static void TestDiscards()
        {
            var (_, _, _, pop1, _, pop2) = QueryCityDataForYears("New York City", 1960, 2010);
            Console.WriteLine($"Population change, 1960 to 2010: {pop2 - pop1:N0}");

            static (string, double, int, int, int, int) QueryCityDataForYears(string name, int year1, int year2)
            {
                int population1 = 0, population2 = 0;
                double area = 0;

                if (name == "New York City")
                {
                    area = 468.48;
                    if (year1 == 1960)
                    {
                        population1 = 7781984;
                    }
                    if (year2 == 2010)
                    {
                        population2 = 8175133;
                    }
                    return (name, area, year1, population1, year2, population2);
                }

                return ("", 0, 0, 0, 0, 0);
            }
        }

        internal static async Task ExecuteAsyncMethod()
        {
            Console.WriteLine("task run...");
            await Task.Run(() =>
            {
                var iterations = 0;
                for (int i = 0; i < int.MaxValue; i++)
                {
                    iterations++;
                }

                Console.WriteLine("Completed looping operation...");
            });
            await Task.Delay(50000);
           Console.WriteLine("Exiting after 5 second delay");
        }

        internal static void PersonTest()
        {
            Person.PersonTest();
        }

    }

    internal class Person
    {
        internal Person(string firstName, string middleName, string lastName, string cityName, string stateName)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            City = cityName;
            State = stateName;
        }

        internal string City { get; set; }
        internal string FirstName { get; set; }
        internal string LastName { get; set; }
        internal string MiddleName { get; set; }
        internal string State { get; set; }
        internal static void PersonTest()
        {
            var p = new Person("John", "Quincy", "Adams", "Boston", "MA");
            var (fName, _, city, _) = p;
            Console.WriteLine($"Hello {fName} of {city}!");
        }

        internal void Deconstruct(out string fName, out string lname,
                    out string city, out string state)
        {
            fName = FirstName;
            lname = LastName;
            city = City;
            state = State;
        }
    }


}
