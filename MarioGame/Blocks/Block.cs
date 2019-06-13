using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gamespace.Blocks
{
    public class Block : AbstractGameObject, IBlock
    {

        public Block(Vector2 positionOnScreen) : base(positionOnScreen)
        {
        }

        public virtual void Bump()
        {
            
        }

        public virtual void Destroy()
        {
            //do nothing
        }

        public virtual void MarioHitBlock()
        {
            Bump();
            Destroy();
        }
      
    }
}
