using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Blocks
{
    internal class UsedBlock : AbstractGameObject, IBlock
    {
        public UsedBlock(Vector2 positionOnScreen) : base(positionOnScreen)
        {

        }

        public void Bump()
        {
            throw new NotImplementedException();
        }

        public void Destroy()
        {
            throw new NotImplementedException();
        }
    }
}
