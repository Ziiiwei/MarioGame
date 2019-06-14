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
using Gamespace.Collision;

namespace Gamespace
{
    class CollisionHandler
    {
        /* Side is relative to the second IGameObject in the tuple */
        private Dictionary<Tuple<Type, Type, Side>, (Type, Type)> collisionActions;
        private Dictionary<(Type, Type), Func<IGameObject, IGameObject, (Type, Type)>> translator;
        private Dictionary<Tuple<Type, Type, Side>, (Type, Type)> statefulCollisionActions;
        public enum Side : int { None, Up, Down, Left, Right };
        static CollisionHandler()
        {
        }

        public CollisionHandler()
        {
            collisionActions = JsonParser.Instance.ParseCollisionFile();
            translator = new Dictionary<(Type, Type), Func<IGameObject, IGameObject, (Type, Type)>>();
            translator.Add((typeof(Mario), typeof(BrickBlock)), new Func<IGameObject, IGameObject, (Type, Type)>(TypeTranslator.MarioBlockTranslator));
            statefulCollisionActions = JsonParser.Instance.ParseCollisionStatefulFile();
        }

        public void HandleCollision(IGameObject mover, IGameObject target)
        {
            if (DetectCollision(mover, target).Item1 == Side.None)
            {
                return;
            }

            (Side, Rectangle) directionAndArea = DetectCollision(mover, target);
            Side side = directionAndArea.Item1;
            Rectangle collisionArea = directionAndArea.Item2;

            Tuple<Type, Type, Side> key = new Tuple<Type, Type, Side>(mover.GetType(),
            target.GetType(), directionAndArea.Item1);

            Action<Dictionary<Tuple<Type, Type, Side>, (Type, Type)>> launchCommand = (actions) =>
            {
                Type object1Type = actions[key].Item1;
                Type object2Type = actions[key].Item2;

                ICommand collisionMember1 = (ICommand)Activator.CreateInstance(object1Type, mover, new CollisionData(collisionArea));
                ICommand collisionMember2 = (ICommand)Activator.CreateInstance(object2Type, target, new CollisionData(collisionArea));

                collisionMember1.Execute();
                collisionMember2.Execute();
            };

            if (collisionActions.ContainsKey(key))
            {
                launchCommand(collisionActions);
            }
            else if (translator.ContainsKey((mover.GetType(), target.GetType())))
            {
                Delegate translatorValue = translator[(mover.GetType(), target.GetType())];
                (Type, Type) statefulActionsKey = ((Type, Type)) translatorValue.DynamicInvoke(mover, target);
                key = new Tuple<Type, Type, Side>(statefulActionsKey.Item1, statefulActionsKey.Item2, side);
                launchCommand(statefulCollisionActions);
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
