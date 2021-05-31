using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceInCSharp.IService;
using InterfaceInCSharp.Service;

namespace InterfaceInCSharp
{
    internal class Test
    {
        internal static async Task TestLightCapabilities(ILight light)
        {
            // Perform basic tests:
            light.SwitchOn();
            Console.WriteLine($"\tAfter switching on, the light is {(light.IsOn() ? "on" : "off")}");
            light.SwitchOff();
            Console.WriteLine($"\tAfter switching off, the light is {(light.IsOn() ? "on" : "off")}");

            if (light is ITimerLight timer)
            {
                Console.WriteLine("\tTesting timer function");
                await timer.TurnOnFor(1000);
                Console.WriteLine("\tTimer function completed");
            }
            else
            {
                Console.WriteLine("\tTimer function not supported.");
            }

            if (light is IBlinkingLight blinker)
            {
                Console.WriteLine("\tTesting blinking function");
                await blinker.Blink(500, 5);
                Console.WriteLine("\tBlink function completed");
            }
            else
            {
                Console.WriteLine("\tBlink function not supported.");
            }
        }
    }
}
