using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gamespace.Items
{
    class Star : AbstractGameObject
    {
        private ISprite sprite;
        private Vector2 location;

        public Star(Vector2 positionOnScreen) : base (positionOnScreen) 
        {

        }
    }
}
