using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Commands
{
    class PauseGameCommand : ICommand
    {
        public PauseGameCommand(IMario mario)
        {
            // No-op.
        }
        public void Execute()
        {
            World.Instance.PauseAllObjects();
        }
    }
}
