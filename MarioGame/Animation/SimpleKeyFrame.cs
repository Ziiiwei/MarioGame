using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Gamespace;
using Gamespace.Commands;

namespace Gamespace.Animation
{
    public class SimpleKeyFrame : IKeyFrame<IGameObject>
    {
        public IGameObject AnimatedObj { get; }
        public Func<Vector2, int, Vector2, int, bool> GoalCheck { get; } //for diffrent type of keyframe goal check
        public ICommand ComandToCall { get; }
        public Vector2 GoalPoint { get; }
        public int GoalFrameCount { get; }

        private Action<IGameObject> frameAnimation;
        private Vector2 initialPosition;
        private Vector2 currentPosition;
        private int frameCount; //for checking the goal of the key frame

        private IAnimation<IGameObject> animation;

        public SimpleKeyFrame(IGameObject obj, Func<Vector2,int,Vector2> func, IAnimation<IGameObject> ani,
            Func<Vector2, int, Vector2, int, bool> goalCheck, Vector2 goalpoint, int goalcount)
        {
            AnimatedObj = obj;
            ComandToCall = new NullCommand();
            GoalCheck = goalCheck;
            GoalPoint = goalpoint;
            GoalFrameCount = goalcount;
            animation = ani;
            frameCount = 0;


            currentPosition = obj.PositionOnScreen;
            initialPosition = obj.PositionOnScreen;
            frameAnimation = (o) =>
            {
                o.PositionOnScreen = func.Invoke(initialPosition, frameCount);
            };
        }

        public void Update()
        {
            currentPosition = AnimatedObj.PositionOnScreen;
            if (GoalCheck(currentPosition, frameCount, GoalPoint, GoalFrameCount))
            {
                FrameFinished();
            }
            else
            {
                frameAnimation.Invoke(AnimatedObj);
                frameCount++;
            }
        }

        public void FrameFinished()
        {
            animation.PlayNextFrame();
        }
    }
}
