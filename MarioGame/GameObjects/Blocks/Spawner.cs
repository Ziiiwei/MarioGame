using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Goombas;
using Gamespace.Data;

namespace Gamespace.Blocks
{
    public class Spawner : AbstractGameObject
    {
        private Random random;
        public Spawner(Vector2 positionOnScreen) : base(positionOnScreen)
        {
            SetSprite();
            random = new Random();
            
        }
    }
}
