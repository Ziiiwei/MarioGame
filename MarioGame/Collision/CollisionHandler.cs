using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Commands;
using Gamespace.Goombas;
using Gamespace.Blocks;
using Gamespace.Items;
using Gamespace.Koopas;

namespace Gamespace
{
    class CollisionHandler
    {
        /* Side is relative to the second IGameObject in the tuple */
        private Dictionary<Tuple<Type, Type, Side>, Tuple<Type, Type>> collisionActions;
        public enum Side : int { None, Up, Down, Left, Right };
        static CollisionHandler()
        {
        }

        public CollisionHandler()
        {
           
             collisionActions = JsonParser.Instance.ParseCollisionFile();

        }
        

        public void HandleCollision(IGameObject mover, IGameObject target)
        {
            if (DetectCollision(mover, target).Item1 == Side.None)
            {
                return;
            }

            (Side, Rectangle) directionAndArea = DetectCollision(mover, target);

            Tuple<Type, Type, Side> key = new Tuple<Type, Type, Side>(mover.GetType(),
                target.GetType(), directionAndArea.Item1);

            if (collisionActions.ContainsKey(key))
            {
                Type object1Type = collisionActions[key].Item1;
                Type object2Type = collisionActions[key].Item2;

                Rectangle collisionArea = directionAndArea.Item2;

                ICommand collisionMember1 = (ICommand) Activator.CreateInstance(object1Type, mover, new CollisionData(collisionArea));
                ICommand collisionMember2 = (ICommand) Activator.CreateInstance(object2Type, target, new CollisionData(collisionArea));

                collisionMember1.Execute();
                collisionMember2.Execute();
            }

        }

        /* Collision direction is target relative 
         * Example: Mario hits top of the block, so that is a top collision.
         */
        private (Side, Rectangle) DetectCollision(IGameObject mover, IGameObject target)
        {
            if (!mover.GetCollisionBoundary().Intersects(target.GetCollisionBoundary()))
            {
                return (Side.None, new Rectangle(0, 0, 0, 0));
            }

            Rectangle collisionArea = Rectangle.Intersect(mover.GetCollisionBoundary(),
                target.GetCollisionBoundary());

            bool horizontalCollision = (collisionArea.Height > collisionArea.Width);

            if (horizontalCollision)
            {
                
                if (mover.GetCenter().X < target.GetCenter().X)
                {
                    return (Side.Right, collisionArea);
                }
                else
                {
                    return (Side.Left, collisionArea);
                }
            }
            else
            {
                if (mover.GetCenter().Y < target.GetCenter().Y)
                {
                    return (Side.Down, collisionArea);
                }
                else
                {
                    return (Side.Up, collisionArea);
                }
            }

        }
    }
}
