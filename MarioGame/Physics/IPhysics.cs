﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Gamespace.Controllers;

namespace Gamespace
{
    internal interface IPhysics
    {
        Vector2 Position { get; }
        Vector2 Velocity { get; }
        (PhysicalStatus, Side) ObjectPhysicalState { get; }
     Vector2 GetPosition();
        Vector2 GetVelocity();
        void LeftStop(Rectangle collisionArea);
        void RightStop(Rectangle collisionArea);
        void UpStop(Rectangle collisionArea);
        void DownStop(Rectangle collisionArea);
        void MoveMaxSpeed(Side side);
        void JumpMaxSpeed(Side side);
        void Update();
        void Stop(Side side);
        void FrictionStop(Side side);

     

    }
}
