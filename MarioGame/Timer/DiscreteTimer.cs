using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    internal class DiscreteTimer
    {
        public int Ticks { get; private set; }
        private Delegate Callback { get; }

        public DiscreteTimer(int ticks, Delegate callback)
        {
            Ticks = ticks;
            Callback = callback;
        }

        public void Tick()
        {
            if (Ticks < 0)
            {
                Callback.DynamicInvoke();
            }
            Ticks--;
        }

    }
}
