using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Commands
{
    class Reset : ICommand
    {
        public Reset(IGameObject obj)
        {
        }
        public void Execute()
        {
            MarioGame.Instance.Reset();
        }
    }
}
