using Gamespace.Commands;
using Gamespace.Koopas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Commands
{
    class KoopaFlipCommand : ICommand
    {
        private Koopa koopa;
        public KoopaFlipCommand(Koopa koopa, CollisionData collisionData)
        {
            this.koopa = koopa;
        }
        public void Execute()
        {
            koopa.IsFlipped();
        }
    }
}
