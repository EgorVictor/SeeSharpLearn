using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/tutorials/pattern-matching

namespace Fundamentals.Registration
{
    internal class TollCalculator
    {
        /* internal decimal CalculateToll(object vehicle) =>
             vehicle switch
             {
                 ConsumerVehicleRegistration.Car c => 2.0m,
                 LiveryRegistration.Taxi => 3.5m,
                 LiveryRegistration.Bus => 5m,
                 CommercialRegistration.DeliveryTruck => 10.0m,
                 { } => throw new ArgumentException(message: "没有匹配的车型"),
                 null => throw new ArgumentNullException(nameof(vehicle))
             };*/


        internal decimal CalculateToll(object vehicle) =>
            vehicle switch
            {
                ConsumerVehicleRegistration.Car c => c.Passengers switch
                {
                    0 => 2.00m + 0.5m,
                    1 => 2.0m,
                    2 => 2.0m - 0.5m,
                    _ => 2.00m - 1.0m
                },

                LiveryRegistration.Taxi t => t.Fares switch
                {
                    0 => 3.50m + 1.00m,
                    1 => 3.50m,
                    2 => 3.50m - 0.50m,
                    _ => 3.50m - 1.00m
                },

                LiveryRegistration.Bus b when ((double)b.Riders / (double)b.Capacity) < 0.50 => 5.00m + 2.00m,
                LiveryRegistration.Bus b when ((double)b.Riders / (double)b.Capacity) > 0.90 => 5.00m - 1.00m,
                LiveryRegistration.Bus b => 5.00m,

                CommercialRegistration.DeliveryTruck t when (t.GrossWeightClass > 5000) => 10.00m + 5.00m,
                CommercialRegistration.DeliveryTruck t when (t.GrossWeightClass < 3000) => 10.00m - 2.00m,
                CommercialRegistration.DeliveryTruck t => 10.00m,

                { } => throw new ArgumentException(message: "Not a known vehicle type", paramName: nameof(vehicle)),
                null => throw new ArgumentNullException(nameof(vehicle))
            };

        // <SnippetFinalTuplePattern>
        public decimal PeakTimePremium(DateTime timeOfToll, bool inbound) =>
            (IsWeekDay(timeOfToll), GetTimeBand(timeOfToll), inbound) switch
            {
                (true, TimeBand.Overnight, _) => 0.75m,
                (true, TimeBand.Daytime, _) => 1.5m,
                (true, TimeBand.MorningRush, true) => 2.0m,
                (true, TimeBand.EveningRush, false) => 2.0m,
                _ => 1.0m,
            };
        // </SnippetFinalTuplePattern>

        // <SnippetPremiumWithoutPattern>
        public decimal PeakTimePremiumIfElse(DateTime timeOfToll, bool inbound)
        {
            if ((timeOfToll.DayOfWeek == DayOfWeek.Saturday) ||
                (timeOfToll.DayOfWeek == DayOfWeek.Sunday))
            {
                return 1.0m;
            }
            else
            {
                int hour = timeOfToll.Hour;
                if (hour < 6)
                {
                    return 0.75m;
                }
                else if (hour < 10)
                {
                    if (inbound)
                    {
                        return 2.0m;
                    }
                    else
                    {
                        return 1.0m;
                    }
                }
                else if (hour < 16)
                {
                    return 1.5m;
                }
                else if (hour < 20)
                {
                    if (inbound)
                    {
                        return 1.0m;
                    }
                    else
                    {
                        return 2.0m;
                    }
                }
                else // Overnight
                {
                    return 0.75m;
                }
            }
        }
        // </SnippetPremiumWithoutPattern>

        // <SnippetTuplePatternOne>
        public decimal PeakTimePremiumFull(DateTime timeOfToll, bool inbound) =>
            (IsWeekDay(timeOfToll), GetTimeBand(timeOfToll), inbound) switch
            {
                (true, TimeBand.MorningRush, true) => 2.00m,
                (true, TimeBand.MorningRush, false) => 1.00m,
                (true, TimeBand.Daytime, true) => 1.50m,
                (true, TimeBand.Daytime, false) => 1.50m,
                (true, TimeBand.EveningRush, true) => 1.00m,
                (true, TimeBand.EveningRush, false) => 2.00m,
                (true, TimeBand.Overnight, true) => 0.75m,
                (true, TimeBand.Overnight, false) => 0.75m,
                (false, TimeBand.MorningRush, true) => 1.00m,
                (false, TimeBand.MorningRush, false) => 1.00m,
                (false, TimeBand.Daytime, true) => 1.00m,
                (false, TimeBand.Daytime, false) => 1.00m,
                (false, TimeBand.EveningRush, true) => 1.00m,
                (false, TimeBand.EveningRush, false) => 1.00m,
                (false, TimeBand.Overnight, true) => 1.00m,
                (false, TimeBand.Overnight, false) => 1.00m,
            };
        // </SnippetTuplePatternOne>

        // <SnippetIsWeekDay>
        private static bool IsWeekDay(DateTime timeOfToll) =>
            timeOfToll.DayOfWeek switch
            {
                DayOfWeek.Saturday => false,
                DayOfWeek.Sunday => false,
                _ => true
            };
        // </SnippetIsWeekDay>

        // <SnippetGetTimeBand>
        private enum TimeBand
        {
            MorningRush,
            Daytime,
            EveningRush,
            Overnight
        }

        private static TimeBand GetTimeBand(DateTime timeOfToll) =>
            timeOfToll.Hour switch
            {
                < 6 or > 19 => TimeBand.Overnight,
                < 10 => TimeBand.MorningRush,
                < 16 => TimeBand.Daytime,
                _ => TimeBand.EveningRush,
            };
        // <SnippetGetTimeBand>
    }

    internal class TollCalculatorTest
    {
        internal static void Test()
        {
            var tollCalc = new TollCalculator();

            var car = new ConsumerVehicleRegistration.Car();
            var taxi = new LiveryRegistration.Taxi();
            var bus = new LiveryRegistration.Bus();
            var truck = new CommercialRegistration.DeliveryTruck();

            Console.WriteLine($"The toll for a car is {tollCalc.CalculateToll(car)}");
            Console.WriteLine($"The toll for a taxi is {tollCalc.CalculateToll(taxi)}");
            Console.WriteLine($"The toll for a bus is {tollCalc.CalculateToll(bus)}");
            Console.WriteLine($"The toll for a truck is {tollCalc.CalculateToll(truck)}");

            try
            {
                tollCalc.CalculateToll("this will fail");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Caught an argument exception when using the wrong type");
            }
            try
            {
                tollCalc.CalculateToll(null!);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Caught an argument exception when using null");
            }
        }
    }
}
