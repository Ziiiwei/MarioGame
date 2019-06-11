using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gamespace.Blocks
{
    public class Block : AbstractGameObject
    {

        public Block(Vector2 positionOnScreen) : base(positionOnScreen)
        {
            SetSprite();
            
        }

        public void MarioHitBlock()
        {

        }
      
    }
}
