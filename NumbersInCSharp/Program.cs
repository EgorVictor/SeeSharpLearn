using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Autofac;
using Autofac.Core;

namespace NumbersInCSharp
{
    class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<IntegerArithmetic>();

            Container = builder.Build();
            using (var scope = Container.BeginLifetimeScope())
            {
                var integerArithmetic = scope.Resolve<IntegerArithmetic>();
                //integerArithmetic.WorkWithIntegers();
                //integerArithmetic.OrderPrecedence();
                //integerArithmetic.IntMaxMinValue();
                //integerArithmetic.DoubleMaxMinValue();
                //integerArithmetic.DecimalMaxMinValue();
                //integerArithmetic.CircleArea(2.50);
            }
            Console.ReadKey();
        }
    }
}
