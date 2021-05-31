using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceInCSharp.IService;

namespace InterfaceInCSharp.Service
{
    public interface IBlinkingLight : ILight
    {
        public async Task Blink(int duration, int repeatCount)
        {
            Console.WriteLine("Using the default interface method for IBlinkingLight.Blink.");
            for (int count = 0; count < repeatCount; count++)
            {
                SwitchOn();
                await Task.Delay(duration);
                SwitchOff();
                await Task.Delay(duration);
            }
            Console.WriteLine("Done with the default interface method for IBlinkingLight.Blink.");
        }
    }
}
