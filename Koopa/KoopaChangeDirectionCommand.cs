﻿using Gamespace.Commands;
using Gamespace.Koopas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    class KoopaChangeDirectionCommand : ICommand
    {
        private Koopa koopa;
        public KoopaChangeDirectionCommand(Koopa koopa)
        {
            this.koopa = koopa;
        }
        public void Execute()
        {
            koopa.ChangeDirection();
        }
    }
}
