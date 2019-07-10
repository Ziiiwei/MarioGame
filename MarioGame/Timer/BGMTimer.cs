using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    internal class BGMTimer
    {
        public int Seconds { get; private set; }
        private Delegate Callback { get; }

        public BGMTimer(int seconds, Delegate callback)
        {
            Seconds = seconds;
            Callback = callback;
        }

        public void Second()
        {
            if (Seconds < 0)
            {
                Callback.DynamicInvoke();
            }
            Seconds--;
        }

    }
}
