using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Commands;

namespace Gamespace
{
    class CollisionHandler
    {
        private Dictionary<Tuple<IGameObject, IGameObject, Side>, (ICommand, ICommand)> collisionActions;
        private static readonly CollisionHandler instance = new CollisionHandler();
        enum Side : int { None, Up, Down, Left, Right };

        static CollisionHandler()
        {
        }

        private CollisionHandler()
        {
        }

        public static CollisionHandler Instance
        {
            get
            {
                return instance;
            }
        }

        public void HandleCollision(IGameObject obj1, IGameObject obj2)
        {
            if (DetectCollision(obj1, obj2) == (Side.None, Side.None))
            {
                return;
            }
            


        }

        private (Side, Side) DetectCollision(IGameObject obj1, IGameObject obj2)
        {
            if (!obj1.GetCollisionBoundary().Intersects(obj2.GetCollisionBoundary()))
            {
                return (Side.None, Side.None);
            }

            Rectangle collisionArea = Rectangle.Intersect(obj1.GetCollisionBoundary(),
                obj2.GetCollisionBoundary());

            bool horizontalCollision = (collisionArea.Height > collisionArea.Width);

            if (horizontalCollision)
            {
                if (obj1.PositionOnScreen.X < obj2.PositionOnScreen.X)
                {
                    return (Side.Right, Side.Left);
                }
                else
                {
                    return (Side.Left, Side.Right);
                }
            }
            else
            {
                if (obj1.PositionOnScreen.Y < obj2.PositionOnScreen.Y)
                {
                    return (Side.Down, Side.Up);
                }
                else
                {
                    return (Side.Up, Side.Down);
                }
            }

        }
    }
}
