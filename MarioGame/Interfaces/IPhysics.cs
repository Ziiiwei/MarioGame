﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Gamespace
{
    public interface IPhysics
    {
        Vector2 GetPosition();
        void MoveLeft();
        void MoveRight();
        void MoveDown();
        void MoveUp();
        void FreeFall();
        void Jump();
        void SpeedUp();
        void SlowDown();
        void Update();
        void HorizontalStop(Rectangle collisionArea);
        void VerticalStop(Rectangle collisionArea);
    }
}
