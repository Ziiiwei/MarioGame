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
    public class KeyFrame : IKeyFrame<IGameObject>
    {
        public IGameObject AnimatedObj { get; }
        public Vector2 FramePoint { get; }
        public Type ComandToCall { get; }
    
        private Action frameAnimation;
        private Vector2 currentPosition;
        private IAnimation<IGameObject> animation;
        
        public KeyFrame(IGameObject obj, Vector2 point, Type command, IAnimation<IGameObject> ani)
        {
            AnimatedObj = obj;
            FramePoint = point;
            ComandToCall = command;
            animation = ani;
           
            currentPosition = obj.PositionOnScreen;
            frameAnimation = () => Activator.CreateInstance(command, obj);
        }

        public void Update()
        {
            currentPosition = AnimatedObj.PositionOnScreen;
            if (Vector2.Distance(currentPosition, FramePoint) <= 1.0)
            {
                FrameFinished();
            }
            else
            {
                frameAnimation.Invoke();
            }
        }

        public void FrameFinished()
        {
            animation.PlayNextFrame();
        }
    }
}
