﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Projectiles
{
    interface IProjectileState
    {
        void ChangeDirection(ShootAngle angle);
    }
}
