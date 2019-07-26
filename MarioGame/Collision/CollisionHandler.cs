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
    public enum Side : int { None, Up, Down, Left, Right , Horizontal, Vertical};
    class CollisionHandler
    {
        /* Side is relative to the second IGameObject in the tuple */
        private readonly    Dictionary<Tuple<Type, Type, Side>, Tuple<Type, Type>> collisionActions;
        private delegate Tuple<Type, Type> Translator(IGameObject mover, IGameObject reciever);
        private Dictionary<Tuple<Type, Type>, Translator> translator;
        private Dictionary<Tuple<Type, Type, Side>, Tuple<Type, Type>> statefulCollisionActions;
        private List<Type> collisionMasks;
        public enum Side  { None, Up, Down, Left, Right };

        public CollisionHandler()
        {
            collisionActions = JsonParser.Instance.ParseCollisionFile();
            translator = new Dictionary<Tuple<Type, Type>, Translator>();
            /* This will become data driven */
            translator.Add(new Tuple<Type, Type>(typeof(Mario), typeof(BrickBlock)), TypeTranslator.MarioBlockTranslator);
            translator.Add(new Tuple<Type, Type>(typeof(Mario), typeof(Goomba)), TypeTranslator.MarioGoombaTranslator);
            translator.Add(new Tuple<Type, Type>(typeof(Scout), typeof(Goomba)), TypeTranslator.MarioGoombaTranslator);
            translator.Add(new Tuple<Type, Type>(typeof(Tank), typeof(Goomba)), TypeTranslator.MarioGoombaTranslator);
            translator.Add(new Tuple<Type, Type>(typeof(Soldier), typeof(Goomba)), TypeTranslator.MarioGoombaTranslator);
            translator.Add(new Tuple<Type, Type>(typeof(Thief), typeof(Goomba)), TypeTranslator.MarioGoombaTranslator);
            translator.Add(new Tuple<Type, Type>(typeof(Mario), typeof(Koopa)), TypeTranslator.MarioKoopaTranslator);
            translator.Add(new Tuple<Type, Type>(typeof(Scout), typeof(Koopa)), TypeTranslator.MarioKoopaTranslator);
            translator.Add(new Tuple<Type, Type>(typeof(Tank), typeof(Koopa)), TypeTranslator.MarioKoopaTranslator);
            translator.Add(new Tuple<Type, Type>(typeof(Soldier), typeof(Koopa)), TypeTranslator.MarioKoopaTranslator);
            translator.Add(new Tuple<Type, Type>(typeof(Thief), typeof(Koopa)), TypeTranslator.MarioKoopaTranslator);
            translator.Add(new Tuple<Type, Type>(typeof(Goomba), typeof(BrickBlock)), TypeTranslator.BumpableBlockEnemyTranslator);
            translator.Add(new Tuple<Type, Type>(typeof(Koopa), typeof(BrickBlock)), TypeTranslator.BumpableBlockEnemyTranslator);
            statefulCollisionActions = JsonParser.Instance.ParseCollisionStatefulFile();

            collisionMasks = new List<Type>()
            {
                typeof(Cloud1),
                typeof(Cloud2),
                typeof(Cloud3),
                typeof(BigHill),
                typeof(SmallHill),
                typeof(Spawner),
                typeof(GoombaSpawner),
                typeof(KoopaSpawner)
            };
        }

        public void HandleCollision(IGameObject mover, IGameObject target)
        {
            Tuple<Side, Rectangle> directionAndArea = DetectCollision(mover, target);
            Side side = directionAndArea.Item1;
            Rectangle collisionArea = directionAndArea.Item2;

            if (side == Side.None)
            {
                return;
            }


            Tuple<Type, Type, Side> key = new Tuple<Type, Type, Side>(mover.GetType(),
            target.GetType(), side);

            if((collisionMasks.Contains(mover.GetType()) || collisionMasks.Contains(target.GetType())))
            {
                return;
            }



            if (collisionActions.ContainsKey(key))
            {
                ExecuteCommand(collisionActions, key, mover, target, collisionArea);
            }
            else if (translator.TryGetValue(new Tuple<Type, Type>(mover.GetType(), target.GetType()), out var @delegate))
            {
                Delegate translatorValue = translator[new Tuple<Type, Type>(mover.GetType(), target.GetType())];
                object[] parameters = { mover, target};
                Tuple<Type, Type> statefulActionsKey = @delegate(mover, target);

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

        private void ExecuteCommand(Dictionary<Tuple<Type, Type, Side>, Tuple<Type, Type>> actions, Tuple<Type, Type, Side> key,
                                    IGameObject mover, IGameObject target, Rectangle collisionArea)
        {
            Type object1Type = actions[key].Item1==null? typeof(NullCommand) : actions[key].Item1;
            Type object2Type = actions[key].Item2==null? typeof(NullCommand) : actions[key].Item2;

            
            ICommand collisionMember1 = (ICommand)Activator.CreateInstance(object1Type, mover, new CollisionData(collisionArea, target));
            ICommand collisionMember2 = (ICommand)Activator.CreateInstance(object2Type, target, new CollisionData(collisionArea, mover));

            // Thiis is for the instance that mario finds a coin
            if (target.GetType().Equals(typeof(QuestionBlock)) || target.GetType().Equals(typeof(BrickBlock)))
            {
                //checks if there is a coin in the collided block and collects it
                if ( RewardChecker.HasCoin( (IBumpable)target ) && mover.GetType().Equals( typeof(Mario) ) )
                {
                    ( (IMario)mover ).Coin();
                }

            }

            collisionMember1.Execute();
            collisionMember2.Execute();
        }

        private void ExecuteDefaultCollision(IGameObject mover, IGameObject target, Rectangle collisionArea, Side side)
        {
            ICommand defaultCommand = new CollideUp((ICollidable)mover, new CollisionData(collisionArea, target));

            if (side is Side.Down)
                defaultCommand = new CollideDown((ICollidable)mover, new CollisionData(collisionArea, target));
            if (side is Side.Left)
                defaultCommand = new CollideLeft((ICollidable)mover, new CollisionData(collisionArea, target));
            if (side is Side.Right)
                defaultCommand = new CollideRight((ICollidable)mover, new CollisionData(collisionArea, target));

            defaultCommand.Execute();
        }
        /* Collision direction is target relative 
         * Example: Mario hits top of the block, so that is a top collision.
         */
        internal Tuple<Side, Rectangle> DetectCollision(IGameObject mover, IGameObject target)
        {
            Rectangle moverCollisionBoundary = mover.CollisionBoundary;
            Rectangle targetCollisionBoundary = target.CollisionBoundary;

            if (!moverCollisionBoundary.Intersects(targetCollisionBoundary))
            {
                return new Tuple<Side, Rectangle> (Side.None, new Rectangle(0, 0, 0, 0));
            }

            Rectangle collisionArea = Rectangle.Intersect(moverCollisionBoundary,
                targetCollisionBoundary);

              bool  horizontalCollision = (collisionArea.Height > collisionArea.Width);

            if (horizontalCollision)
            {
                
                if (mover.Center.X < target.Center.X)
                {
                    return new Tuple<Side, Rectangle>(Side.Right, collisionArea);
                }
                else
                {
                    return new Tuple<Side, Rectangle>(Side.Left, collisionArea);
                }
            }
            else
            {
                if (mover.Center.Y < target.Center.Y)
                {
                    return new Tuple<Side, Rectangle>(Side.Down, collisionArea);
                }
                else
                {
                    return new Tuple<Side, Rectangle>(Side.Up, collisionArea);
                }
            }

        }
    }
}
