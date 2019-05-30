using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2.Commands
{
    class GoombaGetStomped : ICommand
    {
        private Goomba goomba;
        public GoombaGetStomped(Goomba goomba)
        {
            this.goomba = goomba;
        }
        public void Execute()
        {
            goomba.BeStomped();
        }
    }
}
