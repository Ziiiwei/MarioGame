using Gamespace.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Commands
{
    class NullCommand : ICommand
    {
        public NullCommand(object o)
        {

        }
        public void Execute()
        {
            // Do nothing.
        }
    }
}
