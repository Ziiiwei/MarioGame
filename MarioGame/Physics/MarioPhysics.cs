using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    public class MarioPhysics : BasePhysics
    {
        private Dictionary<Side, Action> climbActions;
        public MarioPhysics(IGameObject gameObject, Vector2 position,(float G, float A, float X_V, float Y_V, float F) constants) 
            : base(gameObject,position,constants)
        {
            climbActions = new Dictionary<Side, Action>()
            {
                {Side.Up, new Action(() => {acceleration.Y = -PhysicsConstants.A/100; velocity.Y = -PhysicsConstants.Y_V/5; })},
                {Side.Down, new Action(() => {acceleration.Y = PhysicsConstants.A/100; velocity.Y = PhysicsConstants.Y_V/5; })},
                {Side.Left, new Action(() => {acceleration.X = -PhysicsConstants.A/100; velocity.X = -PhysicsConstants.Y_V/5; })},
                {Side.Right, new Action(() => {acceleration.X = PhysicsConstants.A/100; velocity.X = PhysicsConstants.Y_V/5; })},
            };
        }

        public override void Climb(Side side)
        {
            climbActions[side].Invoke();
            gravityUpdater = () => { };

        }

        public override void Jump()
        {
            
        }
    }
}
