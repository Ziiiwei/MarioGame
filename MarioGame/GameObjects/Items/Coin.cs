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
    class Coin : AbstractGameObject, IItem
    {

        public Coin(Vector2 positionOnScreen) : base(positionOnScreen)
        {
        }

        public void Consume()
        {

        }
    }
}
