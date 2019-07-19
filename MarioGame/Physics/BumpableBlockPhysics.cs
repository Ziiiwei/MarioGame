using Gamespace;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    internal class BumpableBlockPhysics : Physics
    {
        int highWaterMark;
        public BumpableBlockPhysics(IGameObject gameObject, Vector2 position, (float,float,float,float,float) constants) : base(gameObject, position, constants)
        {
            highWaterMark = (int) position.Y;
        }

        public override void Update()
        {
            FreeFall();

            velocity.Y = MinimumMagnitude(velocity.Y + acceleration.Y, Math.Sign(acceleration.Y) * max_Y_V);

            float possiblePosition = position.Y + Velocity.Y;
            if ((int)possiblePosition > highWaterMark)
            {
                position.Y = highWaterMark;
            }
            else
            {
                position.Y = possiblePosition;
            }
        }
    }
}
