using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceInCSharp.IService
{
    public interface ITimerLight : ILight
    {
        public async Task TurnOnFor(int duration)
        {
            Console.WriteLine("Using the default interface method for the ITimerLight.TurnOnFor");
            SwitchOn();
            await Task.Delay(duration);
            SwitchOff();
            Console.WriteLine();
            Console.WriteLine("Completed ITimerLight.TurnOff sequence");
        }
    }
}
