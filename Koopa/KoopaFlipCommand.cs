using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    class KoopaFlipCommand : ICommand
    {
        private Koopa koopa;
        public KoopaFlipCommand(Koopa koopa)
        {
            this.koopa = koopa;
        }
        public void Execute()
        {
            koopa.IsFlipped();
        }
    }
}
