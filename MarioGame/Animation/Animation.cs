
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Gamespace.Animation
{
 
    class Animation : IAnimation<IGameObject>
    {
        public IGameObject AnimatiedObj { get; set; }

        private List<IKeyFrame<IGameObject>> frameList;
        private int frameCounter;   //which frame are we cuurrently in, if the animation is notbeplayed
                                    //set to -1
        private int totalFrames;
        private Action finishedAction;
        private bool activation;

        public Animation(IGameObject gameObject,Action afterAnimation)
        {
            AnimatiedObj = gameObject;
            frameList = new List<IKeyFrame<IGameObject>>();
            frameCounter = -1;
            totalFrames = 0;
            finishedAction = afterAnimation;
            activation = false;
        }

        public void AddFrame(IKeyFrame<IGameObject> frame)
        {
            frameList.Add(frame);
            totalFrames++;
        }

        public void Activate()
        {
            activation = true;
            if (totalFrames<=0)
            {
                throw new Exception("Animation is not created properly");
            } else
            {
                frameCounter = 0;
            }
        }

        public void Play()
        {
            if (activation)
            {
                if (frameCounter < totalFrames)
                {
                    frameList[frameCounter].Update();
                }
                else
                {
                    Finished();
                }
            }
        }
        public void PlayNextFrame()
        {
            frameCounter++;
        }
        public void Finished()
        {
            activation = false;
            finishedAction.Invoke();
            World.Instance.RemoveFinishedAnimation(this);
        }


    }
}
