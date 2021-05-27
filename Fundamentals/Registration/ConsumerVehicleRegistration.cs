namespace Fundamentals.Registration
{
    public class ConsumerVehicleRegistration
    {
        public class Car
        {
            public int Passengers { get; set; }
        }
    }

    public class CommercialRegistration
    {
        public class DeliveryTruck
        {
            public int GrossWeightClass { get; set; }
        }
    }

    public class LiveryRegistration
    {
        public class Taxi
        {
            public int Fares { get; set; }
        }

        public class Bus
        {
            public int Capacity { get; set; }
            public int Riders { get; set; }
        }
    }
}