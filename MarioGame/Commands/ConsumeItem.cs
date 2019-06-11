using Gamespace.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Commands
{
    class ConsumeItem : ICommand
    {
        private AbstractGameObject item;

        public ConsumeItem(AbstractGameObject item, CollisionData collisionData)
        {
            this.item = item;
        }
        public void Execute()
        {
            World.Instance.RemoveFromWorld(item.Uid);
        }
    }
}
