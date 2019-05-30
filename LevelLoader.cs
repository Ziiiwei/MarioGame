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
            world.Mario = new Mario(new Vector2(300, 200));
            world.AddGameObject(new FireFlower(new Vector2(125, 100)));
            world.AddGameObject(new Coin(new Vector2(175, 100)));
            world.AddGameObject(new RedMushroom(new Vector2(225, 100)));
            world.AddGameObject(new GreenMushroom(new Vector2(275, 100)));
            world.AddGameObject(new Star(new Vector2(325, 100)));
            world.AddGameObject(new Pipe(new Vector2(375, 150)));

        }
    }
}
