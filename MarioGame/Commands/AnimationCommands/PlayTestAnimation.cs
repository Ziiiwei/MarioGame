using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Animation;

namespace Gamespace.Commands
{
    class PlayTestAnimation : ICommand
    {
        private IGameObject obj;
        private readonly ICommand endingCommand;
        private IAnimation<IGameObject> ani;
        public PlayTestAnimation(IGameObject gameObject)
        {
            obj = gameObject;
            endingCommand = new NullEndingAnimationCommand(gameObject);
        }
        public void Execute()
        {   

            ani = AnimationFactory.Instance.GetAnimation(obj,()=>endingCommand.Execute(),this.GetType());
            ani.Activate();
           
            World.Instance.AddAnimationToPlay(ani);
        }
    }

    class NullEndingAnimationCommand : ICommand
    {
        private IGameObject obj;
        public NullEndingAnimationCommand(IGameObject gameObject)
        {
            obj = gameObject;
        }
        public void Execute()
        {
            World.Instance.AddToUpdate(obj);
        }
    }
}
