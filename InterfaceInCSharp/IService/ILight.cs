using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceInCSharp.IService
{
    public interface ILight
    {
        void SwitchOn();
        void SwitchOff();
        bool IsOn();
    }


}
