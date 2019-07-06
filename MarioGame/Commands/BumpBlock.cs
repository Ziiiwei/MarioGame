using Gamespace.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Commands
{
    internal class BumpBlock : ICommand
    {
        private IBumpable block;
        public BumpBlock(IBumpable block, CollisionData collisionData)
        {
            this.block = block;
        }
        public void Execute()
        {
            block.Bump();

            SoundFactory.Instance.PlaySoundEffect("BumpBlock");
        }
    }
}
