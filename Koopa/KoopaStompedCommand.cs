using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    class KoopaStompedCommand : ICommand
    {
        private Koopa koopa;
        public KoopaStompedCommand(Koopa koopa)
        {
            this.koopa = koopa;
        }
        public void Execute()
        {
            koopa.BeStomped();
        }
    }
}
