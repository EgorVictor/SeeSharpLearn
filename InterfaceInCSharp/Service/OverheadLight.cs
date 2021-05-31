using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceInCSharp.IService;

namespace InterfaceInCSharp.Service
{
    //默认实现IBlinkingLight和ITimerLight中的闪烁效果

    public class OverheadLight : IBlinkingLight, ITimerLight
    {
        private bool isOn;
        public void SwitchOn()
        {
            isOn = true;
        }

        public void SwitchOff()
        {
            isOn = false;
        }

        public bool IsOn()
        {
            return isOn;
        }
    }
}
