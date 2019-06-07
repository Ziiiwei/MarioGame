﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.States;

namespace Gamespace.Commands
{
    class MakeMarioStar : ICommand
    {
        IMario mario;
        public MakeMarioStar(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.PowerUpState = new StarMarioState();
            mario.UpdateArt();
        }
    }
}
