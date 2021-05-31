using System;
using System.Collections.Generic;
using System.Linq;

namespace NewFunction
{
    internal record DailyTemperature(double HighTemp, double LowTemp)
    {
        private static DailyTemperature[] data = new DailyTemperature[]
        {
            new DailyTemperature(57, 30),
            new DailyTemperature(60, 35),
            new DailyTemperature(63, 33),
            new DailyTemperature(68, 29),
            new DailyTemperature(72, 47),
            new DailyTemperature(75, 55),
            new DailyTemperature(77, 55),
            new DailyTemperature(72, 58),
            new DailyTemperature(70, 47),
            new DailyTemperature(77, 59),
            new DailyTemperature(85, 65),
            new DailyTemperature(87, 65),
            new DailyTemperature(85, 72),
            new DailyTemperature(83, 68),
            new DailyTemperature(77, 65),
            new DailyTemperature(72, 58),
            new DailyTemperature(77, 55),
            new DailyTemperature(76, 53),
            new DailyTemperature(80, 60),
            new DailyTemperature(85, 66)
        };



        public abstract record DegreeDays(double BaseTemperature, IEnumerable<DailyTemperature> TempRecords);

        public record HeatingDegreeDays(double BaseTemperature, IEnumerable<DailyTemperature> TempRecords)
            : DegreeDays(BaseTemperature, TempRecords)
        {
            public double DegreeDays => TempRecords.Where(s => s.Mean < BaseTemperature).Sum(s => BaseTemperature - s.Mean);
        }

        public sealed record CoolingDegreeDays(double BaseTemperature, IEnumerable<DailyTemperature> TempRecords)
            : DegreeDays(BaseTemperature, TempRecords)
        {
            public double DegreeDays => TempRecords.Where(s => s.Mean > BaseTemperature).Sum(s => s.Mean - BaseTemperature);
        }


        internal double Mean => (HighTemp + LowTemp) / 2;

        internal static void TestWriteLine()
        {
            foreach (var item in data)
            {
                Console.WriteLine(item);
            }
        }

        internal static void TestDegreeDays()
        {
            var heatingDegreeDays = new HeatingDegreeDays(65, data);
            Console.WriteLine(heatingDegreeDays);

            var coolingDegreeDays = new CoolingDegreeDays(65, data);
            Console.WriteLine(coolingDegreeDays);
        }
    }




}