using Sprint2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    class LevelLoader
    {
        public LevelLoader(World world)
        {
            world.Mario = new Mario(new Vector2(200, 200));
        }
    }
}
