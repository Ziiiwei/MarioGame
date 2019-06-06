using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    class CollisionHandler
    {
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
            if (DetectCollision(obj1, obj2) == Side.None)
            {
                return;
            }


        }

        private Side DetectCollision(IGameObject obj1, IGameObject obj2)
        {
            if (!obj1.GetCollisionBoundary().Intersects(obj2.GetCollisionBoundary()))
            {
                return Side.None;
            }

            Rectangle collisionArea = Rectangle.Intersect(obj1.GetCollisionBoundary(), 
                obj2.GetCollisionBoundary());

            bool horizontalCollision = true;

            if (collisionArea.Width < collisionArea.Height)
            {
                horizontalCollision = false;
            }

        }
    }
}
