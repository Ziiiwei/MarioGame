using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    internal class TrajectoryPhysics : BasePhysics
    {
        public TrajectoryPhysics(IGameObject gameObject, Vector2 position, (float G, float A, float X_V, float Y_V, float F) constants) : base(gameObject, position, constants)
        {
        }

        public override void Update()
        {
            Vector2 currentPosition = new Vector2(position.X,position.Y);
            positionUpdater.Invoke();
            velocity.Y = position.Y - currentPosition.Y;
            velocity.X = position.X - currentPosition.X;
        }
    }
}
