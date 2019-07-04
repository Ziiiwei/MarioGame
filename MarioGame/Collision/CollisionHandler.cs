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
using Gamespace.Interfaces;
using Gamespace.Clouds;
using Gamespace.Hills;

namespace Gamespace
{
    public enum Side : int { None, Up, Down, Left, Right };
    class CollisionHandler
    {
        /* Side is relative to the second IGameObject in the tuple */
        private readonly    Dictionary<Tuple<Type, Type, Side>, (Type, Type)> collisionActions;
        private Dictionary<(Type, Type), Func<IGameObject, IGameObject, (Type, Type)>> translator;
        private Dictionary<Tuple<Type, Type, Side>, (Type, Type)> statefulCollisionActions;
        private List<Type> collisionMasks;
        public enum Side  { None, Up, Down, Left, Right };

        public CollisionHandler()
        {
            collisionActions = JsonParser.Instance.ParseCollisionFile();
            translator = new Dictionary<(Type, Type), Func<IGameObject, IGameObject, (Type, Type)>>();
            /* This will become data driven */
            translator.Add((typeof(Mario), typeof(BrickBlock)), new Func<IGameObject, IGameObject, (Type, Type)>(TypeTranslator.MarioBlockTranslator));
            translator.Add((typeof(Mario), typeof(Goomba)), new Func<IGameObject, IGameObject, (Type, Type)>(TypeTranslator.MarioGoombaTranslator));
            translator.Add((typeof(Mario), typeof(Koopa)), new Func<IGameObject, IGameObject, (Type, Type)>(TypeTranslator.MarioKoopaTranslator));
            translator.Add((typeof(Goomba), typeof(BrickBlock)), new Func<IGameObject, IGameObject, (Type, Type)>(TypeTranslator.BumpableBlockEnemyTranslator));
            translator.Add((typeof(Koopa), typeof(BrickBlock)), new Func<IGameObject, IGameObject, (Type, Type)>(TypeTranslator.BumpableBlockEnemyTranslator));
            statefulCollisionActions = JsonParser.Instance.ParseCollisionStatefulFile();

            collisionMasks = new List<Type>()
            {
                typeof(Cloud1),
                typeof(Cloud2),
                typeof(Cloud3),
                typeof(BigHill),
                typeof(SmallHill)
            };
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

            if((collisionMasks.Contains(mover.GetType()) || collisionMasks.Contains(target.GetType())))
            {
                return;
            }

            if (collisionActions.ContainsKey(key))
            {
                ExecuteCommand(collisionActions, key, mover, target, collisionArea);
            }
            else if (translator.ContainsKey((mover.GetType(), target.GetType())))
            {
                Delegate translatorValue = translator[(mover.GetType(), target.GetType())];
                (Type, Type) statefulActionsKey = ((Type, Type)) translatorValue.DynamicInvoke(mover, target);

                var statefulKey = new Tuple<Type, Type, Side>(statefulActionsKey.Item1, statefulActionsKey.Item2, side);

                if (statefulCollisionActions.ContainsKey(statefulKey))
                {
                    ExecuteCommand(statefulCollisionActions, statefulKey, mover, target, collisionArea);
                }
                else
                {
                    ExecuteDefaultCollision(mover, target, collisionArea, side);
                } 
            }
            else
            {
                /* This is known to be messy and will be cleaned up later. */
                /* TODO: Consider a collision list where items collide with nothing */
                ExecuteDefaultCollision(mover, target, collisionArea, side);
            }

        }

        private void ExecuteCommand(Dictionary<Tuple<Type, Type, Side>, (Type, Type)> actions, Tuple<Type, Type, Side> key,
                                    IGameObject mover, IGameObject target, Rectangle collisionArea)
        {
            Type object1Type = actions[key].Item1;
            Type object2Type = actions[key].Item2;

            ICommand collisionMember1 = (ICommand)Activator.CreateInstance(object1Type, mover, new CollisionData(collisionArea));
            ICommand collisionMember2 = (ICommand)Activator.CreateInstance(object2Type, target, new CollisionData(collisionArea));

            collisionMember1.Execute();
            collisionMember2.Execute();
        }

        private void ExecuteDefaultCollision(IGameObject mover, IGameObject target, Rectangle collisionArea, Side side)
        {
            ICommand defaultCommand = new CollideUp((ICollidable)mover, new CollisionData(collisionArea));

            if (side is Side.Down)
                defaultCommand = new CollideDown((ICollidable)mover, new CollisionData(collisionArea));
            if (side is Side.Left)
                defaultCommand = new CollideLeft((ICollidable)mover, new CollisionData(collisionArea));
            if (side is Side.Right)
                defaultCommand = new CollideRight((ICollidable)mover, new CollisionData(collisionArea));

            defaultCommand.Execute();
        }
        /* Collision direction is target relative 
         * Example: Mario hits top of the block, so that is a top collision.
         */
        internal (Side, Rectangle) DetectCollision(IGameObject mover, IGameObject target)
        {
            if (!mover.GetCollisionBoundary().Intersects(target.GetCollisionBoundary()))
            {
                return (Side.None, new Rectangle(0, 0, 0, 0));
            }

            Rectangle collisionArea = Rectangle.Intersect(mover.GetCollisionBoundary(),
                target.GetCollisionBoundary());

             //bool horizontalCollision = ((int)mover.GameObjectPhysics.GetVelocity().X < collisionArea.Width);

              bool  horizontalCollision = (collisionArea.Height > collisionArea.Width);

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
