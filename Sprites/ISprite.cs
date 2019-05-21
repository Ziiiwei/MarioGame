using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    //<param>
    // Create an interface called iSprite with Update and Draw functions.
    //</param>
    interface ISprite
    {
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
