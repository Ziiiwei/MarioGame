﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands
{
    class Display : ICommand
    {
        Game game;

        public Display(Game myGame)
        {
            game = myGame;
        }

        public void Execute()
        {
            game.Appear();
        }
    }
}
