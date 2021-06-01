using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace TeleprompterConsole
{
    internal class TeleprompterConfig
    {
        internal int DelayInMilliseconds { get; private set; } = 200;

        internal void UpdateDelay(int increment)
        {
            var newDelay= Min(DelayInMilliseconds + increment, 1000);
            newDelay = Max(newDelay, 20);
            DelayInMilliseconds = newDelay;
        }

        public bool Done { get; private set; }

        public void SetDone()
        {
            Done = true;
        }
    }
}
