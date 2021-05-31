using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceInCSharp.IService;

namespace InterfaceInCSharp.Service
{
    internal class Light : ILight
    {
        private bool _isOn;


        public void SwitchOn() => _isOn = true;

        public void SwitchOff() => _isOn = false;


        public bool IsOn() => _isOn;

        public override string ToString() => $"This light is {(_isOn ? "on" : "off")}";

    }
}
