using Gamespace.Animation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.FlagPole;

namespace Gamespace.Commands
{
      class PlayFlagSlidDown : ICommand
        {
            private IGameObject obj;
            private ICommand endingCommand;
            private IAnimation<IGameObject> ani;
            public PlayFlagSlidDown(IGameObject gameObject, CollisionData cd)
            {
                obj = gameObject;
               
            }

            public PlayFlagSlidDown(IGameObject gameObject)
            {
                obj = gameObject;

            }
            public void Execute()
            {
                World.Instance.MaskCollision(obj);
                obj = World.Instance.FindObject(typeof(Flag));
                World.Instance.MaskCollision(obj);
                endingCommand = new NullEndingAnimationCommand(obj);
                ani = AnimationFactory.Instance.GetSimpleAnimation(obj, () => endingCommand.Execute(), this.GetType());
                ani.Activate();
                World.Instance.AddAnimationToPlay(ani);
            }
        }
    
}
