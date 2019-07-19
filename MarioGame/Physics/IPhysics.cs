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
        Vector2 Position { get; set; }
        Vector2 Velocity { get; set; }
        Vector2 Acceleration { get; set; }
        (float G,float A,float X_V,float Y_V,float F) PhysicsConstants { get; set; }

        void LeftStop(Rectangle collisionArea);
        void RightStop(Rectangle collisionArea);
        void UpStop(Rectangle collisionArea);
        void DownStop(Rectangle collisionArea);
        void Move(Side side);
        void MoveMaxSpeed(Side side);
        void Jump();
        void Climb(Side side);
        void Update();
        void Stop(Side side);
        void FrictionStop(Side side);
        void ResoveCollision(Side side, Rectangle collisionArea);
        void IncrementMove(Side side, int distance);
        void TrajectMove(Func<Vector2, int, Vector2> trajectory);

        //void Rotate();






    }
}
