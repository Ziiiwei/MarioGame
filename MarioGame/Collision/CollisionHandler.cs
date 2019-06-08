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
                new Tuple<Type, Type>(typeof(PushMarioUp), typeof(HitBlock)));
            collisionActions.Add(new Tuple<Type, Type, Side>(typeof(Mario), typeof(Block), Side.Down),
                new Tuple<Type, Type>(typeof(PushMarioDown), typeof(NullCommand)));
            collisionActions.Add(new Tuple<Type, Type, Side>(typeof(Mario), typeof(Block), Side.Left),
                new Tuple<Type, Type>(typeof(PushMarioLeft), typeof(NullCommand)));
            collisionActions.Add(new Tuple<Type, Type, Side>(typeof(Mario), typeof(Block), Side.Right),
                new Tuple<Type, Type>(typeof(PushMarioRight), typeof(NullCommand)));

            collisionActions.Add(new Tuple<Type, Type, Side>(typeof(Mario), typeof(Flower), Side.Right),
                new Tuple<Type, Type>(typeof(HitFlower), typeof(MakeItemDisappear)));
            collisionActions.Add(new Tuple<Type, Type, Side>(typeof(Mario), typeof(Flower), Side.Left),
                new Tuple<Type, Type>(typeof(HitFlower), typeof(MakeItemDisappear)));
            collisionActions.Add(new Tuple<Type, Type, Side>(typeof(Mario), typeof(Flower), Side.Up),
                new Tuple<Type, Type>(typeof(HitFlower), typeof(MakeItemDisappear)));
            collisionActions.Add(new Tuple<Type, Type, Side>(typeof(Mario), typeof(Flower), Side.Down),
                new Tuple<Type, Type>(typeof(HitFlower), typeof(MakeItemDisappear)));
            collisionActions.Add(new Tuple<Type, Type, Side>(typeof(Mario), typeof(RedShroom), Side.Down),
                new Tuple<Type, Type>(typeof(HitShroom), typeof(MakeItemDisappear)));
            collisionActions.Add(new Tuple<Type, Type, Side>(typeof(Mario), typeof(RedShroom), Side.Left),
                new Tuple<Type, Type>(typeof(HitShroom), typeof(MakeItemDisappear)));
            collisionActions.Add(new Tuple<Type, Type, Side>(typeof(Mario), typeof(RedShroom), Side.Right),
                new Tuple<Type, Type>(typeof(HitShroom), typeof(MakeItemDisappear)));
            collisionActions.Add(new Tuple<Type, Type, Side>(typeof(Mario), typeof(RedShroom), Side.Up),
                new Tuple<Type, Type>(typeof(HitShroom), typeof(MakeItemDisappear)));
            collisionActions.Add(new Tuple<Type, Type, Side>(typeof(Mario), typeof(Star), Side.Up),
                new Tuple<Type, Type>(typeof(HitStar), typeof(MakeItemDisappear)));
            collisionActions.Add(new Tuple<Type, Type, Side>(typeof(Mario), typeof(Star), Side.Down),
                new Tuple<Type, Type>(typeof(HitStar), typeof(MakeItemDisappear)));
            collisionActions.Add(new Tuple<Type, Type, Side>(typeof(Mario), typeof(Star), Side.Left),
                new Tuple<Type, Type>(typeof(HitStar), typeof(MakeItemDisappear)));
            collisionActions.Add(new Tuple<Type, Type, Side>(typeof(Mario), typeof(Star), Side.Right),
                new Tuple<Type, Type>(typeof(HitStar), typeof(MakeItemDisappear)));
            collisionActions.Add(new Tuple<Type, Type, Side>(typeof(Mario), typeof(Pipe), Side.Right),
                new Tuple<Type, Type>(typeof(PushMarioRight), typeof(NullCommand)));
            collisionActions.Add(new Tuple<Type, Type, Side>(typeof(Mario), typeof(Pipe), Side.Left),
                new Tuple<Type, Type>(typeof(PushMarioLeft), typeof(NullCommand)));
            collisionActions.Add(new Tuple<Type, Type, Side>(typeof(Mario), typeof(Pipe), Side.Up),
                new Tuple<Type, Type>(typeof(PushMarioUp), typeof(NullCommand)));
            collisionActions.Add(new Tuple<Type, Type, Side>(typeof(Mario), typeof(Pipe), Side.Down),
                new Tuple<Type, Type>(typeof(PushMarioDown), typeof(NullCommand)));
            collisionActions.Add(new Tuple<Type, Type, Side>(typeof(Mario), typeof(Coin), Side.Down),
                new Tuple<Type, Type>(typeof(PushMarioDown), typeof(MakeItemDisappear)));
            collisionActions.Add(new Tuple<Type, Type, Side>(typeof(Mario), typeof(Coin), Side.Up),
                new Tuple<Type, Type>(typeof(PushMarioUp), typeof(MakeItemDisappear)));
            collisionActions.Add(new Tuple<Type, Type, Side>(typeof(Mario), typeof(Coin), Side.Left),
                new Tuple<Type, Type>(typeof(PushMarioLeft), typeof(MakeItemDisappear)));
            collisionActions.Add(new Tuple<Type, Type, Side>(typeof(Mario), typeof(Coin), Side.Right),
                new Tuple<Type, Type>(typeof(PushMarioRight), typeof(MakeItemDisappear)));
            collisionActions.Add(new Tuple<Type, Type, Side>(typeof(Mario), typeof(GreenShroom), Side.Down),
            new Tuple<Type, Type>(typeof(PushMarioDown), typeof(MakeItemDisappear)));
            collisionActions.Add(new Tuple<Type, Type, Side>(typeof(Mario), typeof(GreenShroom), Side.Up),
                new Tuple<Type, Type>(typeof(PushMarioUp), typeof(MakeItemDisappear)));
            collisionActions.Add(new Tuple<Type, Type, Side>(typeof(Mario), typeof(GreenShroom), Side.Left),
                new Tuple<Type, Type>(typeof(PushMarioLeft), typeof(MakeItemDisappear)));
            collisionActions.Add(new Tuple<Type, Type, Side>(typeof(Mario), typeof(GreenShroom), Side.Right),
                new Tuple<Type, Type>(typeof(PushMarioRight), typeof(MakeItemDisappear)));

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

                ICommand collisionMember1 = (ICommand)Activator.CreateInstance(object1Type, mover, directionAndArea.Item2);
                ICommand collisionMember2 = (ICommand)Activator.CreateInstance(object2Type, target, directionAndArea.Item2);

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
                // Try using center
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
