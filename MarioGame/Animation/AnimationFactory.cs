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

        }

        private static readonly AnimationFactory instance = new AnimationFactory();
        public static AnimationFactory Instance { get; } = new AnimationFactory();


    }
}
