﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    class MarioCrouchCommand : ICommand
    {
        IMario mario;
        public MarioCrouchCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.Crouch();
        }
    }
}
