using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2.Commands
{
    class GoombaChangeDirection : ICommand
    {
        private Goomba goomba;
        public GoombaChangeDirection(Goomba goomba)
        {
            this.goomba= goomba;
        }
        public void Execute()
        {
            goomba.ChangeDirection();
        }
    }
}
