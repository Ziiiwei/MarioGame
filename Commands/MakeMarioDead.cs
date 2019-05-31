using Gamespace;
using Gamespace.Commands;
using Gamespace.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Commands
{
    class MakeMarioDead : ICommand
    {
        private IMario mario;
        public MakeMarioDead(IMario mario)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            mario.State = new MarioDeadState();
            mario.Sprite = SpriteFactory.Instance.GetSprite(mario);
        }
    }
}
