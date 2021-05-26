using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using RecordsInCSharp;
//C#9 添加记录类型，记录是一种类
namespace RecordsInCSharp
{
    public record Person(string FirstName, string LastName)
    {
        public string[] PhoneNumbers { get; init; }
    }
}

internal class RecordTest
{
    internal static void PersonTest()
    {
        Person person1 = new Person("Nancy", "Davolio") { PhoneNumbers = new string[1] };
        Console.WriteLine($"person1:{person1}");

        Person person2 = person1 with { FirstName = "John" };
        Console.WriteLine($"person2:{person2}");

        Console.WriteLine(@"person1 with {FirstName = 'John'}," + $" person1==person2:{person1 == person2}");

        person2 = person1 with { PhoneNumbers = new string[1] };
        Console.WriteLine($"person2:{person2}");

        Console.WriteLine($"person1==person2:{person1 == person2}");

        person2 = person1 with { };
        Console.WriteLine("person1 with { } person1==person2:" + $"{person1 == person2}");
    }
}