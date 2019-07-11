using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Animation;

namespace Gamespace.Commands
{
    class PlayMarioTouchFlag : ICommand
    {
        private IGameObject obj;
        private readonly ICommand endingCommand;
        private IAnimation<IGameObject> ani;
        public PlayMarioTouchFlag(IGameObject gameObject, CollisionData cd )
        {
            obj = gameObject;
            endingCommand = new NullEndingAnimationCommand(gameObject);
        }
        public void Execute()
        {
            World.Instance.MaskCollision(obj);
            ani = AnimationFactory.Instance.GetAnimation(obj, () => endingCommand.Execute(), this.GetType());
            ani.Activate();
            World.Instance.AddAnimationToPlay(ani);
        }
    }
}
