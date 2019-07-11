using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    public class AnimationPhysics : Physics
    {

        private Action velocityUpdater;
        private Action positionUpdater;
        private Action gravityUpdater;
        private Action frictionUpdater;
    

        public AnimationPhysics(IGameObject gameObject, Vector2 position, IPhysicsConstants constants) : base(gameObject, position, constants)
        {
            

            velocityUpdater = () =>
            {
                velocity.X = MinimumMagnitude(velocity.X + acceleration.X, Math.Sign(acceleration.X) * max_X_V);
                velocity.Y = MinimumMagnitude(velocity.Y + acceleration.Y, Math.Sign(acceleration.Y) * max_Y_V);
            };

            positionUpdater = () =>
            { 
                this.position.X = (int)(this.position.X + velocity.X);
                this.position.Y = (int)(this.position.Y + velocity.Y);
            };

            frictionUpdater = () =>
            {
                acceleration.X = -Math.Sign(velocity.X) * FRICTION;
                acceleration.Y = -Math.Sign(velocity.Y) * FRICTION;
            };

            gravityUpdater = () =>
            {
                acceleration.Y = gravityConstant;
            };
        }

        public override void Move(Side side)
        {
          
        }

        public override void MoveMaxSpeed(Side side)
        {
           
        }

        public override void Update()
        {
            gravityUpdater.Invoke();
            velocityUpdater.Invoke();
            positionUpdater.Invoke();
            frictionUpdater.Invoke();
        }

   
    }
}
