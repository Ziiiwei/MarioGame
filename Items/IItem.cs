using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    interface IItem
    {
        void Draw(SpriteBatch spriteBatch);
        void Update();
 

    }
}
