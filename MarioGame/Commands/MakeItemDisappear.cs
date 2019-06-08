using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Gamespace;

namespace Gamespace.Commands
{
    class MakeItemDisappear : ICommand
    {
        private IGameObject obj;
        private Rectangle r;

        public MakeItemDisappear(IGameObject obj, Rectangle r)
        {
            this.obj = obj;
            this.r = r;
        }
        public void Execute()
        {
            World.Instance.RemoveFromWorld(obj.Uid);
        }
    }
}
