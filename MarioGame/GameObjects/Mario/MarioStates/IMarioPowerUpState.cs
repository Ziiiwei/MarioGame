﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    public interface IMarioPowerUpState
    {
        void PowerUp(IMario mario);
        void PowerDown(IMario mario);
        void Fire(IMario mario);

        void Jump(IMario mario);
    }
}
