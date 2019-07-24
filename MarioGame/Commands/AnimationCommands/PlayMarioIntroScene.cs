using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Animation;

namespace Gamespace.Commands
{
    class PlayMarioIntroScene: ICommand
    {
        private IGameObject obj;
        private readonly ICommand endingCommand;
        private IAnimation<IGameObject> ani;
        public PlayMarioIntroScene(IGameObject gameObject)
        {
            obj = gameObject;
            endingCommand = new NullEndingAnimationCommand(gameObject);
        }
        public void Execute()
        {

            ani = AnimationFactory.Instance.GetAnimation(obj, () => endingCommand.Execute(), this.GetType());
            ani.Activate();

            World.Instance.AddAnimationToPlay(ani);
        }
    }


}
