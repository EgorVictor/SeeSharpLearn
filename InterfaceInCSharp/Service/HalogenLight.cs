using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceInCSharp.IService;

namespace InterfaceInCSharp.Service
{
    public class HalogenLight : ITimerLight
    {
        private enum HalogenLightState
        {
            Off,
            On,
            TimerModeOn
        }

        private HalogenLightState state;
        public void SwitchOn() => state = HalogenLightState.On;

        public void SwitchOff() => state = HalogenLightState.Off;

        public bool IsOn() => state == HalogenLightState.On;


        //覆盖接口中默认接口实现，不同与虚方法，不适用Override关键字
        public async Task TurnOnFor(int duration)
        {
            Console.WriteLine("Halogen light starting timer function.");
            state = HalogenLightState.TimerModeOn;
            await Task.Delay(duration);
            state = HalogenLightState.Off;
            Console.WriteLine("Halogen light finished custom timer function");
        }

        public override string ToString() => $"The light is {state}";
    }
}
