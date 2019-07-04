using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    internal class ShroomPhysics : Physics
    {
        public ShroomPhysics(IGameObject gameObject, Vector2 position, IPhysicsConstants constants) : base(gameObject, position, constants)
        {
        }

        public override void Update()
        {
            FreeFall();

            velocity.Y = MinimumMagnitude(velocity.Y + acceleration.Y, Math.Sign(acceleration.Y) * max_Y_V);

            position.X += velocity.X;
            position.Y += velocity.Y;
        }
    }
}
