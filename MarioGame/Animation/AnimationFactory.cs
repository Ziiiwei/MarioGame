using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Commands;
using Microsoft.Xna.Framework;


namespace Gamespace.Animation
{
    public class AnimationFactory
    {
        private List<(Side,int,Type)> testMarioAnimation;
        protected Dictionary<Side, Func<Vector2, int, Vector2>> newFrameCaculation;
        static AnimationFactory() { }
        private AnimationFactory()
        {
            testMarioAnimation = new List<(Side side, int distance, Type command)>
            {
                (Side.Right, 100, typeof(MarioMoveRightCommand)),
                (Side.Up, 50, typeof(MarioJumpCommand)),
                (Side.Left,200,typeof(MarioMoveLeftCommand)),
                (Side.None,20,typeof(MarioCrouchCommand)),
                (Side.Up, 50, typeof(MarioJumpCommand))
            };

            newFrameCaculation = new Dictionary<Side, Func<Vector2,int,Vector2>>()
            {
                {Side.Up, new Func<Vector2, int, Vector2>((p,d) => new Vector2(p.X,p.Y-d))},
                {Side.Down, new Func<Vector2, int, Vector2>((p,d) => new Vector2(p.X,p.Y+d))},
                {Side.Left, new Func<Vector2, int, Vector2>((p,d) => new Vector2(p.X-d,p.Y))},
                {Side.Right, new Func<Vector2, int, Vector2>((p,d) => new Vector2(p.X+d,p.Y+d))}
            };
        }

        private static readonly AnimationFactory instance = new AnimationFactory();
        public static AnimationFactory Instance { get; } = new AnimationFactory();

        public IAnimation<IGameObject> GetAnimation(IGameObject obj, Action afterCommand)
        {
            Animation animation = new Animation(obj, afterCommand);
            Vector2 pointToBegin = new Vector2(obj.PositionOnScreen.X, obj.PositionOnScreen.Y);

            foreach ((Side side,int distance,Type type) in testMarioAnimation)
            {
                animation.AddFrame(new KeyFrame(obj, newFrameCaculation[side].Invoke(pointToBegin, distance),type,animation));
                pointToBegin = newFrameCaculation[side].Invoke(pointToBegin, distance);
            }

            return animation;
        }


    }
}
