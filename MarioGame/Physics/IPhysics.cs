using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Gamespace.Controllers;

namespace Gamespace
{
    public interface IPhysics
    {
        Vector2 Position { get; }
        Vector2 Velocity { get; }
        Vector2 Acceleration { get; }
        Vector2 GetPosition();
        Vector2 GetVelocity();
        void LeftStop(Rectangle collisionArea);
        void RightStop(Rectangle collisionArea);
        void UpStop(Rectangle collisionArea);
        void DownStop(Rectangle collisionArea);
        void Move(Side side);
        void MoveMaxSpeed(Side side);

        void Climb(Side side);
        void Update();
        void Stop(Side side);
        void FrictionStop(Side side);

     

    }
}
