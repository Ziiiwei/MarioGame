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
        private CollisionData collisionData;

        public MakeItemDisappear(IGameObject obj, CollisionData collisionData)
        {
            this.obj = obj;
            this.collisionData = collisionData;
        }
        public void Execute()
        {
            World.Instance.RemoveFromWorld(obj.Uid);
        }
    }
}
