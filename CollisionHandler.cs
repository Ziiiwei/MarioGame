using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Commands;
using Gamespace.Goombas;
using Gamespace.Blocks;

namespace Gamespace
{
    class CollisionHandler
    {
        /* Side is relative to the first IGameObject in the tuple */
        private Dictionary<Tuple<Type, Type, Side>, Tuple<Type, Type>> collisionActions;
        //private static readonly CollisionHandler instance = new CollisionHandler();
        enum Side : int { None, Up, Down, Left, Right };

        static CollisionHandler()
        {
        }

        public CollisionHandler()
        {
            collisionActions = new Dictionary<Tuple<Type, Type, Side>, Tuple<Type, Type>>();
            collisionActions.Add(new Tuple<Type, Type, Side>(typeof(Mario), typeof(Block), Side.Up),
                new Tuple<Type, Type>(typeof(MakeMarioBig), typeof(NullCommand)));

        }
        /*
        public static CollisionHandler Instance
        {
            get
            {
                return instance;
            }
        }
        */

        public void HandleCollision(IGameObject obj1, IGameObject obj2)
        {
            if (DetectCollision(obj1, obj2) == (Side.None, Side.None))
            {
                return;
            }

            (Side, Side) collisionDirections = DetectCollision(obj1, obj2);
            Tuple<Type, Type, Side> key = new Tuple<Type, Type, Side>(obj1.GetType(),
                obj2.GetType(), collisionDirections.Item1);

            if (collisionActions.ContainsKey(key))
            {
                Type object1Type = collisionActions[key].Item1;
                Type object2Type = collisionActions[key].Item2;

                ICommand collisionMember1 = (ICommand)Activator.CreateInstance(object1Type, obj1);
                ICommand collisionMember2 = (ICommand)Activator.CreateInstance(object2Type, obj2);

                collisionMember1.Execute();
                collisionMember2.Execute();
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
